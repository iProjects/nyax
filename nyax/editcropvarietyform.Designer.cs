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
	partial class editcropvarietyform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editcropvarietyform));
			this.btnupdate = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnclose = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cbostatus = new System.Windows.Forms.ComboBox();
			this.txtcropvarietyname = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.cbomanufacturers = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbocrops = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// btnupdate
			// 
			this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnupdate.ForeColor = System.Drawing.Color.Black;
			this.btnupdate.Image = ((System.Drawing.Image)(resources.GetObject("btnupdate.Image")));
			this.btnupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnupdate.Location = new System.Drawing.Point(118, 17);
			this.btnupdate.Name = "btnupdate";
			this.btnupdate.Size = new System.Drawing.Size(75, 35);
			this.btnupdate.TabIndex = 0;
			this.btnupdate.Text = "update";
			this.btnupdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnupdate.UseVisualStyleBackColor = true;
			this.btnupdate.Click += new System.EventHandler(this.BtnupdateClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnupdate);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 164);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(355, 58);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btnclose
			// 
			this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnclose.ForeColor = System.Drawing.Color.Black;
			this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
			this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnclose.Location = new System.Drawing.Point(199, 17);
			this.btnclose.Name = "btnclose";
			this.btnclose.Size = new System.Drawing.Size(75, 35);
			this.btnclose.TabIndex = 1;
			this.btnclose.Text = "close";
			this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnclose.UseVisualStyleBackColor = true;
			this.btnclose.Click += new System.EventHandler(this.BtncloseClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(57, 126);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 13;
			this.label3.Text = "status";
			// 
			// cbostatus
			// 
			this.cbostatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbostatus.FormattingEnabled = true;
			this.cbostatus.Location = new System.Drawing.Point(103, 128);
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
			this.groupBox2.Size = new System.Drawing.Size(355, 222);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(21, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 23);
			this.label1.TabIndex = 12;
			this.label1.Text = "variety name";
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(27, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 23);
			this.label4.TabIndex = 21;
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
			this.label2.TabIndex = 20;
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
			// editcropvarietyform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 222);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "editcropvarietyform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "edit crop variety";
			this.Load += new System.EventHandler(this.EditcropvarietyformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox cbocrops;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbomanufacturers;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtcropvarietyname;
		private System.Windows.Forms.ComboBox cbostatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnupdate;
	}
}
