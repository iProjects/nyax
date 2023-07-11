/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 20:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace nthareneapi
{
	/// <summary>
	/// Description of DBContract.
	/// </summary>
	//Define the tables and columns of your local database
	public static class DBContract {
    
    public static String DATABASE_NAME = "ntharenedb";
    public static String SQLITE_DATABASE_NAME = "ntharenedb.sqlite3";
    
    public static String error = "error";
    public static String info = "info";
    public static String warn = "warn";
    
    public static String mssql = "mssql";
    public static String mysql = "mysql";
    public static String sqlite = "sqlite";
    public static String postgresql = "postgresql";
    
    public static DialogResult dialogresult = DialogResult.OK;
    
	//crops
    public static  class cropsentitytable {
        public static  String CROPS_TABLE_NAME = "tblcrops";
        //Columns of the table
        public static  String CROP_ID = "crop_id";
        public static  String CROP_NAME = "crop_name";
        public static  String CROP_STATUS = "crop_status";
        public static  String CREATED_DATE = "created_date";

    }

	//crops varieties
    public static  class cropsvarietiesentitytable {
        public static  String CROPS_VARIETIES_TABLE_NAME = "tblcropsvarieties";
        //Columns of the table
        public static  String CROP_VARIETY_ID = "crop_variety_id";
        public static  String CROP_VARIETY_NAME = "crop_variety_name";
        public static  String CROP_VARIETY_STATUS = "crop_variety_status";
        public static  String CREATED_DATE = "created_date";
        public static  String CROP_VARIETY_CROP_ID = "crop_variety_crop_id";
        public static  String CROP_VARIETY_MANUFACTURER_ID = "crop_variety_manufacturer_id";

    }

	//diseases/pests
    public static  class cropsdiseasesentitytable {
        public static  String CROPS_DISEASES_TABLE_NAME = "tblcropsdiseases";
        //Columns of the table
        public static  String CROP_DISEASE_ID = "crop_disease_id";
        public static  String CROP_DISEASE_NAME = "crop_disease_name";
        public static  String CROP_DISEASE_CATEGORY = "crop_disease_category";
        public static  String CROP_DISEASE_STATUS = "crop_disease_status";
        public static  String CREATED_DATE = "created_date";

    }

	//manufacturers
    public static  class manufacturersentitytable {
        public static  String MANUFACTURERS_TABLE_NAME = "tblmanufacturers";
        //Columns of the table
        public static  String MANUFACTURER_ID = "manufacturer_id";
        public static  String MANUFACTURER_NAME = "manufacturer_name";
        public static  String MANUFACTURER_STATUS = "manufacturer_status";
        public static  String CREATED_DATE = "created_date";

    }

	//pesticides/insecticides
    public static  class pestsinsecticidesentitytable {
        public static  String PESTSINSECTICIDES_TABLE_NAME = "tblpestsinsecticides";
        //Columns of the table
        public static  String PESTINSECTICIDE_ID = "pestinsecticide_id";
        public static  String PESTINSECTICIDE_NAME = "pestinsecticide_name";
        public static  String PESTINSECTICIDE_CATEGORY = "pestinsecticide_category";
        public static  String PESTINSECTICIDE_STATUS = "pestinsecticide_status";
        public static  String CREATED_DATE = "created_date";
        public static  String PESTINSECTICIDE_CROP_DISEASE_ID = "pestinsecticide_crop_disease_id";
        public static  String PESTINSECTICIDE_MANUFACTURER_ID = "pestinsecticide_manufacturer_id";

    }

	//settings
    public static  class settingsentitytable {
        public static  String SETTINGS_TABLE_NAME = "tblsettings";
        //Columns of the table
        public static  String SETTING_ID = "setting_id";
        public static  String SETTING_NAME = "setting_name";
        public static  String SETTING_VALUE = "setting_value";
        public static  String SETTING_STATUS = "setting_status";
        public static  String CREATED_DATE = "created_date";

    }

	//categories
    public static  class categoriesentitytable {
        public static  String CATEGORIES_TABLE_NAME = "tblcategories";
        //Columns of the table
        public static  String CATEGORY_ID = "category_id";
        public static  String CATEGORY_NAME = "category_name";
        public static  String CATEGORY_STATUS = "category_status";
        public static  String CREATED_DATE = "created_date";

    }

	public static String CROPS_SELECT_ALL_QUERY = "SELECT * FROM " +
								DBContract.cropsentitytable.CROPS_TABLE_NAME;
	
	public static String CROPS_SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
			 		    DBContract.cropsentitytable.CROPS_TABLE_NAME +
			 			" where " +
			 			DBContract.cropsentitytable.CROP_STATUS +
			 			" = " +
						"'active'";
	
	public static String CROPS_VARIETIES_SELECT_ALL_QUERY = "SELECT * FROM " +
								DBContract.cropsvarietiesentitytable.CROPS_VARIETIES_TABLE_NAME;
	
	public static String CROPS_VARIETIES_SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
			 		    DBContract.cropsvarietiesentitytable.CROPS_VARIETIES_TABLE_NAME +
			 			" where " +
			 			DBContract.cropsvarietiesentitytable.CROP_VARIETY_STATUS +
			 			" = " +
						"'active'";
	
	public static String CROPS_DISEASES_SELECT_ALL_QUERY = "SELECT * FROM " +
								DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME;
	
	public static String CROPS_DISEASES_SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
			 		    DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME +
			 			" where " +
			 			DBContract.cropsdiseasesentitytable.CROP_DISEASE_STATUS +
			 			" = " +
						"'active'";
	 
	public static String MANUFACTURERS_SELECT_ALL_QUERY = "SELECT * FROM " +
								DBContract.manufacturersentitytable.MANUFACTURERS_TABLE_NAME;
	
	public static String MANUFACTURERS_SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
			 		    DBContract.manufacturersentitytable.MANUFACTURERS_TABLE_NAME +
			 			" where " +
			 			DBContract.manufacturersentitytable.MANUFACTURER_STATUS +
			 			" = " +
						"'active'";
	
	public static String PESTSINSECTICIDES_SELECT_ALL_QUERY = "SELECT * FROM " +
								DBContract.pestsinsecticidesentitytable.PESTSINSECTICIDES_TABLE_NAME;
	
	public static String PESTSINSECTICIDES_SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
			 		    DBContract.pestsinsecticidesentitytable.PESTSINSECTICIDES_TABLE_NAME +
			 			" where " +
			 			DBContract.pestsinsecticidesentitytable.PESTINSECTICIDE_STATUS +
			 			" = " +
						"'active'";
	
	public static String SETTINGS_SELECT_ALL_QUERY = "SELECT * FROM " +
								DBContract.settingsentitytable.SETTINGS_TABLE_NAME;
	
	public static String SETTINGS_SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
			 		    DBContract.settingsentitytable.SETTINGS_TABLE_NAME +
			 			" where " +
			 			DBContract.settingsentitytable.SETTING_STATUS +
			 			" = " +
						"'active'";
	
	public static String CATEGORIES_SELECT_ALL_QUERY = "SELECT * FROM " +
								DBContract.categoriesentitytable.CATEGORIES_TABLE_NAME;
	
	public static String CATEGORIES_SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
			 		    DBContract.categoriesentitytable.CATEGORIES_TABLE_NAME +
			 			" where " +
			 			DBContract.categoriesentitytable.CATEGORY_STATUS +
			 			" = " +
						"'active'";

	public static string getdefaultmssqlconnectionstring(){
		mssqlconnectionstringdto _connectionstringdto = new mssqlconnectionstringdto();
		
		_connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mssql_datasource"];
		_connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mssql_database"];
		_connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mssql_userid"];
		_connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mssql_password"];
		_connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mssql_port"];
		_connectionstringdto.update_schema_temp_db = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
		_connectionstringdto.new_database_name = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
		_connectionstringdto.update_schema_current_db = System.Configuration.ConfigurationManager.AppSettings["mssql_database"];
		
		string CONNECTION_STRING = buildmssqlconnectionstringfromobject(_connectionstringdto);
		
		return CONNECTION_STRING;
	}

	static string buildmssqlconnectionstringfromobject(mssqlconnectionstringdto _connectionstringdto){
		string CONNECTION_STRING = @"Data Source=" + _connectionstringdto.datasource + ";" +
		"Database=" + _connectionstringdto.database + ";" +
		"User Id=" + _connectionstringdto.userid + ";" +
		"Password=" + _connectionstringdto.password;
		return CONNECTION_STRING;
	}
	
	public static string getdefaultmysqlconnectionstring(){
		mysqlconnectionstringdto _connectionstringdto = new mysqlconnectionstringdto();
				
		_connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mysql_datasource"];
		_connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mysql_database"];
		_connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mysql_userid"];
		_connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mysql_password"];
		_connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mysql_port"];
		_connectionstringdto.update_schema_temp_db = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
		_connectionstringdto.new_database_name = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
		_connectionstringdto.update_schema_current_db = System.Configuration.ConfigurationManager.AppSettings["mysql_database"];
			 
		string CONNECTION_STRING = buildmysqlconnectionstringfromobject(_connectionstringdto);
		
		return CONNECTION_STRING;
	}

	static string buildmysqlconnectionstringfromobject(mysqlconnectionstringdto _connectionstringdto){
		string CONNECTION_STRING = @"host=" + _connectionstringdto.datasource + ";" +  
			"database=" + _connectionstringdto.database + ";" +
			"port=" + _connectionstringdto.port + ";" +
			"user=" + _connectionstringdto.userid + ";" +
			"password=" + _connectionstringdto.password;
		return CONNECTION_STRING;
	}
	
	public static string getdefaultpostgresqlconnectionstring(){
		postgresqlconnectionstringdto _connectionstringdto = new postgresqlconnectionstringdto();
				
		_connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["postgresql_datasource"];
		_connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
		_connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["postgresql_userid"];
		_connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["postgresql_password"];
		_connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["postgresql_port"];
		_connectionstringdto.update_schema_temp_db = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
		_connectionstringdto.new_database_name = System.Configuration.ConfigurationManager.AppSettings["update_schema_temp_db"];
		_connectionstringdto.update_schema_current_db = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
			 				 
		string CONNECTION_STRING = buildpostgresqlconnectionstringfromobject(_connectionstringdto);
 	 
		return CONNECTION_STRING;
	}

	static string buildpostgresqlconnectionstringfromobject(postgresqlconnectionstringdto _connectionstringdto)
	{
		string CONNECTION_STRING = @"Server=" + _connectionstringdto.datasource + ";" +
			"Database=" + _connectionstringdto.database + ";" +
			"Port=" + _connectionstringdto.port + ";" +
			"User Id=" + _connectionstringdto.userid + ";" +
			"Password=" + _connectionstringdto.password;
		return CONNECTION_STRING;
	}
	
	public static string getdefaultsqliteconnectionstring(){
		sqliteconnectionstringdto _connectionstringdto = new sqliteconnectionstringdto();
		
		_connectionstringdto.sqlite_database_path = System.Configuration.ConfigurationManager.AppSettings["sqlite_database_path"];
		_connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["sqlite_database"];
		_connectionstringdto.sqlite_db_extension = System.Configuration.ConfigurationManager.AppSettings["sqlite_db_extension"];
		_connectionstringdto.sqlite_version = System.Configuration.ConfigurationManager.AppSettings["sqlite_version"];
		_connectionstringdto.sqlite_pooling = System.Configuration.ConfigurationManager.AppSettings["sqlite_pooling"];
		_connectionstringdto.sqlite_fail_if_missing = System.Configuration.ConfigurationManager.AppSettings["sqlite_fail_if_missing"];
			 
		string CONNECTION_STRING = buildsqliteconnectionstringfromobject(_connectionstringdto);
		
		return CONNECTION_STRING;

	}

	static string buildsqliteconnectionstringfromobject(sqliteconnectionstringdto _connectionstringdto){
			string base_dir = Environment.CurrentDirectory;
		    string database_dir = base_dir + _connectionstringdto.sqlite_database_path;
		    string dbname = _connectionstringdto.database;
		    string database_version = _connectionstringdto.sqlite_version;
		    string db_extension = _connectionstringdto.sqlite_db_extension;
	   		dbname = dbname + "." + db_extension + database_version;
	   		
	        if(!Directory.Exists(database_dir)){
	   			return null;
	   		}else{
	   			
	   		}
	        
	        string full_database_name_with_path = database_dir + dbname;
	        string _secure_path_name_response = _connectionstringdto.sqlite_database_path + dbname;
	        
	        if(!File.Exists(full_database_name_with_path)){
	        	return null;
	        }else{
	        	
	   		}
	    	
			string CONNECTION_STRING = @"Data Source=" + full_database_name_with_path + ";" +
			"Version=" + _connectionstringdto.sqlite_version + ";" +
			"Pooling=" + _connectionstringdto.sqlite_pooling + ";" +
			"FailIfMissing=" + _connectionstringdto.sqlite_fail_if_missing;
			
			return CONNECTION_STRING;
		}
		
	public static string[] table_names_arr = {
		"tblcrops",
		"tblcropsvarieties",
		"tblcropsdiseases",
		"tblmanufacturers",
		"tblpestsinsecticides",
		"tblsettings",
		"tblcategories"
	};

	public static string[] _entities = {
			"mssql", 
			"mysql",
			"postgresql", 
			"sqlite"
		};
		
	
	 
		
		
  }
	
	
	
	
	

}



