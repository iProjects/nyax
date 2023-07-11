/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 12/19/2018
 * Time: 12:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace nthareneapi
{
	/// <summary>
	/// Description of businesslayerapisingleton.
	/// </summary>
	public sealed class businesslayerapisingleton
	{
		// Because the _instance member is made private, the only way to get the single
		// instance is via the static Instance property below. This can also be similarly
		// achieved with a GetInstance() method instead of the property.
		private static businesslayerapisingleton singleInstance;
		 
	    public static businesslayerapisingleton getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname) {
			// The first call will create the one and only instance.
	        if (singleInstance == null)
	            singleInstance = new businesslayerapisingleton(notificationmessageEventname, progressBarNotificationEventname);
	        // Every call afterwards will return the single instance created above.
	        return singleInstance;
	    }
		
		 private event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		 private event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		 
		 DataTable mssql_dt = null;
	     DataTable mysql_dt = null;
	     DataTable sqlite_dt = null;
	     DataTable postgresql_dt = null;
	     DataTable dt = null;
		 
	     string TAG;
		 public string _working_db = "";
		 string query = "";
		 
		 List<cropdto> _cropslst = new List<cropdto>();
		 
		private businesslayerapisingleton(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			_notificationmessageEventname = notificationmessageEventname;
			_progressBarNotificationEventname = progressBarNotificationEventname;
			TAG = this.GetType().Name;
		}
		
		private businesslayerapisingleton()
		{
			 
		}
		
		#region "crops"
		public DataTable getcrops(bool showinactive = true, string nullable_query = ""){
			 
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(showinactive){
					query = DBContract.CROPS_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CROPS_SELECT_ALL_FILTER_QUERY; 
				}
			 }
			  
			 mssql_dt = getcropsfrommssql(query); 
			 
			 mysql_dt = getcropsfrommysql(query); 
			 		 
	  		 postgresql_dt = getcropsfrompostgresql(query);
	  
			 sqlite_dt = getcropsfromsqlite(query);
	
			 if(mssql_dt != null){
			 	dt = mssql_dt;
			 	_working_db = DBContract.mssql;
			 }
			 if(mssql_dt == null && mysql_dt != null){
			 	dt = mysql_dt;
			 	_working_db = DBContract.mysql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt != null){
			 	dt = postgresql_dt;
			 	_working_db = DBContract.postgresql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt == null && sqlite_dt != null){
			 	dt = sqlite_dt;
			 	_working_db = DBContract.sqlite;
			 }
			  
			 return dt; 
			 
		}
		
		public DataTable getcropsfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql crops count: " + mssql_dt.Rows.Count, TAG));
			 }
			 return mssql_dt;
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getcropsfrommysql(string query){
			try{
				
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (mysql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql crops count: " + mysql_dt.Rows.Count, TAG));
			 }
			return mysql_dt;
			
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getcropsfromsqlite(string query){
			try{
				
			DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (sqlite_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite crops count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getcropsfrompostgresql(string query){
			try{
				
			DataTable postgresql_dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (postgresql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql crops count: " + postgresql_dt.Rows.Count, TAG));
			 }
			 return postgresql_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		#endregion "crops"
		
		#region "manufacturers"
		public DataTable getmanufacturers(bool showinactive = true, string nullable_query = ""){
			 
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(showinactive){
					query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.MANUFACTURERS_SELECT_ALL_FILTER_QUERY; 
				}
			 }
			  
			 mssql_dt = getmanufacturersfrommssql(query); 
			 
			 mysql_dt = getmanufacturersfrommysql(query); 
			 		 
	  		 postgresql_dt = getmanufacturersfrompostgresql(query);
	  
			 sqlite_dt = getmanufacturersfromsqlite(query);
	
			 if(mssql_dt != null){
			 	dt = mssql_dt;
			 	_working_db = DBContract.mssql;
			 }
			 if(mssql_dt == null && mysql_dt != null){
			 	dt = mysql_dt;
			 	_working_db = DBContract.mysql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt != null){
			 	dt = postgresql_dt;
			 	_working_db = DBContract.postgresql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt == null && sqlite_dt != null){
			 	dt = sqlite_dt;
			 	_working_db = DBContract.sqlite;
			 }
			  
			 return dt; 
			 
		}
		
		public DataTable getmanufacturersfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql manufacturers count: " + mssql_dt.Rows.Count, TAG));
			 }
			 return mssql_dt;
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getmanufacturersfrommysql(string query){
			try{
				
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (mysql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql manufacturers count: " + mysql_dt.Rows.Count, TAG));
			 }
			return mysql_dt;
			
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getmanufacturersfromsqlite(string query){
			try{
				
			DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (sqlite_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite manufacturers count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getmanufacturersfrompostgresql(string query){
			try{
				
			DataTable postgresql_dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (postgresql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql manufacturers count: " + postgresql_dt.Rows.Count, TAG));
			 }
			 return postgresql_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		#endregion "manufacturers"
		
		#region "categories"
		public DataTable getcategories(bool showinactive = true, string nullable_query = ""){
			 
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(showinactive){
					query = DBContract.CATEGORIES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CATEGORIES_SELECT_ALL_FILTER_QUERY; 
				}
			 }
			  
			 mssql_dt = getcategoriesfrommssql(query); 
			 
			 mysql_dt = getcategoriesfrommysql(query); 
			 		 
	  		 postgresql_dt = getcategoriesfrompostgresql(query);
	  
			 sqlite_dt = getcategoriesfromsqlite(query);
	
			 if(mssql_dt != null){
			 	dt = mssql_dt;
			 	_working_db = DBContract.mssql;
			 }
			 if(mssql_dt == null && mysql_dt != null){
			 	dt = mysql_dt;
			 	_working_db = DBContract.mysql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt != null){
			 	dt = postgresql_dt;
			 	_working_db = DBContract.postgresql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt == null && sqlite_dt != null){
			 	dt = sqlite_dt;
			 	_working_db = DBContract.sqlite;
			 }
			  
			 return dt; 
			 
		}
		
		public DataTable getcategoriesfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql categories count: " + mssql_dt.Rows.Count, TAG));
			 }
			 return mssql_dt;
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getcategoriesfrommysql(string query){
			try{
				
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (mysql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql categories count: " + mysql_dt.Rows.Count, TAG));
			 }
			return mysql_dt;
			
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getcategoriesfromsqlite(string query){
			try{
				
			DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (sqlite_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite categories count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getcategoriesfrompostgresql(string query){
			try{
				
			DataTable postgresql_dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (postgresql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql categories count: " + postgresql_dt.Rows.Count, TAG));
			 }
			 return postgresql_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		#endregion "categories"
		
		#region "settings"
		public DataTable getsettings(bool showinactive = true, string nullable_query = ""){
			 
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(showinactive){
					query = DBContract.SETTINGS_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.SETTINGS_SELECT_ALL_FILTER_QUERY; 
				}
			 }
			  
			 mssql_dt = getsettingsfrommssql(query); 
			 
			 mysql_dt = getsettingsfrommysql(query); 
			 		 
	  		 postgresql_dt = getsettingsfrompostgresql(query);
	  
			 sqlite_dt = getsettingsfromsqlite(query);
	
			 if(mssql_dt != null){
			 	dt = mssql_dt;
			 	_working_db = DBContract.mssql;
			 }
			 if(mssql_dt == null && mysql_dt != null){
			 	dt = mysql_dt;
			 	_working_db = DBContract.mysql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt != null){
			 	dt = postgresql_dt;
			 	_working_db = DBContract.postgresql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt == null && sqlite_dt != null){
			 	dt = sqlite_dt;
			 	_working_db = DBContract.sqlite;
			 }
			  
			 return dt; 
			 
		}
		
		public DataTable getsettingsfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql settings count: " + mssql_dt.Rows.Count, TAG));
			 }
			 return mssql_dt;
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getsettingsfrommysql(string query){
			try{
				
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (mysql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql settings count: " + mysql_dt.Rows.Count, TAG));
			 }
			return mysql_dt;
			
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getsettingsfromsqlite(string query){
			try{
				
			DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (sqlite_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite settings count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getsettingsfrompostgresql(string query){
			try{
				
			DataTable postgresql_dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (postgresql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql settings count: " + postgresql_dt.Rows.Count, TAG));
			 }
			 return postgresql_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		#endregion "settings"
		
		#region "crops varieties"
		public DataTable getcropsvarieties(bool showinactive = true, string nullable_query = ""){
			 
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(showinactive){
					query = DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CROPS_VARIETIES_SELECT_ALL_FILTER_QUERY; 
				}
			 }
			  
			 mssql_dt = getcropsvarietiesfrommssql(query); 
			 
			 mysql_dt = getcropsvarietiesfrommysql(query); 
			 		 
	  		 postgresql_dt = getcropsvarietiesfrompostgresql(query);
	  
			 sqlite_dt = getcropsvarietiesfromsqlite(query);
	
			 if(mssql_dt != null){
			 	dt = mssql_dt;
			 	_working_db = DBContract.mssql;
			 }
			 if(mssql_dt == null && mysql_dt != null){
			 	dt = mysql_dt;
			 	_working_db = DBContract.mysql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt != null){
			 	dt = postgresql_dt;
			 	_working_db = DBContract.postgresql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt == null && sqlite_dt != null){
			 	dt = sqlite_dt;
			 	_working_db = DBContract.sqlite;
			 }
			  
			 return dt; 
			 
		}
		
		public DataTable getcropsvarietiesfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql crops varieties count: " + mssql_dt.Rows.Count, TAG));
			 }
			 return mssql_dt;
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getcropsvarietiesfrommysql(string query){
			try{
				
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (mysql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql crops varieties count: " + mysql_dt.Rows.Count, TAG));
			 }
			return mysql_dt;
			
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getcropsvarietiesfromsqlite(string query){
			try{
				
			DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (sqlite_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite crops varieties count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getcropsvarietiesfrompostgresql(string query){
			try{
				
			DataTable postgresql_dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (postgresql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql crops varieties count: " + postgresql_dt.Rows.Count, TAG));
			 }
			 return postgresql_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		#endregion "crops varieties"
		
		#region "diseases/pests"
		public DataTable getdiseasespests(bool showinactive = true, string nullable_query = ""){
			 
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(showinactive){
					query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.CROPS_DISEASES_SELECT_ALL_FILTER_QUERY; 
				}
			 }
			  
			 mssql_dt = getdiseasespestsfrommssql(query); 
			 
			 mysql_dt = getdiseasespestsfrommysql(query); 
			 		 
	  		 postgresql_dt = getdiseasespestsfrompostgresql(query);
	  
			 sqlite_dt = getdiseasespestsfromsqlite(query);
	
			 if(mssql_dt != null){
			 	dt = mssql_dt;
			 	_working_db = DBContract.mssql;
			 }
			 if(mssql_dt == null && mysql_dt != null){
			 	dt = mysql_dt;
			 	_working_db = DBContract.mysql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt != null){
			 	dt = postgresql_dt;
			 	_working_db = DBContract.postgresql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt == null && sqlite_dt != null){
			 	dt = sqlite_dt;
			 	_working_db = DBContract.sqlite;
			 }
			  
			 return dt; 
			 
		}
		
		public DataTable getdiseasespestsfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql diseases/pests count: " + mssql_dt.Rows.Count, TAG));
			 }
			 return mssql_dt;
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getdiseasespestsfrommysql(string query){
			try{
				
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (mysql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql diseases/pests count: " + mysql_dt.Rows.Count, TAG));
			 }
			return mysql_dt;
			
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getdiseasespestsfromsqlite(string query){
			try{
				
			DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (sqlite_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite diseases/pests count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getdiseasespestsfrompostgresql(string query){
			try{
				
			DataTable postgresql_dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (postgresql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql diseases/pests count: " + postgresql_dt.Rows.Count, TAG));
			 }
			 return postgresql_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		#endregion "diseases/pests"
		
		#region "pesticides/insecticides"
		public DataTable getpesticidesinsecticides(bool showinactive = true, string nullable_query = ""){
			 
			 if(!String.IsNullOrEmpty(nullable_query)){
			 	query = nullable_query;
			 }else{
			 	if(showinactive){
					query = DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY; 
				}else{
					query = DBContract.PESTSINSECTICIDES_SELECT_ALL_FILTER_QUERY; 
				}
			 }
			  
			 mssql_dt = getpesticidesinsecticidesfrommssql(query); 
			 
			 mysql_dt = getpesticidesinsecticidesfrommysql(query); 
			 		 
	  		 postgresql_dt = getpesticidesinsecticidesfrompostgresql(query);
	  
			 sqlite_dt = getpesticidesinsecticidesfromsqlite(query);
	
			 if(mssql_dt != null){
			 	dt = mssql_dt;
			 	_working_db = DBContract.mssql;
			 }
			 if(mssql_dt == null && mysql_dt != null){
			 	dt = mysql_dt;
			 	_working_db = DBContract.mysql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt != null){
			 	dt = postgresql_dt;
			 	_working_db = DBContract.postgresql;
			 }
			 if(mssql_dt == null && mysql_dt == null && postgresql_dt == null && sqlite_dt != null){
			 	dt = sqlite_dt;
			 	_working_db = DBContract.sqlite;
			 }
			  
			 return dt; 
			 
		}
		
		public DataTable getpesticidesinsecticidesfrommssql(string query){
			try{
			
			DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
			 if (mssql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql pesticides/insecticides count: " + mssql_dt.Rows.Count, TAG));
			 }
			 return mssql_dt;
				 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getpesticidesinsecticidesfrommysql(string query){
			try{
				
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (mysql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql pesticides/insecticides count: " + mysql_dt.Rows.Count, TAG));
			 }
			return mysql_dt;
			
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getpesticidesinsecticidesfromsqlite(string query){
			try{
				
			DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (sqlite_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite pesticides/insecticides count: " + sqlite_dt.Rows.Count, TAG));
			 }
			 return sqlite_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		
		public DataTable getpesticidesinsecticidesfrompostgresql(string query){
			try{
				
			DataTable postgresql_dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 if (postgresql_dt != null){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql pesticides/insecticides count: " + postgresql_dt.Rows.Count, TAG));
			 }
			 return postgresql_dt;
			 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
			return null;
			}
		}
		#endregion "pesticides/insecticides"
		
		
	}
}
