/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 10/24/2018
 * Time: 11:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SqlClient;

namespace nthareneapi
{
	/// <summary>
	/// Description of updatemssqlschemasingleton.
	/// </summary>
	public sealed class updatemssqlschemasingleton : abstractupdateschema
	{
		// Because the _instance member is made private, the only way to get the single
		// instance is via the static Instance property below. This can also be similarly
		// achieved with a GetInstance() method instead of the property.
		private static updatemssqlschemasingleton singleInstance;
			 
	    public static updatemssqlschemasingleton getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname) {
			// The first call will create the one and only instance.
	        if (singleInstance == null)
	            singleInstance = new updatemssqlschemasingleton(notificationmessageEventname, progressBarNotificationEventname);
	        // Every call afterwards will return the single instance created above.
	        return singleInstance;
	    }
		 
		private event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		private event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		private string TAG;
		mssqlconnectionstringdto _connectionstringdto_tempdb;
		mssqlconnectionstringdto _connectionstringdto_currentdb;
		
		private updatemssqlschemasingleton(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			_notificationmessageEventname = notificationmessageEventname;
			_progressBarNotificationEventname = progressBarNotificationEventname;
			try{ 
				TAG = this.GetType().Name;
				_connectionstringdto_tempdb = buildcurrentdbconnectiondtowithsystemdefaults();
				_connectionstringdto_currentdb = buildtempdbconnectiondtowithsystemdefaults();
			}catch(Exception ex){  
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));				
			}
		}
		
		private updatemssqlschemasingleton()
		{
			 
		}
		
		mssqlconnectionstringdto buildtempdbconnectiondtowithsystemdefaults()
		{
				mssqlconnectionstringdto _connectionstringdto = new mssqlconnectionstringdto();
				
				_connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mssql_datasource"];
				_connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
				_connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mssql_userid"];
				_connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mssql_password"];
				_connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mssql_port"];
				_connectionstringdto.update_schema_temp_db = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
				_connectionstringdto.new_database_name = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
				_connectionstringdto.update_schema_current_db = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
					 
				return _connectionstringdto;
		}
		
		mssqlconnectionstringdto buildcurrentdbconnectiondtowithsystemdefaults()
		{
				mssqlconnectionstringdto _connectionstringdto = new mssqlconnectionstringdto();
				
				_connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mssql_datasource"];
				_connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mssql_database"];
				_connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mssql_userid"];
				_connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mssql_password"];
				_connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mssql_port"];
				_connectionstringdto.update_schema_temp_db = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
				_connectionstringdto.new_database_name = System.Configuration.ConfigurationManager.AppSettings["mssql_database"];
				_connectionstringdto.update_schema_current_db = System.Configuration.ConfigurationManager.AppSettings["mssql_database"];
					 
				return _connectionstringdto;
		}
		
		string buildconnectionstringfromobject(mssqlconnectionstringdto _connectionstringdto){
			string CONNECTION_STRING = @"Data Source=" + _connectionstringdto.datasource + ";" +
			"Database=" + _connectionstringdto.database + ";" +
			"User Id=" + _connectionstringdto.userid + ";" +
			"Password=" + _connectionstringdto.password;
			return CONNECTION_STRING;
		}
		
		public override responsedto updateschemagivendatastore()
		{
			responsedto _responsedto = new responsedto();
			 try{

				responsedto _createtempdb = createtempdb();
				responsedto _truncatetablesintempdb = truncatetablesintempdb();
				responsedto _copydatafromcurrentdbintotempdb = copydatafromcurrentdbintotempdb();
				//responsedto _droptablesincurrentdb = droptablesincurrentdb();
				//responsedto _recreatetablesincurrentdbwithcorrectschema = recreatetablesincurrentdbwithcorrectschema();
				//responsedto _copydatafromtempdbintocurrentdb = copydatafromtempdbintocurrentdb();
				//responsedto _droptempdb = droptempdb();

				_responsedto.responsesuccessmessage += _createtempdb.responsesuccessmessage;
				_responsedto.responsesuccessmessage += _truncatetablesintempdb.responsesuccessmessage;
				_responsedto.responsesuccessmessage += _copydatafromcurrentdbintotempdb.responsesuccessmessage;
				//_responsedto.responsesuccessmessage += _droptablesincurrentdb.responsesuccessmessage;
				//_responsedto.responsesuccessmessage += _recreatetablesincurrentdbwithcorrectschema.responsesuccessmessage;
				//_responsedto.responsesuccessmessage += _copydatafromtempdbintocurrentdb.responsesuccessmessage;
				//_responsedto.responsesuccessmessage += _droptempdb.responsesuccessmessage;
				
				return _responsedto;
				
			}catch(Exception ex){  
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responsesuccessmessage += ex.Message + Environment.NewLine;
				return _responsedto;			
			}
		}
		
		responsedto createtempdb()
		{
			responsedto _responsedto = new responsedto();
			try{
				
				string CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto_tempdb);
				
			    string query = "CREATE DATABASE " +  _connectionstringdto_tempdb.update_schema_temp_db + ";";
			    
				using (var con = new SqlConnection(CONNECTION_STRING))
				{
					con.Open();
					using (var cmd = new SqlCommand(query, con))
					{
						cmd.ExecuteNonQuery();
						_responsedto.isresponseresultsuccessful = true; 
						_responsedto.responsesuccessmessage	= "successfully created database [ " + _connectionstringdto_tempdb.update_schema_temp_db + " ] in " + DBContract.mssql + "." + Environment.NewLine;
						_responsedto.responseresultobject = _connectionstringdto_tempdb;
						
						mssqlconnectionstringdto _tablesconn = _connectionstringdto_tempdb;
						
						_tablesconn.new_database_name = _connectionstringdto_tempdb.update_schema_temp_db;
						_tablesconn.database = _connectionstringdto_tempdb.update_schema_temp_db;
						
						responsedto _innerresponsedto = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createtables(_connectionstringdto_tempdb);
						
						_responsedto.responsesuccessmessage += _innerresponsedto.responseerrormessage;
						_responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
						
						return _responsedto;
					}
				}
				
			}catch(Exception ex){  
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responsesuccessmessage += ex.Message + Environment.NewLine;
				
				responsedto _innerresponsedto = new responsedto();
			try{ 

				_innerresponsedto = recreatetablesintempdbwithcorrectschema();
				
				_responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
				_responsedto.responsesuccessmessage += _innerresponsedto.responseerrormessage;
				
				return _responsedto;
			}catch(Exception iex){  
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responsesuccessmessage += iex.Message + Environment.NewLine;
				return _responsedto;			
			}
				
				return _responsedto;	
			}
		}
		
		responsedto copydatafromcurrentdbintotempdb()
		{
			responsedto _responsedto = new responsedto();
			try{ 
				
				string[] _table_names_arr = DBContract.table_names_arr;
				
				bool numberOfRowsAffected = false;
				int _per_db_count = 0;
				
				foreach (var _table in _table_names_arr) {
					
					var dt = new DataTable();
					dt = getallrecordsfromcurrentdbgiventable(_table);
					
					_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(1, 0));
					
					if(dt == null)continue;
				    
					int _per_table_count = 0;
					var _recordscount = dt.Rows.Count;
					
					for(int i = 0; i < _recordscount; i++){
						
						if(_table.Equals(DBContract.cropsentitytable.CROPS_TABLE_NAME)){
								
							cropdto _cropdto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropindatabase(_cropdto, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
				    
						}else if(_table.Equals(DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME)){
							
							cropdiseasedto _cropdiseasedto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdiseasedtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropdiseaseindatabase(_cropdiseasedto, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
				    
						}else if(_table.Equals(DBContract.cropsvarietiesentitytable.CROPS_VARIETIES_TABLE_NAME)){
							
							cropvarietydto _cropvarietydto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropvarietydtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropvarietyindatabase(_cropvarietydto, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
				    
						}else if(_table.Equals(DBContract.manufacturersentitytable.MANUFACTURERS_TABLE_NAME)){
							
							manufacturerdto _manufacturerdto = utilzsingleton.getInstance(_notificationmessageEventname).buildmanufacturerdtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createmanufacturerindatabase(_manufacturerdto, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
				    
						}else if(_table.Equals(DBContract.pestsinsecticidesentitytable.PESTSINSECTICIDES_TABLE_NAME)){
							
							pestinsecticidedto _pestinsecticidedto = utilzsingleton.getInstance(_notificationmessageEventname).buildpestinsecticidedtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createpestinsecticideindatabase(_pestinsecticidedto, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
				    
						}else if(_table.Equals(DBContract.settingsentitytable.SETTINGS_TABLE_NAME)){
							
							settingdto _settingdto = utilzsingleton.getInstance(_notificationmessageEventname).buildsettingdtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createsettingindatabase(_settingdto, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
				    
						}
					 
					_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));
					
					_per_db_count++;
					_per_table_count++;
					}
					
					_responsedto.responsesuccessmessage += "[ " + _per_table_count + " ] records transfered for table [ " + _table + " ] in database [ " + buildtempdbconnectiondtowithsystemdefaults().database + " ] - " + DBContract.mssql + Environment.NewLine;
				}
				
				_responsedto.isresponseresultsuccessful = true;
				_responsedto.responsesuccessmessage += "[ " + _per_db_count + " ] records transfered from current db into temp db." + Environment.NewLine;
				return _responsedto;
			}catch(Exception ex){  
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responsesuccessmessage += ex.Message + Environment.NewLine;
				return _responsedto;			
			}
		}
		
		DataTable getallrecordsfromcurrentdbgiventable(string _table)
		{
			var dt = new DataTable();
			if(_table.Equals(DBContract.cropsentitytable.CROPS_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.CROPS_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
			 }else if(_table.Equals(DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.CROPS_DISEASES_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
			 }else if(_table.Equals(DBContract.cropsvarietiesentitytable.CROPS_VARIETIES_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
			}else if(_table.Equals(DBContract.manufacturersentitytable.MANUFACTURERS_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.MANUFACTURERS_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
			}else if(_table.Equals(DBContract.pestsinsecticidesentitytable.PESTSINSECTICIDES_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
			}else if(_table.Equals(DBContract.settingsentitytable.SETTINGS_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.SETTINGS_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
			}
			return dt;
		}
		
		DataTable getallrecordsfromtempdbgiventable(string _table)
		{
			var dt = new DataTable();
			if(_table.Equals(DBContract.cropsentitytable.CROPS_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.CROPS_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
			 }else if(_table.Equals(DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.CROPS_DISEASES_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
			 }else if(_table.Equals(DBContract.cropsvarietiesentitytable.CROPS_VARIETIES_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
			}else if(_table.Equals(DBContract.manufacturersentitytable.MANUFACTURERS_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.MANUFACTURERS_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
			}else if(_table.Equals(DBContract.pestsinsecticidesentitytable.PESTSINSECTICIDES_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
			}else if(_table.Equals(DBContract.settingsentitytable.SETTINGS_TABLE_NAME)){
						dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(DBContract.SETTINGS_SELECT_ALL_QUERY, buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults()));
			}
			return dt;
		}
		
		responsedto truncatetablesintempdb()
		{
			responsedto _responsedto = new responsedto();
			try{
				string CONNECTION_STRING = buildconnectionstringfromobject(buildtempdbconnectiondtowithsystemdefaults());
				
				string[] _table_names_arr = DBContract.table_names_arr;
				
				foreach (var _table in _table_names_arr) {
					
					string query = "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + _table + "]') AND type in (N'U'))";
			          query += " BEGIN ";
			          query += " TRUNCATE TABLE " + _table + ";";
			          query += "END";
			          
					using (var con = new SqlConnection(CONNECTION_STRING))
					{
						con.Open();
						using (var cmd = new SqlCommand(query, con))
						{
							cmd.ExecuteNonQuery();
							_responsedto.isresponseresultsuccessful = true; 
							_responsedto.responsesuccessmessage	+= "successfully truncated table [ " + _table + " ] in database [ " + buildtempdbconnectiondtowithsystemdefaults().database + " ] - " + DBContract.mssql + "." + Environment.NewLine;
						}
					}
				}
				return _responsedto;
			}catch(Exception ex){
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responsesuccessmessage += ex.Message + Environment.NewLine;
				return _responsedto;
			}
		}
		
		responsedto droptablesincurrentdb()
		{
			responsedto _responsedto = new responsedto();
			try{
				string CONNECTION_STRING = buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults());
				
				string[] _table_names_arr = DBContract.table_names_arr;
				
				foreach (var _table in _table_names_arr) {
					
					string query = "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + _table + "]') AND type in (N'U'))";
			          query += " BEGIN ";
			          query += " DROP TABLE " + _table + ";";
			          query += "END";
			          
					using (var con = new SqlConnection(CONNECTION_STRING))
					{
						con.Open();
						using (var cmd = new SqlCommand(query, con))
						{
							cmd.ExecuteNonQuery();
							_responsedto.isresponseresultsuccessful = true; 
							_responsedto.responsesuccessmessage	+= "successfully dropped table [ " + _table + " ] in database [ " + buildcurrentdbconnectiondtowithsystemdefaults().database + " ] - " + DBContract.mssql + "." + Environment.NewLine;
						}
					}
				}
				return _responsedto;
			}catch(Exception ex){
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responsesuccessmessage += ex.Message + Environment.NewLine;
				return _responsedto;
			}
		}
		
		responsedto recreatetablesintempdbwithcorrectschema()
		{
			responsedto _responsedto = new responsedto();
			try{ 

				_responsedto = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createtables(buildtempdbconnectiondtowithsystemdefaults());
				
				return _responsedto;
			}catch(Exception ex){  
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responsesuccessmessage += ex.Message + Environment.NewLine;
				return _responsedto;			
			}
		}
		
		responsedto recreatetablesincurrentdbwithcorrectschema()
		{
			responsedto _responsedto = new responsedto();
			try{ 

				_responsedto = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createtables(buildcurrentdbconnectiondtowithsystemdefaults());
				
				return _responsedto;
			}catch(Exception ex){  
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responsesuccessmessage += ex.Message + Environment.NewLine;
				return _responsedto;			
			}
		}
		
		responsedto copydatafromtempdbintocurrentdb()
		{
			responsedto _responsedto = new responsedto();
			try{ 
				
				string[] _table_names_arr = DBContract.table_names_arr;
				
				bool numberOfRowsAffected = false;
				int _per_db_count = 0;
				
				foreach (var _table in _table_names_arr) {
					
					var dt = new DataTable();
					dt = getallrecordsfromtempdbgiventable(_table);
					
					_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(1, 0));
					
					if(dt == null)continue;
				    
					int _per_table_count = 0;
					var _recordscount = dt.Rows.Count;
					
					for(int i = 0; i < _recordscount; i++){
						
						if(_table.Equals(DBContract.cropsentitytable.CROPS_TABLE_NAME)){
								
							cropdto _cropdto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropindatabase(_cropdto, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
				    
						}else if(_table.Equals(DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME)){
							
							cropdiseasedto _cropdiseasedto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdiseasedtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropdiseaseindatabase(_cropdiseasedto, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
				    
						}else if(_table.Equals(DBContract.cropsvarietiesentitytable.CROPS_VARIETIES_TABLE_NAME)){
							
							cropvarietydto _cropvarietydto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropvarietydtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropvarietyindatabase(_cropvarietydto, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
				    
						}else if(_table.Equals(DBContract.manufacturersentitytable.MANUFACTURERS_TABLE_NAME)){
							
							manufacturerdto _manufacturerdto = utilzsingleton.getInstance(_notificationmessageEventname).buildmanufacturerdtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createmanufacturerindatabase(_manufacturerdto, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
				    
						}else if(_table.Equals(DBContract.pestsinsecticidesentitytable.PESTSINSECTICIDES_TABLE_NAME)){
							
							pestinsecticidedto _pestinsecticidedto = utilzsingleton.getInstance(_notificationmessageEventname).buildpestinsecticidedtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createpestinsecticideindatabase(_pestinsecticidedto, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
				    
						}else if(_table.Equals(DBContract.settingsentitytable.SETTINGS_TABLE_NAME)){
							
							settingdto _settingdto = utilzsingleton.getInstance(_notificationmessageEventname).buildsettingdtogivendatatable(dt, i);
							
							numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createsettingindatabase(_settingdto, buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults()));
				    
						}
					 
					_progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));
					
					_per_db_count++;
					_per_table_count++;
					}
					
				 _responsedto.responsesuccessmessage += "[ " + _per_table_count + " ] records transfered for table [ " + _table + " ] in database [ " + " ] - " + DBContract.mssql + Environment.NewLine;
				}
				
				_responsedto.isresponseresultsuccessful = true;
				_responsedto.responsesuccessmessage += "[ " + _per_db_count + " ] records transfered from current db into temp db." + Environment.NewLine;
				return _responsedto;
			}catch(Exception ex){
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responsesuccessmessage += ex.Message + Environment.NewLine;
				return _responsedto;			
			}
		}
		
		responsedto droptempdb()
		{
			responsedto _responsedto = new responsedto();
			try{
				string CONNECTION_STRING = buildconnectionstringfromobject(buildcurrentdbconnectiondtowithsystemdefaults());
				
			    string query = "DROP DATABASE " +  _connectionstringdto_tempdb.update_schema_temp_db + ";";
			    
				using (var con = new SqlConnection(CONNECTION_STRING))
				{
					con.Open();
					using (var cmd = new SqlCommand(query, con))
					{
						cmd.ExecuteNonQuery();
						_responsedto.isresponseresultsuccessful = true; 
						_responsedto.responsesuccessmessage	= "successfully droped database [ " + _connectionstringdto_tempdb.update_schema_temp_db + " ] in " + DBContract.mssql + "." + Environment.NewLine;
						_responsedto.responseresultobject = _connectionstringdto_tempdb;
						return _responsedto;
					}
				}
			}catch(Exception ex){
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responsesuccessmessage += ex.Message + Environment.NewLine;
				return _responsedto;
			}
		}
		
		
		
		
		
		
	}
}
