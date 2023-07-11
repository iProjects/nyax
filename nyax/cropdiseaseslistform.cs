/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 21:49
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
	/// Description of cropdiseaseslistform.
	/// </summary>
	public partial class cropdiseaseslistform : Form
	{	
		public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		string _working_db = "";
		
		public cropdiseaseslistform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
			
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("initialized diseases/pests list form", TAG));
		}
		
		void CropdiseaseslistformLoad(object sender, EventArgs e)
		{ 
			this.AcceptButton=btncreatecropdisease;
			this.CancelButton=btnclose; 
			populatecropsdiseaseslist();
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loaded diseases/pests list form", TAG));
		}
		
		public void populatecropsdiseaseslist(string nullable_query = ""){
		try{
				
			bindingSourcecropdiseases.DataSource = null;
			dataGridViewcropdiseases.DataSource = null;
			groupBoxlst.Text = "";
			DataTable mssql_dt = null;
		    DataTable mysql_dt = null;
		    DataTable sqlite_dt = null;
		    DataTable dt = null;
		     
			List<cropdiseasedto> _cropsdiseaseslst=new List<cropdiseasedto>();
			string query = "";
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(chkshowinactive.Checked){
					query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CROPS_DISEASES_SELECT_ALL_FILTER_QUERY; 
				}
			 }
			 
			 dt = businesslayerapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getdiseasespests();
			 
			 _working_db = businesslayerapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname)._working_db;
			 
			 _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("working db [ " +  _working_db + " ]", TAG));
			 
//			 mssql_dt = getallrecordsfrommssql(query); 
//			 
//			 mysql_dt = getallrecordsfrommysql(query); 
//			 
//			 sqlite_dt = getallrecordsfromsqlite(query); 
//	  
//			 if(mssql_dt != null){
//			 	dt = mssql_dt;
//			 	_working_db = "mssql";
//			 }
//			 if(mssql_dt == null && mysql_dt != null){
//			 	dt = mysql_dt;
//			 	_working_db = "mysql";
//			 }
//			 if(mssql_dt == null && mysql_dt == null && sqlite_dt != null){
//			 	dt = sqlite_dt;
//			 	_working_db = "sqlite";
//			 }
			  
			 if(dt == null)return;
			  
			var _recordscount = dt.Rows.Count;
			
			for(int i = 0; i < _recordscount; i++){
				
				cropdiseasedto _cropdiseasedto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdiseasedtogivendatatable(dt, i);
							 
				_cropsdiseaseslst.Add(_cropdiseasedto);  
					 
				_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));
						
			}
			
			_cropsdiseaseslst.Reverse();
			 
			groupBoxlst.Text = "count [ " + _cropsdiseaseslst.Count.ToString() + " ] working db [ " +  _working_db + " ]";
			bindingSourcecropdiseases.DataSource = _cropsdiseaseslst;
			dataGridViewcropdiseases.DataSource = bindingSourcecropdiseases;
			dataGridViewcropdiseases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewcropdiseases.MultiSelect = false;
			dataGridViewcropdiseases.ReadOnly = true;
			dataGridViewcropdiseases.AllowUserToAddRows = false;
			dataGridViewcropdiseases.AllowUserToDeleteRows = false;
			dataGridViewcropdiseases.AutoGenerateColumns = false;
			dataGridViewcropdiseases.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { 
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql diseases/pests count: " + mssql_dt.Rows.Count, TAG));
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql diseases/pests count: " + mysql_dt.Rows.Count, TAG));
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite diseases/pests count: " + sqlite_dt.Rows.Count, TAG));
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
		 
		void BtncreatecropdiseaseClick(object sender, EventArgs e)
		{
			createcropdiseaseform _createcropdiseaseform = new createcropdiseaseform(_notificationmessageEventname, _progressBarNotificationEventname);
			_createcropdiseaseform.ShowDialog();
			populatecropsdiseaseslist();
		}
		
		void CropdiseaseslistformFormClosing(object sender, FormClosingEventArgs e)
		{
				_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(-1, 100)); 
		}
		
		void DataGridViewcropdiseasesCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewcropdiseases.SelectedRows.Count != 0){
			
			cropdiseasedto _cropdiseasedto = (cropdiseasedto)bindingSourcecropdiseases.Current;
			editcropdiseaseform _editcropdiseaseform = new editcropdiseaseform(_cropdiseasedto, this, _notificationmessageEventname, _progressBarNotificationEventname);
			_editcropdiseaseform.Text = "Edit [ " + _cropdiseasedto.crop_disease_name + " ]";
			_editcropdiseaseform.ShowDialog(); 
			}
		}
		 
		void BtndeletecropdiseaseClick(object sender, EventArgs e)
		{
			if (dataGridViewcropdiseases.SelectedRows.Count != 0){
			
			cropdiseasedto _cropdiseasedto = (cropdiseasedto)bindingSourcecropdiseases.Current; 
			if(msgboxform.Show(String.Format("are you sure you want to delete disease/pest [ {0} ]", _cropdiseasedto.crop_disease_name), TAG, msgtype.warn) == DialogResult.OK){
			deletefromdatastore(_cropdiseasedto);
			}
			}
		}
		
		void deletefromdatastore(cropdiseasedto _cropdiseasedto){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(String.Format("deleting disease/pest [ {0} ]", _cropdiseasedto.crop_disease_name), TAG)); 
			bool numberOfRowsAffected = false;
			numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).deletecropdiseaseindatabase(_cropdiseasedto);
			if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully deleted disease/pest in mssql db...", TAG));
		    	populatecropsdiseaseslist();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("error deleting disease/pest in mssql db...", TAG));
			}
		}
		 
		void BtneditcropdiseaseClick(object sender, EventArgs e)
		{
			if (dataGridViewcropdiseases.SelectedRows.Count != 0){
			
			cropdiseasedto _cropdiseasedto = (cropdiseasedto)bindingSourcecropdiseases.Current;
			editcropdiseaseform _editcropdiseaseform = new editcropdiseaseform(_cropdiseasedto, this, _notificationmessageEventname, _progressBarNotificationEventname);
			_editcropdiseaseform.Text = "Edit [ " + _cropdiseasedto.crop_disease_name + " ]";
			_editcropdiseaseform.ShowDialog(); 
			}
		}
		
		void ChkshowinactiveCheckedChanged(object sender, EventArgs e)
		{
			if(chkshowinactive.Checked){
				string query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY;
				populatecropsdiseaseslist(query); 
			}else{
				string query = DBContract.CROPS_DISEASES_SELECT_ALL_FILTER_QUERY;
				populatecropsdiseaseslist(query);
			}
		}
		
		
		
		
	}
}
