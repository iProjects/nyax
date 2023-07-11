/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/16/2018
 * Time: 05:49
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
	/// Description of editmanufacturerform.
	/// </summary>
	public partial class editmanufacturerform : Form
	{
		public string TAG; 
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		public responsedto _responsedto = new responsedto();
		public manufacturerdto _manufacturerdto;
		public manufacturerslistform _manufacturerslistform;
		 
		public editmanufacturerform(manufacturerdto manufacturerdto, manufacturerslistform manufacturerslistform, EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			_manufacturerdto = manufacturerdto;
			_manufacturerslistform = manufacturerslistform;
				
			TAG = this.GetType().Name;
				
		    _notificationmessageEventname = notificationmessageEventname; 
			_progressBarNotificationEventname = progressBarNotificationEventname;
			  
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded editmanufacturerform", TAG));
				
		}
		
		void populatecontrols(){
			txtmanufacturername.Text = _manufacturerdto.manufacturer_name;
			cbostatus.SelectedValue = _manufacturerdto.manufacturer_status; 
		}
		
		void EditmanufacturerformLoad(object sender, EventArgs e)
		{
			 cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex=0;
			 
			 this.AcceptButton = btnupdate;
			 this.CancelButton = btnclose;
			 txtmanufacturername.Focus();
			 
			populatecontrols();
		}
		 
		void BtncloseClick(object sender, EventArgs e)
		{
		 	this.Close();	
		}
		
		void BtnupdateClick(object sender, EventArgs e)
		{
			if(validateuserinput()){
				_manufacturerslistform.populatemanufacturerslist();
				this.Close();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("record validation failed...", TAG));
			}
				
		}
		
		bool validateuserinput()
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtmanufacturername.Text)){
				_isuserdetailsvalid=false;
				_errormsg+="manufacturer name cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("manufacturer name cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"status cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("status cannot be null.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _isupdaterecordsuccessful = updatemanufacturerindatabase();
			if(_isupdaterecordsuccessful){
				_manufacturerslistform.populatemanufacturerslist();	
				this.Close(); 
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtmanufacturername.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error);	 
				txtmanufacturername.Focus();
			}
			return _isuserdetailsvalid;
		}
		 
		bool updatemanufacturerindatabase(){
		try{
		 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
	 
				manufacturerdto _manufacturer_dto = new manufacturerdto();
				_manufacturer_dto.manufacturer_id = _manufacturerdto.manufacturer_id; 
				_manufacturer_dto.manufacturer_name = txtmanufacturername.Text; 
				_manufacturer_dto.manufacturer_status = cbostatus.Text;
				_manufacturer_dto.created_date = dateTimeString; 
				  
				saveinmssqldb(_manufacturer_dto);
				saveinsqlitedb(_manufacturer_dto);
				saveinmysqldb(_manufacturer_dto);
				  
				return true; 
					
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		
		void saveinmssqldb(manufacturerdto _manufacturerdto)
		{ 
			try{
				string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
				  
				bool _saveinmssql;
				bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
					
				if(_saveinmssql){
					bool numberOfRowsAffected = false;
				    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).updatemanufacturerindatabase(_manufacturerdto);
				    if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated manufacturer in mssql db { " +                                                                       Environment.NewLine + "manufacturer name: " + _manufacturerdto.manufacturer_name + "," +
					Environment.NewLine + "status: " + _manufacturerdto.manufacturer_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinmysqldb(manufacturerdto _manufacturerdto)
		{ 
			try{
				string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
				
				bool _saveinmysql;
				bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
					
				if(_saveinmysql){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).updatemanufacturerindatabase(_manufacturerdto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated manufacturer in mysql db { " +                                                                       Environment.NewLine + "manufacturer name: " + _manufacturerdto.manufacturer_name + "," +
					Environment.NewLine + "status: " + _manufacturerdto.manufacturer_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinsqlitedb(manufacturerdto _manufacturerdto)
		{ 
			try{
				string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
				
				bool _saveinsqlite;
				bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
					
				if(_saveinsqlite){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).updatemanufacturerindatabase(_manufacturerdto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated manufacturer in sqlite db { " +                                                                       Environment.NewLine + "manufacturer name: " + _manufacturerdto.manufacturer_name + "," +
					Environment.NewLine + "status: " + _manufacturerdto.manufacturer_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		 
		
		
	}
}
