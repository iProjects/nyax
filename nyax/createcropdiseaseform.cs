/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 21:48
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
	/// Description of createcropdiseaseform.
	/// </summary>
	public partial class createcropdiseaseform : Form
	{	
		public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname; 
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		
		public createcropdiseaseform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
			 
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded createcropdiseaseform", TAG));
				
		}
		
		void CreatecropdiseaseformLoad(object sender, EventArgs e)
		{
			cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex = 0;
			 
			 cbocategory.Items.AddRange(new [] {"PEST", "DISEASE" });
			 cbocategory.SelectedIndex = 0;
			 
			 this.AcceptButton = btncreate;
			 this.CancelButton = btnclose;
			 txtdiseasename.Focus();
		}
		
		void BtncreateClick(object sender, EventArgs e)
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtdiseasename.Text)){
				_isuserdetailsvalid=false;
				_errormsg+="disease/pest name cannot be null.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("disease/pest name cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbocategory.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select category.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("select category.", TAG));
			} 
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"select status.";
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("select status.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _iscreatecropdiseasesuccessful = createcropdiseaseindatabase();
			if(_iscreatecropdiseasesuccessful){  
				
			this.Close();
			
			}else{ 
				msgboxform.Show(_errormsg, TAG, msgtype.error);
				txtdiseasename.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtdiseasename.Focus();
			}
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close(); 
		}
		
		bool createcropdiseaseindatabase(){
			try{
			 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
				
				cropdiseasedto _cropdiseasedto = new cropdiseasedto();
				_cropdiseasedto.crop_disease_name = txtdiseasename.Text; 
				_cropdiseasedto.crop_disease_category = cbocategory.Text;  
				_cropdiseasedto.crop_disease_status = cbostatus.Text;
				_cropdiseasedto.created_date = dateTimeString; 
				   
				bool _exists_in_mssql = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifdiseasepestexists(_cropdiseasedto.crop_disease_name, DBContract.getdefaultmssqlconnectionstring());
				
				if(!_exists_in_mssql){
					saveinmssqldb(_cropdiseasedto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("disease/pest with name [ " + _cropdiseasedto.crop_disease_name + " ] exists in " + DBContract.mssql + ".", TAG));
				}
				
				bool _exists_in_sqlite = sqliteapisingleton.getInstance(_notificationmessageEventname).checkifdiseasepestexists(_cropdiseasedto.crop_disease_name, DBContract.getdefaultsqliteconnectionstring());
				
				if(!_exists_in_sqlite){
					saveinsqlitedb(_cropdiseasedto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("disease/pest with name [ " + _cropdiseasedto.crop_disease_name + " ] exists in " + DBContract.sqlite + ".", TAG));
				}
				
				bool _exists_in_mysql = mysqlapisingleton.getInstance(_notificationmessageEventname).checkifdiseasepestexists(_cropdiseasedto.crop_disease_name, DBContract.getdefaultmysqlconnectionstring());
				
				if(!_exists_in_mysql){
					saveinmysqldb(_cropdiseasedto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("disease/pest with name [ " + _cropdiseasedto.crop_disease_name + " ] exists in " + DBContract.mysql + ".", TAG));
				}
				
				bool _exists_in_postgresql = postgresqlapisingleton.getInstance(_notificationmessageEventname).checkifdiseasepestexists(_cropdiseasedto.crop_disease_name, DBContract.getdefaultpostgresqlconnectionstring());
				
				if(!_exists_in_postgresql){
					saveinpostgresqldb(_cropdiseasedto);
				}else{
					this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("disease/pest with name [ " + _cropdiseasedto.crop_disease_name + " ] exists in " + DBContract.postgresql + ".", TAG));
				}
				
				return true; 
				
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return false;
			}
		}
		 
		void saveinmssqldb(cropdiseasedto _cropdiseasedto)
		{ 
			string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
			  
			bool _saveinmssql;
			bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
				
			if(_saveinmssql){
				bool numberOfRowsAffected = false;
				numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropdiseaseindatabase(_cropdiseasedto, DBContract.getdefaultmssqlconnectionstring());
			    if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created disease/pest in mssql db { " +
 				Environment.NewLine + "disease/pest name: " + _cropdiseasedto.crop_disease_name + ","+
 				Environment.NewLine + "category: " + _cropdiseasedto.crop_disease_category + ","+
				Environment.NewLine + "status: " + _cropdiseasedto.crop_disease_status + " }.", TAG));
			    }
			}
		}
		
		void saveinmysqldb(cropdiseasedto _cropdiseasedto)
		{ 
			string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
			
			bool _saveinmysql;
			bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
				
			if(_saveinmysql){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).createcropdiseaseindatabase(_cropdiseasedto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created disease/pest in mysql db { " +
 				Environment.NewLine + "disease/pest name: " + _cropdiseasedto.crop_disease_name + ","+
 				Environment.NewLine + "category: " + _cropdiseasedto.crop_disease_category + ","+
				Environment.NewLine + "status: " + _cropdiseasedto.crop_disease_status + " }.", TAG));
			    }
			}
		}
		
		void saveinsqlitedb(cropdiseasedto _cropdiseasedto)
		{ 
			string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
			
			bool _saveinsqlite;
			bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
				
			if(_saveinsqlite){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).createcropdiseaseindatabase(_cropdiseasedto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created disease/pest in sqlite db { " +
 				Environment.NewLine + "disease/pest name: " + _cropdiseasedto.crop_disease_name + ","+
 				Environment.NewLine + "category: " + _cropdiseasedto.crop_disease_category + ","+
				Environment.NewLine + "status: " + _cropdiseasedto.crop_disease_status + " }.", TAG));
			    }
			}
		}
		
		void saveinpostgresqldb(cropdiseasedto _cropdiseasedto)
		{ 
			string saveinpostgresql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinpostgresql", "false");
			
			bool _saveinpostgresql;
			bool _trysaveinpostgresql = bool.TryParse(saveinpostgresql, out _saveinpostgresql);
				
			if(_saveinpostgresql){
				bool numberOfRowsAffected = false;
			  	numberOfRowsAffected = postgresqlapisingleton.getInstance(_notificationmessageEventname).createcropdiseaseindatabase(_cropdiseasedto);
			  	if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully created disease/pest in postgresql db { " +
 				Environment.NewLine + "disease/pest name: " + _cropdiseasedto.crop_disease_name + ","+
 				Environment.NewLine + "category: " + _cropdiseasedto.crop_disease_category + ","+
				Environment.NewLine + "status: " + _cropdiseasedto.crop_disease_status + " }.", TAG));
			    }
			}
		}
		
		
		
	}
}
