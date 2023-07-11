/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 16:40
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
	/// Description of createmanufacturerform.
	/// </summary>
	public partial class createmanufacturerform : Form
	{	
		public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname; 
		
		public createmanufacturerform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
			_progressBarNotificationEventname = progressBarNotificationEventname;
			
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded createmanufacturerform", TAG));
			
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void BtncreateClick(object sender, EventArgs e)
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtmanufacturername.Text)){
				_isuserdetailsvalid=false;
				_errormsg+="manufacturer name cannot be null.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("manufacturer name cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select status.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("select status.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _iscreatemanufacturersuccessful=createmanufacturerindatabase();
			if(_iscreatemanufacturersuccessful){
				
			this.Close(); 
			
			}else{
				msgboxform.Show(_errormsg, TAG,msgtype.error); 
				txtmanufacturername.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtmanufacturername.Focus();
			}
		}
		
		void CreatemanufacturerformLoad(object sender, EventArgs e)
		{
			cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex=0;
			 
			 this.AcceptButton=btncreate;
			 this.CancelButton=btnclose;
			 txtmanufacturername.Focus();
		}
		
		
		bool createmanufacturerindatabase(){
			try{
			 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
			
			    manufacturerdto _manufacturerdto = new manufacturerdto();
				_manufacturerdto.manufacturer_name = txtmanufacturername.Text; 
			    _manufacturerdto.manufacturer_status = cbostatus.Text;
			    _manufacturerdto.created_date = dateTimeString; 
					
				bool _exists_in_mssql = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifmanufacturerexists(_manufacturerdto.manufacturer_name, DBContract.getdefaultmssqlconnectionstring());
				
				if(!_exists_in_mssql){
					saveinmssqldb(_manufacturerdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("manufacturer with name [ " + _manufacturerdto.manufacturer_name + " ] exists in " + DBContract.mssql + ".", TAG));
				}
				
				bool _exists_in_sqlite = sqliteapisingleton.getInstance(_notificationmessageEventname).checkifmanufacturerexists(_manufacturerdto.manufacturer_name, DBContract.getdefaultsqliteconnectionstring());
				
				if(!_exists_in_sqlite){
					saveinsqlitedb(_manufacturerdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("manufacturer with name [ " + _manufacturerdto.manufacturer_name + " ] exists in " + DBContract.sqlite + ".", TAG));
				}
				
				bool _exists_in_mysql = mysqlapisingleton.getInstance(_notificationmessageEventname).checkifmanufacturerexists(_manufacturerdto.manufacturer_name, DBContract.getdefaultmysqlconnectionstring());
				
				if(!_exists_in_mysql){
					saveinmysqldb(_manufacturerdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("manufacturer with name [ " + _manufacturerdto.manufacturer_name + " ] exists in " + DBContract.mysql + ".", TAG));
				}
				
				bool _exists_in_postgresql = postgresqlapisingleton.getInstance(_notificationmessageEventname).checkifmanufacturerexists(_manufacturerdto.manufacturer_name, DBContract.getdefaultpostgresqlconnectionstring());
				
				if(!_exists_in_postgresql){
					saveinpostgresqldb(_manufacturerdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("manufacturer with name [ " + _manufacturerdto.manufacturer_name + " ] exists in " + DBContract.postgresql + ".", TAG));
				}
				
				return true; 
				
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		void saveinmssqldb(manufacturerdto _manufacturerdto)
		{ 
			string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
			  
			bool _saveinmssql;
			bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
				
			if(_saveinmssql){
				bool numberOfRowsAffected = false;
			    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createmanufacturerindatabase(_manufacturerdto, DBContract.getdefaultmssqlconnectionstring());
			    if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created manufacturer in mssql db { " +                                                                      Environment.NewLine + "manufacturer name: " + _manufacturerdto.manufacturer_name + "," +
				Environment.NewLine + "status: " + _manufacturerdto.manufacturer_status + " }.", TAG));
			    }
			}
		}
		
		void saveinmysqldb(manufacturerdto _manufacturerdto)
		{ 
			string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
			
			bool _saveinmysql;
			bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
				
			if(_saveinmysql){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).createmanufacturerindatabase(_manufacturerdto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created manufacturer in mysql db { " +                                                                      Environment.NewLine + "manufacturer name: " + _manufacturerdto.manufacturer_name + "," +
				Environment.NewLine + "status: " + _manufacturerdto.manufacturer_status + " }.", TAG));
			    }
			}
		}
		
		void saveinsqlitedb(manufacturerdto _manufacturerdto)
		{ 
			string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
			
			bool _saveinsqlite;
			bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
				
			if(_saveinsqlite){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).createmanufacturerindatabase(_manufacturerdto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created manufacturer in sqlite db { " +                                                                      Environment.NewLine + "manufacturer name: " + _manufacturerdto.manufacturer_name + "," +
				Environment.NewLine + "status: " + _manufacturerdto.manufacturer_status + " }.", TAG));
			    }
			}
		}
		
		void saveinpostgresqldb(manufacturerdto _manufacturerdto)
		{ 
			string saveinpostgresql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinpostgresql", "false");
			
			bool _saveinpostgresql;
			bool _trysaveinpostgresql = bool.TryParse(saveinpostgresql, out _saveinpostgresql);
				
			if(_saveinpostgresql){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = postgresqlapisingleton.getInstance(_notificationmessageEventname).createmanufacturerindatabase(_manufacturerdto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created manufacturer in postgresql db { " +                                                                      Environment.NewLine + "manufacturer name: " + _manufacturerdto.manufacturer_name + "," +
				Environment.NewLine + "status: " + _manufacturerdto.manufacturer_status + " }.", TAG));
			    }
			}
		}
		
		
		
	}
}
