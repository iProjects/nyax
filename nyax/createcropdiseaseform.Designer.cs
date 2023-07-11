/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 21:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class createcropdiseaseform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createcropdiseaseform));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btncreate = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbocategory = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbostatus = new System.Windows.Forms.ComboBox();
			this.txtdiseasename = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btncreate);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 145);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(413, 53);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btncreate
			// 
			this.btncreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreate.ForeColor = System.Drawing.Color.Black;
			this.btncreate.Image = ((System.Drawing.Image)(resources.GetObject("btncreate.Image")));
			this.btncreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreate.Location = new System.Drawing.Point(149, 13);
			this.btncreate.Name = "btncreate";
			this.btncreate.Size = new System.Drawing.Size(75, 35);
			this.btncreate.TabIndex = 0;
			this.btncreate.Text = "create";
			this.btncreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btncreate.UseVisualStyleBackColor = true;
			this.btncreate.Click += new System.EventHandler(this.BtncreateClick);
			// 
			// btnclose
			// 
			this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnclose.ForeColor = System.Drawing.Color.Black;
			this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
			this.btnclose.Location = new System.Drawing.Point(228, 13);
			this.btnclose.Name = "btnclose";
			this.btnclose.Size = new System.Drawing.Size(75, 35);
			this.btnclose.TabIndex = 1;
			this.btnclose.Text = "close";
			this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnclose.UseVisualStyleBackColor = true;
			this.btnclose.Click += new System.EventHandler(this.BtncloseClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.cbocategory);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cbostatus);
			this.groupBox2.Controls.Add(this.txtdiseasename);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(413, 145);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(63, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 23);
			this.label2.TabIndex = 11;
			this.label2.Text = "category";
			// 
			// cbocategory
			// 
			this.cbocategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbocategory.FormattingEnabled = true;
			this.cbocategory.Location = new System.Drawing.Point(122, 61);
			this.cbocategory.Name = "cbocategory";
			this.cbocategory.Size = new System.Drawing.Size(248, 21);
			this.cbocategory.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(76, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 9;
			this.label3.Text = "status";
			// 
			// cbostatus
			// 
			this.cbostatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbostatus.FormattingEnabled = true;
			this.cbostatus.Location = new System.Drawing.Point(122, 101);
			this.cbostatus.Name = "cbostatus";
			this.cbostatus.Size = new System.Drawing.Size(248, 21);
			this.cbostatus.TabIndex = 2;
			// 
			// txtdiseasename
			// 
			this.txtdiseasename.Location = new System.Drawing.Point(122, 20);
			this.txtdiseasename.Name = "txtdiseasename";
			this.txtdiseasename.Size = new System.Drawing.Size(248, 20);
			this.txtdiseasename.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(19, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "disease/pest name";
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// createcropdiseaseform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(413, 198);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "createcropdiseaseform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "create disease/pest";
			this.Load += new System.EventHandler(this.CreatecropdiseaseformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.ComboBox cbocategory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button btncreate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtdiseasename;
		private System.Windows.Forms.ComboBox cbostatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
