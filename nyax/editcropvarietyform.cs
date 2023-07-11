/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 10/23/2018
 * Time: 20:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using nthareneapi;

namespace nyax
{
	/// <summary>
	/// Description of editcropvarietyform.
	/// </summary>
	public partial class editcropvarietyform : Form
	{
		public string TAG; 
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		public responsedto _responsedto = new responsedto();
		public cropvarietydto _cropvarietydto;
		public cropsvarietieslistform _cropsvarietieslistform;
		 
		public editcropvarietyform(cropvarietydto cropvarietydto, cropsvarietieslistform cropsvarietieslistform, EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			_cropvarietydto = cropvarietydto;
			_cropsvarietieslistform = cropsvarietieslistform;
				
			TAG = this.GetType().Name;
				
		    _notificationmessageEventname = notificationmessageEventname; 
			_progressBarNotificationEventname = progressBarNotificationEventname;
			  
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded editcropvarietyform", TAG));
				
		}
		
		void populatecontrols(){
			txtcropvarietyname.Text = _cropvarietydto.crop_variety_name;
			cbostatus.SelectedValue = _cropvarietydto.crop_variety_status;
			cbocrops.SelectedValue = _cropvarietydto.crop_variety_crop_id;
			cbomanufacturers.SelectedValue = _cropvarietydto.crop_variety_manufacturer_id;
		}
		
		void EditcropvarietyformLoad(object sender, EventArgs e)
		{
			 cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex=0;
			 
			 this.AcceptButton = btnupdate;
			 this.CancelButton = btnclose;
			 txtcropvarietyname.Focus();
			 
			 populatemanufacturers();
			 populatecrops();
  
			 populatecontrols();
		}
		
		void populatemanufacturers(){
			try{
				
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			    
				List<manufacturerdto> _manufacturerslst=new List<manufacturerdto>();
				string query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY; 		
					
				 mssql_dt = getallrecordsfrommssql(query); 
				 
				 mysql_dt = getallrecordsfrommysql(query); 
				 
				 sqlite_dt = getallrecordsfromsqlite(query); 
		  
				 if(mssql_dt != null){
				 	dt = mssql_dt;
				 }
				 if(mssql_dt == null && mysql_dt != null){
				 	dt = mysql_dt;
				 }
				 if(mssql_dt == null && mysql_dt == null && sqlite_dt != null){
				 	dt = sqlite_dt;
				 }
				  
				 if(dt == null)return;
				    
				var _recordscount = dt.Rows.Count; 
				for(int i=0;i<_recordscount;i++){	
 
					manufacturerdto _manufacturerdto = utilzsingleton.getInstance(_notificationmessageEventname).buildmanufacturerdtogivendatatable(dt, i);
											
//					manufacturerdto _manufacturerdto = new manufacturerdto();
//					_manufacturerdto.manufacturer_id = Convert.ToString(dt.Rows[i]["manufacturer_id"]);
//					_manufacturerdto.manufacturer_name = Convert.ToString(dt.Rows[i]["manufacturer_name"]); 
//					_manufacturerdto.manufacturer_status = Convert.ToString(dt.Rows[i]["manufacturer_status"]);
//					_manufacturerdto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);
					
					_manufacturerslst.Add(_manufacturerdto);  
				}
				  
				_manufacturerslst.Reverse();
			   
				cbomanufacturers.DataSource = _manufacturerslst;
				cbomanufacturers.DisplayMember = "manufacturer_name";
				cbomanufacturers.ValueMember = "manufacturer_id";
				if(_recordscount > 0)cbomanufacturers.SelectedIndex = 0;
				
				}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 	
			}
		}
		
