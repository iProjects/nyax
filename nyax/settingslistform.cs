/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 21:36
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
	/// Description of settingslistform.
	/// </summary>
	public partial class settingslistform : Form
	{	
		public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		string _working_db = "";
		
		public settingslistform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
			 	
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("initialized settingslistform", TAG));
		}
		
		void SettingslistformLoad(object sender, EventArgs e)
		{
			this.AcceptButton=btncreatesetting;
			this.CancelButton=btnclose;
			 
			populatesettingslist();
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loaded settingslistform", TAG));
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void BtncreatesettingClick(object sender, EventArgs e)
		{
			createsettingform _createsettingform=new createsettingform(_notificationmessageEventname, _progressBarNotificationEventname);
			_createsettingform.ShowDialog();
			populatesettingslist();
		}
		
		public void populatesettingslist(string nullable_query = ""){
			try{
				
				bindingSourcesettings.DataSource = null;
				dataGridViewsettings.DataSource = null;
				groupBoxlst.Text = "";
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			    
				List<settingdto> _settingslst=new List<settingdto>();
			 	string query = "";
				 if(!String.IsNullOrEmpty(nullable_query)){
				 	query = nullable_query;
				 }else{
				 	if(chkshowinactive.Checked){
						query = DBContract.SETTINGS_SELECT_ALL_QUERY; 
					}else{
						query = DBContract.SETTINGS_SELECT_ALL_FILTER_QUERY; 
					}
				 }

			 	dt = businesslayerapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getsettings();
				
			 	_working_db = businesslayerapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname)._working_db;
			 	
			 	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("working db [ " +  _working_db + " ]", TAG));
			 
//				 mssql_dt = getallrecordsfrommssql(query); 
//				 
//				 mysql_dt = getallrecordsfrommysql(query); 
//				 
//				 sqlite_dt = getallrecordsfromsqlite(query); 
//		  
//				 if(mssql_dt != null){
//				 	dt = mssql_dt;
//				 	_working_db = "mssql";
//				 }
//				 if(mssql_dt == null && mysql_dt != null){
//				 	dt = mysql_dt;
//				 	_working_db = "mysql";
//				 }
//				 if(mssql_dt == null && mysql_dt == null && sqlite_dt != null){
//				 	dt = sqlite_dt;
//				 	_working_db = "sqlite";
//				 }
				  
				 if(dt == null)return;
				  	  
				var _recordscount=dt.Rows.Count; 			
				for(int i = 0; i < _recordscount; i++){
				
					settingdto _settingdto = utilzsingleton.getInstance(_notificationmessageEventname).buildsettingdtogivendatatable(dt, i);
	
					_settingslst.Add(_settingdto); 
					 
					_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));
				}
				
				_settingslst.Reverse();
			   
				groupBoxlst.Text = "count [ " + _settingslst.Count.ToString() + " ] working db [ " +  _working_db + " ]";
				bindingSourcesettings.DataSource = _settingslst;
				dataGridViewsettings.DataSource = bindingSourcesettings;
				dataGridViewsettings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				dataGridViewsettings.MultiSelect = false;
				dataGridViewsettings.ReadOnly = true;
				dataGridViewsettings.AllowUserToAddRows = false;
				dataGridViewsettings.AllowUserToDeleteRows = false;
				dataGridViewsettings.AutoGenerateColumns = false;
				dataGridViewsettings.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { 
					BackColor = utilzsingleton.getInstance(_notificationmessageEventname).AlternatingRowsDefaultCellStyleBackColor,
 					ForeColor = utilzsingleton.getInstance(_notificationmessageEventname).AlternatingRowsDefaultCellStyleForeColor 
				}; 
				 
				}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			}
		}
		
		DataTable getallrecordsfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null && mssql_dt.Rows.Count != 0){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql settings count: " + mssql_dt.Rows.Count, TAG));
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql settings count: " + mysql_dt.Rows.Count, TAG));
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite settings count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		   
		void SettingslistformFormClosing(object sender, FormClosingEventArgs e)
		{
			_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(-1, 100));
		}
		
		void DataGridViewsettingsCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewsettings.SelectedRows.Count != 0){
			
			settingdto _settingdto = (settingdto)bindingSourcesettings.Current;
			editsettingform _editsettingform = new editsettingform(_settingdto, this, _notificationmessageEventname, _progressBarNotificationEventname);
			_editsettingform.Text = "Edit [ " + _settingdto.setting_name + " ] ";
			_editsettingform.ShowDialog(); 
		}
		}
		
		void BtneditsettingClick(object sender, EventArgs e)
		{
			if (dataGridViewsettings.SelectedRows.Count != 0){
			
			settingdto _settingdto = (settingdto)bindingSourcesettings.Current;
			editsettingform _editsettingform = new editsettingform(_settingdto, this, _notificationmessageEventname, _progressBarNotificationEventname);
			_editsettingform.Text = "Edit [ " + _settingdto.setting_name + " ] ";
			_editsettingform.ShowDialog(); 
			}
		}
		
		void BtndeletesettingClick(object sender, EventArgs e)
		{
			if (dataGridViewsettings.SelectedRows.Count != 0){
			
			settingdto _settingdto = (settingdto)bindingSourcesettings.Current; 
			if(msgboxform.Show(String.Format("are you sure you want to delete setting [ {0} ]", _settingdto.setting_name), TAG, msgtype.warn) == DialogResult.OK){
			deletefromdatastore(_settingdto);
			}
			}
		}
		
		void deletefromdatastore(settingdto _settingdto){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(String.Format("deleting setting [ {0} ]", _settingdto.setting_name), TAG)); 
			bool numberOfRowsAffected = false;
			numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).deletesettingindatabase(_settingdto);
			if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully deleted setting in mssql db...", TAG));
		    	populatesettingslist("");
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("error deleting setting in mssql db...", TAG));
			}
		}
		 
		void ChkshowinactiveCheckedChanged(object sender, EventArgs e)
		{
			if(chkshowinactive.Checked){
				string query = DBContract.SETTINGS_SELECT_ALL_QUERY;
				populatesettingslist(query); 
			}else{
				string query = DBContract.SETTINGS_SELECT_ALL_FILTER_QUERY;
				populatesettingslist(query);
			}
		}
	}
}
