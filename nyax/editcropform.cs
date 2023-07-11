/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/14/2018
 * Time: 09:25
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
	/// Description of editcropform.
	/// </summary>
	public partial class editcropform : Form
	{
		public string TAG; 
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		public responsedto _responsedto = new responsedto();
		public cropdto _cropdto;
		public cropslistform _cropslistform;
		string _working_db = "";
		
		public editcropform(cropdto cropdto, cropslistform cropslistform, EventHandler<notificationmessageEventArgs> notificationmessageEventname, string working_db, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			_working_db = working_db;
			_cropdto = cropdto;
			_cropslistform = cropslistform;
			
			TAG = this.GetType().Name;
				
		    _notificationmessageEventname = notificationmessageEventname;
		    _progressBarNotificationEventname = progressBarNotificationEventname;
			 
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded editcropform", TAG));
					
		}
		
		void populatecontrols(){
			txtcropname.Text = _cropdto.crop_name; 
			cbostatus.SelectedValue = _cropdto.crop_status; 
		}
		
		void EditcropformLoad(object sender, EventArgs e)
		{
			 cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex=0;
			 
			 this.AcceptButton = btnupdate;
			 this.CancelButton = btnclose;
			 txtcropname.Focus();
			 
			populatecontrols();
		}
		 
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();	
		}
		
		void BtnupdateClick(object sender, EventArgs e)
		{
			if(validateuserinput()){
				_cropslistform.populatecropslist();
				this.Close();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("record validation failed...", TAG));
			}
			  	
		}
		 
		bool validateuserinput()
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtcropname.Text)){
				_isuserdetailsvalid=false;
				_errormsg+="crop name cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("crop name cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"status cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("status cannot be null.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _isupdaterecordsuccessful = updatecropdiseaseindatabase();
			if(_isupdaterecordsuccessful){
				_cropslistform.populatecropslist();
				this.Close();
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtcropname.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error);	 
				txtcropname.Focus();
			}
			return _isuserdetailsvalid;
		}
		 
		bool updatecropdiseaseindatabase(){
		try{
		 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
	 
				cropdto _crop_dto = new cropdto();
				_crop_dto.crop_id = _cropdto.crop_id; 
				_crop_dto.crop_name = txtcropname.Text;  
				_crop_dto.crop_status = cbostatus.Text;
				_crop_dto.created_date = dateTimeString; 
			  
				saveinmssqldb(_crop_dto);
				saveinsqlitedb(_crop_dto);
				saveinmysqldb(_crop_dto);
				  
				return true; 
					
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		void saveinmssqldb(cropdto _cropdto)
		{ 
			try{
				string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
				  
				bool _saveinmssql;
				bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
					
				if(_saveinmssql){
					bool numberOfRowsAffected = false;
				    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).updatecropindatabase(_cropdto);
				    if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated crop in mssql db { " +                                                                       Environment.NewLine + "crop name: " + _cropdto.crop_name + ","+ 
					Environment.NewLine + "status: " + _cropdto.crop_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinmysqldb(cropdto _cropdto_from_ui)
		{ 
			try{
				string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
				
				bool _saveinmysql;
				bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
					
				if(_saveinmysql){
					bool numberOfRowsAffected = false;
					
					if(_working_db != DBContract.mysql){
					cropdto _crop_dto_from_db = mysqlapisingleton.getInstance(_notificationmessageEventname).getcropbyname(_cropdto.crop_name); 
					if(_crop_dto_from_db == null)return;
					_cropdto_from_ui.crop_id = _crop_dto_from_db.crop_id;
					}
					
				  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).updatecropindatabase(_cropdto_from_ui);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated crop in mysql db { " +                                                                       Environment.NewLine + "crop name: " + _cropdto_from_ui.crop_name + ","+ 
					Environment.NewLine + "status: " + _cropdto_from_ui.crop_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinsqlitedb(cropdto _cropdto_from_ui)
		{ 
			try{
				string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
				
				bool _saveinsqlite;
				bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
					
				if(_saveinsqlite){
					bool numberOfRowsAffected = false;
					
					if(_working_db != DBContract.sqlite){
					cropdto _crop_dto_from_db = sqliteapisingleton.getInstance(_notificationmessageEventname).getcropbyname(_cropdto.crop_name);
					if(_crop_dto_from_db == null)return;
					_cropdto_from_ui.crop_id = _crop_dto_from_db.crop_id;
					}
					
				  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).updatecropindatabase(_cropdto_from_ui);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated crop in sqlite db { " +                                                                       Environment.NewLine + "crop name: " + _cropdto_from_ui.crop_name + ","+ 
					Environment.NewLine + "status: " + _cropdto_from_ui.crop_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		
	}
}
