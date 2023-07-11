/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/14/2018
 * Time: 09:26
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
	/// Description of editpestinsecticideform.
	/// </summary>
	public partial class editpestinsecticideform : Form
	{
		public string TAG; 
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;		
		public responsedto _responsedto = new responsedto();
		pestinsecticidedto _pestinsecticidedto;
		pestsinsecticideslistform _pestinsecticideslistform;
		 
		public editpestinsecticideform(pestinsecticidedto pestinsecticidedto, pestsinsecticideslistform pestinsecticideslistform, EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			_pestinsecticidedto = pestinsecticidedto;
			_pestinsecticideslistform = pestinsecticideslistform;
				
			TAG = this.GetType().Name;
				
		    _notificationmessageEventname = notificationmessageEventname; 
			 _progressBarNotificationEventname = progressBarNotificationEventname;
			 
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded editpestinsecticideform", TAG));
				
		}
		
		void populatecontrols(){
			txtpestinsecticidename.Text = _pestinsecticidedto.pestinsecticide_name;
			cbocategory.SelectedValue = _pestinsecticidedto.pestinsecticide_category;
			if(_pestinsecticidedto.pestinsecticide_manufacturer_id != null){
				cbomanufacturer.SelectedValue = _pestinsecticidedto.pestinsecticide_manufacturer_id;
			}
			cbodiseasespests.SelectedValue = _pestinsecticidedto.pestinsecticide_crop_disease_id;
			cbostatus.SelectedValue = _pestinsecticidedto.pestinsecticide_status; 
		}
		 
		void EditpestinsecticideformLoad(object sender, EventArgs e)
		{
			 cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex=0;
			 
			 //cbocategory.Items.AddRange(new [] {"INSECTICIDES", "FUNGICIDES" , "MITICIDES" , "HERBICIDES" , "SOIL SOLUTIONS" , "FOLIAR FRTILIZER" });
			 //cbocategory.SelectedIndex=0;
			  
			 this.AcceptButton = btnupdate;
			 this.CancelButton = btnclose;
			 txtpestinsecticidename.Focus();
			  
			 populatemanufacturers();
			 populatediseasespests();
			 populatecategories();
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
			   
				cbomanufacturer.DataSource = _manufacturerslst;
				cbomanufacturer.DisplayMember = "manufacturer_name";
				cbomanufacturer.ValueMember = "manufacturer_id";
				if(_recordscount > 0)cbomanufacturer.SelectedIndex = 0;
				
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

				List<cropdiseasedto> _diseasespestsdtolst=new List<cropdiseasedto>();
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
												
//					cropdiseasedto _cropdiseasedto = new cropdiseasedto();
//					_cropdiseasedto.crop_disease_id = Convert.ToString(dt.Rows[i]["crop_disease_id"]);
//					_cropdiseasedto.crop_disease_name = Convert.ToString(dt.Rows[i]["crop_disease_name"]); 
//					_cropdiseasedto.crop_disease_category = Convert.ToString(dt.Rows[i]["crop_disease_category"]);
//					_cropdiseasedto.crop_disease_status = Convert.ToString(dt.Rows[i]["crop_disease_status"]);
//					_cropdiseasedto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);
					
					_diseasespestsdtolst.Add(_cropdiseasedto);  
				}
				  
				_diseasespestsdtolst.Reverse();
			   
				cbodiseasespests.DataSource = _diseasespestsdtolst;
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
						
//					categorydto _categorydto = new categorydto();
//					_categorydto.category_id = Convert.ToString(dt.Rows[i]["category_id"]);
//					_categorydto.category_name = Convert.ToString(dt.Rows[i]["category_name"]); 
//					_categorydto.category_status = Convert.ToString(dt.Rows[i]["category_status"]);
//					_categorydto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);
							
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
		  
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();	
		}
		
		void BtnupdateClick(object sender, EventArgs e)
		{
			if(validateuserinput()){
				_pestinsecticideslistform.populatepestsinsecticideslist();
				this.Close();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("record validation failed...", TAG));
			}
				
		}
		
		bool validateuserinput()
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtpestinsecticidename.Text)){
				_isuserdetailsvalid=false;
				_errormsg+= "pesticide/insecticide name cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("pesticide/insecticide name cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbocategory.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"category cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("category cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbomanufacturer.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"manufacturer cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("manufacturer cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbodiseasespests.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"disease/pest cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("disease/pest cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"status cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("status cannot be null.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _isupdaterecordsuccessful = updatepestinsecticideindatabase();
			if(_isupdaterecordsuccessful){
				_pestinsecticideslistform.populatepestsinsecticideslist();
				this.Close(); 
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error);	 
				txtpestinsecticidename.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error);	 
				txtpestinsecticidename.Focus();
			}
			return _isuserdetailsvalid;
		}
		 
		bool updatepestinsecticideindatabase(){
		try{
		 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
				 
				pestinsecticidedto _pestinsecticide_dto = new pestinsecticidedto();
				_pestinsecticide_dto.pestinsecticide_id = _pestinsecticidedto.pestinsecticide_id; 
				_pestinsecticide_dto.pestinsecticide_name = txtpestinsecticidename.Text; 
				_pestinsecticide_dto.pestinsecticide_category = cbocategory.SelectedValue.ToString();
				_pestinsecticidedto.pestinsecticide_crop_disease_id = cbodiseasespests.SelectedValue.ToString();
				_pestinsecticidedto.pestinsecticide_manufacturer_id = cbomanufacturer.SelectedValue.ToString();
				_pestinsecticide_dto.pestinsecticide_status = cbostatus.Text;
				_pestinsecticide_dto.created_date = dateTimeString; 
				  
				saveinmssqldb(_pestinsecticide_dto);
				saveinsqlitedb(_pestinsecticide_dto);
				saveinmysqldb(_pestinsecticide_dto);
				  
				return true; 
					
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		void saveinmssqldb(pestinsecticidedto _pestinsecticidedto)
		{ 
			try{
				string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
				  
				bool _saveinmssql;
				bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
					
				if(_saveinmssql){
					bool numberOfRowsAffected = false;
				    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).updatepestinsecticideindatabase(_pestinsecticidedto);
				    if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated pesticide/insecticide in mssql db { " +                                                                       Environment.NewLine + "pestinsecticidename: " + _pestinsecticidedto.pestinsecticide_name + "," +
	                Environment.NewLine + " category: " + _pestinsecticidedto.pestinsecticide_category + "," +
	                Environment.NewLine + " status: " + _pestinsecticidedto.pestinsecticide_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinmysqldb(pestinsecticidedto _pestinsecticidedto)
		{ 
			try{
				string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
				
				bool _saveinmysql;
				bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
					
				if(_saveinmysql){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).updatepestinsecticideindatabase(_pestinsecticidedto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated pesticide/insecticide in mysql db { " +                                                                       Environment.NewLine + "pestinsecticidename: " + _pestinsecticidedto.pestinsecticide_name + "," +
	                Environment.NewLine + " category: " + _pestinsecticidedto.pestinsecticide_category + "," +
	                Environment.NewLine + " status: " + _pestinsecticidedto.pestinsecticide_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinsqlitedb(pestinsecticidedto _pestinsecticidedto)
		{ 
			try{
				string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
				
				bool _saveinsqlite;
				bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
					
				if(_saveinsqlite){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).updatepestinsecticideindatabase(_pestinsecticidedto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated pesticide/insecticide in sqlite db { " +                                                                       Environment.NewLine + "pestinsecticidename: " + _pestinsecticidedto.pestinsecticide_name + "," +
	                Environment.NewLine + " category: " + _pestinsecticidedto.pestinsecticide_category + "," +
	                Environment.NewLine + " status: " + _pestinsecticidedto.pestinsecticide_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
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
		  
		  
		
	}
}
