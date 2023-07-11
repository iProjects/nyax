/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 16:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class manufacturerslistform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manufacturerslistform));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btneditmanufacturer = new System.Windows.Forms.Button();
			this.chkshowinactive = new System.Windows.Forms.CheckBox();
			this.btndeletemanufacturer = new System.Windows.Forms.Button();
			this.btncreatemanufacturer = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.groupBoxlst = new System.Windows.Forms.GroupBox();
			this.dataGridViewmanufacturers = new System.Windows.Forms.DataGridView();
			this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSourcemanufacturers = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBoxlst.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewmanufacturers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcemanufacturers)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btneditmanufacturer);
			this.groupBox1.Controls.Add(this.chkshowinactive);
			this.groupBox1.Controls.Add(this.btndeletemanufacturer);
			this.groupBox1.Controls.Add(this.btncreatemanufacturer);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(602, 66);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btneditmanufacturer
			// 
			this.btneditmanufacturer.BackColor = System.Drawing.SystemColors.Control;
			this.btneditmanufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btneditmanufacturer.ForeColor = System.Drawing.Color.Black;
			this.btneditmanufacturer.Image = ((System.Drawing.Image)(resources.GetObject("btneditmanufacturer.Image")));
			this.btneditmanufacturer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditmanufacturer.Location = new System.Drawing.Point(92, 10);
			this.btneditmanufacturer.Name = "btneditmanufacturer";
			this.btneditmanufacturer.Size = new System.Drawing.Size(52, 46);
			this.btneditmanufacturer.TabIndex = 10;
			this.btneditmanufacturer.Text = "edit ";
			this.btneditmanufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditmanufacturer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btneditmanufacturer.UseVisualStyleBackColor = false;
			this.btneditmanufacturer.Click += new System.EventHandler(this.BtneditmanufacturerClick);
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
			// btndeletemanufacturer
			// 
			this.btndeletemanufacturer.BackColor = System.Drawing.SystemColors.Control;
			this.btndeletemanufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndeletemanufacturer.ForeColor = System.Drawing.Color.Black;
			this.btndeletemanufacturer.Image = ((System.Drawing.Image)(resources.GetObject("btndeletemanufacturer.Image")));
			this.btndeletemanufacturer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btndeletemanufacturer.Location = new System.Drawing.Point(150, 10);
			this.btndeletemanufacturer.Name = "btndeletemanufacturer";
			this.btndeletemanufacturer.Size = new System.Drawing.Size(73, 46);
			this.btndeletemanufacturer.TabIndex = 8;
			this.btndeletemanufacturer.Text = "delete";
			this.btndeletemanufacturer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btndeletemanufacturer.UseVisualStyleBackColor = false;
			this.btndeletemanufacturer.Click += new System.EventHandler(this.BtndeletemanufacturerClick);
			// 
			// btncreatemanufacturer
			// 
			this.btncreatemanufacturer.BackColor = System.Drawing.SystemColors.Control;
			this.btncreatemanufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreatemanufacturer.ForeColor = System.Drawing.Color.Black;
			this.btncreatemanufacturer.Image = ((System.Drawing.Image)(resources.GetObject("btncreatemanufacturer.Image")));
			this.btncreatemanufacturer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreatemanufacturer.Location = new System.Drawing.Point(12, 10);
			this.btncreatemanufacturer.Name = "btncreatemanufacturer";
			this.btncreatemanufacturer.Size = new System.Drawing.Size(74, 46);
			this.btncreatemanufacturer.TabIndex = 2;
			this.btncreatemanufacturer.Text = "create";
			this.btncreatemanufacturer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncreatemanufacturer.UseVisualStyleBackColor = false;
			this.btncreatemanufacturer.Click += new System.EventHandler(this.BtncreatemanufacturerClick);
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
			// groupBoxlst
			// 
			this.groupBoxlst.Controls.Add(this.dataGridViewmanufacturers);
			this.groupBoxlst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxlst.Location = new System.Drawing.Point(0, 66);
			this.groupBoxlst.Name = "groupBoxlst";
			this.groupBoxlst.Size = new System.Drawing.Size(602, 395);
			this.groupBoxlst.TabIndex = 1;
			this.groupBoxlst.TabStop = false;
			// 
			// dataGridViewmanufacturers
			// 
			this.dataGridViewmanufacturers.AllowUserToAddRows = false;
			this.dataGridViewmanufacturers.AllowUserToDeleteRows = false;
			this.dataGridViewmanufacturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewmanufacturers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Columnid,
									this.Columnname,
									this.Columnstatus,
									this.Column1createddate});
			this.dataGridViewmanufacturers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewmanufacturers.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewmanufacturers.MultiSelect = false;
			this.dataGridViewmanufacturers.Name = "dataGridViewmanufacturers";
			this.dataGridViewmanufacturers.ReadOnly = true;
			this.dataGridViewmanufacturers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewmanufacturers.Size = new System.Drawing.Size(596, 376);
			this.dataGridViewmanufacturers.TabIndex = 0;
			this.dataGridViewmanufacturers.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewmanufacturersCellContentDoubleClick);
			// 
			// Columnid
			// 
			this.Columnid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnid.DataPropertyName = "manufacturer_id";
			this.Columnid.HeaderText = "id";
			this.Columnid.Name = "Columnid";
			this.Columnid.ReadOnly = true;
			this.Columnid.Width = 50;
			// 
			// Columnname
			// 
			this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnname.DataPropertyName = "manufacturer_name";
			this.Columnname.HeaderText = "name";
			this.Columnname.Name = "Columnname";
			this.Columnname.ReadOnly = true;
			this.Columnname.Width = 200;
			// 
			// Columnstatus
			// 
			this.Columnstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnstatus.DataPropertyName = "manufacturer_status";
			this.Columnstatus.HeaderText = "status";
			this.Columnstatus.Name = "Columnstatus";
			this.Columnstatus.ReadOnly = true;
			// 
			// Column1createddate
			// 
			this.Column1createddate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column1createddate.DataPropertyName = "created_date";
			this.Column1createddate.HeaderText = "created date";
			this.Column1createddate.Name = "Column1createddate";
			this.Column1createddate.ReadOnly = true;
			// 
			// manufacturerslistform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(602, 461);
			this.Controls.Add(this.groupBoxlst);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "manufacturerslistform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "manufacturers";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManufacturerslistformFormClosing);
			this.Load += new System.EventHandler(this.ManufacturerslistformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBoxlst.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewmanufacturers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcemanufacturers)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btndeletemanufacturer;
		private System.Windows.Forms.CheckBox chkshowinactive;
		private System.Windows.Forms.Button btneditmanufacturer;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1createddate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnstatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
		private System.Windows.Forms.BindingSource bindingSourcemanufacturers;
		private System.Windows.Forms.DataGridView dataGridViewmanufacturers;
		private System.Windows.Forms.GroupBox groupBoxlst;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button btncreatemanufacturer;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
