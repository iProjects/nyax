/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 21:36
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
	/// Description of createsettingform.
	/// </summary>
	public partial class createsettingform : Form
	{	
	public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname; 
		errordto _errordto=new errordto();
		
		public createsettingform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			TAG = this.GetType().Name;
			
			_notificationmessageEventname = notificationmessageEventname;
			_progressBarNotificationEventname = progressBarNotificationEventname;
			
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("initialized settingslistform", TAG));
		}
		
		void CreatesettingformLoad(object sender, EventArgs e)
		{
			 cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex=0;
			  
			 this.AcceptButton=btncreate;
			 this.CancelButton=btnclose;
			 
			 txtsettingname.Focus();
		}
		 
		void BtncreateClick(object sender, EventArgs e)
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtsettingname.Text)){
				_isuserdetailsvalid=false;
				_errormsg+= "setting name cannot be null.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("setting name cannot be null.", TAG));
			}  
			if(String.IsNullOrEmpty(txtsettingvalue.Text)){
				_isuserdetailsvalid=false;
				_errormsg+= Environment.NewLine+"setting value cannot be null.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("setting value cannot be null.", TAG));
			}  
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select status.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("select status.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _iscreatesettingsuccessful=createsettingindatabase();
			if(_iscreatesettingsuccessful){
			 
			this.Close(); 
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error);	 
				txtsettingname.Focus();
				_errordto.errormessage=_errormsg;			
			}
			
			}else{
				 msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtsettingname.Focus();
				_errordto.errormessage=_errormsg;
				 
			}
		}
		
		bool createsettingindatabase(){
			try{
			 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");

				settingdto _settingdto = new settingdto();
				_settingdto.setting_name = txtsettingname.Text; 
				_settingdto.setting_value = txtsettingvalue.Text; 
				_settingdto.setting_status = cbostatus.Text;
				_settingdto.created_date = dateTimeString; 
				  
				bool _exists_in_mssql = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifsettingexists(_settingdto.setting_name, DBContract.getdefaultmssqlconnectionstring());
				
				if(!_exists_in_mssql){
					saveinmssqldb(_settingdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("setting with name [ " + _settingdto.setting_name + " ] exists in " + DBContract.mssql + ".", TAG));
				}
				
				bool _exists_in_sqlite = sqliteapisingleton.getInstance(_notificationmessageEventname).checkifsettingexists(_settingdto.setting_name, DBContract.getdefaultsqliteconnectionstring());
				
				if(!_exists_in_sqlite){
					saveinsqlitedb(_settingdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("setting with name [ " + _settingdto.setting_name + " ] exists in " + DBContract.sqlite + ".", TAG));
				}
				
				bool _exists_in_mysql = mysqlapisingleton.getInstance(_notificationmessageEventname).checkifsettingexists(_settingdto.setting_name, DBContract.getdefaultmysqlconnectionstring());
				
				if(!_exists_in_mysql){
					saveinmysqldb(_settingdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("setting with name [ " + _settingdto.setting_name + " ] exists in " + DBContract.mysql + ".", TAG));
				}
				
				bool _exists_in_postgresql = postgresqlapisingleton.getInstance(_notificationmessageEventname).checkifsettingexists(_settingdto.setting_name, DBContract.getdefaultpostgresqlconnectionstring());
				
				if(!_exists_in_postgresql){
					saveinpostgresqldb(_settingdto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("setting with name [ " + _settingdto.setting_name + " ] exists in " + DBContract.postgresql + ".", TAG));
				}
				
				return true;
				 
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		void saveinmssqldb(settingdto _settingdto)
		{ 
			try{
				string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
				  
				bool _saveinmssql;
				bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
					
				if(_saveinmssql){
					bool numberOfRowsAffected = false;
				    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createsettingindatabase(_settingdto, DBContract.getdefaultmssqlconnectionstring());
				    if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created setting in mssql db { " +                                                                       Environment.NewLine + "setting name: " + _settingdto.setting_name + "," +
					Environment.NewLine + "setting value: " + _settingdto.setting_value + "," +
					Environment.NewLine + "status: " + _settingdto.setting_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinmysqldb(settingdto _settingdto)
		{ 
			try{
				string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
				
				bool _saveinmysql;
				bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
					
				if(_saveinmysql){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).createsettingindatabase(_settingdto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created setting in mysql db { " +                                                                       Environment.NewLine + "setting name: " + _settingdto.setting_name + "," +
					Environment.NewLine + "setting value: " + _settingdto.setting_value + "," +
					Environment.NewLine + "status: " + _settingdto.setting_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinsqlitedb(settingdto _settingdto)
		{ 
			try{
				string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
				
				bool _saveinsqlite;
				bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
					
				if(_saveinsqlite){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).createsettingindatabase(_settingdto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created setting in sqlite db { " +                                                                       Environment.NewLine + "setting name: " + _settingdto.setting_name + "," +
					Environment.NewLine + "setting value: " + _settingdto.setting_value + "," +
					Environment.NewLine + "status: " + _settingdto.setting_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinpostgresqldb(settingdto _settingdto)
		{ 
			try{
				string saveinpostgresql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinpostgresql", "false");
				
				bool _saveinpostgresql;
				bool _trysaveinpostgresql = bool.TryParse(saveinpostgresql, out _saveinpostgresql);
					
				if(_saveinpostgresql){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = postgresqlapisingleton.getInstance(_notificationmessageEventname).createsettingindatabase(_settingdto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created setting in postgresql db { " +                                                                       Environment.NewLine + "setting name: " + _settingdto.setting_name + "," +
					Environment.NewLine + "setting value: " + _settingdto.setting_value + "," +
					Environment.NewLine + "status: " + _settingdto.setting_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();			
		}
		
		
		
	}
}
