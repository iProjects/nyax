/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 12/18/2018
 * Time: 10:16 PM
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
	/// Description of categorieslistform.
	/// </summary>
	public partial class categorieslistform : Form
	{
		public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		string _working_db = "";
		
		public categorieslistform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
			
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("initialized categorieslistform", TAG));
		}
		
		void CategorieslistformLoad(object sender, EventArgs e)
		{
			this.AcceptButton=btncreatecategory;
			this.CancelButton=btnclose; 
			populatecategorieslist();
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loaded categorieslistform", TAG));
		}
		
		void BtncreatecategoryClick(object sender, EventArgs e)
		{
			createcategoryform _createcategoryform = new createcategoryform(_notificationmessageEventname, _progressBarNotificationEventname);
			_createcategoryform.ShowDialog();
			populatecategorieslist();
		}
		
		public void populatecategorieslist(string nullable_query = "")
		{
			try{
				
			bindingSourcecategories.DataSource = null;
			dataGridViewcategories.DataSource = null;
			groupBoxlst.Text = "";
			DataTable mssql_dt = null;
		    DataTable mysql_dt = null;
		    DataTable sqlite_dt = null;
		    DataTable dt = null;
		     
			List<categorydto> _categorieslst=new List<categorydto>();
			string query = "";
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(chkshowinactive.Checked){
					query = DBContract.CATEGORIES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CATEGORIES_SELECT_ALL_FILTER_QUERY; 
				}
			 }
			 
			 dt = businesslayerapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getcategories();
			 
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
				
				categorydto _categorydto = utilzsingleton.getInstance(_notificationmessageEventname).buildcategorydtogivendatatable(dt, i);
		
				_categorieslst.Add(_categorydto);  
				
				_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));
						
			}
			
			_categorieslst.Reverse();
			 
			groupBoxlst.Text = "count [ " + _categorieslst.Count.ToString() + " ] working db [ " +  _working_db + " ]";
			bindingSourcecategories.DataSource = _categorieslst;
			dataGridViewcategories.DataSource = bindingSourcecategories;
			dataGridViewcategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewcategories.MultiSelect = false;
			dataGridViewcategories.ReadOnly = true;
			dataGridViewcategories.AllowUserToAddRows = false;
			dataGridViewcategories.AllowUserToDeleteRows = false;
			dataGridViewcategories.AutoGenerateColumns = false;
			dataGridViewcategories.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { 
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql categories count: " + mssql_dt.Rows.Count, TAG));
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql categories count: " + mysql_dt.Rows.Count, TAG));
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite categories count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		void BtneditcategoryClick(object sender, EventArgs e)
		{
			if (dataGridViewcategories.SelectedRows.Count != 0){			
				categorydto _categorydto = (categorydto)bindingSourcecategories.Current;
				editcategoryform _editcategoryform = new editcategoryform(_categorydto, this, _notificationmessageEventname, _progressBarNotificationEventname);
				_editcategoryform.Text = "Edit [ " + _categorydto.category_name + " ]";
				_editcategoryform.ShowDialog(); 
			}
		}
		
		void BtndeletecategoryClick(object sender, EventArgs e)
		{
			if (dataGridViewcategories.SelectedRows.Count != 0){
			
				categorydto _categorydto = (categorydto)bindingSourcecategories.Current;
				if(msgboxform.Show(String.Format("are you sure you want to delete category [ {0} ]", _categorydto.category_name), TAG, msgtype.warn) == DialogResult.OK){
				deletefromdatastore(_categorydto);
				}
			}
		}
		
		void deletefromdatastore(categorydto _categorydto){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(String.Format("deleting category [ {0} ]", _categorydto.category_name), TAG)); 
			bool numberOfRowsAffected = false;
			//numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).deletecategoryindatabase(_categorydto);
			if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully deleted category in mssql db...", TAG));
		    	populatecategorieslist();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("error deleting category in mssql db...", TAG));
			}
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void ChkshowinactiveCheckedChanged(object sender, EventArgs e)
		{
			if(chkshowinactive.Checked){
				string query = DBContract.CATEGORIES_SELECT_ALL_QUERY;
				populatecategorieslist(query); 
			}else{
				string query = DBContract.CATEGORIES_SELECT_ALL_FILTER_QUERY;
				populatecategorieslist(query);
			}
		}
		
		void CategorieslistformFormClosing(object sender, FormClosingEventArgs e)
		{
			_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(-1, 100)); 
		}
		
		void DataGridViewcategoriesCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewcategories.SelectedRows.Count != 0){
			
			categorydto _categorydto = (categorydto)bindingSourcecategories.Current;
			editcategoryform _editcategoryform = new editcategoryform(_categorydto, this, _notificationmessageEventname, _progressBarNotificationEventname);
			_editcategoryform.Text = "Edit [ " + _categorydto.category_name + " ]";
			_editcategoryform.ShowDialog(); 
			}
		}
	}
}
