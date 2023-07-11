/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 10/23/2018
 * Time: 20:53
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
	/// Description of cropsvarietieslistform.
	/// </summary>
	public partial class cropsvarietieslistform : Form
	{	
		public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		string _working_db = "";
		
		public cropsvarietieslistform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
			 
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("initialized cropsvarietieslistform", TAG));
		}
		
		void BtncreatecropvarietyClick(object sender, EventArgs e)
		{
			createcropvarietyform _createcropvarietyform=new createcropvarietyform(_notificationmessageEventname, _progressBarNotificationEventname);
			_createcropvarietyform.ShowDialog();  
			populatecropsvarietieslist();
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void cropsvarietieslistformLoad(object sender, EventArgs e)
		{
			this.AcceptButton=btncreatecropvariety;
			this.CancelButton=btnclose; 
			populatecropsvarietieslist(); 
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loaded cropsvarietieslistform", TAG));
		}
		
		public void populatecropsvarietieslist(string nullable_query = ""){
		try{
				
				bindingSourcecropsvarieties.DataSource = null;
				dataGridViewcropsvarieties.DataSource = null;
				groupBoxlst.Text = "";
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			    
				List<cropvarietydto> _cropsvarietieslst=new List<cropvarietydto>();
				string query = "";
				 if(!String.IsNullOrEmpty(nullable_query)){
				 	query = nullable_query;
				 }else{
				 	if(chkshowinactive.Checked){
						query = DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY; 
					}else{
						query = DBContract.CROPS_VARIETIES_SELECT_ALL_FILTER_QUERY; 
					}
				 }
				
			 	dt = businesslayerapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getcropsvarieties();
			 	
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
					 
					cropvarietydto _cropvarietydto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropvarietydtogivendatatable(dt, i);
	
					_cropsvarietieslst.Add(_cropvarietydto);  
						
					_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));
				}
				
				_cropsvarietieslst.Reverse();
			  	
				List<ui_cropvarietydto> _ui_cropvarietydtolst = new List<ui_cropvarietydto>();
				
				foreach (var _cropvarietydto in _cropsvarietieslst) 
				{
					ui_cropvarietydto _ui_cropvarietydto = convertdaldtointoui_dto(_cropvarietydto);
					
					_ui_cropvarietydtolst.Add(_ui_cropvarietydto);	
				}
				
				groupBoxlst.Text = "count [ " + _ui_cropvarietydtolst.Count.ToString() + " ] working db [ " +  _working_db + " ]";
				bindingSourcecropsvarieties.DataSource = _ui_cropvarietydtolst;
				dataGridViewcropsvarieties.DataSource = bindingSourcecropsvarieties;
				dataGridViewcropsvarieties.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				dataGridViewcropsvarieties.MultiSelect = false;
				dataGridViewcropsvarieties.ReadOnly = true;
				dataGridViewcropsvarieties.AllowUserToAddRows = false;
				dataGridViewcropsvarieties.AllowUserToDeleteRows = false;
				dataGridViewcropsvarieties.AutoGenerateColumns = false;
				dataGridViewcropsvarieties.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { 
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql cropsvarieties count: " + mssql_dt.Rows.Count, TAG));
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql cropsvarieties count: " + mysql_dt.Rows.Count, TAG));
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
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite cropsvarieties count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		void cropsvarietieslistformFormClosing(object sender, FormClosingEventArgs e)
		{
			_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(-1, 100)); 
		}
		 
		void DataGridViewcropsvarietiesCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewcropsvarieties.SelectedRows.Count != 0){
			
				ui_cropvarietydto _ui_cropvarietydto = (ui_cropvarietydto)bindingSourcecropsvarieties.Current;
				 
				cropvarietydto _cropvarietydto = convertui_dtointodaldto(_ui_cropvarietydto);
				  
				editcropvarietyform _editcropvarietyform = new editcropvarietyform(_cropvarietydto, this, _notificationmessageEventname, _progressBarNotificationEventname);
				_editcropvarietyform.Text = "Edit [ " + _cropvarietydto.crop_variety_name + " ]";
				_editcropvarietyform.ShowDialog();
			}
		}
		
		void BtneditcropvarietyClick(object sender, EventArgs e)
		{
			if (dataGridViewcropsvarieties.SelectedRows.Count != 0){
			 	
				ui_cropvarietydto _ui_cropvarietydto = (ui_cropvarietydto)bindingSourcecropsvarieties.Current;
				 
				cropvarietydto _cropvarietydto = convertui_dtointodaldto(_ui_cropvarietydto);
				  
				editcropvarietyform _editcropvarietyform = new editcropvarietyform(_cropvarietydto, this, _notificationmessageEventname, _progressBarNotificationEventname);
				_editcropvarietyform.Text = "Edit [ " + _cropvarietydto.crop_variety_name + " ]";
				_editcropvarietyform.ShowDialog(); 
			
			}
		}
		
		void BtndeletecropvarietyClick(object sender, EventArgs e)
		{
			if (dataGridViewcropsvarieties.SelectedRows.Count != 0){
			 	
				ui_cropvarietydto _ui_cropvarietydto = (ui_cropvarietydto)bindingSourcecropsvarieties.Current;
				 
				cropvarietydto _cropvarietydto = convertui_dtointodaldto(_ui_cropvarietydto);
				  
				if(msgboxform.Show(String.Format("are you sure you want to delete cropvariety [ {0} ]", _cropvarietydto.crop_variety_name), TAG, msgtype.warn) == DialogResult.OK){
					deletefromdatastore(_cropvarietydto);
				}
			}
		}
		
		void deletefromdatastore(cropvarietydto _cropvarietydto){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(String.Format("deleting cropvariety [ {0} ]", _cropvarietydto.crop_variety_name), TAG)); 
			bool numberOfRowsAffected = false;
			numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).deletecropvarietyindatabase(_cropvarietydto);
			if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully deleted cropvariety in mssql db...", TAG));
		    	populatecropsvarietieslist();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("error deleting cropvariety in mssql db...", TAG));
			}
		}
		 
		void ChkshowinactiveCheckedChanged(object sender, EventArgs e)
		{
			if(chkshowinactive.Checked){
				string query = DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY;
				populatecropsvarietieslist(query); 
			}else{
				string query = DBContract.CROPS_VARIETIES_SELECT_ALL_FILTER_QUERY;
				populatecropsvarietieslist(query);
			}
		}
		
	    ui_cropvarietydto convertdaldtointoui_dto(cropvarietydto _cropvarietydto)
	    {
	    	ui_cropvarietydto _ui_cropvarietydto = new ui_cropvarietydto();
				
			_ui_cropvarietydto.crop_variety_id = _cropvarietydto.crop_variety_id;
			_ui_cropvarietydto.crop_variety_name = _cropvarietydto.crop_variety_name;
			
			_ui_cropvarietydto.crop_variety_status = _cropvarietydto.crop_variety_status;
			_ui_cropvarietydto.created_date = _cropvarietydto.created_date;
	
			_ui_cropvarietydto.crop_variety_crop_name = get_crop_name_given_id(_cropvarietydto.crop_variety_crop_id);
			_ui_cropvarietydto.crop_variety_manufacturer_name = get_manufacturer_name_given_id(_cropvarietydto.crop_variety_manufacturer_id);
			
			return _ui_cropvarietydto;
	    }
		
	    cropvarietydto convertui_dtointodaldto(ui_cropvarietydto _ui_cropvarietydto)
	    {
	    	cropvarietydto _cropvarietydto = new cropvarietydto();
			
			_cropvarietydto.crop_variety_id = _ui_cropvarietydto.crop_variety_id;
			_cropvarietydto.crop_variety_name = _ui_cropvarietydto.crop_variety_name;
			
			_cropvarietydto.crop_variety_status = _ui_cropvarietydto.crop_variety_status;
			_cropvarietydto.created_date = _ui_cropvarietydto.created_date;
			
			_cropvarietydto.crop_variety_crop_id = get_crop_id_given_name(_ui_cropvarietydto.crop_variety_crop_name);
			_cropvarietydto.crop_variety_manufacturer_id = get_manufacturer_id_given_name(_ui_cropvarietydto.crop_variety_manufacturer_name);
			
			return _cropvarietydto;
	    }
		
		string get_crop_id_given_name(string dto_name)
		{
			try{
				
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			     
			 	string query = "";
				 
			 	if(chkshowinactive.Checked){
					query = DBContract.CROPS_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CROPS_SELECT_ALL_FILTER_QUERY; 
				} 
			  
				 mssql_dt = getallrecordsfrommssql(query); 
				 
				 mysql_dt = getallrecordsfrommysql(query); 
				 
				 sqlite_dt = getallrecordsfromsqlite(query); 
		  
				 if(mssql_dt != null){
				 	dt = mssql_dt;
				 	_working_db = "mssql";
				 }
				 if(mssql_dt == null && mysql_dt != null){
				 	dt = mysql_dt;
				 	_working_db = "mysql";
				 }
				 if(mssql_dt == null && mysql_dt == null && sqlite_dt != null){
				 	dt = sqlite_dt;
				 	_working_db = "sqlite";
				 }
				 
				 if(dt == null)return null;
				 
				var _recordscount = dt.Rows.Count;
				 
				for(int i = 0; i < _recordscount; i++){

					cropdto _cropdto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdtogivendatatable(dt, i);
					 
					var _record_from_server = Convert.ToString(dt.Rows[i]["crop_name"]);

					if(dto_name == _record_from_server){
						return Convert.ToString(dt.Rows[i]["crop_id"]);
					}
					
				}
				return null;
			}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return null; 
			}
		}
		
		string get_manufacturer_id_given_name(string dto_name)
		{
			try{
				
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			     
			 	string query = "";
				 
			 	if(chkshowinactive.Checked){
					query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.MANUFACTURERS_SELECT_ALL_FILTER_QUERY; 
				} 
			  
				 mssql_dt = getallrecordsfrommssql(query); 
				 
				 mysql_dt = getallrecordsfrommysql(query); 
				 
				 sqlite_dt = getallrecordsfromsqlite(query); 
		  
				 if(mssql_dt != null){
				 	dt = mssql_dt;
				 	_working_db = "mssql";
				 }
				 if(mssql_dt == null && mysql_dt != null){
				 	dt = mysql_dt;
				 	_working_db = "mysql";
				 }
				 if(mssql_dt == null && mysql_dt == null && sqlite_dt != null){
				 	dt = sqlite_dt;
				 	_working_db = "sqlite";
				 }
				 
				 if(dt == null)return null;
				 
				var _recordscount = dt.Rows.Count;
				 
				for(int i = 0; i < _recordscount; i++){

					manufacturerdto _manufacturerdto = utilzsingleton.getInstance(_notificationmessageEventname).buildmanufacturerdtogivendatatable(dt, i);
					 
					var _record_from_server = Convert.ToString(dt.Rows[i]["manufacturer_name"]);

					if(dto_name == _record_from_server){
						return Convert.ToString(dt.Rows[i]["manufacturer_id"]);
					}
					
				}
				return null;
			}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return null; 
			}
		}
		
		string get_crop_name_given_id(string dto_id)
		{
			try{
				
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			     
			 	string query = "";
				 
			 	if(chkshowinactive.Checked){
					query = DBContract.CROPS_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CROPS_SELECT_ALL_FILTER_QUERY; 
				} 
			  
				 mssql_dt = getallrecordsfrommssql(query); 
				 
				 mysql_dt = getallrecordsfrommysql(query); 
				 
				 sqlite_dt = getallrecordsfromsqlite(query); 
		  
				 if(mssql_dt != null){
				 	dt = mssql_dt;
				 	_working_db = "mssql";
				 }
				 if(mssql_dt == null && mysql_dt != null){
				 	dt = mysql_dt;
				 	_working_db = "mysql";
				 }
				 if(mssql_dt == null && mysql_dt == null && sqlite_dt != null){
				 	dt = sqlite_dt;
				 	_working_db = "sqlite";
				 }
				 
				 if(dt == null)return null;
				 
				var _recordscount = dt.Rows.Count;
				 
				for(int i = 0; i < _recordscount; i++){

					cropdto _cropdto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdtogivendatatable(dt, i);
 
					var _record_from_server = Convert.ToString(dt.Rows[i]["crop_id"]);

					if(dto_id == _record_from_server){
						return Convert.ToString(dt.Rows[i]["crop_name"]);
					}
					
				}
				return null;
			}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return null; 
			}
		}
		
		string get_manufacturer_name_given_id(string dto_id)
		{
			try{
				
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			     
			 	string query = "";
				 
			 	if(chkshowinactive.Checked){
					query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.MANUFACTURERS_SELECT_ALL_FILTER_QUERY; 
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
				 
				 if(dt == null)return null;
				 
				var _recordscount = dt.Rows.Count;
				 
				for(int i = 0; i < _recordscount; i++){

					manufacturerdto _manufacturerdto = utilzsingleton.getInstance(_notificationmessageEventname).buildmanufacturerdtogivendatatable(dt, i);
 
					var _record_from_server = Convert.ToString(dt.Rows[i]["manufacturer_id"]);

					if(dto_id == _record_from_server){
						return Convert.ToString(dt.Rows[i]["manufacturer_name"]);
					}
					
				}
				return null;
			}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return null; 
			}
		}
		
		
		 
	}
}
