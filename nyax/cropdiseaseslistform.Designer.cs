/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 21:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class cropdiseaseslistform
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cropdiseaseslistform));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btneditcropdisease = new System.Windows.Forms.Button();
			this.chkshowinactive = new System.Windows.Forms.CheckBox();
			this.btndeletecropdisease = new System.Windows.Forms.Button();
			this.btncreatecropdisease = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.groupBoxlst = new System.Windows.Forms.GroupBox();
			this.dataGridViewcropdiseases = new System.Windows.Forms.DataGridView();
			this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columndiseasepest = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSourcecropdiseases = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBoxlst.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewcropdiseases)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcecropdiseases)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btneditcropdisease);
			this.groupBox1.Controls.Add(this.chkshowinactive);
			this.groupBox1.Controls.Add(this.btndeletecropdisease);
			this.groupBox1.Controls.Add(this.btncreatecropdisease);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(584, 63);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btneditcropdisease
			// 
			this.btneditcropdisease.BackColor = System.Drawing.SystemColors.Control;
			this.btneditcropdisease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btneditcropdisease.ForeColor = System.Drawing.Color.Black;
			this.btneditcropdisease.Image = ((System.Drawing.Image)(resources.GetObject("btneditcropdisease.Image")));
			this.btneditcropdisease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditcropdisease.Location = new System.Drawing.Point(90, 12);
			this.btneditcropdisease.Name = "btneditcropdisease";
			this.btneditcropdisease.Size = new System.Drawing.Size(50, 46);
			this.btneditcropdisease.TabIndex = 7;
			this.btneditcropdisease.Text = "edit";
			this.btneditcropdisease.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditcropdisease.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btneditcropdisease.UseVisualStyleBackColor = false;
			this.btneditcropdisease.Click += new System.EventHandler(this.BtneditcropdiseaseClick);
			// 
			// chkshowinactive
			// 
			this.chkshowinactive.Dock = System.Windows.Forms.DockStyle.Right;
			this.chkshowinactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkshowinactive.Location = new System.Drawing.Point(477, 16);
			this.chkshowinactive.Name = "chkshowinactive";
			this.chkshowinactive.Size = new System.Drawing.Size(104, 44);
			this.chkshowinactive.TabIndex = 6;
			this.chkshowinactive.Text = "show inactive";
			this.chkshowinactive.UseVisualStyleBackColor = true;
			this.chkshowinactive.CheckedChanged += new System.EventHandler(this.ChkshowinactiveCheckedChanged);
			// 
			// btndeletecropdisease
			// 
			this.btndeletecropdisease.BackColor = System.Drawing.SystemColors.Control;
			this.btndeletecropdisease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndeletecropdisease.ForeColor = System.Drawing.Color.Black;
			this.btndeletecropdisease.Image = ((System.Drawing.Image)(resources.GetObject("btndeletecropdisease.Image")));
			this.btndeletecropdisease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btndeletecropdisease.Location = new System.Drawing.Point(146, 12);
			this.btndeletecropdisease.Name = "btndeletecropdisease";
			this.btndeletecropdisease.Size = new System.Drawing.Size(78, 46);
			this.btndeletecropdisease.TabIndex = 5;
			this.btndeletecropdisease.Text = "delete";
			this.btndeletecropdisease.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btndeletecropdisease.UseVisualStyleBackColor = false;
			this.btndeletecropdisease.Click += new System.EventHandler(this.BtndeletecropdiseaseClick);
			// 
			// btncreatecropdisease
			// 
			this.btncreatecropdisease.BackColor = System.Drawing.SystemColors.Control;
			this.btncreatecropdisease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreatecropdisease.ForeColor = System.Drawing.Color.Black;
			this.btncreatecropdisease.Image = ((System.Drawing.Image)(resources.GetObject("btncreatecropdisease.Image")));
			this.btncreatecropdisease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreatecropdisease.Location = new System.Drawing.Point(12, 12);
			this.btncreatecropdisease.Name = "btncreatecropdisease";
			this.btncreatecropdisease.Size = new System.Drawing.Size(72, 46);
			this.btncreatecropdisease.TabIndex = 0;
			this.btncreatecropdisease.Text = "create";
			this.btncreatecropdisease.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncreatecropdisease.UseVisualStyleBackColor = false;
			this.btncreatecropdisease.Click += new System.EventHandler(this.BtncreatecropdiseaseClick);
			// 
			// btnclose
			// 
			this.btnclose.BackColor = System.Drawing.SystemColors.Control;
			this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnclose.ForeColor = System.Drawing.Color.Black;
			this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
			this.btnclose.Location = new System.Drawing.Point(230, 12);
			this.btnclose.Name = "btnclose";
			this.btnclose.Size = new System.Drawing.Size(61, 46);
			this.btnclose.TabIndex = 1;
			this.btnclose.Text = "close";
			this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnclose.UseVisualStyleBackColor = false;
			this.btnclose.Click += new System.EventHandler(this.BtncloseClick);
			// 
			// groupBoxlst
			// 
			this.groupBoxlst.Controls.Add(this.dataGridViewcropdiseases);
			this.groupBoxlst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxlst.Location = new System.Drawing.Point(0, 63);
			this.groupBoxlst.Name = "groupBoxlst";
			this.groupBoxlst.Size = new System.Drawing.Size(584, 398);
			this.groupBoxlst.TabIndex = 1;
			this.groupBoxlst.TabStop = false;
			// 
			// dataGridViewcropdiseases
			// 
			this.dataGridViewcropdiseases.AllowUserToAddRows = false;
			this.dataGridViewcropdiseases.AllowUserToDeleteRows = false;
			this.dataGridViewcropdiseases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewcropdiseases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Columnid,
									this.Columnname,
									this.Columndiseasepest,
									this.Columnstatus,
									this.Column1createddate});
			this.dataGridViewcropdiseases.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewcropdiseases.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewcropdiseases.MultiSelect = false;
			this.dataGridViewcropdiseases.Name = "dataGridViewcropdiseases";
			this.dataGridViewcropdiseases.ReadOnly = true;
			this.dataGridViewcropdiseases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewcropdiseases.Size = new System.Drawing.Size(578, 379);
			this.dataGridViewcropdiseases.TabIndex = 0;
			this.dataGridViewcropdiseases.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewcropdiseasesCellContentDoubleClick);
			// 
			// Columnid
			// 
			this.Columnid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnid.DataPropertyName = "crop_disease_id";
			this.Columnid.HeaderText = "id";
			this.Columnid.Name = "Columnid";
			this.Columnid.ReadOnly = true;
			this.Columnid.Width = 50;
			// 
			// Columnname
			// 
			this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnname.DataPropertyName = "crop_disease_name";
			this.Columnname.HeaderText = "name";
			this.Columnname.Name = "Columnname";
			this.Columnname.ReadOnly = true;
			this.Columnname.Width = 150;
			// 
			// Columndiseasepest
			// 
			this.Columndiseasepest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columndiseasepest.DataPropertyName = "crop_disease_category";
			this.Columndiseasepest.HeaderText = "category";
			this.Columndiseasepest.Name = "Columndiseasepest";
			this.Columndiseasepest.ReadOnly = true;
			// 
			// Columnstatus
			// 
			this.Columnstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnstatus.DataPropertyName = "crop_disease_status";
			this.Columnstatus.HeaderText = "status";
			this.Columnstatus.Name = "Columnstatus";
			this.Columnstatus.ReadOnly = true;
			// 
			// Column1createddate
			// 
			this.Column1createddate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column1createddate.DataPropertyName = "created_date";
			this.Column1createddate.HeaderText = "created date";
			this.Column1createddate.Name = "Column1createddate";
			this.Column1createddate.ReadOnly = true;
			this.Column1createddate.Width = 135;
			// 
			// cropdiseaseslistform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 461);
			this.Controls.Add(this.groupBoxlst);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "cropdiseaseslistform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "diseases/pests";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CropdiseaseslistformFormClosing);
			this.Load += new System.EventHandler(this.CropdiseaseslistformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBoxlst.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewcropdiseases)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcecropdiseases)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btndeletecropdisease;
		private System.Windows.Forms.CheckBox chkshowinactive;
		private System.Windows.Forms.Button btneditcropdisease;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columndiseasepest;
		private System.Windows.Forms.BindingSource bindingSourcecropdiseases;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1createddate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnstatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
		private System.Windows.Forms.DataGridView dataGridViewcropdiseases;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button btncreatecropdisease;
		private System.Windows.Forms.GroupBox groupBoxlst;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
