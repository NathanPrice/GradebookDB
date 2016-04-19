using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace GradebookDB
{
    public partial class frmMain : Form
    {
        // String to connect to your Database
        SqlConnection con = new SqlConnection("Data Source=PC16\\SQLEXPRESS;Initial Catalog=Gradebook;Integrated Security=True");

        // Variable to send SQL Commands
        SqlCommand cmd;

        // Represents a set of data commands and a database connection that are used to fill the DataSet and update a SQL Server database
        SqlDataAdapter sda = new SqlDataAdapter();

        DataSet ds = new DataSet();
        Grades calc = new Grades();

        public frmMain()
        {
            InitializeComponent();
            fillCombo();
            filterCombo();
        }

        private void infoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.infoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gradebookDataSet);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gradebookDS.Info' table. You can move, or remove it, as needed.
            this.infoTableAdapter1.Fill(this.gradebookDS.Info);
            // TODO: This line of code loads data into the 'gradebookDataSet.Info' table. You can move, or remove it, as needed.
            this.infoTableAdapter.Fill(this.gradebookDataSet.Info);
            clearTextBoxes();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int average = calc.getAverage(Convert.ToInt32(txtGrade1.Text), Convert.ToInt32(txtGrade2.Text), Convert.ToInt32(txtGrade3.Text));
                char letterGrade = calc.getLetterGrade(average);

                con.Open();
                cmd = new SqlCommand(@"INSERT INTO Info (First_Name, Last_Name, Grade_1, Grade_2, Grade_3, Average, Letter_Grade) VALUES (@First_Name, @Last_Name, @Grade_1, @Grade_2, @Grade_3, @Average, @Letter_Grade)", con);
                cmd.Parameters.AddWithValue("@First_Name", txtFname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtLname.Text);
                cmd.Parameters.AddWithValue("@Grade_1", Convert.ToInt32(txtGrade1.Text));
                cmd.Parameters.AddWithValue("@Grade_2", Convert.ToInt32(txtGrade2.Text));
                cmd.Parameters.AddWithValue("@Grade_3", Convert.ToInt32(txtGrade3.Text));
                cmd.Parameters.AddWithValue("@Average", average);
                cmd.Parameters.AddWithValue("@Letter_Grade", letterGrade);
                cmd.ExecuteNonQuery();
                con.Close();

                refreshData();
                clearTextBoxes();
                cmbSearch.Items.Clear();
                fillCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void clearTextBoxes()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            txtGrade1.Text = "";
            txtGrade2.Text = "";
            txtGrade3.Text = "";
        }

        private void infoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int average = calc.getAverage(Convert.ToInt32(txtGrade1.Text), Convert.ToInt32(txtGrade2.Text), Convert.ToInt32(txtGrade3.Text));
                char letterGrade = calc.getLetterGrade(average);
                SqlDataAdapter da = new SqlDataAdapter();

                da.UpdateCommand = new SqlCommand("UPDATE Info SET First_Name = @First_Name, Last_Name = @Last_Name, Grade_1 = @Grade_1, Grade_2 = @Grade_2, Grade_3 = @Grade_3, Average = @Average, Letter_Grade = @Letter_Grade WHERE Id = @Id", con);
                da.UpdateCommand.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = txtFname.Text;
                da.UpdateCommand.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = txtLname.Text;
                da.UpdateCommand.Parameters.Add("@Grade_1", SqlDbType.Int).Value = Convert.ToInt32(txtGrade1.Text);
                da.UpdateCommand.Parameters.Add("@Grade_2", SqlDbType.Int).Value = Convert.ToInt32(txtGrade2.Text);
                da.UpdateCommand.Parameters.Add("@Grade_3", SqlDbType.Int).Value = Convert.ToInt32(txtGrade3.Text);
                da.UpdateCommand.Parameters.Add("@Average", SqlDbType.Int).Value = average;
                da.UpdateCommand.Parameters.Add("@Letter_Grade", SqlDbType.VarChar).Value = letterGrade;
                da.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int).Value = gradebookDataSet.Tables[0].Rows[infoBindingSource.Position][0];

                con.Open();
                da.UpdateCommand.ExecuteNonQuery();
                refreshData();
                cmbSearch.Items.Clear();
                fillCombo();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Are you sure?\n There is no undo option once data is deleted", "Confirm Deletion",MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                deleteData();
                refreshData();
                cmbSearch.Items.Clear();
                fillCombo();
            }
            else
            {
                MessageBox.Show("Deletion Canceled");
            }
        }

        public void refreshData()
        {
            DataTable dt = new DataTable();
            sda = new SqlDataAdapter("SELECT * FROM Info", con);
            infoDataGridView.DataSource = dt;
            sda.Fill(dt);
            infoDataGridView.Update();
        }

        public void deleteData()
        {
            sda.DeleteCommand = new SqlCommand("DELETE FROM Info WHERE Id = @Id", con);
            sda.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int).Value = gradebookDataSet.Tables[0].Rows[infoBindingSource.Position][0];

            con.Open();
            sda.DeleteCommand.ExecuteNonQuery();
            con.Close();
        }

        void fillCombo()
        {
            string constring = ("Data Source=PC16\\SQLEXPRESS;Initial Catalog=Gradebook;Integrated Security=True");
            string query = "SELECT * FROM Info";
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string fName = reader.GetString(1);
                    cmbSearch.Items.Add(fName);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        void filterCombo()
        {
            cmbSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            string constring = ("Data Source=PC16\\SQLEXPRESS;Initial Catalog=Gradebook;Integrated Security=True");
            string query = "SELECT * FROM Info";
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string fName = reader.GetString(1);
                    collection.Add(fName);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            cmbSearch.AutoCompleteCustomSource = collection;

        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = ("Data Source=PC16\\SQLEXPRESS;Initial Catalog=Gradebook;Integrated Security=True");
            string query = "SELECT * FROM Info WHERE First_Name='"+ cmbSearch.Text +"'";
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string fName = reader.GetString(1);
                    string lName = reader.GetString(2);
                    string Grade1 = reader.GetInt32(3).ToString();
                    string Grade2 = reader.GetInt32(4).ToString();
                    string Grade3 = reader.GetInt32(5).ToString();

                    txtFname.Text = fName;
                    txtLname.Text = lName;
                    txtGrade1.Text = Grade1;
                    txtGrade2.Text = Grade2;
                    txtGrade3.Text = Grade3;

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }

}