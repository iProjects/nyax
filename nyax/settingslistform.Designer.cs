/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 21:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class settingslistform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingslistform));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btneditsetting = new System.Windows.Forms.Button();
			this.chkshowinactive = new System.Windows.Forms.CheckBox();
			this.btndeletesetting = new System.Windows.Forms.Button();
			this.btncreatesetting = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.groupBoxlst = new System.Windows.Forms.GroupBox();
			this.dataGridViewsettings = new System.Windows.Forms.DataGridView();
			this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columncrop_variety = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSourcesettings = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBoxlst.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewsettings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcesettings)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btneditsetting);
			this.groupBox1.Controls.Add(this.chkshowinactive);
			this.groupBox1.Controls.Add(this.btndeletesetting);
			this.groupBox1.Controls.Add(this.btncreatesetting);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(526, 69);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btneditsetting
			// 
			this.btneditsetting.BackColor = System.Drawing.SystemColors.Control;
			this.btneditsetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btneditsetting.ForeColor = System.Drawing.Color.Black;
			this.btneditsetting.Image = ((System.Drawing.Image)(resources.GetObject("btneditsetting.Image")));
			this.btneditsetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditsetting.Location = new System.Drawing.Point(91, 14);
			this.btneditsetting.Name = "btneditsetting";
			this.btneditsetting.Size = new System.Drawing.Size(54, 46);
			this.btneditsetting.TabIndex = 13;
			this.btneditsetting.Text = "edit";
			this.btneditsetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditsetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btneditsetting.UseVisualStyleBackColor = false;
			this.btneditsetting.Click += new System.EventHandler(this.BtneditsettingClick);
			// 
			// chkshowinactive
			// 
			this.chkshowinactive.Dock = System.Windows.Forms.DockStyle.Right;
			this.chkshowinactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkshowinactive.Location = new System.Drawing.Point(419, 16);
			this.chkshowinactive.Name = "chkshowinactive";
			this.chkshowinactive.Size = new System.Drawing.Size(104, 50);
			this.chkshowinactive.TabIndex = 12;
			this.chkshowinactive.Text = "show inactive";
			this.chkshowinactive.UseVisualStyleBackColor = true;
			this.chkshowinactive.CheckedChanged += new System.EventHandler(this.ChkshowinactiveCheckedChanged);
			// 
			// btndeletesetting
			// 
			this.btndeletesetting.BackColor = System.Drawing.SystemColors.Control;
			this.btndeletesetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndeletesetting.ForeColor = System.Drawing.Color.Black;
			this.btndeletesetting.Image = ((System.Drawing.Image)(resources.GetObject("btndeletesetting.Image")));
			this.btndeletesetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btndeletesetting.Location = new System.Drawing.Point(151, 14);
			this.btndeletesetting.Name = "btndeletesetting";
			this.btndeletesetting.Size = new System.Drawing.Size(78, 46);
			this.btndeletesetting.TabIndex = 11;
			this.btndeletesetting.Text = "delete";
			this.btndeletesetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btndeletesetting.UseVisualStyleBackColor = false;
			this.btndeletesetting.Click += new System.EventHandler(this.BtndeletesettingClick);
			// 
			// btncreatesetting
			// 
			this.btncreatesetting.BackColor = System.Drawing.SystemColors.Control;
			this.btncreatesetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreatesetting.ForeColor = System.Drawing.Color.Black;
			this.btncreatesetting.Image = ((System.Drawing.Image)(resources.GetObject("btncreatesetting.Image")));
			this.btncreatesetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreatesetting.Location = new System.Drawing.Point(12, 14);
			this.btncreatesetting.Name = "btncreatesetting";
			this.btncreatesetting.Size = new System.Drawing.Size(73, 46);
			this.btncreatesetting.TabIndex = 0;
			this.btncreatesetting.Text = "create";
			this.btncreatesetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncreatesetting.UseVisualStyleBackColor = false;
			this.btncreatesetting.Click += new System.EventHandler(this.BtncreatesettingClick);
			// 
			// btnclose
			// 
			this.btnclose.BackColor = System.Drawing.SystemColors.Control;
			this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnclose.ForeColor = System.Drawing.Color.Black;
			this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
			this.btnclose.Location = new System.Drawing.Point(235, 14);
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
			this.groupBoxlst.Controls.Add(this.dataGridViewsettings);
			this.groupBoxlst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxlst.Location = new System.Drawing.Point(0, 69);
			this.groupBoxlst.Name = "groupBoxlst";
			this.groupBoxlst.Size = new System.Drawing.Size(526, 392);
			this.groupBoxlst.TabIndex = 1;
			this.groupBoxlst.TabStop = false;
			// 
			// dataGridViewsettings
			// 
			this.dataGridViewsettings.AllowUserToAddRows = false;
			this.dataGridViewsettings.AllowUserToDeleteRows = false;
			this.dataGridViewsettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewsettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Columnid,
									this.Columnname,
									this.Columncrop_variety,
									this.Columnstatus,
									this.Column1createddate});
			this.dataGridViewsettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewsettings.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewsettings.MultiSelect = false;
			this.dataGridViewsettings.Name = "dataGridViewsettings";
			this.dataGridViewsettings.ReadOnly = true;
			this.dataGridViewsettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewsettings.Size = new System.Drawing.Size(520, 373);
			this.dataGridViewsettings.TabIndex = 0;
			this.dataGridViewsettings.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewsettingsCellContentDoubleClick);
			// 
			// Columnid
			// 
			this.Columnid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnid.DataPropertyName = "setting_id";
			this.Columnid.HeaderText = "id";
			this.Columnid.Name = "Columnid";
			this.Columnid.ReadOnly = true;
			this.Columnid.Width = 50;
			// 
			// Columnname
			// 
			this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnname.DataPropertyName = "setting_name";
			this.Columnname.HeaderText = "name";
			this.Columnname.Name = "Columnname";
			this.Columnname.ReadOnly = true;
			this.Columnname.Width = 150;
			// 
			// Columncrop_variety
			// 
			this.Columncrop_variety.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columncrop_variety.DataPropertyName = "setting_value";
			this.Columncrop_variety.HeaderText = "value";
			this.Columncrop_variety.Name = "Columncrop_variety";
			this.Columncrop_variety.ReadOnly = true;
			// 
			// Columnstatus
			// 
			this.Columnstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnstatus.DataPropertyName = "setting_status";
			this.Columnstatus.HeaderText = "status";
			this.Columnstatus.Name = "Columnstatus";
			this.Columnstatus.ReadOnly = true;
			this.Columnstatus.Width = 60;
			// 
			// Column1createddate
			// 
			this.Column1createddate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column1createddate.DataPropertyName = "created_date";
			this.Column1createddate.HeaderText = "created date";
			this.Column1createddate.Name = "Column1createddate";
			this.Column1createddate.ReadOnly = true;
			// 
			// settingslistform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(526, 461);
			this.Controls.Add(this.groupBoxlst);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "settingslistform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingslistformFormClosing);
			this.Load += new System.EventHandler(this.SettingslistformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBoxlst.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewsettings)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcesettings)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btndeletesetting;
		private System.Windows.Forms.CheckBox chkshowinactive;
		private System.Windows.Forms.Button btneditsetting;
		private System.Windows.Forms.BindingSource bindingSourcesettings;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columncrop_variety;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1createddate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnstatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
		private System.Windows.Forms.DataGridView dataGridViewsettings;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button btncreatesetting;
		private System.Windows.Forms.GroupBox groupBoxlst;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
