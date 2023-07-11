/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 06:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using nthareneapi;

namespace nyax
{
	/// <summary>
	/// Description of about.
	/// </summary>
	public partial class aboutform : Form
	{	
	public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		
		public aboutform(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			TAG = this.GetType().Name;
			
			_notificationmessageEventname=notificationmessageEventname;
				
			_notificationmessageEventname=notificationmessageEventname;
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded aboutform", TAG));
				
		}
		
		void AboutformLoad(object sender, EventArgs e)
		{
			lblcopyright.Text = "copyright @ " + DateTime.Now.Year; 
			lblversion.Text = "Product Version " + Application.ProductVersion;
			lblcompanyname.Text = "Company Name " + Application.CompanyName;
			lblproductname.Text = "Product Name " + Application.ProductName;
		}
	}
}
