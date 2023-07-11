/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/14/2018
 * Time: 09:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class editpestinsecticideform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editpestinsecticideform));
			this.label4 = new System.Windows.Forms.Label();
			this.cbocategory = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbomanufacturer = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnupdate = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cbostatus = new System.Windows.Forms.ComboBox();
			this.txtpestinsecticidename = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbodiseasespests = new System.Windows.Forms.ComboBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(107, 157);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 17;
			this.label4.Text = "status";
			// 
			// cbocategory
			// 
			this.cbocategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbocategory.FormattingEnabled = true;
			this.cbocategory.Location = new System.Drawing.Point(153, 56);
			this.cbocategory.Name = "cbocategory";
			this.cbocategory.Size = new System.Drawing.Size(216, 21);
			this.cbocategory.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(72, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 23);
			this.label2.TabIndex = 15;
			this.label2.Text = "manufacturer";
			// 
			// cbomanufacturer
			// 
			this.cbomanufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbomanufacturer.FormattingEnabled = true;
			this.cbomanufacturer.Location = new System.Drawing.Point(153, 92);
			this.cbomanufacturer.Name = "cbomanufacturer";
			this.cbomanufacturer.Size = new System.Drawing.Size(216, 21);
			this.cbomanufacturer.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnupdate);
			this.groupBox1.Controls.Add(this.btnclose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 186);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(415, 58);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btnupdate
			// 
			this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnupdate.ForeColor = System.Drawing.Color.Black;
			this.btnupdate.Image = ((System.Drawing.Image)(resources.GetObject("btnupdate.Image")));
			this.btnupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnupdate.Location = new System.Drawing.Point(176, 17);
			this.btnupdate.Name = "btnupdate";
			this.btnupdate.Size = new System.Drawing.Size(75, 35);
			this.btnupdate.TabIndex = 0;
			this.btnupdate.Text = "update";
			this.btnupdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnupdate.UseVisualStyleBackColor = true;
			this.btnupdate.Click += new System.EventHandler(this.BtnupdateClick);
			// 
			// btnclose
			// 
			this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnclose.ForeColor = System.Drawing.Color.Black;
			this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
			this.btnclose.Location = new System.Drawing.Point(266, 17);
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
			this.label3.Location = new System.Drawing.Point(96, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 23);
			this.label3.TabIndex = 13;
			this.label3.Text = "category";
			// 
			// cbostatus
			// 
			this.cbostatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbostatus.FormattingEnabled = true;
			this.cbostatus.Location = new System.Drawing.Point(153, 157);
			this.cbostatus.Name = "cbostatus";
			this.cbostatus.Size = new System.Drawing.Size(216, 21);
			this.cbostatus.TabIndex = 3;
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
			this.label1.Location = new System.Drawing.Point(11, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 20);
			this.label1.TabIndex = 12;
			this.label1.Text = "pesticide/insecticide name";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.cbodiseasespests);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.cbocategory);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.cbomanufacturer);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cbostatus);
			this.groupBox2.Controls.Add(this.txtpestinsecticidename);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(415, 244);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(72, 124);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 23);
			this.label5.TabIndex = 21;
			this.label5.Text = "disease/pest";
			// 
			// cbodiseasespests
			// 
			this.cbodiseasespests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbodiseasespests.FormattingEnabled = true;
			this.cbodiseasespests.Location = new System.Drawing.Point(153, 124);
			this.cbodiseasespests.Name = "cbodiseasespests";
			this.cbodiseasespests.Size = new System.Drawing.Size(216, 21);
			this.cbodiseasespests.TabIndex = 20;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// editpestinsecticideform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(415, 244);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "editpestinsecticideform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "edit pesticide/insecticide";
			this.Load += new System.EventHandler(this.EditpestinsecticideformLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox cbodiseasespests;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtpestinsecticidename;
		private System.Windows.Forms.ComboBox cbostatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button btnupdate;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cbomanufacturer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbocategory;
		private System.Windows.Forms.Label label4;
	}
}
