using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GradebookDB
{
    public partial class frmMain : Form
    {
        // String to connect to your Database
        private SqlConnection con = new SqlConnection("Data Source=PC16\\SQLEXPRESS;Initial Catalog=Gradebook;Integrated Security=True");

        // Variable to send SQL Commands
        private SqlCommand cmd;

        // Represents a set of data commands and a database connection that are used to fill the DataSet and update a SQL Server database
        private SqlDataAdapter sda = new SqlDataAdapter();

        private Grades calc = new Grades();

        // Variable for getting the ID from combobox based on selected First Name
        private string id;

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
            clearTextBoxes();
        }

        // Stores Textbox Values in the DataGridView
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int average = calc.getAverage(Convert.ToInt32(txtGrade1.Text), Convert.ToInt32(txtGrade2.Text), Convert.ToInt32(txtGrade3.Text));
                char letterGrade = calc.getLetterGrade(average);

                con.Open();
                // Uses the Stored Procedure insertData to Put the Values in the Database
                cmd = new SqlCommand("insertData", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
                filterCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        // Updates DataGridView & SQL Values
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int average = calc.getAverage(Convert.ToInt32(txtGrade1.Text), Convert.ToInt32(txtGrade2.Text), Convert.ToInt32(txtGrade3.Text));
                char letterGrade = calc.getLetterGrade(average);

                // Uses the Stored Procedure updateData to Update the Values in my SQL Database
                cmd = new SqlCommand("updateData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@First_Name", txtFname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtLname.Text);
                cmd.Parameters.AddWithValue("@Grade_1", Convert.ToInt32(txtGrade1.Text));
                cmd.Parameters.AddWithValue("@Grade_2", Convert.ToInt32(txtGrade2.Text));
                cmd.Parameters.AddWithValue("@Grade_3", Convert.ToInt32(txtGrade3.Text));
                cmd.Parameters.AddWithValue("@Average", average);
                cmd.Parameters.AddWithValue("@Letter_Grade", letterGrade);
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
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

        // Deletes Data from DataGridView & SQL
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Are you sure?\n There is no undo option once data is deleted", "Confirm Deletion", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                deleteData();
                refreshData();
                cmbSearch.Items.Clear();
                fillCombo();
                filterCombo();
            }
            else
            {
                MessageBox.Show("Deletion Canceled");
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

        public void refreshData()
        {
            DataTable dt = new DataTable();
            sda = new SqlDataAdapter("EXEC getData", con);
            infoDataGridView.DataSource = dt;
            sda.Fill(dt);
            infoDataGridView.Update();
        }

        public void deleteData()
        {
            try
            {
                /*
                sda.DeleteCommand = new SqlCommand("DELETE FROM Info WHERE First_Name = @First_Name AND Last_Name = @Last_Name AND Grade_1 = @Grade_1 AND Grade_2 = @Grade_2 AND @Grade_3 = Grade_3", con);
                sda.DeleteCommand.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = txtFname.Text;
                sda.DeleteCommand.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = txtLname.Text;
                sda.DeleteCommand.Parameters.Add("@Grade_1", SqlDbType.Int).Value = Convert.ToInt32(txtGrade1.Text);
                sda.DeleteCommand.Parameters.Add("@Grade_2", SqlDbType.Int).Value = Convert.ToInt32(txtGrade2.Text);
                sda.DeleteCommand.Parameters.Add("@Grade_3", SqlDbType.Int).Value = Convert.ToInt32(txtGrade3.Text);
                */

                cmd = new SqlCommand("deleteData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                // sda.DeleteCommand.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void fillCombo()
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

        private void filterCombo()
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

        // Gets Value Based on Selected Combobox Item
        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = ("Data Source=PC16\\SQLEXPRESS;Initial Catalog=Gradebook;Integrated Security=True");
            string query = "SELECT * FROM Info WHERE First_Name='" + cmbSearch.Text + "'";
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader.GetInt32(0).ToString();
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

        private void infoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }
    }
}