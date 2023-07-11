/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 07:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class pestsinsecticideslistform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pestsinsecticideslistform));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btneditpestinsecticide = new System.Windows.Forms.Button();
			this.chkshowinactive = new System.Windows.Forms.CheckBox();
			this.btndeletepestinsecticide = new System.Windows.Forms.Button();
			this.btncreatepestinsecticide = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.groupBoxlst = new System.Windows.Forms.GroupBox();
			this.dataGridViewpestsinsecticides = new System.Windows.Forms.DataGridView();
			this.bindingSourcepestsinsecticides = new System.Windows.Forms.BindingSource(this.components);
			this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnpestinsecticide_manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columncrop_variety = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			this.groupBoxlst.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewpestsinsecticides)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcepestsinsecticides)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btneditpestinsecticide);
			this.groupBox1.Controls.Add(this.chkshowinactive);
			this.groupBox1.Controls.Add(this.btndeletepestinsecticide);
			this.groupBox1.Controls.Add(this.btncreatepestinsecticide);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(596, 68);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btneditpestinsecticide
			// 
			this.btneditpestinsecticide.BackColor = System.Drawing.SystemColors.Control;
			this.btneditpestinsecticide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btneditpestinsecticide.ForeColor = System.Drawing.Color.Black;
			this.btneditpestinsecticide.Image = ((System.Drawing.Image)(resources.GetObject("btneditpestinsecticide.Image")));
			this.btneditpestinsecticide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditpestinsecticide.Location = new System.Drawing.Point(93, 12);
			this.btneditpestinsecticide.Name = "btneditpestinsecticide";
			this.btneditpestinsecticide.Size = new System.Drawing.Size(53, 46);
			this.btneditpestinsecticide.TabIndex = 10;
			this.btneditpestinsecticide.Text = "edit";
			this.btneditpestinsecticide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditpestinsecticide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btneditpestinsecticide.UseVisualStyleBackColor = false;
			this.btneditpestinsecticide.Click += new System.EventHandler(this.BtneditpestinsecticideClick);
			// 
			// chkshowinactive
			// 
			this.chkshowinactive.Dock = System.Windows.Forms.DockStyle.Right;
			this.chkshowinactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkshowinactive.Location = new System.Drawing.Point(489, 16);
			this.chkshowinactive.Name = "chkshowinactive";
			this.chkshowinactive.Size = new System.Drawing.Size(104, 49);
			this.chkshowinactive.TabIndex = 9;
			this.chkshowinactive.Text = "show inactive";
			this.chkshowinactive.UseVisualStyleBackColor = true;
			this.chkshowinactive.CheckedChanged += new System.EventHandler(this.ChkshowinactiveCheckedChanged);
			// 
			// btndeletepestinsecticide
			// 
			this.btndeletepestinsecticide.BackColor = System.Drawing.SystemColors.Control;
			this.btndeletepestinsecticide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndeletepestinsecticide.ForeColor = System.Drawing.Color.Black;
			this.btndeletepestinsecticide.Image = ((System.Drawing.Image)(resources.GetObject("btndeletepestinsecticide.Image")));
			this.btndeletepestinsecticide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btndeletepestinsecticide.Location = new System.Drawing.Point(152, 12);
			this.btndeletepestinsecticide.Name = "btndeletepestinsecticide";
			this.btndeletepestinsecticide.Size = new System.Drawing.Size(73, 46);
			this.btndeletepestinsecticide.TabIndex = 8;
			this.btndeletepestinsecticide.Text = "delete";
			this.btndeletepestinsecticide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btndeletepestinsecticide.UseVisualStyleBackColor = false;
			this.btndeletepestinsecticide.Click += new System.EventHandler(this.BtndeletepestinsecticideClick);
			// 
			// btncreatepestinsecticide
			// 
			this.btncreatepestinsecticide.BackColor = System.Drawing.SystemColors.Control;
			this.btncreatepestinsecticide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreatepestinsecticide.ForeColor = System.Drawing.Color.Black;
			this.btncreatepestinsecticide.Image = ((System.Drawing.Image)(resources.GetObject("btncreatepestinsecticide.Image")));
			this.btncreatepestinsecticide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreatepestinsecticide.Location = new System.Drawing.Point(12, 12);
			this.btncreatepestinsecticide.Name = "btncreatepestinsecticide";
			this.btncreatepestinsecticide.Size = new System.Drawing.Size(75, 46);
			this.btncreatepestinsecticide.TabIndex = 0;
			this.btncreatepestinsecticide.Text = "create";
			this.btncreatepestinsecticide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncreatepestinsecticide.UseVisualStyleBackColor = false;
			this.btncreatepestinsecticide.Click += new System.EventHandler(this.BtncreatepestinsecticideClick);
			// 
			// btnclose
			// 
			this.btnclose.BackColor = System.Drawing.SystemColors.Control;
			this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnclose.ForeColor = System.Drawing.Color.Black;
			this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
			this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnclose.Location = new System.Drawing.Point(231, 12);
			this.btnclose.Name = "btnclose";
			this.btnclose.Size = new System.Drawing.Size(60, 46);
			this.btnclose.TabIndex = 1;
			this.btnclose.Text = "close";
			this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnclose.UseVisualStyleBackColor = false;
			this.btnclose.Click += new System.EventHandler(this.BtncloseClick);
			// 
			// groupBoxlst
			// 
			this.groupBoxlst.Controls.Add(this.dataGridViewpestsinsecticides);
			this.groupBoxlst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxlst.Location = new System.Drawing.Point(0, 68);
			this.groupBoxlst.Name = "groupBoxlst";
			this.groupBoxlst.Size = new System.Drawing.Size(596, 393);
			this.groupBoxlst.TabIndex = 1;
			this.groupBoxlst.TabStop = false;
			// 
			// dataGridViewpestsinsecticides
			// 
			this.dataGridViewpestsinsecticides.AllowUserToAddRows = false;
			this.dataGridViewpestsinsecticides.AllowUserToDeleteRows = false;
			this.dataGridViewpestsinsecticides.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewpestsinsecticides.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Columnid,
									this.Columnname,
									this.Columnpestinsecticide_manufacturer,
									this.Column1,
									this.Columncrop_variety,
									this.Columnstatus,
									this.Column1createddate});
			this.dataGridViewpestsinsecticides.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewpestsinsecticides.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewpestsinsecticides.MultiSelect = false;
			this.dataGridViewpestsinsecticides.Name = "dataGridViewpestsinsecticides";
			this.dataGridViewpestsinsecticides.ReadOnly = true;
			this.dataGridViewpestsinsecticides.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewpestsinsecticides.Size = new System.Drawing.Size(590, 374);
			this.dataGridViewpestsinsecticides.TabIndex = 0;
			this.dataGridViewpestsinsecticides.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewpestsinsecticidesCellContentDoubleClick);
			// 
			// Columnid
			// 
			this.Columnid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnid.DataPropertyName = "pestinsecticide_id";
			this.Columnid.HeaderText = "id";
			this.Columnid.Name = "Columnid";
			this.Columnid.ReadOnly = true;
			this.Columnid.Width = 50;
			// 
			// Columnname
			// 
			this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnname.DataPropertyName = "pestinsecticide_name";
			this.Columnname.HeaderText = "name";
			this.Columnname.Name = "Columnname";
			this.Columnname.ReadOnly = true;
			// 
			// Columnpestinsecticide_manufacturer
			// 
			this.Columnpestinsecticide_manufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnpestinsecticide_manufacturer.DataPropertyName = "pestinsecticide_manufacturer_name";
			this.Columnpestinsecticide_manufacturer.HeaderText = "manufacturer";
			this.Columnpestinsecticide_manufacturer.Name = "Columnpestinsecticide_manufacturer";
			this.Columnpestinsecticide_manufacturer.ReadOnly = true;
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column1.DataPropertyName = "pestinsecticide_crop_disease_name";
			this.Column1.HeaderText = "disease/pest";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Columncrop_variety
			// 
			this.Columncrop_variety.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columncrop_variety.DataPropertyName = "pestinsecticide_category_name";
			this.Columncrop_variety.HeaderText = "category";
			this.Columncrop_variety.Name = "Columncrop_variety";
			this.Columncrop_variety.ReadOnly = true;
			// 
			// Columnstatus
			// 
			this.Columnstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Columnstatus.DataPropertyName = "pestinsecticide_status";
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
			this.Column1createddate.Width = 5;
			// 
			// pestsinsecticideslistform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 461);
			this.Controls.Add(this.groupBoxlst);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "pestsinsecticideslistform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "pesticides/insecticides";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PestsinsecticideslistformFormClosing);
			this.Load += new System.EventHandler(this.PestsinsecticideslistformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBoxlst.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewpestsinsecticides)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcepestsinsecticides)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.Button btndeletepestinsecticide;
		private System.Windows.Forms.CheckBox chkshowinactive;
		private System.Windows.Forms.Button btneditpestinsecticide;
		private System.Windows.Forms.BindingSource bindingSourcepestsinsecticides;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1createddate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnstatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnpestinsecticide_manufacturer;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columncrop_variety;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
		private System.Windows.Forms.DataGridView dataGridViewpestsinsecticides;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button btncreatepestinsecticide;
		private System.Windows.Forms.GroupBox groupBoxlst;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
