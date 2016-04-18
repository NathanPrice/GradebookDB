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
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            fillCombo();
            filterCombo();
        }

        // Fills the ComboBox with all the results in the First Name Column in the Database
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

        private void frmSearch_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {


        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
