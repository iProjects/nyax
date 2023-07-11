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
	/// Description of createcategoryform.
	/// </summary>
	public partial class createcategoryform : Form
	{
		public string TAG;
		
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		errordto _errordto = new errordto();
		string _working_db = "";
		
		public createcategoryform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
			
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded createcategoryform", TAG));
				
		}
		
		void CreatecategoryformLoad(object sender, EventArgs e)
		{
			cbostatus.Items.AddRange(new [] {"active", "inactive" });
			cbostatus.SelectedIndex=0;
			 
			 this.AcceptButton=btncreate;
			 this.CancelButton=btnclose;
			 txtcategoryname.Focus();
		}
		
		void BtncreateClick(object sender, EventArgs e)
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtcategoryname.Text)){
				_isuserdetailsvalid=false;
				_errormsg+="category name cannot be null.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("category name cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select status.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("select status.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _iscreatecategoriesuccessful = createcategoryindatabase();
			if(_iscreatecategoriesuccessful){ 
				
				this.Close();
				
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error);
				txtcategoryname.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtcategoryname.Focus();
			}
		}
		
		bool createcategoryindatabase(){
			try{
				DateTime currentDate = DateTime.Now; 
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
				
				categorydto _categorydto = new categorydto();
				_categorydto.category_name = txtcategoryname.Text; 
				_categorydto.category_status = cbostatus.Text;
				_categorydto.created_date = dateTimeString; 
					   
				bool _exists_in_mssql = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifcategoryexists(_categorydto.category_name, DBContract.getdefaultmssqlconnectionstring());
				
				if(!_exists_in_mssql){
					saveinmssqldb(_categorydto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("category with name [ " + _categorydto.category_name + " ] exists in " + DBContract.mssql + ".", TAG));
				}
				
				bool _exists_in_sqlite = sqliteapisingleton.getInstance(_notificationmessageEventname).checkifcategoryexists(_categorydto.category_name, DBContract.getdefaultsqliteconnectionstring());
				
				if(!_exists_in_sqlite){
					saveinsqlitedb(_categorydto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("category with name [ " + _categorydto.category_name + " ] exists in " + DBContract.sqlite + ".", TAG));
				}
				
				bool _exists_in_mysql = mysqlapisingleton.getInstance(_notificationmessageEventname).checkifcategoryexists(_categorydto.category_name, DBContract.getdefaultmysqlconnectionstring());
				
				if(!_exists_in_mysql){
					saveinmysqldb(_categorydto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("category with name [ " + _categorydto.category_name + " ] exists in " + DBContract.mysql + ".", TAG));
				}
				
				bool _exists_in_postgresql = postgresqlapisingleton.getInstance(_notificationmessageEventname).checkifcategoryexists(_categorydto.category_name, DBContract.getdefaultpostgresqlconnectionstring());
				
				if(!_exists_in_postgresql){
					saveinpostgresqldb(_categorydto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("category with name [ " + _categorydto.category_name + " ] exists in " + DBContract.postgresql + ".", TAG));
				}
				
				return true; 
				
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return false;
			}
		}
		 
		void saveinmssqldb(categorydto _categorydto)
		{ 
			string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
			  
			bool _saveinmssql;
			bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
				
			if(_saveinmssql){
				bool numberOfRowsAffected = false;
			    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcategoryindatabase(_categorydto, DBContract.getdefaultmssqlconnectionstring());			    
			    if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created category in mssql db { " +
 				Environment.NewLine + "category name: " + _categorydto.category_name + ","+ 
				Environment.NewLine + "status: " + _categorydto.category_status + " }.", TAG));
			    }
			}
		}
		
		void saveinmysqldb(categorydto _categorydto)
		{ 
			string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
			
			bool _saveinmysql;
			bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
				
			if(_saveinmysql){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).createcategoryindatabase(_categorydto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created category in mysql db { " +
 				Environment.NewLine + "category name: " + _categorydto.category_name + ","+ 
				Environment.NewLine + "status: " + _categorydto.category_status + " }.", TAG));
			    }
			}
		}
		
		void saveinsqlitedb(categorydto _categorydto)
		{ 
			string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
			
			bool _saveinsqlite;
			bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
				
			if(_saveinsqlite){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).createcategoryindatabase(_categorydto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created category in sqlite db { " +
 				Environment.NewLine + "category name: " + _categorydto.category_name + ","+ 
				Environment.NewLine + "status: " + _categorydto.category_status + " }.", TAG));
			    }
			}
		}
		
		void saveinpostgresqldb(categorydto _categorydto)
		{ 
			string saveinpostgresql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinpostgresql", "false");
			
			bool _saveinpostgresql;
			bool _trysaveinpostgresql = bool.TryParse(saveinpostgresql, out _saveinpostgresql);
				
			if(_saveinpostgresql){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = postgresqlapisingleton.getInstance(_notificationmessageEventname).createcategoryindatabase(_categorydto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created category in postgresql db { " +
 				Environment.NewLine + "category name: " + _categorydto.category_name + ","+ 
				Environment.NewLine + "status: " + _categorydto.category_status + " }.", TAG));
			    }
			}
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close(); 			
		}
	}
}
