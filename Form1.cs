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

            txtFname.Text = "";
            txtLname.Text = "";
            txtGrade1.Text = "";
            txtGrade2.Text = "";
            txtGrade3.Text = "";

        }

        // String to connect to your Database
        SqlConnection con = new SqlConnection("Data Source=PC16\\SQLEXPRESS;Initial Catalog=Gradebook;Integrated Security=True");

        // Variable to send SQL Commands
        SqlCommand cmd;

        // Represents a set of data commands and a database connection that are used to fill the DataSet and update a SQL Server database
        SqlDataAdapter sda;
        DataTable dt;

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Grades calc = new Grades();
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

                // Refreshes DataGridView with newly entered Info
                sda = new SqlDataAdapter("SELECT * FROM Info", con);
                dt = new DataTable();
                sda.Fill(dt);
                infoDataGridView.DataSource = dt;
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
