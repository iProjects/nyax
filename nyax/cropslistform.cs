/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/08/2018
 * Time: 10:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using nthareneapi;

namespace nyax
{
	/// <summary>
	/// Description of cropslistform.
	/// </summary>
	public partial class cropslistform : Form
	{	
		public string TAG;
	 
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		string _working_db = "";
		
		public cropslistform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
			
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("initialized cropslistform", TAG));
		}
		
		void CropslistformLoad(object sender, EventArgs e)
		{ 
			this.AcceptButton=btncreatecrop;
			this.CancelButton=btnclose; 
			populatecropslist(); 
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loaded cropslistform", TAG));
		}
		
		public void populatecropslist(string nullable_query = ""){
		try{
			 
			 bindingSourcecrops.DataSource = null;
		     dataGridViewcrops.DataSource = null; 
		     groupBoxlst.Text = "";
		     DataTable mssql_dt = null;
		     DataTable mysql_dt = null;
		     DataTable sqlite_dt = null;
		     DataTable postgresql_dt = null;
		     DataTable dt = null;

			 List<cropdto> _cropslst = new List<cropdto>();
			 string query = "";
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(chkshowinactive.Checked){
					query = DBContract.CROPS_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CROPS_SELECT_ALL_FILTER_QUERY; 
				}
			 }

			 dt = businesslayerapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getcrops();
			 
			 _working_db = businesslayerapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname)._working_db;
			 
			 _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("working db [ " +  _working_db + " ]", TAG));
			 
//			 mssql_dt = getallrecordsfrommssql(query); 
//			 
//			 mysql_dt = getallrecordsfrommysql(query); 
//			 
//			 sqlite_dt = getallrecordsfromsqlite(query);
//			 
//	  		 postgresql_dt = getallrecordsfrompostgresql(query);
//	  
//			 if(mssql_dt != null){
//			 	dt = mssql_dt;
//			 	_working_db = DBContract.mssql;
//			 }
//			 if(mssql_dt == null && mysql_dt != null){
//			 	dt = mysql_dt;
//			 	_working_db = DBContract.mysql;
//			 }
//			 if(mssql_dt == null && mysql_dt == null && sqlite_dt != null){
//			 	dt = sqlite_dt;
//			 	_working_db = DBContract.sqlite;
//			 }
			  
			 if(dt == null)return;
			 
			var _recordscount = dt.Rows.Count;
			for(int i = 0; i < _recordscount; i++){

				cropdto _cropdto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdtogivendatatable(dt, i);

				_cropslst.Add(_cropdto); 

				_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));
			}

			_cropslst.Reverse();

			groupBoxlst.Text = "count [ " + _cropslst.Count.ToString() + " ] working db [ " +  _working_db + " ]";
			bindingSourcecrops.DataSource = _cropslst;
			dataGridViewcrops.DataSource = bindingSourcecrops; 
			dataGridViewcrops.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewcrops.MultiSelect = false;
			dataGridViewcrops.ReadOnly = true;
			dataGridViewcrops.AllowUserToAddRows = false;
			dataGridViewcrops.AllowUserToDeleteRows = false;
			dataGridViewcrops.AutoGenerateColumns = false;
			dataGridViewcrops.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { 
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql crops count: " + mssql_dt.Rows.Count, TAG));
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql crops count: " + mysql_dt.Rows.Count, TAG));
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite crops count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		DataTable getallrecordsfrompostgresql(string query){
			try{
				
			DataTable postgresql_dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (postgresql_dt != null && postgresql_dt.Rows.Count != 0){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql crops count: " + postgresql_dt.Rows.Count, TAG));
			 }
			 return postgresql_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void BtncreatecropClick(object sender, EventArgs e)
		{
			createcropform _createcropform=new createcropform(_notificationmessageEventname, _progressBarNotificationEventname);
			_createcropform.ShowDialog();  
			populatecropslist(); 
		}
		  
		void CropslistformFormClosing(object sender, FormClosingEventArgs e)
		{ 
			_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(-1, 100)); 
		}
		
		void DataGridViewcropsCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewcrops.SelectedRows.Count != 0){
			
			cropdto _cropdto = (cropdto)bindingSourcecrops.Current;
			editcropform _editcropform = new editcropform(_cropdto, this, _notificationmessageEventname, _working_db, _progressBarNotificationEventname);
			_editcropform.Text = "Edit [ " + _cropdto.crop_name + " ] ";
			_editcropform.ShowDialog(); 
			}
		}
		
		void BtndeleteClick(object sender, EventArgs e)
		{  
			if (dataGridViewcrops.SelectedRows.Count != 0){
			
			 	cropdto _cropdto = (cropdto)bindingSourcecrops.Current;
			 	
				if(msgboxform.Show(String.Format("are you sure you want to delete crop [ {0} ]", _cropdto.crop_name), TAG, msgtype.warn) == DialogResult.OK){
					deletefromdatastore(_cropdto);
				}
			 	
			}
		}
		
		void deletefromdatastore(cropdto _cropdto){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(String.Format("deleting crop [ {0} ]", _cropdto.crop_name), TAG)); 
			bool numberOfRowsAffected = false;
			numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).deletecropindatabase(_cropdto);
			if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully deleted crop in mssql db...", TAG));
		    	populatecropslist();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("error deleting crop in mssql db...", TAG));
			}
		}
		 
		void ChkshowinactiveCheckedChanged(object sender, EventArgs e)
		{
			if(chkshowinactive.Checked){
				string query = DBContract.CROPS_SELECT_ALL_QUERY;
				populatecropslist(query); 
			}else{
				string query = DBContract.CROPS_SELECT_ALL_FILTER_QUERY;
				populatecropslist(query);
			}
		}
		 
		void BtneditcropClick(object sender, EventArgs e)
		{
			if (dataGridViewcrops.SelectedRows.Count != 0){
			
			cropdto _cropdto = (cropdto)bindingSourcecrops.Current;
			editcropform _editcropform = new editcropform(_cropdto, this, _notificationmessageEventname, _working_db, _progressBarNotificationEventname);
			_editcropform.Text = "Edit [ " + _cropdto.crop_name + " ] ";
			_editcropform.ShowDialog(); 
			}
		}
		
		
		
	}
}