		void populatecrops(){
			try{
				
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			    
				List<cropdto> _cropslst = new List<cropdto>();
		  
				string query = DBContract.CROPS_SELECT_ALL_QUERY; 		
					
				 mssql_dt = getallrecordsfrommssql(query); 
				 
				 mysql_dt = getallrecordsfrommysql(query); 
				 
				 sqlite_dt = getallrecordsfromsqlite(query); 
		  
				 if(mssql_dt != null){
				 	dt = mssql_dt;
				 }
				 if(mssql_dt == null && mysql_dt != null){
				 	dt = mysql_dt;
				 }
				 if(mssql_dt == null && mysql_dt == null && sqlite_dt != null){
				 	dt = sqlite_dt;
				 }
				  
				 if(dt == null)return;
				    
				var _recordscount = dt.Rows.Count; 
				
				for(int i = 0;i < _recordscount; i++){	
 
					cropdto _cropdto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdtogivendatatable(dt, i);
						
	//				cropdto _cropdto = new cropdto();
	//				_cropdto.crop_id = Convert.ToString(dt.Rows[i]["crop_id"]);
	//				_cropdto.crop_name = Convert.ToString(dt.Rows[i]["crop_name"]); 
	//				_cropdto.crop_status = Convert.ToString(dt.Rows[i]["crop_status"]);
	//				_cropdto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);
	
					_cropslst.Add(_cropdto);
				}
				  
				_cropslst.Reverse();
			   
				cbocrops.DataSource = _cropslst;
				cbocrops.DisplayMember = "crop_name";
            	cbocrops.ValueMember = "crop_id";
				if(_recordscount > 0)cbocrops.SelectedIndex = 0;
				
				}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 	
			}
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
		 	this.Close();	
		}
		
		void BtnupdateClick(object sender, EventArgs e)
		{
			if(validateuserinput()){
				_cropsvarietieslistform.populatecropsvarietieslist();
				this.Close();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("record validation failed...", TAG));
			}
				
		}
		
		bool validateuserinput()
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtcropvarietyname.Text)){
				_isuserdetailsvalid=false;
				_errormsg+="variety name cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("variety name cannot be null.", TAG));
			}
			if(String.IsNullOrEmpty(cbocrops.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select crop.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("select crop.", TAG));
			}
			if(String.IsNullOrEmpty(cbomanufacturers.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select manufacturer.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("select manufacturer.", TAG));
			}
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select status.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("select status.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _isupdaterecordsuccessful = updatecropvarietyindatabase();
			if(_isupdaterecordsuccessful){
				_cropsvarietieslistform.populatecropsvarietieslist();	
				this.Close(); 
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtcropvarietyname.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error);	 
				txtcropvarietyname.Focus();
			}
			return _isuserdetailsvalid;
		}
		 
		bool updatecropvarietyindatabase(){
		try{
		 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
	 
				cropvarietydto _cropvariety_dto = new cropvarietydto();
				_cropvariety_dto.crop_variety_id = _cropvarietydto.crop_variety_id; 
				_cropvariety_dto.crop_variety_name = txtcropvarietyname.Text; 
				_cropvariety_dto.crop_variety_status = cbostatus.Text;
				_cropvariety_dto.created_date = dateTimeString;
				
				_cropvariety_dto.crop_variety_crop_id = cbocrops.SelectedValue.ToString();
				_cropvariety_dto.crop_variety_manufacturer_id = cbomanufacturers.SelectedValue.ToString();
				  
				saveinmssqldb(_cropvariety_dto);
				saveinsqlitedb(_cropvariety_dto);
				saveinmysqldb(_cropvariety_dto);
				  
				return true; 
					
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		
		void saveinmssqldb(cropvarietydto _cropvarietydto)
		{ 
			try{
				string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
				  
				bool _saveinmssql;
				bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
					
				if(_saveinmssql){
					bool numberOfRowsAffected = false;
				    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).updatecropvarietyindatabase(_cropvarietydto);
				    if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated cropvariety in mssql db { " +                                                                       Environment.NewLine + "cropvariety name: " + _cropvarietydto.crop_variety_name + "," +
					Environment.NewLine + "status: " + _cropvarietydto.crop_variety_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinmysqldb(cropvarietydto _cropvarietydto)
		{ 
			try{
				string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
				
				bool _saveinmysql;
				bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
					
				if(_saveinmysql){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).updatecropvarietyindatabase(_cropvarietydto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated cropvariety in mysql db { " +                                                                       Environment.NewLine + "cropvariety name: " + _cropvarietydto.crop_variety_name + "," +
					Environment.NewLine + "status: " + _cropvarietydto.crop_variety_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinsqlitedb(cropvarietydto _cropvarietydto)
		{ 
			try{
				string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
				
				bool _saveinsqlite;
				bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
					
				if(_saveinsqlite){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).updatecropvarietyindatabase(_cropvarietydto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated cropvariety in sqlite db { " +                                                                       Environment.NewLine + "cropvariety name: " + _cropvarietydto.crop_variety_name + "," +
					Environment.NewLine + "status: " + _cropvarietydto.crop_variety_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		DataTable getallrecordsfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null && mssql_dt.Rows.Count != 0){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql manufacturers count: " + mssql_dt.Rows.Count, TAG));
			 }
			 return mssql_dt;
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		DataTable getallrecordsfrommysql(string query){
			try{
				
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (mysql_dt != null && mysql_dt.Rows.Count != 0){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql manufacturers count: " + mysql_dt.Rows.Count, TAG));
			 }
			return mysql_dt;
			
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		DataTable getallrecordsfromsqlite(string query){
			try{
				
			DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (sqlite_dt != null && sqlite_dt.Rows.Count != 0){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite manufacturers count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		  
		 
		
		
	}
}
