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
	partial class createsettingform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createsettingform));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtsettingvalue = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbostatus = new System.Windows.Forms.ComboBox();
			this.txtsettingname = new System.Windows.Forms.TextBox();
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
			this.groupBox1.Controls.Add(this.txtsettingvalue);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.cbostatus);
			this.groupBox1.Controls.Add(this.txtsettingname);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(357, 127);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// txtsettingvalue
			// 
			this.txtsettingvalue.Location = new System.Drawing.Point(102, 56);
			this.txtsettingvalue.Name = "txtsettingvalue";
			this.txtsettingvalue.Size = new System.Drawing.Size(193, 20);
			this.txtsettingvalue.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(22, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 20);
			this.label2.TabIndex = 23;
			this.label2.Text = "setting value";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(56, 94);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 21;
			this.label4.Text = "status";
			// 
			// cbostatus
			// 
			this.cbostatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbostatus.FormattingEnabled = true;
			this.cbostatus.Location = new System.Drawing.Point(102, 91);
			this.cbostatus.Name = "cbostatus";
			this.cbostatus.Size = new System.Drawing.Size(193, 21);
			this.cbostatus.TabIndex = 2;
			// 
			// txtsettingname
			// 
			this.txtsettingname.Location = new System.Drawing.Point(102, 19);
			this.txtsettingname.Name = "txtsettingname";
			this.txtsettingname.Size = new System.Drawing.Size(193, 20);
			this.txtsettingname.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(22, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 20);
			this.label1.TabIndex = 20;
			this.label1.Text = "setting name";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btncreate);
			this.groupBox2.Controls.Add(this.btnclose);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 127);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(357, 64);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// btncreate
			// 
			this.btncreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreate.ForeColor = System.Drawing.Color.Black;
			this.btncreate.Image = ((System.Drawing.Image)(resources.GetObject("btncreate.Image")));
			this.btncreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreate.Location = new System.Drawing.Point(104, 17);
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
			this.btnclose.Location = new System.Drawing.Point(194, 17);
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
			// createsettingform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(357, 191);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "createsettingform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "create setting";
			this.Load += new System.EventHandler(this.CreatesettingformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtsettingvalue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtsettingname;
		private System.Windows.Forms.ComboBox cbostatus;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button btncreate;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
