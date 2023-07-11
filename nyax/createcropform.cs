/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/08/2018
 * Time: 10:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using nthareneapi;

namespace nyax
{
	/// <summary>
	/// Description of createcrop.
	/// </summary>
	public partial class createcropform : Form
	{ 	
		public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		
		public createcropform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			TAG = this.GetType().Name;
			 
			_progressBarNotificationEventname = progressBarNotificationEventname; 
			_notificationmessageEventname = notificationmessageEventname;
			
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded createcropform", TAG));
				
		}
		
		void BtncreateClick(object sender, EventArgs e)
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtcropname.Text)){
				_isuserdetailsvalid=false;
				_errormsg+="crop name cannot be null.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("crop name cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select status.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("select status.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _iscreatecropsuccessful = createcropindatabase();
			if(_iscreatecropsuccessful){ 
				
				this.Close();
				
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error);
				txtcropname.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtcropname.Focus();
			}
		}
		
		bool createcropindatabase(){
			try{
				DateTime currentDate = DateTime.Now; 
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
				
				cropdto _cropdto = new cropdto();
				_cropdto.crop_name = txtcropname.Text; 
				_cropdto.crop_status = cbostatus.Text;
				_cropdto.created_date = dateTimeString; 
				
				bool _exists_in_mssql = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifcropexists(_cropdto.crop_name, DBContract.getdefaultmssqlconnectionstring());
				
				if(!_exists_in_mssql){
					saveinmssqldb(_cropdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("crop with name [ " + _cropdto.crop_name + " ] exists in " + DBContract.mssql + ".", TAG));
				}
				
				bool _exists_in_sqlite = sqliteapisingleton.getInstance(_notificationmessageEventname).checkifcropexists(_cropdto.crop_name, DBContract.getdefaultsqliteconnectionstring());
				
				if(!_exists_in_sqlite){
					saveinsqlitedb(_cropdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("crop with name [ " + _cropdto.crop_name + " ] exists in " + DBContract.sqlite + ".", TAG));
				}
				
				bool _exists_in_mysql = mysqlapisingleton.getInstance(_notificationmessageEventname).checkifcropexists(_cropdto.crop_name, DBContract.getdefaultmysqlconnectionstring());
				
				if(!_exists_in_mysql){
					saveinmysqldb(_cropdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("crop with name [ " + _cropdto.crop_name + " ] exists in " + DBContract.mysql + ".", TAG));
				}
				
				bool _exists_in_postgresql = postgresqlapisingleton.getInstance(_notificationmessageEventname).checkifcropexists(_cropdto.crop_name, DBContract.getdefaultpostgresqlconnectionstring());
				
				if(!_exists_in_postgresql){
					saveinpostgresqldb(_cropdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("crop with name [ " + _cropdto.crop_name + " ] exists in " + DBContract.postgresql + ".", TAG));
				}
				
				return true; 
				
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return false;
			}
		}
		 
		void saveinmssqldb(cropdto _cropdto)
		{ 
			string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
			  
			bool _saveinmssql;
			bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
				
			if(_saveinmssql){
				bool numberOfRowsAffected = false;
			    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropindatabase(_cropdto, DBContract.getdefaultmssqlconnectionstring());			    
			    if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created crop in mssql db { " +
 				Environment.NewLine + "crop name: " + _cropdto.crop_name + ","+ 
				Environment.NewLine + "status: " + _cropdto.crop_status + " }.", TAG));
			    }
			}
		}
		
		void saveinmysqldb(cropdto _cropdto)
		{ 
			string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
			
			bool _saveinmysql;
			bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
				
			if(_saveinmysql){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).createcropindatabase(_cropdto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created crop in mysql db { " +
 				Environment.NewLine + "crop name: " + _cropdto.crop_name + ","+ 
				Environment.NewLine + "status: " + _cropdto.crop_status + " }.", TAG));
			    }
			}
		}
		
		void saveinsqlitedb(cropdto _cropdto)
		{ 
			string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
			
			bool _saveinsqlite;
			bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
				
			if(_saveinsqlite){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).createcropindatabase(_cropdto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created crop in sqlite db { " +
 				Environment.NewLine + "crop name: " + _cropdto.crop_name + ","+ 
				Environment.NewLine + "status: " + _cropdto.crop_status + " }.", TAG));
			    }
			}
		}
		
		void saveinpostgresqldb(cropdto _cropdto)
		{ 
			string saveinpostgresql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinpostgresql", "false");
			
			bool _saveinpostgresql;
			bool _trysaveinpostgresql = bool.TryParse(saveinpostgresql, out _saveinpostgresql);
				
			if(_saveinpostgresql){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = postgresqlapisingleton.getInstance(_notificationmessageEventname).createcropindatabase(_cropdto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created crop in postgresql db { " +
 				Environment.NewLine + "crop name: " + _cropdto.crop_name + ","+ 
				Environment.NewLine + "status: " + _cropdto.crop_status + " }.", TAG));
			    }
			}
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close(); 
		}
		
		void CreatecropformLoad(object sender, EventArgs e)
		{  
			cbostatus.Items.AddRange(new [] {"active", "inactive" });
			cbostatus.SelectedIndex=0;
			 
			 this.AcceptButton=btncreate;
			 this.CancelButton=btnclose;
			 txtcropname.Focus();
		}
		
	}
}
