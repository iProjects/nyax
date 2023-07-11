/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 01/17/2019
 * Time: 11:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class searchform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchform));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblstatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnsearch = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.txtcropname = new System.Windows.Forms.TextBox();
			this.cbosearchcriteria = new System.Windows.Forms.ComboBox();
			this.chkshowinactive = new System.Windows.Forms.CheckBox();
			this.btnclose = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtlog = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.dataGridViewcrops = new System.Windows.Forms.DataGridView();
			this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Columnstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1createddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSourcecrops = new System.Windows.Forms.BindingSource(this.components);
			this.statusStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewcrops)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcecrops)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.lblstatus,
									this.toolStripProgressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 415);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(564, 26);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblstatus
			// 
			this.lblstatus.Name = "lblstatus";
			this.lblstatus.Size = new System.Drawing.Size(22, 21);
			this.lblstatus.Text = ".....";
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(100, 20);
			this.toolStripProgressBar.Step = 1;
			this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnsearch);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.txtcropname);
			this.groupBox1.Controls.Add(this.cbosearchcriteria);
			this.groupBox1.Controls.Add(this.chkshowinactive);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(564, 89);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btnsearch
			// 
			this.btnsearch.BackColor = System.Drawing.SystemColors.Control;
			this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnsearch.ForeColor = System.Drawing.Color.Black;
			this.btnsearch.Image = ((System.Drawing.Image)(resources.GetObject("btnsearch.Image")));
			this.btnsearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnsearch.Location = new System.Drawing.Point(6, 50);
			this.btnsearch.Name = "btnsearch";
			this.btnsearch.Size = new System.Drawing.Size(79, 33);
			this.btnsearch.TabIndex = 9;
			this.btnsearch.Text = "search";
			this.btnsearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnsearch.UseVisualStyleBackColor = false;
			this.btnsearch.Click += new System.EventHandler(this.BtnsearchClick);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(107, 69);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(153, 20);
			this.textBox2.TabIndex = 8;
			// 
			// txtcropname
			// 
			this.txtcropname.Location = new System.Drawing.Point(107, 43);
			this.txtcropname.Name = "txtcropname";
			this.txtcropname.Size = new System.Drawing.Size(153, 20);
			this.txtcropname.TabIndex = 7;
			// 
			// cbosearchcriteria
			// 
			this.cbosearchcriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbosearchcriteria.FormattingEnabled = true;
			this.cbosearchcriteria.Location = new System.Drawing.Point(107, 16);
			this.cbosearchcriteria.Name = "cbosearchcriteria";
			this.cbosearchcriteria.Size = new System.Drawing.Size(153, 21);
			this.cbosearchcriteria.TabIndex = 6;
			this.cbosearchcriteria.SelectedIndexChanged += new System.EventHandler(this.CbosearchcriteriaSelectedIndexChanged);
			// 
			// chkshowinactive
			// 
			this.chkshowinactive.Dock = System.Windows.Forms.DockStyle.Right;
			this.chkshowinactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkshowinactive.Location = new System.Drawing.Point(457, 16);
			this.chkshowinactive.Name = "chkshowinactive";
			this.chkshowinactive.Size = new System.Drawing.Size(104, 70);
			this.chkshowinactive.TabIndex = 5;
			this.chkshowinactive.Text = "show inactive";
			this.chkshowinactive.UseVisualStyleBackColor = true;
			this.chkshowinactive.CheckedChanged += new System.EventHandler(this.ChkshowinactiveCheckedChanged);
			// 
			// btnclose
			// 
			this.btnclose.BackColor = System.Drawing.SystemColors.Control;
			this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnclose.ForeColor = System.Drawing.Color.Black;
			this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
			this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnclose.Location = new System.Drawing.Point(6, 12);
			this.btnclose.Name = "btnclose";
			this.btnclose.Size = new System.Drawing.Size(79, 33);
			this.btnclose.TabIndex = 4;
			this.btnclose.Text = "close";
			this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnclose.UseVisualStyleBackColor = false;
			this.btnclose.Click += new System.EventHandler(this.BtncloseClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtlog);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox2.Location = new System.Drawing.Point(0, 321);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(564, 94);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			// 
			// txtlog
			// 
			this.txtlog.BackColor = System.Drawing.Color.Black;
			this.txtlog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtlog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtlog.ForeColor = System.Drawing.Color.Lime;
			this.txtlog.Location = new System.Drawing.Point(3, 16);
			this.txtlog.Multiline = true;
			this.txtlog.Name = "txtlog";
			this.txtlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtlog.Size = new System.Drawing.Size(558, 75);
			this.txtlog.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.dataGridViewcrops);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(0, 89);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(564, 232);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
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
			this.dataGridViewcrops.Size = new System.Drawing.Size(558, 213);
			this.dataGridViewcrops.TabIndex = 1;
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
			// searchform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(564, 441);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "searchform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "search";
			this.Load += new System.EventHandler(this.SearchformLoad);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewcrops)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourcecrops)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txtcropname;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btnsearch;
		private System.Windows.Forms.ComboBox cbosearchcriteria;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.CheckBox chkshowinactive;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel lblstatus;
		private System.Windows.Forms.BindingSource bindingSourcecrops;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1createddate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnstatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
		private System.Windows.Forms.DataGridView dataGridViewcrops;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtlog;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.StatusStrip statusStrip1;
	}
}
