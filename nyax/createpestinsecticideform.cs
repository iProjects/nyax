/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 07:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using nthareneapi;

namespace nyax
{
	/// <summary>
	/// Description of createpestinsecticideform.
	/// </summary>
	public partial class createpestinsecticideform : Form
	{
		public string TAG;
		
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		errordto _errordto=new errordto();
		
		public createpestinsecticideform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
			
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded createpestinsecticideform", TAG));
				
		}
		 
		void BtncloseClick(object sender, EventArgs e)
		{ 
			this.Close(); 
		}
		
		void BtncreateClick(object sender, EventArgs e)
		{
		bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtpestinsecticidename.Text)){
				_isuserdetailsvalid=false;
				_errormsg+= "pesticide/insecticide name cannot be null.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("pesticide/insecticide name cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbocategory.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select category.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("select category.", TAG));
			} 
			if(String.IsNullOrEmpty(cbomanufacturers.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select manufacturer.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("select manufacturer.", TAG));
			} 
			if(String.IsNullOrEmpty(cbodiseasespests.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select disease/pest.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("select disease/pest.", TAG));
			} 
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select status.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("select status.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _iscreatepestinsecticidesuccessful=createpestinsecticideindatabase();
			if(_iscreatepestinsecticidesuccessful){
				
			this.Close(); 
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtpestinsecticidename.Focus();
				_errordto.errormessage=_errormsg;			
			}
			
			}else{
				 msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtpestinsecticidename.Focus();
				_errordto.errormessage=_errormsg;
				 
			}	
		}
		
		void CreatepestinsecticideformLoad(object sender, EventArgs e)
		{
			 cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex=0;
			 
			 //cbocategory.Items.AddRange(new [] {"INSECTICIDES", "FUNGICIDES" , "MITICIDES" , "HERBICIDES" , "SOIL SOLUTIONS" , "FOLIAR FERTILIZER" });
			 //cbocategory.SelectedIndex=0;
			  
			 this.AcceptButton=btncreate;
			 this.CancelButton=btnclose;
			 
			 txtpestinsecticidename.Focus();
			  
			 populatemanufacturers();
			 
			 populatediseasespests();
			 
			 populatecategories();
		}
		
		bool createpestinsecticideindatabase(){
			try{
			 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
				
				pestinsecticidedto _pestinsecticidedto = new pestinsecticidedto();
				_pestinsecticidedto.pestinsecticide_name = txtpestinsecticidename.Text; 
				_pestinsecticidedto.pestinsecticide_category = cbocategory.SelectedValue.ToString();
				_pestinsecticidedto.pestinsecticide_crop_disease_id = cbodiseasespests.SelectedValue.ToString();
				_pestinsecticidedto.pestinsecticide_manufacturer_id = cbomanufacturers.SelectedValue.ToString();
				_pestinsecticidedto.pestinsecticide_status = cbostatus.Text;
				_pestinsecticidedto.created_date = dateTimeString; 
			
				bool _exists_in_mssql = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifpesticideinsecticideexists(_pestinsecticidedto.pestinsecticide_name, DBContract.getdefaultmssqlconnectionstring());
				
				if(!_exists_in_mssql){
					saveinmssqldb(_pestinsecticidedto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("pesticide/insecticide with name [ " + _pestinsecticidedto.pestinsecticide_name + " ] exists in " + DBContract.mssql + ".", TAG));
				}
				
				bool _exists_in_sqlite = sqliteapisingleton.getInstance(_notificationmessageEventname).checkifpesticideinsecticideexists(_pestinsecticidedto.pestinsecticide_name, DBContract.getdefaultsqliteconnectionstring());
				
				if(!_exists_in_sqlite){
					saveinsqlitedb(_pestinsecticidedto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("pesticide/insecticide with name [ " + _pestinsecticidedto.pestinsecticide_name + " ] exists in " + DBContract.sqlite + ".", TAG));
				}
				
				bool _exists_in_mysql = mysqlapisingleton.getInstance(_notificationmessageEventname).checkifpesticideinsecticideexists(_pestinsecticidedto.pestinsecticide_name, DBContract.getdefaultmysqlconnectionstring());
				
				if(!_exists_in_mysql){
					saveinmysqldb(_pestinsecticidedto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("pesticide/insecticide with name [ " + _pestinsecticidedto.pestinsecticide_name + " ] exists in " + DBContract.mysql + ".", TAG));
				}
				
				bool _exists_in_postgresql = postgresqlapisingleton.getInstance(_notificationmessageEventname).checkifpesticideinsecticideexists(_pestinsecticidedto.pestinsecticide_name, DBContract.getdefaultpostgresqlconnectionstring());
				
				if(!_exists_in_postgresql){
					saveinpostgresqldb(_pestinsecticidedto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("pesticide/insecticide with name [ " + _pestinsecticidedto.pestinsecticide_name + " ] exists in " + DBContract.postgresql + ".", TAG));
				}
				
				return true;
				 
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
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
		
		void populatediseasespests(){
			try{
				 
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			    
			    List<cropdiseasedto> _diseasespestslst = new List<cropdiseasedto>();
			 	string query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY;
			  
				 mssql_dt = getalldiseasespestsrecordsfrommssql(query); 
				 
				 mysql_dt = getalldiseasespestsrecordsfrommysql(query); 
				 
				 sqlite_dt = getalldiseasespestsrecordsfromsqlite(query); 
		  
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
					
					cropdiseasedto _cropdiseasedto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdiseasedtogivendatatable(dt, i);
							 
					_diseasespestslst.Add(_cropdiseasedto);
				}
				  
				_diseasespestslst.Reverse();
			   
	            cbodiseasespests.DataSource = _diseasespestslst;
	            cbodiseasespests.DisplayMember = "crop_disease_name";
	            cbodiseasespests.ValueMember = "crop_disease_id";
	            if(_recordscount > 0)cbodiseasespests.SelectedIndex = 0;
				
				}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 	
			}
		}
		
		void populatecategories(){
			try{
				 
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			    
			    List<categorydto> _categorieslst = new List<categorydto>();
			 	string query = DBContract.CATEGORIES_SELECT_ALL_QUERY;
			  
				 mssql_dt = getallcategoriesrecordsfrommssql(query); 
				 
				 mysql_dt = getallcategoriesrecordsfrommysql(query); 
				 
				 sqlite_dt = getallcategoriesrecordsfromsqlite(query); 
		  
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
				
				for(int i = 0; i < _recordscount; i++){	
						
					categorydto _categorydto = utilzsingleton.getInstance(_notificationmessageEventname).buildcategorydtogivendatatable(dt, i);
						 
					_categorieslst.Add(_categorydto); 
				}
				  
				_categorieslst.Reverse();
			   
	            cbocategory.DataSource = _categorieslst;
	            cbocategory.DisplayMember = "category_name";
	            cbocategory.ValueMember = "category_id";
	            if(_recordscount > 0)cbocategory.SelectedIndex = 0;
				
				}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 	
			}
		}
		
		DataTable getallrecordsfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null && mssql_dt.Rows.Count != 0){
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql manufacturers count: " + mssql_dt.Rows.Count, TAG));
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
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql manufacturers count: " + mysql_dt.Rows.Count, TAG));
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
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite manufacturers count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		  
		DataTable getalldiseasespestsrecordsfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null && mssql_dt.Rows.Count != 0){
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql diseases/pests count: " + mssql_dt.Rows.Count, TAG));
			 }
			 return mssql_dt;
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		DataTable getalldiseasespestsrecordsfrommysql(string query){
			try{
				
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (mysql_dt != null && mysql_dt.Rows.Count != 0){
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql diseases/pests count: " + mysql_dt.Rows.Count, TAG));
			 }
			return mysql_dt;
			
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		DataTable getalldiseasespestsrecordsfromsqlite(string query){
			try{
				
			DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (sqlite_dt != null && sqlite_dt.Rows.Count != 0){
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite diseases/pests count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		DataTable getallcategoriesrecordsfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null && mssql_dt.Rows.Count != 0){
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql categories count: " + mssql_dt.Rows.Count, TAG));
			 }
			 return mssql_dt;
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		DataTable getallcategoriesrecordsfrommysql(string query){
			try{
				
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (mysql_dt != null && mysql_dt.Rows.Count != 0){
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql categories count: " + mysql_dt.Rows.Count, TAG));
			 }
			return mysql_dt;
			
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		DataTable getallcategoriesrecordsfromsqlite(string query){
			try{
				
			DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (sqlite_dt != null && sqlite_dt.Rows.Count != 0){
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite categories count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		  
		void saveinmssqldb(pestinsecticidedto _pestinsecticidedto)
		{ 
			string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
			  
			bool _saveinmssql;
			bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
				
			if(_saveinmssql){
				bool numberOfRowsAffected = false;
			    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createpestinsecticideindatabase(_pestinsecticidedto, DBContract.getdefaultmssqlconnectionstring());
			    if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created pesticide/insecticide in mssql db { " + 
 				 Environment.NewLine + "pestinsecticidename: " + _pestinsecticidedto.pestinsecticide_name + "," +
                 Environment.NewLine + " category: " + _pestinsecticidedto.pestinsecticide_category + "," + Environment.NewLine + " status: " + _pestinsecticidedto.pestinsecticide_status + " }.", TAG));
			    }
			}
		}
		
		void saveinmysqldb(pestinsecticidedto _pestinsecticidedto)
		{ 
			string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
			
			bool _saveinmysql;
			bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
				
			if(_saveinmysql){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).createpestinsecticideindatabase(_pestinsecticidedto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created pesticide/insecticide in mysql db { " + 
 				 Environment.NewLine + "pestinsecticidename: " + _pestinsecticidedto.pestinsecticide_name + "," +
                 Environment.NewLine + " category: " + _pestinsecticidedto.pestinsecticide_category + "," + Environment.NewLine + " status: " + _pestinsecticidedto.pestinsecticide_status + " }.", TAG));
			    }
			}
		}
		
		void saveinsqlitedb(pestinsecticidedto _pestinsecticidedto)
		{ 
			string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
			
			bool _saveinsqlite;
			bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
				
			if(_saveinsqlite){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).createpestinsecticideindatabase(_pestinsecticidedto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created pesticide/insecticide in sqlite db { " + 
 				 Environment.NewLine + "pestinsecticidename: " + _pestinsecticidedto.pestinsecticide_name + "," +
                 Environment.NewLine + " category: " + _pestinsecticidedto.pestinsecticide_category + "," + Environment.NewLine + " status: " + _pestinsecticidedto.pestinsecticide_status + " }.", TAG));
			    }
			}
		}
		
		void saveinpostgresqldb(pestinsecticidedto _pestinsecticidedto)
		{ 
			string saveinpostgresql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinpostgresql", "false");
			
			bool _saveinpostgresql;
			bool _trysaveinpostgresql = bool.TryParse(saveinpostgresql, out _saveinpostgresql);
				
			if(_saveinpostgresql){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = postgresqlapisingleton.getInstance(_notificationmessageEventname).createpestinsecticideindatabase(_pestinsecticidedto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created pesticide/insecticide in postgresql db { " + 
 				 Environment.NewLine + "pestinsecticidename: " + _pestinsecticidedto.pestinsecticide_name + "," +
                 Environment.NewLine + " category: " + _pestinsecticidedto.pestinsecticide_category + "," + Environment.NewLine + " status: " + _pestinsecticidedto.pestinsecticide_status + " }.", TAG));
			    }
			}
		}
		
		
		
	}
}
