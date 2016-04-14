namespace GradebookDB
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label first_NameLabel;
            System.Windows.Forms.Label last_NameLabel;
            System.Windows.Forms.Label grade_1Label;
            System.Windows.Forms.Label grade_2Label;
            System.Windows.Forms.Label grade_3Label;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gradebookDataSet = new GradebookDB.GradebookDataSet();
            this.infoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.infoTableAdapter = new GradebookDB.GradebookDataSetTableAdapters.InfoTableAdapter();
            this.tableAdapterManager = new GradebookDB.GradebookDataSetTableAdapters.TableAdapterManager();
            this.infoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtGrade1 = new System.Windows.Forms.TextBox();
            this.txtGrade2 = new System.Windows.Forms.TextBox();
            this.txtGrade3 = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            first_NameLabel = new System.Windows.Forms.Label();
            last_NameLabel = new System.Windows.Forms.Label();
            grade_1Label = new System.Windows.Forms.Label();
            grade_2Label = new System.Windows.Forms.Label();
            grade_3Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gradebookDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // first_NameLabel
            // 
            first_NameLabel.AutoSize = true;
            first_NameLabel.Location = new System.Drawing.Point(35, 34);
            first_NameLabel.Name = "first_NameLabel";
            first_NameLabel.Size = new System.Drawing.Size(60, 13);
            first_NameLabel.TabIndex = 2;
            first_NameLabel.Text = "First Name:";
            // 
            // last_NameLabel
            // 
            last_NameLabel.AutoSize = true;
            last_NameLabel.Location = new System.Drawing.Point(231, 33);
            last_NameLabel.Name = "last_NameLabel";
            last_NameLabel.Size = new System.Drawing.Size(61, 13);
            last_NameLabel.TabIndex = 4;
            last_NameLabel.Text = "Last Name:";
            // 
            // grade_1Label
            // 
            grade_1Label.AutoSize = true;
            grade_1Label.Location = new System.Drawing.Point(423, 34);
            grade_1Label.Name = "grade_1Label";
            grade_1Label.Size = new System.Drawing.Size(48, 13);
            grade_1Label.TabIndex = 6;
            grade_1Label.Text = "Grade 1:";
            // 
            // grade_2Label
            // 
            grade_2Label.AutoSize = true;
            grade_2Label.Location = new System.Drawing.Point(604, 34);
            grade_2Label.Name = "grade_2Label";
            grade_2Label.Size = new System.Drawing.Size(48, 13);
            grade_2Label.TabIndex = 8;
            grade_2Label.Text = "Grade 2:";
            // 
            // grade_3Label
            // 
            grade_3Label.AutoSize = true;
            grade_3Label.Location = new System.Drawing.Point(786, 34);
            grade_3Label.Name = "grade_3Label";
            grade_3Label.Size = new System.Drawing.Size(48, 13);
            grade_3Label.TabIndex = 10;
            grade_3Label.Text = "Grade 3:";
            // 
            // gradebookDataSet
            // 
            this.gradebookDataSet.DataSetName = "GradebookDataSet";
            this.gradebookDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // infoBindingSource
            // 
            this.infoBindingSource.DataMember = "Info";
            this.infoBindingSource.DataSource = this.gradebookDataSet;
            this.infoBindingSource.CurrentChanged += new System.EventHandler(this.infoBindingSource_CurrentChanged);
            // 
            // infoTableAdapter
            // 
            this.infoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.InfoTableAdapter = this.infoTableAdapter;
            this.tableAdapterManager.UpdateOrder = GradebookDB.GradebookDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // infoDataGridView
            // 
            this.infoDataGridView.AutoGenerateColumns = false;
            this.infoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.infoDataGridView.DataSource = this.infoBindingSource;
            this.infoDataGridView.Location = new System.Drawing.Point(63, 151);
            this.infoDataGridView.Name = "infoDataGridView";
            this.infoDataGridView.Size = new System.Drawing.Size(843, 337);
            this.infoDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "First_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "First_Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Last_Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Last_Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Grade_1";
            this.dataGridViewTextBoxColumn4.HeaderText = "Grade_1";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Grade_2";
            this.dataGridViewTextBoxColumn5.HeaderText = "Grade_2";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Grade_3";
            this.dataGridViewTextBoxColumn6.HeaderText = "Grade_3";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Average";
            this.dataGridViewTextBoxColumn7.HeaderText = "Average";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Letter_Grade";
            this.dataGridViewTextBoxColumn8.HeaderText = "Letter_Grade";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(342, 113);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtFname
            // 
            this.txtFname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "First_Name", true));
            this.txtFname.Location = new System.Drawing.Point(101, 31);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(100, 20);
            this.txtFname.TabIndex = 3;
            // 
            // txtLname
            // 
            this.txtLname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "Last_Name", true));
            this.txtLname.Location = new System.Drawing.Point(298, 30);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(100, 20);
            this.txtLname.TabIndex = 5;
            // 
            // txtGrade1
            // 
            this.txtGrade1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "Grade_1", true));
            this.txtGrade1.Location = new System.Drawing.Point(477, 31);
            this.txtGrade1.Name = "txtGrade1";
            this.txtGrade1.Size = new System.Drawing.Size(100, 20);
            this.txtGrade1.TabIndex = 7;
            // 
            // txtGrade2
            // 
            this.txtGrade2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "Grade_2", true));
            this.txtGrade2.Location = new System.Drawing.Point(658, 31);
            this.txtGrade2.Name = "txtGrade2";
            this.txtGrade2.Size = new System.Drawing.Size(100, 20);
            this.txtGrade2.TabIndex = 9;
            // 
            // txtGrade3
            // 
            this.txtGrade3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.infoBindingSource, "Grade_3", true));
            this.txtGrade3.Location = new System.Drawing.Point(840, 31);
            this.txtGrade3.Name = "txtGrade3";
            this.txtGrade3.Size = new System.Drawing.Size(100, 20);
            this.txtGrade3.TabIndex = 11;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(436, 113);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(529, 113);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 510);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(grade_3Label);
            this.Controls.Add(this.txtGrade3);
            this.Controls.Add(grade_2Label);
            this.Controls.Add(this.txtGrade2);
            this.Controls.Add(grade_1Label);
            this.Controls.Add(this.txtGrade1);
            this.Controls.Add(last_NameLabel);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(first_NameLabel);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.infoDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Gradebook";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradebookDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GradebookDataSet gradebookDataSet;
        private System.Windows.Forms.BindingSource infoBindingSource;
        private GradebookDataSetTableAdapters.InfoTableAdapter infoTableAdapter;
        private GradebookDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView infoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.TextBox txtGrade1;
        private System.Windows.Forms.TextBox txtGrade2;
        private System.Windows.Forms.TextBox txtGrade3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}

