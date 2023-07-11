/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 10/23/2018
 * Time: 20:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class createcropvarietyform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createcropvarietyform));
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbomanufacturers = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbocrops = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbostatus = new System.Windows.Forms.ComboBox();
			this.txtcropvarietyname = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnclose = new System.Windows.Forms.Button();
			this.btncreate = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.cbomanufacturers);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.cbocrops);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cbostatus);
			this.groupBox2.Controls.Add(this.txtcropvarietyname);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(355, 166);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(27, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 23);
			this.label4.TabIndex = 17;
			this.label4.Text = "manufacturer";
			// 
			// cbomanufacturers
			// 
			this.cbomanufacturers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbomanufacturers.FormattingEnabled = true;
			this.cbomanufacturers.Location = new System.Drawing.Point(103, 90);
			this.cbomanufacturers.Name = "cbomanufacturers";
			this.cbomanufacturers.Size = new System.Drawing.Size(216, 21);
			this.cbomanufacturers.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(62, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 15;
			this.label2.Text = "crop";
			// 
			// cbocrops
			// 
			this.cbocrops.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbocrops.FormattingEnabled = true;
			this.cbocrops.Location = new System.Drawing.Point(103, 55);
			this.cbocrops.Name = "cbocrops";
			this.cbocrops.Size = new System.Drawing.Size(216, 21);
			this.cbocrops.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(61, 123);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 13;
			this.label3.Text = "status";
			// 
			// cbostatus
			// 
			this.cbostatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbostatus.FormattingEnabled = true;
			this.cbostatus.Location = new System.Drawing.Point(103, 125);
			this.cbostatus.Name = "cbostatus";
			this.cbostatus.Size = new System.Drawing.Size(216, 21);
			this.cbostatus.TabIndex = 3;
			// 
			// txtcropvarietyname
			// 
			this.txtcropvarietyname.Location = new System.Drawing.Point(103, 19);
			this.txtcropvarietyname.Name = "txtcropvarietyname";
			this.txtcropvarietyname.Size = new System.Drawing.Size(216, 20);
			this.txtcropvarietyname.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(31, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 23);
			this.label1.TabIndex = 12;
			this.label1.Text = "variety name";
			// 
			// btnclose
			// 
			this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnclose.ForeColor = System.Drawing.Color.Black;
			this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
			this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnclose.Location = new System.Drawing.Point(200, 13);
			this.btnclose.Name = "btnclose";
			this.btnclose.Size = new System.Drawing.Size(75, 35);
			this.btnclose.TabIndex = 1;
			this.btnclose.Text = "close";
			this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnclose.UseVisualStyleBackColor = true;
			this.btnclose.Click += new System.EventHandler(this.BtncloseClick);
			// 
			// btncreate
			// 
			this.btncreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreate.ForeColor = System.Drawing.Color.Black;
			this.btncreate.Image = ((System.Drawing.Image)(resources.GetObject("btncreate.Image")));
			this.btncreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreate.Location = new System.Drawing.Point(119, 13);
			this.btncreate.Name = "btncreate";
			this.btncreate.Size = new System.Drawing.Size(75, 35);
			this.btncreate.TabIndex = 0;
			this.btncreate.Text = "create";
			this.btncreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncreate.UseVisualStyleBackColor = true;
			this.btncreate.Click += new System.EventHandler(this.BtncreateClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btncreate);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 166);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(355, 56);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// createcropvarietyform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 222);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "createcropvarietyform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "create variety";
			this.Load += new System.EventHandler(this.CreatecropvarietyformLoad);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox cbocrops;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbomanufacturers;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btncreate;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtcropvarietyname;
		private System.Windows.Forms.ComboBox cbostatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}
