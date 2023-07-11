/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 06:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class aboutform
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aboutform));
			this.lblcopyright = new System.Windows.Forms.Label();
			this.lblcompanyname = new System.Windows.Forms.Label();
			this.lblproductname = new System.Windows.Forms.Label();
			this.lblversion = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblcopyright
			// 
			this.lblcopyright.ForeColor = System.Drawing.Color.Lime;
			this.lblcopyright.Location = new System.Drawing.Point(12, 141);
			this.lblcopyright.Name = "lblcopyright";
			this.lblcopyright.Size = new System.Drawing.Size(250, 26);
			this.lblcopyright.TabIndex = 0;
			this.lblcopyright.Text = "copyright";
			// 
			// lblcompanyname
			// 
			this.lblcompanyname.ForeColor = System.Drawing.Color.Lime;
			this.lblcompanyname.Location = new System.Drawing.Point(12, 102);
			this.lblcompanyname.Name = "lblcompanyname";
			this.lblcompanyname.Size = new System.Drawing.Size(250, 26);
			this.lblcompanyname.TabIndex = 1;
			this.lblcompanyname.Text = "company name";
			// 
			// lblproductname
			// 
			this.lblproductname.ForeColor = System.Drawing.Color.Lime;
			this.lblproductname.Location = new System.Drawing.Point(12, 23);
			this.lblproductname.Name = "lblproductname";
			this.lblproductname.Size = new System.Drawing.Size(250, 26);
			this.lblproductname.TabIndex = 3;
			this.lblproductname.Text = "product name";
			// 
			// lblversion
			// 
			this.lblversion.ForeColor = System.Drawing.Color.Lime;
			this.lblversion.Location = new System.Drawing.Point(12, 59);
			this.lblversion.Name = "lblversion";
			this.lblversion.Size = new System.Drawing.Size(250, 26);
			this.lblversion.TabIndex = 2;
			this.lblversion.Text = "version";
			// 
			// aboutform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.lblproductname);
			this.Controls.Add(this.lblversion);
			this.Controls.Add(this.lblcompanyname);
			this.Controls.Add(this.lblcopyright);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "aboutform";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "about";
			this.Load += new System.EventHandler(this.AboutformLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblversion;
		private System.Windows.Forms.Label lblproductname;
		private System.Windows.Forms.Label lblcompanyname;
		private System.Windows.Forms.Label lblcopyright;
	}
}
