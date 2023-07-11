/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/08/2018
 * Time: 10:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class cropslistform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cropslistform));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btneditcrop = new System.Windows.Forms.Button();
			this.chkshowinactive = new System.Windows.Forms.CheckBox();
			this.btndeletecrop = new System.Windows.Forms.Button();
			this.btncreatecrop = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.groupBoxlst = new System.Windows.Forms.GroupBox();
			this.dataGridViewcrops = new System.Windows.Forms.DataGridView();
			this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSourcecrops = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBoxlst.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewcrops)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcecrops)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btneditcrop);
			this.groupBox1.Controls.Add(this.chkshowinactive);
			this.groupBox1.Controls.Add(this.btndeletecrop);
			this.groupBox1.Controls.Add(this.btncreatecrop);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(527, 62);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btneditcrop
			// 
			this.btneditcrop.BackColor = System.Drawing.SystemColors.Control;
			this.btneditcrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btneditcrop.ForeColor = System.Drawing.Color.Black;
			this.btneditcrop.Image = ((System.Drawing.Image)(resources.GetObject("btneditcrop.Image")));
			this.btneditcrop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditcrop.Location = new System.Drawing.Point(94, 14);
			this.btneditcrop.Name = "btneditcrop";
			this.btneditcrop.Size = new System.Drawing.Size(51, 46);
			this.btneditcrop.TabIndex = 4;
			this.btneditcrop.Text = "edit";
			this.btneditcrop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditcrop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btneditcrop.UseVisualStyleBackColor = false;
			this.btneditcrop.Click += new System.EventHandler(this.BtneditcropClick);
			// 
			// chkshowinactive
			// 
			this.chkshowinactive.Dock = System.Windows.Forms.DockStyle.Right;
			this.chkshowinactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkshowinactive.Location = new System.Drawing.Point(420, 16);
			this.chkshowinactive.Name = "chkshowinactive";
			this.chkshowinactive.Size = new System.Drawing.Size(104, 43);
			this.chkshowinactive.TabIndex = 3;
			this.chkshowinactive.Text = "show inactive";
			this.chkshowinactive.UseVisualStyleBackColor = true;
			this.chkshowinactive.CheckedChanged += new System.EventHandler(this.ChkshowinactiveCheckedChanged);
			// 
			// btndeletecrop
			// 
			this.btndeletecrop.BackColor = System.Drawing.SystemColors.Control;
			this.btndeletecrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndeletecrop.ForeColor = System.Drawing.Color.Black;
			this.btndeletecrop.Image = ((System.Drawing.Image)(resources.GetObject("btndeletecrop.Image")));
			this.btndeletecrop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btndeletecrop.Location = new System.Drawing.Point(151, 14);
			this.btndeletecrop.Name = "btndeletecrop";
			this.btndeletecrop.Size = new System.Drawing.Size(71, 46);
			this.btndeletecrop.TabIndex = 2;
			this.btndeletecrop.Text = "delete";
			this.btndeletecrop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btndeletecrop.UseVisualStyleBackColor = false;
			this.btndeletecrop.Click += new System.EventHandler(this.BtndeleteClick);
			// 
			// btncreatecrop
			// 
			this.btncreatecrop.BackColor = System.Drawing.SystemColors.Control;
			this.btncreatecrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreatecrop.ForeColor = System.Drawing.Color.Black;
			this.btncreatecrop.Image = ((System.Drawing.Image)(resources.GetObject("btncreatecrop.Image")));
			this.btncreatecrop.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btncreatecrop.Location = new System.Drawing.Point(12, 14);
			this.btncreatecrop.Name = "btncreatecrop";
			this.btncreatecrop.Size = new System.Drawing.Size(76, 46);
			this.btncreatecrop.TabIndex = 0;
			this.btncreatecrop.Text = "create";
			this.btncreatecrop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreatecrop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncreatecrop.UseVisualStyleBackColor = false;
			this.btncreatecrop.Click += new System.EventHandler(this.BtncreatecropClick);
			// 
			// btnclose
			// 
			this.btnclose.BackColor = System.Drawing.SystemColors.Control;
			this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnclose.ForeColor = System.Drawing.Color.Black;
			this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
			this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnclose.Location = new System.Drawing.Point(228, 12);
			this.btnclose.Name = "btnclose";
			this.btnclose.Size = new System.Drawing.Size(58, 46);
			this.btnclose.TabIndex = 1;
			this.btnclose.Text = "close";
			this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnclose.UseVisualStyleBackColor = false;
			this.btnclose.Click += new System.EventHandler(this.BtncloseClick);
			// 
			// groupBoxlst
			// 
			this.groupBoxlst.Controls.Add(this.dataGridViewcrops);
			this.groupBoxlst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxlst.Location = new System.Drawing.Point(0, 62);
			this.groupBoxlst.Name = "groupBoxlst";
			this.groupBoxlst.Size = new System.Drawing.Size(527, 399);
			this.groupBoxlst.TabIndex = 1;
			this.groupBoxlst.TabStop = false;
			// 
			// dataGridViewcrops
			// 
			this.dataGridViewcrops.AllowUserToAddRows = false;
			this.dataGridViewcrops.AllowUserToDeleteRows = false;
			this.dataGridViewcrops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewcrops.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Columnid,
									this.Columnname,
									this.Columnstatus,
									this.Column1createddate});
			this.dataGridViewcrops.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewcrops.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewcrops.MultiSelect = false;
			this.dataGridViewcrops.Name = "dataGridViewcrops";
			this.dataGridViewcrops.ReadOnly = true;
			this.dataGridViewcrops.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewcrops.Size = new System.Drawing.Size(521, 380);
			this.dataGridViewcrops.TabIndex = 0;
			this.dataGridViewcrops.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewcropsCellContentDoubleClick);
			// 
			// Columnid
			// 
			this.Columnid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnid.DataPropertyName = "crop_id";
			this.Columnid.HeaderText = "id";
			this.Columnid.Name = "Columnid";
			this.Columnid.ReadOnly = true;
			this.Columnid.Width = 50;
			// 
			// Columnname
			// 
			this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnname.DataPropertyName = "crop_name";
			this.Columnname.HeaderText = "name";
			this.Columnname.Name = "Columnname";
			this.Columnname.ReadOnly = true;
			this.Columnname.Width = 190;
			// 
			// Columnstatus
			// 
			this.Columnstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnstatus.DataPropertyName = "crop_status";
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
			// cropslistform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(527, 461);
			this.Controls.Add(this.groupBoxlst);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "cropslistform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "crops";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CropslistformFormClosing);
			this.Load += new System.EventHandler(this.CropslistformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBoxlst.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewcrops)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcecrops)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btneditcrop;
		private System.Windows.Forms.CheckBox chkshowinactive;
		private System.Windows.Forms.Button btndeletecrop;
		private System.Windows.Forms.BindingSource bindingSourcecrops;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1createddate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnstatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
		private System.Windows.Forms.DataGridView dataGridViewcrops;
		private System.Windows.Forms.Button btncreatecrop;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.GroupBox groupBoxlst;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
