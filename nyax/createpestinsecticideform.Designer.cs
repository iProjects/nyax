/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 07:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class createpestinsecticideform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createpestinsecticideform));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btncreate = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbodiseasespests = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbocategory = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbomanufacturers = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbostatus = new System.Windows.Forms.ComboBox();
			this.txtpestinsecticidename = new System.Windows.Forms.TextBox();
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
			this.groupBox1.Location = new System.Drawing.Point(0, 203);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(390, 58);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btncreate
			// 
			this.btncreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btncreate.ForeColor = System.Drawing.Color.Black;
			this.btncreate.Image = ((System.Drawing.Image)(resources.GetObject("btncreate.Image")));
			this.btncreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btncreate.Location = new System.Drawing.Point(141, 10);
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
			this.btnclose.Location = new System.Drawing.Point(231, 10);
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
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.cbodiseasespests);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.cbocategory);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.cbomanufacturers);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cbostatus);
			this.groupBox2.Controls.Add(this.txtpestinsecticidename);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(390, 203);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(71, 127);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 23);
			this.label5.TabIndex = 19;
			this.label5.Text = "disease/pest";
			// 
			// cbodiseasespests
			// 
			this.cbodiseasespests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbodiseasespests.FormattingEnabled = true;
			this.cbodiseasespests.Location = new System.Drawing.Point(153, 127);
			this.cbodiseasespests.Name = "cbodiseasespests";
			this.cbodiseasespests.Size = new System.Drawing.Size(216, 21);
			this.cbodiseasespests.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(107, 160);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 17;
			this.label4.Text = "status";
			// 
			// cbocategory
			// 
			this.cbocategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbocategory.FormattingEnabled = true;
			this.cbocategory.Location = new System.Drawing.Point(153, 60);
			this.cbocategory.Name = "cbocategory";
			this.cbocategory.Size = new System.Drawing.Size(216, 21);
			this.cbocategory.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(71, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 23);
			this.label2.TabIndex = 15;
			this.label2.Text = "manufacturer";
			// 
			// cbomanufacturers
			// 
			this.cbomanufacturers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbomanufacturers.FormattingEnabled = true;
			this.cbomanufacturers.Location = new System.Drawing.Point(153, 97);
			this.cbomanufacturers.Name = "cbomanufacturers";
			this.cbomanufacturers.Size = new System.Drawing.Size(216, 21);
			this.cbomanufacturers.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(90, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 23);
			this.label3.TabIndex = 13;
			this.label3.Text = "category";
			// 
			// cbostatus
			// 
			this.cbostatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbostatus.FormattingEnabled = true;
			this.cbostatus.Location = new System.Drawing.Point(153, 160);
			this.cbostatus.Name = "cbostatus";
			this.cbostatus.Size = new System.Drawing.Size(216, 21);
			this.cbostatus.TabIndex = 4;
			// 
			// txtpestinsecticidename
			// 
			this.txtpestinsecticidename.Location = new System.Drawing.Point(153, 22);
			this.txtpestinsecticidename.Name = "txtpestinsecticidename";
			this.txtpestinsecticidename.Size = new System.Drawing.Size(216, 20);
			this.txtpestinsecticidename.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 20);
			this.label1.TabIndex = 12;
			this.label1.Text = "pesticide/insecticide name";
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// createpestinsecticideform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(390, 261);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "createpestinsecticideform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "create pesticide/insecticide";
			this.Load += new System.EventHandler(this.CreatepestinsecticideformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox cbodiseasespests;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.ComboBox cbocategory;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtpestinsecticidename;
		private System.Windows.Forms.ComboBox cbostatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbomanufacturers;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button btncreate;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
