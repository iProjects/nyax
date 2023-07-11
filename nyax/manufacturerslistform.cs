/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 16:40
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
	/// Description of manufacturerslistform.
	/// </summary>
	public partial class manufacturerslistform : Form
	{	
		public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		string _working_db = "";
		
		public manufacturerslistform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
			 
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("initialized manufacturerslistform", TAG));
		}
		
		void BtncreatemanufacturerClick(object sender, EventArgs e)
		{
			createmanufacturerform _createmanufacturerform=new createmanufacturerform(_notificationmessageEventname, _progressBarNotificationEventname);
			_createmanufacturerform.ShowDialog();  
			populatemanufacturerslist();
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void ManufacturerslistformLoad(object sender, EventArgs e)
		{
			this.AcceptButton=btncreatemanufacturer;
			this.CancelButton=btnclose; 
			populatemanufacturerslist(); 
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loaded manufacturerslistform", TAG));
		}
		
		public void populatemanufacturerslist(string nullable_query = ""){
		try{
				
				bindingSourcemanufacturers.DataSource = null;
				dataGridViewmanufacturers.DataSource = null;
				groupBoxlst.Text = "";
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			    
				List<manufacturerdto> _manufacturerslst=new List<manufacturerdto>();
				string query = "";
				 if(!String.IsNullOrEmpty(nullable_query)){
				 	query = nullable_query;
				 }else{
				 	if(chkshowinactive.Checked){
						query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY; 
					}else{
						query = DBContract.MANUFACTURERS_SELECT_ALL_FILTER_QUERY; 
					}
				 } 
					
			 	dt = businesslayerapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getmanufacturers();
			 	
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
				
				var _recordscount = dt.Rows.Count;
				for(int i = 0; i < _recordscount; i++){
					
					manufacturerdto _manufacturerdto = utilzsingleton.getInstance(_notificationmessageEventname).buildmanufacturerdtogivendatatable(dt, i);

					_manufacturerslst.Add(_manufacturerdto);  

					_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));
				}

				_manufacturerslst.Reverse();

				groupBoxlst.Text = "count [ " + _manufacturerslst.Count.ToString() + " ] working db [ " +  _working_db + " ]";
				bindingSourcemanufacturers.DataSource = _manufacturerslst;
				dataGridViewmanufacturers.DataSource = bindingSourcemanufacturers;
				dataGridViewmanufacturers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				dataGridViewmanufacturers.MultiSelect = false;
				dataGridViewmanufacturers.ReadOnly = true;
				dataGridViewmanufacturers.AllowUserToAddRows = false;
				dataGridViewmanufacturers.AllowUserToDeleteRows = false;
				dataGridViewmanufacturers.AutoGenerateColumns = false;
				dataGridViewmanufacturers.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { 
					BackColor = utilzsingleton.getInstance(_notificationmessageEventname).AlternatingRowsDefaultCellStyleBackColor,
 					ForeColor = utilzsingleton.getInstance(_notificationmessageEventname).AlternatingRowsDefaultCellStyleForeColor 
				}; 
				 
				}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				msgboxform.Show(ex.Message, TAG, msgtype.error);	 
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
		  
		void ManufacturerslistformFormClosing(object sender, FormClosingEventArgs e)
		{
			_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(-1, 100)); 
		}
		 
		void DataGridViewmanufacturersCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewmanufacturers.SelectedRows.Count != 0){
		
			manufacturerdto _manufacturerdto = (manufacturerdto)bindingSourcemanufacturers.Current;
			editmanufacturerform _editmanufacturerform = new editmanufacturerform(_manufacturerdto, this, _notificationmessageEventname, _progressBarNotificationEventname);
			_editmanufacturerform.Text = "Edit [ " + _manufacturerdto.manufacturer_name + " ]";
			_editmanufacturerform.ShowDialog(); 
		}
		}
		
		void BtneditmanufacturerClick(object sender, EventArgs e)
		{
			if (dataGridViewmanufacturers.SelectedRows.Count != 0){
			
			manufacturerdto _manufacturerdto = (manufacturerdto)bindingSourcemanufacturers.Current;
			editmanufacturerform _editmanufacturerform = new editmanufacturerform(_manufacturerdto, this, _notificationmessageEventname, _progressBarNotificationEventname);
			_editmanufacturerform.Text = "Edit [ " + _manufacturerdto.manufacturer_name + " ]";
			_editmanufacturerform.ShowDialog();
			}
		}
		
		void BtndeletemanufacturerClick(object sender, EventArgs e)
		{
			if (dataGridViewmanufacturers.SelectedRows.Count != 0){
			
			manufacturerdto _manufacturerdto = (manufacturerdto)bindingSourcemanufacturers.Current; 
			if(msgboxform.Show(String.Format("are you sure you want to delete manufacturer [ {0} ]", _manufacturerdto.manufacturer_name), TAG, msgtype.warn) == DialogResult.OK){
			deletefromdatastore(_manufacturerdto);
			}
			}
		}
		
		void deletefromdatastore(manufacturerdto _manufacturerdto){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(String.Format("deleting manufacturer [ {0} ]", _manufacturerdto.manufacturer_name), TAG)); 
			bool numberOfRowsAffected = false;
			numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).deletemanufacturerindatabase(_manufacturerdto);
			if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully deleted manufacturer in mssql db...", TAG));
		    	populatemanufacturerslist();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("error deleting manufacturer in mssql db...", TAG));
			}
		}
		 
		void ChkshowinactiveCheckedChanged(object sender, EventArgs e)
		{
			if(chkshowinactive.Checked){
				string query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY;
				populatemanufacturerslist(query); 
			}else{
				string query = DBContract.MANUFACTURERS_SELECT_ALL_FILTER_QUERY;
				populatemanufacturerslist(query);
			}
		}
		
		
		
		
	}
}
