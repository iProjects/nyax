/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 12/18/2018
 * Time: 10:17 PM
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
	/// Description of editcategoryform.
	/// </summary>
	public partial class editcategoryform : Form
	{
		public string TAG;
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		string _working_db = "";
			
		public responsedto _responsedto = new responsedto();
		categorydto _categorydto;
		categorieslistform _categorieslistform;
		
		public editcategoryform(categorydto categorydto, categorieslistform categorieslistform, EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			_categorydto = categorydto;
			_categorieslistform = categorieslistform;
				
			TAG = this.GetType().Name;
				
		    _notificationmessageEventname = notificationmessageEventname; 
			 _progressBarNotificationEventname = progressBarNotificationEventname;
			 
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded editcategoryform", TAG));
				
		}
		
		void EditcategoryformLoad(object sender, EventArgs e)
		{
			 cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex=0;
			 
			 this.AcceptButton = btnupdate;
			 this.CancelButton = btnclose;
			 txtcategoryname.Focus();
			 
			populatecontrols();
		}
		
		void populatecontrols(){
			txtcategoryname.Text = _categorydto.category_name; 
			cbostatus.SelectedValue = _categorydto.category_status; 
		}
		
		void BtnupdateClick(object sender, EventArgs e)
		{
			if(validateuserinput()){
				_categorieslistform.populatecategorieslist();
				this.Close();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("record validation failed...", TAG));
			}
		}
		
		bool validateuserinput()
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtcategoryname.Text)){
				_isuserdetailsvalid=false;
				_errormsg+="category name cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("category name cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"status cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("status cannot be null.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _isupdaterecordsuccessful = updatecategorydiseaseindatabase();
			if(_isupdaterecordsuccessful){
				_categorieslistform.populatecategorieslist();
				this.Close();
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtcategoryname.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error);	 
				txtcategoryname.Focus();
			}
			return _isuserdetailsvalid;
		}
		 
		bool updatecategorydiseaseindatabase(){
		try{
		 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
	 
				categorydto _category_dto = new categorydto();
				_category_dto.category_id = _categorydto.category_id; 
				_category_dto.category_name = txtcategoryname.Text;  
				_category_dto.category_status = cbostatus.Text;
				_category_dto.created_date = dateTimeString; 
			  
				saveinmssqldb(_category_dto);
				saveinsqlitedb(_category_dto);
				saveinmysqldb(_category_dto);
				  
				return true; 
					
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		void saveinmssqldb(categorydto _categorydto)
		{ 
			try{
				string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
				  
				bool _saveinmssql;
				bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
					
				if(_saveinmssql){
					bool numberOfRowsAffected = false;
				    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).updatecategoryindatabase(_categorydto);
				    if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated category in mssql db { " +                                                                       Environment.NewLine + "category name: " + _categorydto.category_name + ","+ 
					Environment.NewLine + "status: " + _categorydto.category_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinmysqldb(categorydto _categorydto_from_ui)
		{ 
			try{
				string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
				
				bool _saveinmysql;
				bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
					
				if(_saveinmysql){
					bool numberOfRowsAffected = false;
					
					if(_working_db != DBContract.mysql){
					categorydto _category_dto_from_db = mysqlapisingleton.getInstance(_notificationmessageEventname).getcategorybyname(_categorydto.category_name); 
					if(_category_dto_from_db == null)return;
					_categorydto_from_ui.category_id = _category_dto_from_db.category_id;
					}
					
				  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).updatecategoryindatabase(_categorydto_from_ui);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated category in mysql db { " +                                                                       Environment.NewLine + "category name: " + _categorydto_from_ui.category_name + ","+ 
					Environment.NewLine + "status: " + _categorydto_from_ui.category_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinsqlitedb(categorydto _categorydto_from_ui)
		{ 
			try{
				string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
				
				bool _saveinsqlite;
				bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
					
				if(_saveinsqlite){
					bool numberOfRowsAffected = false;
					
					if(_working_db != DBContract.sqlite){
					categorydto _category_dto_from_db = sqliteapisingleton.getInstance(_notificationmessageEventname).getcategorybyname(_categorydto.category_name);
					if(_category_dto_from_db == null)return;
					_categorydto_from_ui.category_id = _category_dto_from_db.category_id;
					}
					
				  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).updatecategoryindatabase(_categorydto_from_ui);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated category in sqlite db { " +                                                                       Environment.NewLine + "category name: " + _categorydto_from_ui.category_name + ","+ 
					Environment.NewLine + "status: " + _categorydto_from_ui.category_status + " }.", TAG));
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
