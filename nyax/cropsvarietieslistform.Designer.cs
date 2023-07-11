/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 10/23/2018
 * Time: 20:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class cropsvarietieslistform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cropsvarietieslistform));
			this.dataGridViewcropsvarieties = new System.Windows.Forms.DataGridView();
			this.groupBoxlst = new System.Windows.Forms.GroupBox();
			this.bindingSourcecropsvarieties = new System.Windows.Forms.BindingSource(this.components);
			this.btneditcropvariety = new System.Windows.Forms.Button();
			this.chkshowinactive = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btndeletecropvariety = new System.Windows.Forms.Button();
			this.btncreatecropvariety = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewcropsvarieties)).BeginInit();
			this.groupBoxlst.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcecropsvarieties)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridViewcropsvarieties
			// 
			this.dataGridViewcropsvarieties.AllowUserToAddRows = false;
			this.dataGridViewcropsvarieties.AllowUserToDeleteRows = false;
			this.dataGridViewcropsvarieties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewcropsvarieties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Columnid,
									this.Columnname,
									this.Column1,
									this.Column2,
									this.Columnstatus,
									this.Column1createddate});
			this.dataGridViewcropsvarieties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewcropsvarieties.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewcropsvarieties.MultiSelect = false;
			this.dataGridViewcropsvarieties.Name = "dataGridViewcropsvarieties";
			this.dataGridViewcropsvarieties.ReadOnly = true;
			this.dataGridViewcropsvarieties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewcropsvarieties.Size = new System.Drawing.Size(596, 376);
			this.dataGridViewcropsvarieties.TabIndex = 0;
			// 
			// groupBoxlst
			// 
			this.groupBoxlst.Controls.Add(this.dataGridViewcropsvarieties);
			this.groupBoxlst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxlst.Location = new System.Drawing.Point(0, 66);
			this.groupBoxlst.Name = "groupBoxlst";
			this.groupBoxlst.Size = new System.Drawing.Size(602, 395);
			this.groupBoxlst.TabIndex = 3;
			this.groupBoxlst.TabStop = false;
			// 
			// btneditcropvariety
			// 
			this.btneditcropvariety.BackColor = System.Drawing.SystemColors.Control;
			this.btneditcropvariety.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btneditcropvariety.ForeColor = System.Drawing.Color.Black;
			this.btneditcropvariety.Image = ((System.Drawing.Image)(resources.GetObject("btneditcropvariety.Image")));
			this.btneditcropvariety.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditcropvariety.Location = new System.Drawing.Point(90, 10);
			this.btneditcropvariety.Name = "btneditcropvariety";
			this.btneditcropvariety.Size = new System.Drawing.Size(54, 46);
			this.btneditcropvariety.TabIndex = 10;
			this.btneditcropvariety.Text = "edit";
			this.btneditcropvariety.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditcropvariety.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btneditcropvariety.UseVisualStyleBackColor = false;
			this.btneditcropvariety.Click += new System.EventHandler(this.BtneditcropvarietyClick);
			// 
			// chkshowinactive
			// 
			this.chkshowinactive.Dock = System.Windows.Forms.DockStyle.Right;
			this.chkshowinactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkshowinactive.Location = new System.Drawing.Point(495, 16);
			this.chkshowinactive.Name = "chkshowinactive";
			this.chkshowinactive.Size = new System.Drawing.Size(104, 47);
			this.chkshowinactive.TabIndex = 9;
			this.chkshowinactive.Text = "show inactive";
			this.chkshowinactive.UseVisualStyleBackColor = true;
			this.chkshowinactive.CheckedChanged += new System.EventHandler(this.ChkshowinactiveCheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btneditcropvariety);
			this.groupBox1.Controls.Add(this.chkshowinactive);
			this.groupBox1.Controls.Add(this.btndeletecropvariety);
			this.groupBox1.Controls.Add(this.btncreatecropvariety);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(602, 66);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// btndeletecropvariety
			// 
			this.btndeletecropvariety.BackColor = System.Drawing.SystemColors.Control;
			this.btndeletecropvariety.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndeletecropvariety.ForeColor = System.Drawing.Color.Black;
			this.btndeletecropvariety.Image = ((System.Drawing.Image)(resources.GetObject("btndeletecropvariety.Image")));
			this.btndeletecropvariety.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btndeletecropvariety.Location = new System.Drawing.Point(150, 10);
			this.btndeletecropvariety.Name = "btndeletecropvariety";
			this.btndeletecropvariety.Size = new System.Drawing.Size(73, 46);
			this.btndeletecropvariety.TabIndex = 8;
			this.btndeletecropvariety.Text = "delete";
			this.btndeletecropvariety.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btndeletecropvariety.UseVisualStyleBackColor = false;
			this.btndeletecropvariety.Click += new System.EventHandler(this.BtndeletecropvarietyClick);
			// 
			// btncreatecropvariety
			// 
			this.btncreatecropvariety.BackColor = System.Drawing.SystemColors.Control;
			this.btncreatecropvariety.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreatecropvariety.ForeColor = System.Drawing.Color.Black;
			this.btncreatecropvariety.Image = ((System.Drawing.Image)(resources.GetObject("btncreatecropvariety.Image")));
			this.btncreatecropvariety.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreatecropvariety.Location = new System.Drawing.Point(12, 10);
			this.btncreatecropvariety.Name = "btncreatecropvariety";
			this.btncreatecropvariety.Size = new System.Drawing.Size(72, 46);
			this.btncreatecropvariety.TabIndex = 2;
			this.btncreatecropvariety.Text = "create";
			this.btncreatecropvariety.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncreatecropvariety.UseVisualStyleBackColor = false;
			this.btncreatecropvariety.Click += new System.EventHandler(this.BtncreatecropvarietyClick);
			// 
			// btnclose
			// 
			this.btnclose.BackColor = System.Drawing.SystemColors.Control;
			this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnclose.ForeColor = System.Drawing.Color.Black;
			this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
			this.btnclose.Location = new System.Drawing.Point(229, 10);
			this.btnclose.Name = "btnclose";
			this.btnclose.Size = new System.Drawing.Size(62, 46);
			this.btnclose.TabIndex = 3;
			this.btnclose.Text = "close";
			this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnclose.UseVisualStyleBackColor = false;
			this.btnclose.Click += new System.EventHandler(this.BtncloseClick);
			// 
			// Columnid
			// 
			this.Columnid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnid.DataPropertyName = "crop_variety_id";
			this.Columnid.HeaderText = "id";
			this.Columnid.Name = "Columnid";
			this.Columnid.ReadOnly = true;
			this.Columnid.Width = 50;
			// 
			// Columnname
			// 
			this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnname.DataPropertyName = "crop_variety_name";
			this.Columnname.HeaderText = "name";
			this.Columnname.Name = "Columnname";
			this.Columnname.ReadOnly = true;
			this.Columnname.Width = 200;
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column1.DataPropertyName = "crop_variety_crop_name";
			this.Column1.HeaderText = "crop";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column2.DataPropertyName = "crop_variety_manufacturer_name";
			this.Column2.HeaderText = "manufacturer";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Columnstatus
			// 
			this.Columnstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Columnstatus.DataPropertyName = "crop_variety_status";
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
			this.Column1createddate.Visible = false;
			this.Column1createddate.Width = 203;
			// 
			// cropsvarietieslistform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(602, 461);
			this.Controls.Add(this.groupBoxlst);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "cropsvarietieslistform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "varieties";
			this.Load += new System.EventHandler(this.cropsvarietieslistformLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewcropsvarieties)).EndInit();
			this.groupBoxlst.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcecropsvarieties)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button btncreatecropvariety;
		private System.Windows.Forms.Button btndeletecropvariety;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkshowinactive;
		private System.Windows.Forms.Button btneditcropvariety;
		private System.Windows.Forms.BindingSource bindingSourcecropsvarieties;
		private System.Windows.Forms.GroupBox groupBoxlst;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnstatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
		private System.Windows.Forms.DataGridView dataGridViewcropsvarieties;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1createddate;
	}
}
