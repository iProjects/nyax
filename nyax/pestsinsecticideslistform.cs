/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 07:05
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
	/// Description of pestinsecticidelistform.
	/// </summary>
	public partial class pestsinsecticideslistform : Form
	{	
		public string TAG;
	
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		string _working_db = "";
		
		public pestsinsecticideslistform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
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
		
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("initialized pestsinsecticideslistform", TAG));
		}
		
		void PestsinsecticideslistformLoad(object sender, EventArgs e)
		{
			this.AcceptButton=btncreatepestinsecticide;
			this.CancelButton=btnclose; 
			populatepestsinsecticideslist();
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loaded pestsinsecticideslistform", TAG));
		}
		
		public void populatepestsinsecticideslist(string nullable_query = ""){
			try{
				
			bindingSourcepestsinsecticides.DataSource = null;
			dataGridViewpestsinsecticides.DataSource = null;
			groupBoxlst.Text = "";
			DataTable mssql_dt = null;
		    DataTable mysql_dt = null;
		    DataTable sqlite_dt = null;
		    DataTable dt = null;
		    
			List<pestinsecticidedto> _pestinsecticidelst = new List<pestinsecticidedto>();
			
		 	string query = "";
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(chkshowinactive.Checked){
					query = DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.PESTSINSECTICIDES_SELECT_ALL_FILTER_QUERY; 
				}
			 }
		  	
			 dt = businesslayerapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getpesticidesinsecticides();
			 
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
				
				pestinsecticidedto _pestinsecticidedto = utilzsingleton.getInstance(_notificationmessageEventname).buildpestinsecticidedtogivendatatable(dt, i);
	 
				_pestinsecticidelst.Add(_pestinsecticidedto);  

				_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));
			}
			
			_pestinsecticidelst.Reverse();
			 
			List<ui_pestinsecticidedto> _ui_pestinsecticidedtolst = new List<ui_pestinsecticidedto>();
			
			foreach (var _pestinsecticidedto in _pestinsecticidelst) 
			{
				ui_pestinsecticidedto _ui_pestinsecticidedto = convertdaldtointoui_dto(_pestinsecticidedto);
				 
				_ui_pestinsecticidedtolst.Add(_ui_pestinsecticidedto);	
			}
			
			groupBoxlst.Text = "count [ " + _ui_pestinsecticidedtolst.Count.ToString() + " ] working db [ " +  _working_db + " ]";
			bindingSourcepestsinsecticides.DataSource = _ui_pestinsecticidedtolst;
			dataGridViewpestsinsecticides.DataSource = bindingSourcepestsinsecticides;
			dataGridViewpestsinsecticides.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewpestsinsecticides.MultiSelect = false;
			dataGridViewpestsinsecticides.ReadOnly = true;
			dataGridViewpestsinsecticides.AllowUserToAddRows = false;
			dataGridViewpestsinsecticides.AllowUserToDeleteRows = false;
			dataGridViewpestsinsecticides.AutoGenerateColumns = false;
			dataGridViewpestsinsecticides.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { 
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
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql pesticides/insecticides count: " + mssql_dt.Rows.Count, TAG));
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
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql pesticides/insecticides count: " + mysql_dt.Rows.Count, TAG));
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
				//_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite pesticides/insecticides count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		 
		void BtncreatepestinsecticideClick(object sender, EventArgs e)
		{
			createpestinsecticideform _createpestinsecticideform=new createpestinsecticideform(_notificationmessageEventname, _progressBarNotificationEventname);
			_createpestinsecticideform.ShowDialog();
			populatepestsinsecticideslist();
		}
		
		void BtncloseClick(object sender, EventArgs e)
		{ 		
			this.Close();		
		}
		
		void PestsinsecticideslistformFormClosing(object sender, FormClosingEventArgs e)
		{
			_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(-1, 100));
		}
		
		void DataGridViewpestsinsecticidesCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewpestsinsecticides.SelectedRows.Count != 0){
			 
				ui_pestinsecticidedto _ui_pestinsecticidedto = (ui_pestinsecticidedto)bindingSourcepestsinsecticides.Current;
				 
				pestinsecticidedto _pestinsecticidedto = convertui_dtointodaldto(_ui_pestinsecticidedto);
				 
				editpestinsecticideform _editpestinsecticideform = new editpestinsecticideform(_pestinsecticidedto, this, _notificationmessageEventname, _progressBarNotificationEventname);
				_editpestinsecticideform.Text = "Edit [ " + _pestinsecticidedto.pestinsecticide_name + " ] ";
				_editpestinsecticideform.ShowDialog();
			}
		}
		 
		void BtneditpestinsecticideClick(object sender, EventArgs e)
		{
			if (dataGridViewpestsinsecticides.SelectedRows.Count != 0){
				 	
				ui_pestinsecticidedto _ui_pestinsecticidedto = (ui_pestinsecticidedto)bindingSourcepestsinsecticides.Current;
				 
				pestinsecticidedto _pestinsecticidedto = convertui_dtointodaldto(_ui_pestinsecticidedto);
				 
				editpestinsecticideform _editpestinsecticideform = new editpestinsecticideform(_pestinsecticidedto, this, _notificationmessageEventname, _progressBarNotificationEventname);
				_editpestinsecticideform.Text = "Edit [ " + _pestinsecticidedto.pestinsecticide_name + " ] ";
				_editpestinsecticideform.ShowDialog();
			}
		}
		
		void BtndeletepestinsecticideClick(object sender, EventArgs e)
		{
			if (dataGridViewpestsinsecticides.SelectedRows.Count != 0){
			 
				ui_pestinsecticidedto _ui_pestinsecticidedto = (ui_pestinsecticidedto)bindingSourcepestsinsecticides.Current;
				 
				pestinsecticidedto _pestinsecticidedto = convertui_dtointodaldto(_ui_pestinsecticidedto);
				 
				if(msgboxform.Show(String.Format("are you sure you want to delete pesticide/insecticide [ {0} ]", _pestinsecticidedto.pestinsecticide_name), TAG, msgtype.warn) == DialogResult.OK){
				deletefromdatastore(_pestinsecticidedto);
				}
			}
		}
		
		void deletefromdatastore(pestinsecticidedto _pestinsecticidedto){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(String.Format("deleting pesticide/insecticide [ {0} ]", _pestinsecticidedto.pestinsecticide_name), TAG)); 
			bool numberOfRowsAffected = false;
			numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).deletepestinsecticideindatabase(_pestinsecticidedto);
			if(numberOfRowsAffected){
		    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully deleted pesticide/insecticide in mssql db...", TAG));
		    	populatepestsinsecticideslist("");
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("error deleting pesticide/insecticide in mssql db...", TAG));
			}
		}
		 
		void ChkshowinactiveCheckedChanged(object sender, EventArgs e)
		{
			if(chkshowinactive.Checked){
				string query = DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY;
				populatepestsinsecticideslist(query); 
			}else{
				string query = DBContract.PESTSINSECTICIDES_SELECT_ALL_FILTER_QUERY;
				populatepestsinsecticideslist(query);
			}
		}
		
		string get_category_name_given_id(string dto_id)
		{
			try{
				
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			     
			 	string query = "";
				 
			 	if(chkshowinactive.Checked){
					query = DBContract.CATEGORIES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CATEGORIES_SELECT_ALL_FILTER_QUERY; 
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

					categorydto _categorydto = utilzsingleton.getInstance(_notificationmessageEventname).buildcategorydtogivendatatable(dt, i);
	
					var _record_from_server = Convert.ToString(dt.Rows[i]["category_id"]);

					if(dto_id == _record_from_server){
						return Convert.ToString(dt.Rows[i]["category_name"]);
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
		
		string get_diseasepest_name_given_id(string dto_id)
		{
			try{
				
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			     
			 	string query = "";
				 
			 	if(chkshowinactive.Checked){
					query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CROPS_DISEASES_SELECT_ALL_FILTER_QUERY; 
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

					cropdiseasedto _cropdiseasedto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdiseasedtogivendatatable(dt, i);
	
					var _record_from_server = Convert.ToString(dt.Rows[i]["crop_disease_id"]);

					if(dto_id == _record_from_server){
						return Convert.ToString(dt.Rows[i]["crop_disease_name"]);
					}
					
				}
				return null;
			}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return null; 
			}
		}
		
	    ui_pestinsecticidedto convertdaldtointoui_dto(pestinsecticidedto _pestinsecticidedto)
	    {
	    	ui_pestinsecticidedto _ui_pestinsecticidedto = new ui_pestinsecticidedto();

			_ui_pestinsecticidedto.pestinsecticide_id = _pestinsecticidedto.pestinsecticide_id;
			_ui_pestinsecticidedto.pestinsecticide_name = _pestinsecticidedto.pestinsecticide_name;

			_ui_pestinsecticidedto.pestinsecticide_status = _pestinsecticidedto.pestinsecticide_status;
			_ui_pestinsecticidedto.created_date = _pestinsecticidedto.created_date;

			_ui_pestinsecticidedto.pestinsecticide_category_name = get_category_name_given_id(_pestinsecticidedto.pestinsecticide_category);
			_ui_pestinsecticidedto.pestinsecticide_crop_disease_name = get_diseasepest_name_given_id(_pestinsecticidedto.pestinsecticide_crop_disease_id);
			_ui_pestinsecticidedto.pestinsecticide_manufacturer_name = get_manufacturer_name_given_id(_pestinsecticidedto.pestinsecticide_manufacturer_id);

			return _ui_pestinsecticidedto;
	    }
		
	    pestinsecticidedto convertui_dtointodaldto(ui_pestinsecticidedto _ui_pestinsecticidedto)
	    {
	    	pestinsecticidedto _pestinsecticidedto = new pestinsecticidedto();
			
			_pestinsecticidedto.pestinsecticide_id = _ui_pestinsecticidedto.pestinsecticide_id;
			_pestinsecticidedto.pestinsecticide_name = _ui_pestinsecticidedto.pestinsecticide_name;
			
			_pestinsecticidedto.pestinsecticide_status = _ui_pestinsecticidedto.pestinsecticide_status;
			_pestinsecticidedto.created_date = _ui_pestinsecticidedto.created_date;
			
			_pestinsecticidedto.pestinsecticide_category = get_category_id_given_name(_ui_pestinsecticidedto.pestinsecticide_category_name);
			_pestinsecticidedto.pestinsecticide_crop_disease_id = get_diseasepest_id_given_name(_ui_pestinsecticidedto.pestinsecticide_crop_disease_name);
			_pestinsecticidedto.pestinsecticide_manufacturer_id = get_manufacturer_id_given_name(_ui_pestinsecticidedto.pestinsecticide_manufacturer_name);
			
			return _pestinsecticidedto;
	    }
		
		string get_category_id_given_name(string dto_name)
		{
			try{
				
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			     
			 	string query = "";
				 
			 	if(chkshowinactive.Checked){
					query = DBContract.CATEGORIES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CATEGORIES_SELECT_ALL_FILTER_QUERY; 
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

					categorydto _categorydto = utilzsingleton.getInstance(_notificationmessageEventname).buildcategorydtogivendatatable(dt, i);
	 
					var _record_from_server = Convert.ToString(dt.Rows[i]["category_name"]);

					if(dto_name == _record_from_server){
						return Convert.ToString(dt.Rows[i]["category_id"]);
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
		
		string get_diseasepest_id_given_name(string dto_name)
		{
			try{
				
				DataTable mssql_dt = null;
			    DataTable mysql_dt = null;
			    DataTable sqlite_dt = null;
			    DataTable dt = null;
			     
			 	string query = "";
				 
			 	if(chkshowinactive.Checked){
					query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CROPS_DISEASES_SELECT_ALL_FILTER_QUERY; 
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

					cropdiseasedto _cropdiseasedto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdiseasedtogivendatatable(dt, i);
	 
					var _record_from_server = Convert.ToString(dt.Rows[i]["crop_disease_name"]);

					if(dto_name == _record_from_server){
						return Convert.ToString(dt.Rows[i]["crop_disease_id"]);
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
