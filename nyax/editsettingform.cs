/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/14/2018
 * Time: 09:26
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
	/// Description of editsettingform.
	/// </summary>
	public partial class editsettingform : Form
	{
		public string TAG; 
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		public responsedto _responsedto = new responsedto();		
		public settingdto _settingdto;
		public settingslistform _settingslistform;
		 
		public editsettingform(settingdto settingdto, settingslistform settingslistform, EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			_settingdto = settingdto;
			_settingslistform = settingslistform;
				
			TAG = this.GetType().Name;
				
		    _notificationmessageEventname = notificationmessageEventname; 
			_progressBarNotificationEventname = progressBarNotificationEventname;
			 
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded editcropdiseaseform", TAG));
				
		}
		
		void populatecontrols(){
			txtsettingname.Text = _settingdto.setting_name;
			txtsettingvalue.Text = _settingdto.setting_value;
			cbostatus.SelectedValue = _settingdto.setting_status; 
		}
		
		void EditsettingformLoad(object sender, EventArgs e)
		{
			 cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex=0;
			 
			 this.AcceptButton = btnupdate;
			 this.CancelButton = btnclose;
			 txtsettingname.Focus();
			 
			populatecontrols();
		}
		 
		void BtncloseClick(object sender, EventArgs e)
		{
		   this.Close();	
		}
		
		void BtnupdateClick(object sender, EventArgs e)
		{
			if(validateuserinput()){
				_settingslistform.populatesettingslist();
				this.Close();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("record validation failed...", TAG));
			} 
		}
		
		bool validateuserinput()
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtsettingname.Text)){
				_isuserdetailsvalid=false;
				_errormsg+= "setting name cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("setting name cannot be null.", TAG));
			}  
			if(String.IsNullOrEmpty(txtsettingvalue.Text)){
				_isuserdetailsvalid=false;
				_errormsg+= Environment.NewLine+"setting value cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("setting value cannot be null.", TAG));
			}  
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"status cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("status cannot be null.", TAG));
			}
			
			if(_isuserdetailsvalid){
			bool _isupdaterecordsuccessful = updatesettingindatabase();
			if(_isupdaterecordsuccessful){
				_settingslistform.populatesettingslist();	
				this.Close();  
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtsettingname.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtsettingname.Focus();
			}
			return _isuserdetailsvalid;
		}
		 
		bool updatesettingindatabase(){
		try{
			 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
	 
				settingdto _setting_dto = new settingdto();
				_setting_dto.setting_id = _settingdto.setting_id; 
				_setting_dto.setting_name = txtsettingname.Text; 
				_setting_dto.setting_value = txtsettingvalue.Text; 
				_setting_dto.setting_status = cbostatus.Text;
				_setting_dto.created_date = dateTimeString; 
			 
				saveinmssqldb(_setting_dto);
				saveinsqlitedb(_setting_dto);
				saveinmysqldb(_setting_dto);
				  
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
				    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).updatesettingindatabase(_settingdto);
				    if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated setting in mssql db { " +                                                                       Environment.NewLine + "setting name: " + _settingdto.setting_name + "," +
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
				  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).updatesettingindatabase(_settingdto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated setting in mysql db { " +                                                                       Environment.NewLine + "setting name: " + _settingdto.setting_name + "," +
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
				  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).updatesettingindatabase(_settingdto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated setting in sqlite db { " +                                                                       Environment.NewLine + "setting name: " + _settingdto.setting_name + "," +
					Environment.NewLine + "setting value: " + _settingdto.setting_value + "," +
					Environment.NewLine + "status: " + _settingdto.setting_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		
		
		
		
	}
}
