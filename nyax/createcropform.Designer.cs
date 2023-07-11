/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/08/2018
 * Time: 10:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class createcropform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createcropform));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbostatus = new System.Windows.Forms.ComboBox();
			this.txtcropname = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btncreate = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cbostatus);
			this.groupBox1.Controls.Add(this.txtcropname);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(405, 101);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(50, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "status";
			// 
			// cbostatus
			// 
			this.cbostatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbostatus.FormattingEnabled = true;
			this.cbostatus.Location = new System.Drawing.Point(98, 66);
			this.cbostatus.Name = "cbostatus";
			this.cbostatus.Size = new System.Drawing.Size(265, 21);
			this.cbostatus.TabIndex = 2;
			// 
			// txtcropname
			// 
			this.txtcropname.Location = new System.Drawing.Point(98, 31);
			this.txtcropname.Name = "txtcropname";
			this.txtcropname.Size = new System.Drawing.Size(265, 20);
			this.txtcropname.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "crop name";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btncreate);
			this.groupBox2.Controls.Add(this.btnclose);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 101);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(405, 64);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// btncreate
			// 
			this.btncreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreate.ForeColor = System.Drawing.Color.Black;
			this.btncreate.Image = ((System.Drawing.Image)(resources.GetObject("btncreate.Image")));
			this.btncreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreate.Location = new System.Drawing.Point(140, 19);
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
			this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnclose.Location = new System.Drawing.Point(221, 19);
			this.btnclose.Name = "btnclose";
			this.btnclose.Size = new System.Drawing.Size(75, 35);
			this.btnclose.TabIndex = 1;
			this.btnclose.Text = "close";
			this.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnclose.UseVisualStyleBackColor = true;
			this.btnclose.Click += new System.EventHandler(this.BtncloseClick);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// createcropform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 165);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "createcropform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "create crop";
			this.Load += new System.EventHandler(this.CreatecropformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.ComboBox cbostatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button btncreate;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtcropname;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
