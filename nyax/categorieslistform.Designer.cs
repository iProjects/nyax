/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 12/18/2018
 * Time: 10:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class categorieslistform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(categorieslistform));
			this.btneditcategory = new System.Windows.Forms.Button();
			this.chkshowinactive = new System.Windows.Forms.CheckBox();
			this.btndeletecategory = new System.Windows.Forms.Button();
			this.btncreatecategory = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnclose = new System.Windows.Forms.Button();
			this.bindingSourcecategories = new System.Windows.Forms.BindingSource(this.components);
			this.groupBoxlst = new System.Windows.Forms.GroupBox();
			this.dataGridViewcategories = new System.Windows.Forms.DataGridView();
			this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcecategories)).BeginInit();
			this.groupBoxlst.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewcategories)).BeginInit();
			this.SuspendLayout();
			// 
			// btneditcategory
			// 
			this.btneditcategory.BackColor = System.Drawing.SystemColors.Control;
			this.btneditcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btneditcategory.ForeColor = System.Drawing.Color.Black;
			this.btneditcategory.Image = ((System.Drawing.Image)(resources.GetObject("btneditcategory.Image")));
			this.btneditcategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditcategory.Location = new System.Drawing.Point(90, 12);
			this.btneditcategory.Name = "btneditcategory";
			this.btneditcategory.Size = new System.Drawing.Size(50, 46);
			this.btneditcategory.TabIndex = 7;
			this.btneditcategory.Text = "edit";
			this.btneditcategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btneditcategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btneditcategory.UseVisualStyleBackColor = false;
			this.btneditcategory.Click += new System.EventHandler(this.BtneditcategoryClick);
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
			// btndeletecategory
			// 
			this.btndeletecategory.BackColor = System.Drawing.SystemColors.Control;
			this.btndeletecategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndeletecategory.ForeColor = System.Drawing.Color.Black;
			this.btndeletecategory.Image = ((System.Drawing.Image)(resources.GetObject("btndeletecategory.Image")));
			this.btndeletecategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btndeletecategory.Location = new System.Drawing.Point(146, 12);
			this.btndeletecategory.Name = "btndeletecategory";
			this.btndeletecategory.Size = new System.Drawing.Size(78, 46);
			this.btndeletecategory.TabIndex = 5;
			this.btndeletecategory.Text = "delete";
			this.btndeletecategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btndeletecategory.UseVisualStyleBackColor = false;
			this.btndeletecategory.Click += new System.EventHandler(this.BtndeletecategoryClick);
			// 
			// btncreatecategory
			// 
			this.btncreatecategory.BackColor = System.Drawing.SystemColors.Control;
			this.btncreatecategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreatecategory.ForeColor = System.Drawing.Color.Black;
			this.btncreatecategory.Image = ((System.Drawing.Image)(resources.GetObject("btncreatecategory.Image")));
			this.btncreatecategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreatecategory.Location = new System.Drawing.Point(12, 12);
			this.btncreatecategory.Name = "btncreatecategory";
			this.btncreatecategory.Size = new System.Drawing.Size(72, 46);
			this.btncreatecategory.TabIndex = 0;
			this.btncreatecategory.Text = "create";
			this.btncreatecategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncreatecategory.UseVisualStyleBackColor = false;
			this.btncreatecategory.Click += new System.EventHandler(this.BtncreatecategoryClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btneditcategory);
			this.groupBox1.Controls.Add(this.chkshowinactive);
			this.groupBox1.Controls.Add(this.btndeletecategory);
			this.groupBox1.Controls.Add(this.btncreatecategory);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(584, 63);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// btnclose
			// 
			this.btnclose.BackColor = System.Drawing.SystemColors.Control;
			this.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
			this.groupBoxlst.Controls.Add(this.dataGridViewcategories);
			this.groupBoxlst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxlst.Location = new System.Drawing.Point(0, 63);
			this.groupBoxlst.Name = "groupBoxlst";
			this.groupBoxlst.Size = new System.Drawing.Size(584, 398);
			this.groupBoxlst.TabIndex = 4;
			this.groupBoxlst.TabStop = false;
			// 
			// dataGridViewcategories
			// 
			this.dataGridViewcategories.AllowUserToAddRows = false;
			this.dataGridViewcategories.AllowUserToDeleteRows = false;
			this.dataGridViewcategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewcategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Columnid,
									this.Columnname,
									this.Columnstatus,
									this.Column1createddate});
			this.dataGridViewcategories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewcategories.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewcategories.MultiSelect = false;
			this.dataGridViewcategories.Name = "dataGridViewcategories";
			this.dataGridViewcategories.ReadOnly = true;
			this.dataGridViewcategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewcategories.Size = new System.Drawing.Size(578, 379);
			this.dataGridViewcategories.TabIndex = 0;
			this.dataGridViewcategories.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewcategoriesCellContentDoubleClick);
			// 
			// Columnid
			// 
			this.Columnid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnid.DataPropertyName = "category_id";
			this.Columnid.HeaderText = "id";
			this.Columnid.Name = "Columnid";
			this.Columnid.ReadOnly = true;
			this.Columnid.Width = 50;
			// 
			// Columnname
			// 
			this.Columnname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnname.DataPropertyName = "category_name";
			this.Columnname.HeaderText = "name";
			this.Columnname.Name = "Columnname";
			this.Columnname.ReadOnly = true;
			this.Columnname.Width = 200;
			// 
			// Columnstatus
			// 
			this.Columnstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Columnstatus.DataPropertyName = "category_status";
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
			this.Column1createddate.Width = 185;
			// 
			// categorieslistform
			// 
			this.AcceptButton = this.btncreatecategory;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnclose;
			this.ClientSize = new System.Drawing.Size(584, 461);
			this.Controls.Add(this.groupBoxlst);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "categorieslistform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "categories";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CategorieslistformFormClosing);
			this.Load += new System.EventHandler(this.CategorieslistformLoad);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcecategories)).EndInit();
			this.groupBoxlst.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewcategories)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.GroupBox groupBoxlst;
		private System.Windows.Forms.BindingSource bindingSourcecategories;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btncreatecategory;
		private System.Windows.Forms.Button btndeletecategory;
		private System.Windows.Forms.CheckBox chkshowinactive;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1createddate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnstatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
		private System.Windows.Forms.DataGridView dataGridViewcategories;
		private System.Windows.Forms.Button btneditcategory;
	}
}
