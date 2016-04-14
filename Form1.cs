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
        }

        private void infoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.infoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gradebookDataSet);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
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
                da.UpdateCommand.Parameters.Add("@First_Name", SqlDbType.Text).Value = txtFname.Text;
                da.UpdateCommand.Parameters.Add("@Last_Name", SqlDbType.Text).Value = txtLname.Text;
                da.UpdateCommand.Parameters.Add("@Grade_1", SqlDbType.Int).Value = Convert.ToInt32(txtGrade1.Text);
                da.UpdateCommand.Parameters.Add("@Grade_2", SqlDbType.Int).Value = Convert.ToInt32(txtGrade2.Text);
                da.UpdateCommand.Parameters.Add("@Grade_3", SqlDbType.Int).Value = Convert.ToInt32(txtGrade3.Text);
                da.UpdateCommand.Parameters.Add("@Average", SqlDbType.Int).Value = average;
                da.UpdateCommand.Parameters.Add("@Letter_Grade", SqlDbType.Text).Value = letterGrade;
                da.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int).Value = gradebookDataSet.Tables[0].Rows[infoBindingSource.Position][0];

                con.Open();
                da.UpdateCommand.ExecuteNonQuery();
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
            dr = MessageBox.Show("Are you sure?\n There is no undo option once data is deleted", "Confirum Deletion",MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                deleteData();
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
    }

}