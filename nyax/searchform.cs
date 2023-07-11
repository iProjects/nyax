/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 01/17/2019
 * Time: 11:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using Npgsql;
using nthareneapi;
using SMOScripting;

namespace nyax
{
	/// <summary>
	/// Description of searchform.
	/// </summary>
	public partial class searchform : Form
	{
		public string TAG;
		public List<notificationdto> _lstnotificationdto = new List<notificationdto>();
		
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<notificationmessageEventArgs> _databaseutilsnotificationeventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		
		public searchform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			TAG = this.GetType().Name;
			 
			//Subscribing events:  
			_notificationmessageEventname = notificationmessageEventname;
			_progressBarNotificationEventname = progressBarNotificationEventname;
			_databaseutilsnotificationeventname += databaseutilsnotificationhandler;
			
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded searchform", TAG));
		}
		 
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void CbosearchcriteriaSelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void SearchformLoad(object sender, EventArgs e)
		{
			try{
				cbosearchcriteria.Items.AddRange(new [] {"crop", "disease/pest" });
				cbosearchcriteria.SelectedIndex=0;
				 
				 this.AcceptButton=btnsearch;
				 this.CancelButton=btnclose;
				 txtcropname.Focus();
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		//Event handler declaration:
		public void databaseutilsnotificationhandler(object sender, notificationmessageEventArgs args) 
		{ 
			notificationdto _notificationdto = new notificationdto();
	
		    DateTime currentDate = DateTime.Now; 
		    String dateTimenow = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
		    
			string message = args.message;		    
			String _logtext = Environment.NewLine + "[ " + dateTimenow + " ]   " + message;
			
			 _notificationdto._notification_message = _logtext;
			 _notificationdto._created_datetime = dateTimenow;
			 _notificationdto.TAG = TAG;
			 
			 _lstnotificationdto.Add(_notificationdto);
			 
			var _lstmsgdto = from msgdto in _lstnotificationdto
			orderby msgdto._created_datetime descending
			select msgdto._notification_message;
			  
		    String[] _logflippedlines = _lstmsgdto.ToArray();
				
			txtlog.Lines = _logflippedlines;
		
			this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(message, TAG)); 
		}

		//Event handler declaration:
		public void progressBarNotificationHandler(object sender, progressBarNotificationEventArgs args) {
		/* Handler logic */   
			toolStripProgressBar.Maximum = args.ProgressMaximum;
			
			if(args.ProgressPercentage == -1){ 
				toolStripProgressBar.Value = 0;
//				lblprogresscounta.Text = string.Empty;
			}else{ 
				Invoke(new Action(() => { 
              	toolStripProgressBar.PerformStep(); }));
			}
		}
	 
		void logtoutils(string message)
		{
			try{  
				this._databaseutilsnotificationeventname.Invoke(this, new notificationmessageEventArgs(message, TAG)); 	 
			}catch(Exception ex){ 
				logtoutils(ex.Message); 
			}	
		}
		
		void ChkshowinactiveCheckedChanged(object sender, EventArgs e)
		{
			
		}
		
		void BtnsearchClick(object sender, EventArgs e)
		{
			
		}
	}
}
