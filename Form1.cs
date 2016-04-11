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

        }

        // String to connect to your Database
        SqlConnection con = new SqlConnection("Data Source=PC16\\SQLEXPRESS;Initial Catalog=Gradebook;Integrated Security=True");

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Grades calc = new Grades();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }

}
