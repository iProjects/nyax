/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 20:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace nthareneapi
{
	/// <summary>
	/// Description of mysqlapisingleton.
	/// </summary>
	public sealed class mysqlapisingleton {
		
		// Because the _instance member is made private, the only way to get the single
		// instance is via the static Instance property below. This can also be similarly
		// achieved with a GetInstance() method instead of the property.
		private static mysqlapisingleton singleInstance;
			 
	    public static mysqlapisingleton getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname) {
			// The first call will create the one and only instance.
	        if (singleInstance == null)
	            singleInstance = new mysqlapisingleton(notificationmessageEventname);
	        // Every call afterwards will return the single instance created above.
	        return singleInstance;
	    }
		 
		private string CONNECTION_STRING = @"Data Source=KMK\SQLEXPRESS;Database=ntharenedb;User Id=sa;Password=123456789"; 
		 
		private const string db_name = "123";//DBContract.DATABASE_NAME;
		private event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		private string TAG;
		
		private mysqlapisingleton(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
		{
			_notificationmessageEventname = notificationmessageEventname;
			try{ 
				TAG = this.GetType().Name;			
				setconnectionstring();
				//createtables();
//				updateexistingdbschema();
			}catch(Exception ex){  
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));				
			}
		}
		
		private mysqlapisingleton()
		{
			 
		}
		
		private void setconnectionstring(){
			try{
				mysqlconnectionstringdto _connectionstringdto = new mysqlconnectionstringdto();
				
				_connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mysql_datasource"];
				_connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mysql_database"];
				_connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mysql_userid"];
				_connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mysql_password"];
				_connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mysql_port"];
					 
				CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);
 
			}catch(Exception ex){  
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));				
			}
		}
		
		string buildconnectionstringfromobject(mysqlconnectionstringdto _connectionstringdto){
			string CONNECTION_STRING = @"host=" + _connectionstringdto.datasource + ";" +  
				"database=" + _connectionstringdto.database + ";" +
				"port=" + _connectionstringdto.port + ";" +
				"user=" + _connectionstringdto.userid + ";" +
				"password=" + _connectionstringdto.password;
			return CONNECTION_STRING;
		}
		
		public responsedto createdatabasegivenname(mysqlconnectionstringdto _connectionstringdto){
			responsedto _responsedto = new responsedto();
			try{
				_connectionstringdto.database = "mysql";
				
				string CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);
				
			    string query = "CREATE DATABASE " +  _connectionstringdto.new_database_name + ";";
			    
				using (var con = new MySqlConnection(CONNECTION_STRING))
				{
					con.Open();
					using (var cmd = new MySqlCommand(query, con))
					{
						cmd.ExecuteNonQuery();
						_responsedto.isresponseresultsuccessful = true; 
						_responsedto.responsesuccessmessage	= "successfully created database [ " + _connectionstringdto.new_database_name + " ] in " + DBContract.mysql + ".";
						_responsedto.responseresultobject = _connectionstringdto;
						return _responsedto;
					}
				}
			}catch(Exception ex){
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responseerrormessage = ex.Message;
				return _responsedto;
			}
		}
		
		public responsedto createdatabasegivennamefromconsole(string new_database_name){
			responsedto _responsedto = new responsedto();
			try{
				mysqlconnectionstringdto _connectionstringdto = getmysqlconnectionstringdto();
				_connectionstringdto.database = "mysql";
				
				string CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);
				
			    string query = "CREATE DATABASE " +  new_database_name + ";";
			    
				using (var con = new MySqlConnection(CONNECTION_STRING))
				{
					con.Open();
					using (var cmd = new MySqlCommand(query, con))
					{
						cmd.ExecuteNonQuery();
						_responsedto.isresponseresultsuccessful = true; 
						_responsedto.responsesuccessmessage	= "successfully created database [ " + new_database_name + " ] in " + DBContract.mysql + ".";
						_responsedto.responseresultobject = _connectionstringdto;
						return _responsedto;
					}
				}
			}catch(Exception ex){
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responseerrormessage = ex.Message;
				return _responsedto;
			}
		}
		
		public bool createdatabase(){
			try{
				string _default_database_name = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_database", "ntharenedb");
				string query = "CREATE DATABASE " +  _default_database_name + ";";
				using (var con = new MySqlConnection(CONNECTION_STRING))
				{
					con.Open();
					using (var cmd = new MySqlCommand(query, con))
					{
						 cmd.ExecuteNonQuery();
						 return true;
					}
				}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		
		public bool createcropindatabase(cropdto _cropdto){
			try{
			  
			const string query = "INSERT INTO tblcrops(crop_name, crop_status, created_date) VALUES(@crop_name, @crop_status, @created_date)"; 
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
				{"@crop_name", _cropdto.crop_name},
				{"@crop_status", _cropdto.crop_status},
				{"@created_date", _cropdto.created_date} 
			};
			
			int numberOfRowsAffected = insertgeneric(query, args);
			if(numberOfRowsAffected !=1){
				return false;
			}else{
				return true;
			}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		public bool createcropdiseaseindatabase(cropdiseasedto _cropdiseasedto){
		try{ 
				const string query = "INSERT INTO tblcropsdiseases(crop_disease_name,  crop_disease_category, crop_disease_status, created_date) VALUES(@crop_disease_name, @crop_disease_category, @crop_disease_status, @created_date)"; 
	 
				//here we are setting the parameter values that will be actually replaced in the query in Execute method
				var args = new Dictionary<string, object>
				{
				{"@crop_disease_name", _cropdiseasedto.crop_disease_name}, 
				{"@crop_disease_category", _cropdiseasedto.crop_disease_category},
				{"@crop_disease_status", _cropdiseasedto.crop_disease_status},
				{"@created_date", _cropdiseasedto.created_date} 
				};
				
				int numberOfRowsAffected= insertgeneric(query, args);
				if(numberOfRowsAffected !=1){
					return false;
				}else{
					return true;
				}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		public int insertgeneric(string query, Dictionary<string, object> args)
		{
			try{
			  
			if(!isdbconnectionalive())return 0;
			
			int numberOfRowsAffected;
			//setup the connection to the database
			using (var con = new MySqlConnection(CONNECTION_STRING))
			{
				con.Open();
				//open a new command
				using (var cmd = new MySqlCommand(query, con))
				{
					//set the arguments given in the query
					foreach (var pair in args)
					{
						cmd.Parameters.AddWithValue(pair.Key, pair.Value);
					}
					//execute the query and get the number of row affected
					numberOfRowsAffected = cmd.ExecuteNonQuery();
				}
				return numberOfRowsAffected;
			}
			
			}catch(Exception ex){
//				msgboxform.Show(ex.Message, TAG, "OK", msgtype.error);	
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
//				MessageBox.Show(ex.Message,"crop disease insert",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return 0;
			}
		}
	
		public DataTable getallrecordsglobal(string query)
		{
			if(!isdbconnectionalive())return null;
			
			if (string.IsNullOrEmpty(query.Trim()))
			return null;
			using (var con = new MySqlConnection(CONNECTION_STRING))
			{
				con.Open();
				using (var cmd = new MySqlCommand(query, con))
				{
					var da = new MySqlDataAdapter(cmd); 
					var dt = new DataTable();
					da.Fill(dt);
					da.Dispose();
					return dt;
				}
			}
		}

		public DataTable getallrecordsglobal(string query, string CONNECTION_STRING)
		{
			if(!isdbconnectionalive(CONNECTION_STRING))return null;
			
			if (string.IsNullOrEmpty(query.Trim())) return null;
			
			using (var con = new MySqlConnection(CONNECTION_STRING))
			{
				con.Open();
				using (var cmd = new MySqlCommand(query, con))
				{
					var da = new MySqlDataAdapter(cmd); 
					var dt = new DataTable();
					da.Fill(dt);
					da.Dispose();
					return dt;
				}
			}
		}

		public bool createpestinsecticideindatabase(pestinsecticidedto _pestinsecticidedto){
			try{
			  
			const string query = "INSERT INTO tblpestsinsecticides(" +
				"pestinsecticide_name, " +
				"pestinsecticide_category, " +
				"pestinsecticide_crop_disease_id, " +
				"pestinsecticide_manufacturer_id, " +
				"pestinsecticide_status, " +
				"created_date) " +
				"VALUES(" +
				"@pestinsecticide_name, " +
				"@pestinsecticide_category, " +
				"@pestinsecticide_crop_disease_id, " +
				"@pestinsecticide_manufacturer_id, " +
				"@pestinsecticide_status, " +
				"@created_date)";
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
			{"@pestinsecticide_name", _pestinsecticidedto.pestinsecticide_name}, 
			{"@pestinsecticide_category", _pestinsecticidedto.pestinsecticide_category},
			{"@pestinsecticide_crop_disease_id", _pestinsecticidedto.pestinsecticide_crop_disease_id},
			{"@pestinsecticide_manufacturer_id", _pestinsecticidedto.pestinsecticide_manufacturer_id},
			{"@pestinsecticide_status", _pestinsecticidedto.pestinsecticide_status},
			{"@created_date", _pestinsecticidedto.created_date} 
			};
			
			int numberOfRowsAffected= insertgeneric(query, args);
			if(numberOfRowsAffected !=1){
				return false;
			}else{
			    return true;
			}
			}catch(Exception ex){
//				msgboxform.Show(ex.Message, TAG, "OK", msgtype.error);	
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
//				MessageBox.Show(ex.Message,"pesticide/insecticide insert",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
		}
		 
		public bool createcropvarietyindatabase(cropvarietydto _cropvarietydto){
			try{ 
			const string query = "INSERT INTO tblcropsvarieties(" +
				"crop_variety_name, " +
				"crop_variety_status, " +
				"crop_variety_crop_id, " +
				"crop_variety_manufacturer_id, " +
				"created_date) " +
				"VALUES(" +
				"@crop_variety_name, " +
				"@crop_variety_status, " +
				"@crop_variety_crop_id, " +
				"@crop_variety_manufacturer_id, " +
				"@created_date)";
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
				{"@crop_variety_name", _cropvarietydto.crop_variety_name},
				{"@crop_variety_status", _cropvarietydto.crop_variety_status},
				{"@crop_variety_crop_id", _cropvarietydto.crop_variety_crop_id},
				{"@crop_variety_manufacturer_id", _cropvarietydto.crop_variety_manufacturer_id},
				{"@created_date", _cropvarietydto.created_date}
			};
			
			int numberOfRowsAffected= insertgeneric(query, args);
			if(numberOfRowsAffected !=1){
				return false;
			}else{
				return true;
			}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return false;
			}
		}
		 
		public bool createmanufacturerindatabase(manufacturerdto _manufacturerdto){
			try{ 
			const string query = "INSERT INTO tblmanufacturers(manufacturer_name, manufacturer_status, created_date) VALUES(@manufacturer_name, @manufacturer_status, @created_date)"; 
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
			{"@manufacturer_name", _manufacturerdto.manufacturer_name},  
			{"@manufacturer_status", _manufacturerdto.manufacturer_status},
			{"@created_date", _manufacturerdto.created_date} 
			};
			
			int numberOfRowsAffected= insertgeneric(query, args);
			if(numberOfRowsAffected !=1){
				return false;
			}else{
				return true;
			}
			}catch(Exception ex){
//				msgboxform.Show(ex.Message, TAG, "OK", msgtype.error);	
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
//				MessageBox.Show(ex.Message,"manufacturer insert",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
		}
		 
		public bool createsettingindatabase(settingdto _settingdto){
			try{ 
			const string query = "INSERT INTO tblsettings(setting_name, setting_value, setting_status, created_date) VALUES(@setting_name, @setting_value, @setting_status, @created_date)"; 
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
			{"@setting_name", _settingdto.setting_name}, 
			{"@setting_value", _settingdto.setting_value}, 
			{"@setting_status", _settingdto.setting_status},
			{"@created_date", _settingdto.created_date} 
			};
			
			int numberOfRowsAffected = insertgeneric(query, args);
			if(numberOfRowsAffected != 1){
				return false;
			}else{
				return true;
			}
			}catch(Exception ex){
//				msgboxform.Show(ex.Message, TAG, "OK", msgtype.error);	
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
//				MessageBox.Show(ex.Message,"setting insert",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
		}
		
		public bool createcategoryindatabase(categorydto _categorydto){
			try{
			  
			const string query = "INSERT INTO tblcategories(category_name, category_status, created_date) VALUES(@category_name, @category_status, @created_date)"; 
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
				{"@category_name", _categorydto.category_name},
				{"@category_status", _categorydto.category_status},
				{"@created_date", _categorydto.created_date} 
			};
			
			int numberOfRowsAffected = insertgeneric(query, args);
			if(numberOfRowsAffected != 1){
				return false;
			}else{
				return true;
			}
			}catch(Exception ex){
//				msgboxform.Show(ex.Message, TAG, "OK", msgtype.error);	
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
//				MessageBox.Show(ex.Message,"crop insert",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
		}
		 
		public int updategeneric(string query, Dictionary<string, object> args)
		{
			if(!isdbconnectionalive())return 0;
			
			int numberOfRowsAffected;
			//setup the connection to the database
			using (var con = new MySqlConnection(CONNECTION_STRING))
			{
				con.Open();
				//open a new command
				using (var cmd = new MySqlCommand(query, con))
				{
					//set the arguments given in the query
					foreach (var pair in args)
					{
						cmd.Parameters.AddWithValue(pair.Key, pair.Value);
					}
					//execute the query and get the number of row affected
					numberOfRowsAffected = cmd.ExecuteNonQuery();
				}
				return numberOfRowsAffected;
			}
		}
	
		public bool updatecropdiseaseindatabase(cropdiseasedto _cropdiseasedto){
			try{
			  
				const string query = "UPDATE tblcropsdiseases SET " +
				"crop_disease_name = @crop_disease_name, " +
				"crop_disease_category = @crop_disease_category, " +
				"crop_disease_status = @crop_disease_status " + 
				"WHERE crop_disease_id = @crop_disease_id";
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
				{"@crop_disease_id", _cropdiseasedto.crop_disease_id},
				{"@crop_disease_name", _cropdiseasedto.crop_disease_name},	
				{"@crop_disease_category", _cropdiseasedto.crop_disease_category},					
				{"@crop_disease_status", _cropdiseasedto.crop_disease_status} 
			};
			
			int numberOfRowsAffected = updategeneric(query, args);
			if(numberOfRowsAffected != 1){
				return false;
			}else{
			    return true;
			}
			}catch(Exception ex){
//				msgboxform.Show(ex.Message, TAG, "OK", msgtype.error);	
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
//				MessageBox.Show(ex.Message, "crop disease update", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		
		public bool updatecropindatabase(cropdto _cropdto){
			try{
			  
				const string query = "UPDATE tblcrops SET " +
				"crop_name = @crop_name, " +
				"crop_status = @crop_status " + 
				"WHERE crop_id = @crop_id";
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
				{"@crop_id", _cropdto.crop_id},
				{"@crop_name", _cropdto.crop_name},
				{"@crop_status", _cropdto.crop_status}
			};
			
			int numberOfRowsAffected = updategeneric(query, args);
			if(numberOfRowsAffected != 1){
				return false;
			}else{
			    return true;
			}
			}catch(Exception ex){
//				msgboxform.Show(ex.Message, TAG, "OK", msgtype.error);	
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
//				MessageBox.Show(ex.Message, "record update", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		
		public bool updatecropvarietyindatabase(cropvarietydto _cropvarietydto){
			try{
			  
				const string query = "UPDATE tblcropsvarieties SET " +
				"crop_variety_name = @crop_variety_name, " + 
				"crop_variety_crop_id = @crop_variety_crop_id, " + 
				"crop_variety_manufacturer_id = @crop_variety_manufacturer_id, " + 
				"crop_variety_status = @crop_variety_status " + 
				"WHERE crop_variety_id = @crop_variety_id";
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
				{"@crop_variety_id", _cropvarietydto.crop_variety_id},
				{"@crop_variety_name", _cropvarietydto.crop_variety_name},
				{"@crop_variety_crop_id", _cropvarietydto.crop_variety_crop_id},
				{"@crop_variety_manufacturer_id", _cropvarietydto.crop_variety_manufacturer_id},
				{"@crop_variety_status", _cropvarietydto.crop_variety_status} 
			};
			
			int numberOfRowsAffected = updategeneric(query, args);
			if(numberOfRowsAffected != 1){
				return false;
			}else{
			    return true;
			}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return false;
			}
		}
		
		public bool updatemanufacturerindatabase(manufacturerdto _manufacturerdto){
			try{
			  
				const string query = "UPDATE tblmanufacturers SET " +
				"manufacturer_name = @manufacturer_name, " + 
				"manufacturer_status = @manufacturer_status " + 
				"WHERE manufacturer_id = @manufacturer_id";
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
				{"@manufacturer_id", _manufacturerdto.manufacturer_id},
				{"@manufacturer_name", _manufacturerdto.manufacturer_name},	 			
				{"@manufacturer_status", _manufacturerdto.manufacturer_status} 
			};
			
			int numberOfRowsAffected = updategeneric(query, args);
			if(numberOfRowsAffected != 1){
				return false;
			}else{
			    return true;
			}
			}catch(Exception ex){
//				msgboxform.Show(ex.Message, TAG, "OK", msgtype.error);	
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
//				MessageBox.Show(ex.Message, "record update", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		
		public bool updatepestinsecticideindatabase(pestinsecticidedto _pestinsecticidedto){
			try{
			  
				const string query = "UPDATE tblpestsinsecticides SET " +
				"pestinsecticide_name = @pestinsecticide_name, " + 
				"pestinsecticide_crop_disease_id = @pestinsecticide_crop_disease_id, " +
				"pestinsecticide_manufacturer_id = @pestinsecticide_manufacturer_id, " +
				"pestinsecticide_status = @pestinsecticide_status " + 
				"WHERE pestinsecticide_id = @pestinsecticide_id";
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
				{"@pestinsecticide_id", _pestinsecticidedto.pestinsecticide_id},
				{"@pestinsecticide_name", _pestinsecticidedto.pestinsecticide_name},
				{"@pestinsecticide_crop_disease_id", _pestinsecticidedto.pestinsecticide_crop_disease_id},
				{"@pestinsecticide_manufacturer_id", _pestinsecticidedto.pestinsecticide_manufacturer_id},
				{"@pestinsecticide_status", _pestinsecticidedto.pestinsecticide_status} 
			};
			
			int numberOfRowsAffected = updategeneric(query, args);
			if(numberOfRowsAffected != 1){
				return false;
			}else{
			    return true;
			}
			}catch(Exception ex){
//				msgboxform.Show(ex.Message, TAG, "OK", msgtype.error);	
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
//				MessageBox.Show(ex.Message, "record update", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		
		public bool updatesettingindatabase(settingdto _settingdto){
			try{
			  
				const string query = "UPDATE tblsettings SET " +
				"setting_name = @setting_name, " + 
				"setting_value = @setting_value, " + 
				"setting_status = @setting_status " + 
				"WHERE setting_id = @setting_id";
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
				{"@setting_id", _settingdto.setting_id},
				{"@setting_name", _settingdto.setting_name},
				{"@setting_value", _settingdto.setting_value},				
				{"@setting_status", _settingdto.setting_status} 
			};
			
			int numberOfRowsAffected = updategeneric(query, args);
			if(numberOfRowsAffected != 1){
				return false;
			}else{
			    return true;
			}
			}catch(Exception ex){
//				msgboxform.Show(ex.Message, TAG, "OK", msgtype.error);	 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return false;
			}
		}
		
		public bool updatecategoryindatabase(categorydto _categorydto){
			try{
			  
				const string query = "UPDATE tblcategories SET " +
				"category_name = @category_name, " +
				"category_status = @category_status " + 
				"WHERE category_id = @category_id";
 
			//here we are setting the parameter values that will be actually replaced in the query in Execute method
			var args = new Dictionary<string, object>
			{
				{"@category_id", _categorydto.category_id},
				{"@category_name", _categorydto.category_name},					
				{"@category_status", _categorydto.category_status} 
			};
			
			int numberOfRowsAffected = updategeneric(query, args);
			if(numberOfRowsAffected != 1){
				return false;
			}else{
			    return true;
			}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return false;
			}
		}
		
		public int deletegeneric(string query, Dictionary<string, object> args)
		{ 
			int numberOfRowsAffected;
			//setup the connection to the database
			using (var con = new SqlConnection(CONNECTION_STRING))
			{
				con.Open();
				//open a new command
				using (var cmd = new SqlCommand(query, con))
				{
					//set the arguments given in the query
					foreach (var pair in args)
					{
						cmd.Parameters.AddWithValue(pair.Key, pair.Value);
					}
					//execute the query and get the number of row affected
					numberOfRowsAffected = cmd.ExecuteNonQuery();
				}
				return numberOfRowsAffected;
			}
		}
	
		public bool deletecropindatabase(cropdto _cropdto){
		try{ 
				string query = "DELETE FROM " + 
						DBContract.cropsentitytable.CROPS_TABLE_NAME +
						" WHERE " +
						DBContract.cropsentitytable.CROP_ID + 
						" = " +
						"@crop_id";
	 
				//here we are setting the parameter values that will be actually replaced in the query in Execute method
				var args = new Dictionary<string, object>
				{
					{"@crop_id", _cropdto.crop_id}  
				};
				
				int numberOfRowsAffected = deletegeneric(query, args);
				if(numberOfRowsAffected != 1){
					return false;
				}else{
					return true;
				}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
	 	
		public bool deletecategoryindatabase(categorydto _categorydto){
		try{ 
				string query = "DELETE FROM " + 
						DBContract.categoriesentitytable.CATEGORIES_TABLE_NAME +
						" WHERE " +
						DBContract.categoriesentitytable.CATEGORY_ID + 
						" = " +
						"@category_id";
	 
				//here we are setting the parameter values that will be actually replaced in the query in Execute method
				var args = new Dictionary<string, object>
				{
					{"@category_id", _categorydto.category_id}  
				};
				
				int numberOfRowsAffected = deletegeneric(query, args);
				if(numberOfRowsAffected != 1){
					return false;
				}else{
					return true;
				}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
	 	
		public bool deletecropdiseaseindatabase(cropdiseasedto _cropdiseasedto){
		try{ 
				string query = "DELETE FROM " + 
						DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME +
						" WHERE " +
						DBContract.cropsdiseasesentitytable.CROP_DISEASE_ID + 
						" = " +
						"@crop_disease_id";
	 
				//here we are setting the parameter values that will be actually replaced in the query in Execute method
				var args = new Dictionary<string, object>
				{
					{"@crop_disease_id", _cropdiseasedto.crop_disease_id}  
				};
				
				int numberOfRowsAffected = deletegeneric(query, args);
				if(numberOfRowsAffected != 1){
					return false;
				}else{
					return true;
				}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		
		public bool deletemanufacturerindatabase(manufacturerdto _manufacturerdto){
		try{ 
				string query = "DELETE FROM " + 
						DBContract.manufacturersentitytable.MANUFACTURERS_TABLE_NAME +
						" WHERE " +
						DBContract.manufacturersentitytable.MANUFACTURER_ID + 
						" = " +
						"@manufacturer_id";
	 
				//here we are setting the parameter values that will be actually replaced in the query in Execute method
				var args = new Dictionary<string, object>
				{
					{"@manufacturer_id", _manufacturerdto.manufacturer_id}  
				};
				
				int numberOfRowsAffected = deletegeneric(query, args);
				if(numberOfRowsAffected != 1){
					return false;
				}else{
					return true;
				}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		public bool deletepestinsecticideindatabase(pestinsecticidedto _pestinsecticidedto){
		try{ 
				string query = "DELETE FROM " + 
						DBContract.pestsinsecticidesentitytable.PESTSINSECTICIDES_TABLE_NAME +
						" WHERE " +
						DBContract.pestsinsecticidesentitytable.PESTINSECTICIDE_ID + 
						" = " +
						"@pestinsecticide_id";
	 
				//here we are setting the parameter values that will be actually replaced in the query in Execute method
				var args = new Dictionary<string, object>
				{
					{"@pestinsecticide_id", _pestinsecticidedto.pestinsecticide_id}  
				};
				
				int numberOfRowsAffected = deletegeneric(query, args);
				if(numberOfRowsAffected != 1){
					return false;
				}else{
					return true;
				}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		public bool deletesettingindatabase(settingdto _settingdto){
		try{ 
				string query = "DELETE FROM " + 
						DBContract.settingsentitytable.SETTINGS_TABLE_NAME +
						" WHERE " +
						DBContract.settingsentitytable.SETTING_ID + 
						" = " +
						"@setting_id";
	 
				//here we are setting the parameter values that will be actually replaced in the query in Execute method
				var args = new Dictionary<string, object>
				{
					{"@setting_id", _settingdto.setting_id}  
				};
				
				int numberOfRowsAffected = deletegeneric(query, args);
				if(numberOfRowsAffected != 1){
					return false;
				}else{
					return true;
				}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		public bool deletecropvarietyindatabase(cropvarietydto _cropvarietydto){
		try{ 
				string query = "DELETE FROM " + 
						DBContract.cropsvarietiesentitytable.CROPS_VARIETIES_TABLE_NAME +
						" WHERE " +
						DBContract.cropsvarietiesentitytable.CROP_VARIETY_ID + 
						" = " +
						"@crop_variety_id";
	 
				//here we are setting the parameter values that will be actually replaced in the query in Execute method
				var args = new Dictionary<string, object>
				{
					{"@crop_variety_id", _cropvarietydto.crop_variety_id}  
				};
				
				int numberOfRowsAffected = deletegeneric(query, args);
				if(numberOfRowsAffected != 1){
					return false;
				}else{
					return true;
				}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}

        public responsedto createtable(string query, string CONNECTION_STRING){
			responsedto _responsedto = new responsedto();
         try{ 
	        	//setup the connection to the database
				using (var con = new MySqlConnection(CONNECTION_STRING))
				{
					con.Open();
					//open a new command
					using (var cmd = new MySqlCommand(query, con))
					{ 
						//execute the query  
						cmd.ExecuteNonQuery();
				
						_responsedto.isresponseresultsuccessful = true;
						string[] _conn_arr = CONNECTION_STRING.Split(new char[]{';'});
						_conn_arr.SetValue("", _conn_arr.Length - 1);
						_conn_arr.SetValue("", _conn_arr.Length - 2);
						string _sanitized_conn_arr = _conn_arr[0] + ";" + _conn_arr[1];
						_responsedto.responsesuccessmessage += "successfully executed query [ " + query + " ] against connection [ " + _sanitized_conn_arr + " ]." + Environment.NewLine;
						return _responsedto;
					}
				}
			}catch(Exception ex){
				_responsedto.isresponseresultsuccessful = false;
				Exception _exception = ex.GetBaseException();
				_responsedto.responseerrormessage += Environment.NewLine + "error executing query [ " + query + " ].";
				_responsedto.responseerrormessage += Environment.NewLine + Environment.NewLine +  _exception.Message + Environment.NewLine;
				return _responsedto;
			}		
        }
 
	    public responsedto createtables(mysqlconnectionstringdto _connectionstringdto) {
			responsedto _responsedto = new responsedto();
			responsedto _innerresponsedto = new responsedto();
			try{ 
				
				_connectionstringdto.database = _connectionstringdto.new_database_name;	
				 string CONNECTION_STRING = buildconnectionstringfromobject(_connectionstringdto);
				
	        //Create the crops table
	         string SQL_CREATE_CROPS_TABLE = "CREATE TABLE IF NOT EXISTS " + DBContract.cropsentitytable.CROPS_TABLE_NAME + " (" +
	                DBContract.cropsentitytable.CROP_ID + " INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
	                DBContract.cropsentitytable.CROP_NAME + " TEXT, " + 
	                DBContract.cropsentitytable.CROP_STATUS + " TEXT, " +
	                DBContract.cropsentitytable.CREATED_DATE + " TEXT " +
	                " ); ";
         
	          _innerresponsedto = createtable(SQL_CREATE_CROPS_TABLE, CONNECTION_STRING);
	          if(_innerresponsedto.isresponseresultsuccessful)
	          	_responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
	          else
	          	_responsedto.responseerrormessage += _innerresponsedto.responseerrormessage;
	          
		         //Create the crops varieties table
				string SQL_CREATE_CROPS_VARIETIES_TABLE = "CREATE TABLE IF NOT EXISTS " + DBContract.cropsvarietiesentitytable.CROPS_VARIETIES_TABLE_NAME + " (" +
		                DBContract.cropsvarietiesentitytable.CROP_VARIETY_ID + " INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
		                DBContract.cropsvarietiesentitytable.CROP_VARIETY_NAME + " TEXT, " +
		                DBContract.cropsvarietiesentitytable.CROP_VARIETY_STATUS + " TEXT, " +
						DBContract.cropsvarietiesentitytable.CROP_VARIETY_CROP_ID + " TEXT, " +
						DBContract.cropsvarietiesentitytable.CROP_VARIETY_MANUFACTURER_ID + " TEXT, " +
		                DBContract.cropsvarietiesentitytable.CREATED_DATE + " TEXT " +
		                " ); ";
		          
		          _innerresponsedto = createtable(SQL_CREATE_CROPS_VARIETIES_TABLE, CONNECTION_STRING);
		          if(_innerresponsedto.isresponseresultsuccessful)
		          	_responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
		          else
		          	_responsedto.responseerrormessage += _innerresponsedto.responseerrormessage;
		          
	        //Create the crops diseases/pests table
	         string SQL_CREATE_CROPS_DISEASES_TABLE = "CREATE TABLE IF NOT EXISTS " + DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME + " (" +
	                DBContract.cropsdiseasesentitytable.CROP_DISEASE_ID + " INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
	                DBContract.cropsdiseasesentitytable.CROP_DISEASE_NAME + " TEXT, " +
	         		DBContract.cropsdiseasesentitytable.CROP_DISEASE_CATEGORY + " TEXT, " +
	                DBContract.cropsdiseasesentitytable.CROP_DISEASE_STATUS + " TEXT, " + 
	                DBContract.cropsdiseasesentitytable.CREATED_DATE + " TEXT " +
	                " ); ";
	         
		          _innerresponsedto = createtable(SQL_CREATE_CROPS_DISEASES_TABLE, CONNECTION_STRING);
		          if(_innerresponsedto.isresponseresultsuccessful)
		          	_responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
		          else
		          	_responsedto.responseerrormessage += _innerresponsedto.responseerrormessage;
		          
	        //Create the manufacturers table
	         string SQL_CREATE_MANUFACTURERS_TABLE = "CREATE TABLE IF NOT EXISTS " + DBContract.manufacturersentitytable.MANUFACTURERS_TABLE_NAME + " (" +
	                DBContract.manufacturersentitytable.MANUFACTURER_ID + " INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
	                DBContract.manufacturersentitytable.MANUFACTURER_NAME + " TEXT, " +
	                DBContract.manufacturersentitytable.MANUFACTURER_STATUS + " TEXT, " +
	                DBContract.manufacturersentitytable.CREATED_DATE + " TEXT " +
	                " ); ";
	         
		          _innerresponsedto = createtable(SQL_CREATE_MANUFACTURERS_TABLE, CONNECTION_STRING);
		          if(_innerresponsedto.isresponseresultsuccessful)
		          	_responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
		          else
		          	_responsedto.responseerrormessage += _innerresponsedto.responseerrormessage;
		        
	        //Create the pesticides/insecticides table
	         string SQL_CREATE_PESTSINSECTICIDES_TABLE = "CREATE TABLE IF NOT EXISTS " + DBContract.pestsinsecticidesentitytable.PESTSINSECTICIDES_TABLE_NAME + " (" +
	                DBContract.pestsinsecticidesentitytable.PESTINSECTICIDE_ID + " INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
	                DBContract.pestsinsecticidesentitytable.PESTINSECTICIDE_NAME + " TEXT, " +
	                DBContract.pestsinsecticidesentitytable.PESTINSECTICIDE_CATEGORY + " TEXT, " + 
	                DBContract.pestsinsecticidesentitytable.PESTINSECTICIDE_STATUS + " TEXT, " +
					DBContract.pestsinsecticidesentitytable.PESTINSECTICIDE_CROP_DISEASE_ID + " TEXT, " +
					DBContract.pestsinsecticidesentitytable.PESTINSECTICIDE_MANUFACTURER_ID + " TEXT, " +
	                DBContract.pestsinsecticidesentitytable.CREATED_DATE + " TEXT " +
	                " ); ";
	         
		          _innerresponsedto = createtable(SQL_CREATE_PESTSINSECTICIDES_TABLE, CONNECTION_STRING);
		          if(_innerresponsedto.isresponseresultsuccessful)
		          	_responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
		          else
		          	_responsedto.responseerrormessage += _innerresponsedto.responseerrormessage;
		        
	        //Create the settings table
	         string SQL_CREATE_SETTINGS_TABLE = "CREATE TABLE IF NOT EXISTS " + DBContract.settingsentitytable.SETTINGS_TABLE_NAME + " (" +
	                DBContract.settingsentitytable.SETTING_ID + " INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
	                DBContract.settingsentitytable.SETTING_NAME + " TEXT, " +
	                DBContract.settingsentitytable.SETTING_VALUE + " TEXT, " +
	                DBContract.settingsentitytable.SETTING_STATUS + " TEXT, " +
	                DBContract.settingsentitytable.CREATED_DATE + " TEXT " +
	                " ); ";
	         
		          _innerresponsedto = createtable(SQL_CREATE_SETTINGS_TABLE, CONNECTION_STRING);
		          if(_innerresponsedto.isresponseresultsuccessful)
		          	_responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
		          else
		          	_responsedto.responseerrormessage += _innerresponsedto.responseerrormessage;
		          
	        //Create the categories table
	         string SQL_CREATE_CATEGORIES_TABLE = "CREATE TABLE IF NOT EXISTS " + DBContract.categoriesentitytable.CATEGORIES_TABLE_NAME + " (" +
	                DBContract.categoriesentitytable.CATEGORY_ID + " INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
	                DBContract.categoriesentitytable.CATEGORY_NAME + " TEXT, " + 
	                DBContract.categoriesentitytable.CATEGORY_STATUS + " TEXT, " +
	                DBContract.categoriesentitytable.CREATED_DATE + " TEXT " +
	                " ); ";
	         
		          _innerresponsedto = createtable(SQL_CREATE_CATEGORIES_TABLE, CONNECTION_STRING);
		          if(_innerresponsedto.isresponseresultsuccessful)
		          	_responsedto.responsesuccessmessage += _innerresponsedto.responsesuccessmessage;
		          else
		          	_responsedto.responseerrormessage += _innerresponsedto.responseerrormessage;
		          
					  /* _responsedto.responsesuccessmessage += Environment.NewLine;
					  _responsedto.responsesuccessmessage += "successfully created tables in database [ " + _connectionstringdto.database + " ].";
					  _responsedto.responsesuccessmessage += Environment.NewLine; */
//					 
//					  string[] _tables = DBContract.table_names_arr;
//					  int _entity_count = _tables.Length;
//					  Console.WriteLine("_entity_count [ " + _entity_count +  " ]");
//					  int _task_count = 0;
//					  
//					  foreach(var _table in _tables){
//					  	switch(_table){
//					  		case DBContract.cropsentitytable.CROPS_TABLE_NAME:
//					  			_task_count++;
//					  		break;
//					  		case DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME:
//					  			_task_count++;
//					  		break;
//					  		case DBContract.cropsvarietiesentitytable.CROPS_VARIETIES_TABLE_NAME:
//					  			_task_count++;
//					  		break;
//					  		case DBContract.manufacturersentitytable.MANUFACTURERS_TABLE_NAME:
//					  			_task_count++;
//					  		break;
//					  		case DBContract.pestsinsecticidesentitytable.PESTSINSECTICIDES_TABLE_NAME:
//					  			_task_count++;
//					  		break;
//					  		case DBContract.settingsentitytable.SETTINGS_TABLE_NAME:
//					  			_task_count++;
//					  		break;
//					  		case DBContract.categoriesentitytable.CATEGORIES_TABLE_NAME:
//					  			_task_count++;
//					  		break;
//					  	}
//					  	
//					  }
//					  
//					  Console.WriteLine("_task_count [ " + _task_count +  " ]");
					   
					  string successmsg = "successfully created tables in database [ " + _connectionstringdto.database + " ] - server [ " + DBContract.mysql + " ].";
					  int msg_length = successmsg.Length;
					  msg_length = msg_length + 1; 
					  int stars_printed = 0;
					  string str_stars = "";
					  string str_newline = Environment.NewLine;
					  
					  while(stars_printed != msg_length){
						str_stars += "*";
						++stars_printed;
					  }
					  
					  _responsedto.responsesuccessmessage += str_newline;
					  _responsedto.responsesuccessmessage += str_stars;
					  _responsedto.responsesuccessmessage += str_newline;
					  _responsedto.responsesuccessmessage += successmsg;
					  _responsedto.responsesuccessmessage += str_newline;
					  _responsedto.responsesuccessmessage += str_newline;
					  _responsedto.responsesuccessmessage += str_stars;
					    
			       _responsedto.isresponseresultsuccessful = true;
			       return _responsedto;
	        
			}catch(Exception ex){ 	 
				_responsedto.isresponseresultsuccessful = false; 
				_responsedto.responseerrormessage += Environment.NewLine + ex.Message;
				return _responsedto;
			}
	    }

		public bool isdbconnectionalive()
		{   
			 var con = new MySqlConnection(CONNECTION_STRING);
			 con.Open();
			 return true;
		}
		 
		public bool isdbconnectionalive(string CONNECTION_STRING)
		{    
			 var con = new MySqlConnection(CONNECTION_STRING);
			 con.Open();
			 return true;
		}
		 
        private void updatedbschema(string query){ 
         try{ 
	        	//setup the connection to the database
				using (var con = new MySqlConnection(CONNECTION_STRING))
				{
					con.Open();
					//open a new command
					using (var cmd = new MySqlCommand(query, con))
					{ 
						//execute the query  
						cmd.ExecuteNonQuery();
					}
				}
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));				
			}			
        }
 
		public void updateexistingdbschema(){
		try{
				 
			  //update the tables  
	          string SQL_ALTER_CROPS_DISEASES_TABLE = " ALTER TABLE " + 
	          	DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME +
	                " ADD " +
	                DBContract.cropsdiseasesentitytable.CROP_DISEASE_CATEGORY + 
	                " TEXT "; 
	          updatedbschema(SQL_ALTER_CROPS_DISEASES_TABLE);				
 
			}catch(Exception ex){  
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));				
			}
		}
		
		public cropdto getcropbyname(string crop_name)
		{
			try{ 
				
				var query = "SELECT * FROM " +
					DBContract.cropsentitytable.CROPS_TABLE_NAME +
					" WHERE " +
					DBContract.cropsentitytable.CROP_NAME + 
					" = " +
					"@crop_name";
				 
				var args = new Dictionary<string, object>
				{
					{"@crop_name", crop_name}
				};
				
				DataTable dt = ExecuteRead(query, args);
				if (dt == null || dt.Rows.Count == 0)
				{
					return null;
				}
				
				cropdto _crop_dto = new cropdto();
				_crop_dto.crop_id = Convert.ToString(dt.Rows[0]["crop_id"]);
				_crop_dto.crop_name = Convert.ToString(dt.Rows[0]["crop_name"]); 
				_crop_dto.crop_status = Convert.ToString(dt.Rows[0]["crop_status"]);
				_crop_dto.created_date = Convert.ToString(dt.Rows[0]["created_date"]);
				     
				return _crop_dto;
				
			}catch(Exception ex){  
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));	
				return null;				
			}
		}
		
		public categorydto getcategorybyname(string category_name)
		{
			try{ 
				
				var query = "SELECT * FROM " +
					DBContract.categoriesentitytable.CATEGORIES_TABLE_NAME +
					" WHERE " +
					DBContract.categoriesentitytable.CATEGORY_NAME + 
					" = " +
					"@category_name";
				 
				var args = new Dictionary<string, object>
				{
					{"@category_name", category_name}
				};
				
				DataTable dt = ExecuteRead(query, args);
				if (dt == null || dt.Rows.Count == 0)
				{
					return null;
				}
				
				categorydto _category_dto = new categorydto();
				_category_dto.category_id = Convert.ToString(dt.Rows[0]["category_id"]);
				_category_dto.category_name = Convert.ToString(dt.Rows[0]["category_name"]); 
				_category_dto.category_status = Convert.ToString(dt.Rows[0]["category_status"]);
				_category_dto.created_date = Convert.ToString(dt.Rows[0]["created_date"]);
				
				return _category_dto;
				
			}catch(Exception ex){  
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));	
				return null;				
			}
		}
		
		private DataTable ExecuteRead(string query, Dictionary<string, object> args)
		{
			if (string.IsNullOrEmpty(query.Trim()))
			return null;
			using (var con = new MySqlConnection(CONNECTION_STRING))
			{
				con.Open();
				using (var cmd = new MySqlCommand(query, con))
				{
					foreach (KeyValuePair<string, object> entry in args)
					{
						cmd.Parameters.AddWithValue(entry.Key, entry.Value);
					}
					var da = new MySqlDataAdapter(cmd);
					var dt = new DataTable();
					da.Fill(dt);
					da.Dispose();
					return dt;
				}
			}
		}
        public responsedto checkmysqlconnectionstate()
        {
            responsedto _responsedto = new responsedto();
            try
            {
                mysqlconnectionstringdto _connectionstringdto = getmysqlconnectionstringdto();

                _responsedto = checkconnectionasadmin(_connectionstringdto);

                return _responsedto;
            }
            catch (Exception ex)
            {
                _responsedto.isresponseresultsuccessful = false;
                _responsedto.responseerrormessage = ex.Message;
                return _responsedto;
            }
        }
		public responsedto checkconnectionasadmin(mysqlconnectionstringdto _connectionstringdto){
			responsedto _responsedto = new responsedto();
			try{
				string CONNECTION_STRING = @"host=" + _connectionstringdto.datasource + ";" +  
				"database=" + _connectionstringdto.database + ";" +
				"port=" + _connectionstringdto.port + ";" +
				"user=" + _connectionstringdto.userid + ";" +
				"password=" + _connectionstringdto.password;
				
			    string query = DBContract.CROPS_SELECT_ALL_QUERY;
			    
			    int count = getrecordscountgiventable(DBContract.cropsentitytable.CROPS_TABLE_NAME, CONNECTION_STRING);
			    
			    if(count != -1){
			    	_responsedto.isresponseresultsuccessful = true;
					_responsedto.responsesuccessmessage = "connection to mysql successfull. crops count [ " + count + " ]";
			    	return _responsedto;
			    }else{
			    	_responsedto.isresponseresultsuccessful = false;
					_responsedto.responseerrormessage = "connection to mysql failed.";
			    	return _responsedto;
			    }
			}catch(Exception ex){  
				_responsedto.isresponseresultsuccessful = false;
				_responsedto.responseerrormessage = ex.Message;
				return _responsedto; 
			}
		}
		
		public int getrecordscountgiventable(string tablename, string CONNECTION_STRING){ 
		    string query = "SELECT * FROM " + tablename;
		    DataTable dt = getallrecordsglobal(query, CONNECTION_STRING);
		    if(dt != null)
		    	return dt.Rows.Count;
		    else
		    	return -1;
		}
		 
		public bool checkifcropexists(string entity_name, string connection_string){
			bool _exists = false;
			try{
				 
				string query = DBContract.CROPS_SELECT_ALL_QUERY;
				
				DataTable dt = getallrecordsglobal(query, connection_string);
				
				var _recordscount = dt.Rows.Count;
				
				for(int i = 0; i < _recordscount; i++){
					
					var _record_from_server = Convert.ToString(dt.Rows[i]["crop_name"]);
		 
					if(entity_name == _record_from_server){
						_exists = true;
						return _exists;
					} 
				}
				
				return _exists; 
				
				}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				_exists = false;
				return _exists; 
			}
		}
		
		public bool checkifmanufacturerexists(string entity_name, string connection_string){
			bool _exists = false;
			try{
				 
				string query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY;
				
				DataTable dt = getallrecordsglobal(query, connection_string);
				
				var _recordscount = dt.Rows.Count;
				
				for(int i = 0; i < _recordscount; i++){
					
					var _record_from_server = Convert.ToString(dt.Rows[i]["manufacturer_name"]);
		 
					if(entity_name == _record_from_server){
						_exists = true;
						return _exists;
					} 
				}
				
				return _exists; 
				
				}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				_exists = false;
				return _exists; 
			}
		}
		
		public bool checkifcategoryexists(string entity_name, string connection_string){
			bool _exists = false;
			try{
				 
				string query = DBContract.CATEGORIES_SELECT_ALL_QUERY;
				
				DataTable dt = getallrecordsglobal(query, connection_string);
				
				var _recordscount = dt.Rows.Count;
				
				for(int i = 0; i < _recordscount; i++){
					
					var _record_from_server = Convert.ToString(dt.Rows[i]["category_name"]);
		 
					if(entity_name == _record_from_server){
						_exists = true;
						return _exists;
					} 
				}
				
				return _exists; 
				
				}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				_exists = false;
				return _exists; 
			}
		}
		
		public bool checkifsettingexists(string entity_name, string connection_string){
			bool _exists = false;
			try{
				 
				string query = DBContract.SETTINGS_SELECT_ALL_QUERY;
				
				DataTable dt = getallrecordsglobal(query, connection_string);
				
				var _recordscount = dt.Rows.Count;
				
				for(int i = 0; i < _recordscount; i++){
					
					var _record_from_server = Convert.ToString(dt.Rows[i]["setting_name"]);
		 
					if(entity_name == _record_from_server){
						_exists = true;
						return _exists;
					} 
				}
				
				return _exists; 
				
				}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				_exists = false;
				return _exists; 
			}
		}
		
		public bool checkifcropvarietyexists(string entity_name, string connection_string){
			bool _exists = false;
			try{
				 
				string query = DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY;
				
				DataTable dt = getallrecordsglobal(query, connection_string);
				
				var _recordscount = dt.Rows.Count;
				
				for(int i = 0; i < _recordscount; i++){
					
					var _record_from_server = Convert.ToString(dt.Rows[i]["crop_variety_name"]);
		 
					if(entity_name == _record_from_server){
						_exists = true;
						return _exists;
					} 
				}
				
				return _exists; 
				
				}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				_exists = false;
				return _exists; 
			}
		}
		
		public bool checkifdiseasepestexists(string entity_name, string connection_string){
			bool _exists = false;
			try{
				 
				string query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY;
				
				DataTable dt = getallrecordsglobal(query, connection_string);
				
				var _recordscount = dt.Rows.Count;
				
				for(int i = 0; i < _recordscount; i++){
					
					var _record_from_server = Convert.ToString(dt.Rows[i]["crop_disease_name"]);
		 
					if(entity_name == _record_from_server){
						_exists = true;
						return _exists;
					} 
				}
				
				return _exists; 
				
				}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				_exists = false;
				return _exists; 
			}
		}
		
		public bool checkifpesticideinsecticideexists(string entity_name, string connection_string){
			bool _exists = false;
			try{
				 
				string query = DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY;
				
				DataTable dt = getallrecordsglobal(query, connection_string);
				
				var _recordscount = dt.Rows.Count;
				
				for(int i = 0; i < _recordscount; i++){
					
					var _record_from_server = Convert.ToString(dt.Rows[i]["pestinsecticide_name"]);
		 
					if(entity_name == _record_from_server){
						_exists = true;
						return _exists;
					} 
				}
				
				return _exists; 
				
				}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				_exists = false;
				return _exists; 
			}
		}
		
		public mysqlconnectionstringdto getmysqlconnectionstringdto(){
			try{
				mysqlconnectionstringdto _connectionstringdto = new mysqlconnectionstringdto();
				
				_connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mysql_datasource"];
				_connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mysql_database"]; 
				_connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mysql_userid"];
				_connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mysql_password"];
				_connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mysql_port"];
		  
				return _connectionstringdto;
				
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return null;
			}
		}
		
		public List<string> get_mysql_databases()
		{
			List<string> server_databases = new List<string>();
			try{
				 string CONNECTION_STRING = getmysqlconnectionstring();
				//string query = "SELECT * FROM information_schema.TABLES";
				string query = "SHOW databases";
				
				 DataTable dt = getmysqldatabasesfromschema(query, CONNECTION_STRING);
				 
				 var _recordscount = dt.Rows.Count;
				 
				for(int i = 0; i < _recordscount; i++){
	 
					server_databases.Add(Convert.ToString(dt.Rows[i]["Database"]));
						 
				}		 	
				return server_databases;				 
			 }catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return server_databases;
			}
		}
		
		public bool check_if_mysql_database_exists(string database_name)
		{
			bool _exists = false;
			try{
				 List<string> server_databases = get_mysql_databases();
				 var _recordscount = server_databases.Count;
				 
				 for(int i = 0; i < _recordscount; i++){
					
					var _record_from_server = server_databases[i];
		 
					if(database_name == _record_from_server){
						_exists = true;
						return _exists;
					} 
				}
				 
				return _exists;				 
			 }catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return _exists;
			}
		}
		
		public string getmysqlconnectionstring(){
			try{
				mysqlconnectionstringdto _connectionstringdto = new mysqlconnectionstringdto();
				
				_connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mysql_datasource"];
				_connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mysql_database"];
				_connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mysql_userid"];
				_connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mysql_password"];
				_connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mysql_port"];
					 
				string CONNECTION_STRING = buildmysqlconnectionstringfromobject(_connectionstringdto);
 	 
				return CONNECTION_STRING;
				
			}catch(Exception ex){ 
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
				return null;
			}
		}
		
		string buildmysqlconnectionstringfromobject(mysqlconnectionstringdto _connectionstringdto){
			string CONNECTION_STRING = @"Server=" + _connectionstringdto.datasource + ";" +
				"Database=" + _connectionstringdto.database + ";" +
				"Port=" + _connectionstringdto.port + ";" +
				"User Id=" + _connectionstringdto.userid + ";" +
				"Password=" + _connectionstringdto.password;
			return CONNECTION_STRING;
		}
		
		public DataTable getmysqldatabasesfromschema(string query, string CONNECTION_STRING)
		{
			if (string.IsNullOrEmpty(query.Trim())) return null;
			
			using (var con = new MySqlConnection(CONNECTION_STRING))
			{
				con.Open();
				using (var cmd = new MySqlCommand(query, con))
				{
					var da = new MySqlDataAdapter(cmd); 
					var dt = new DataTable();
					da.Fill(dt);
					da.Dispose();
					return dt;
				}
			}
		}

		public DataTable execute_select_query(string query, string CONNECTION_STRING)
		{
			using (var con = new MySqlConnection(CONNECTION_STRING))
			{
				con.Open();
				using (var cmd = new MySqlCommand(query, con))
				{
					var da = new MySqlDataAdapter(cmd); 
					var dt = new DataTable();
					da.Fill(dt);
					da.Dispose();
					return dt;
				}
			}
		} 
		
		public int execute_data_manipulation_query(string query, string CONNECTION_STRING)
		{ 
			int numberOfRowsAffected;
			//setup the connection to the database
			using (var con = new MySqlConnection(CONNECTION_STRING))
			{
				con.Open();
				//open a new command
				using (var cmd = new MySqlCommand(query, con))
				{ 
					//execute the query and get the number of row affected
					numberOfRowsAffected = cmd.ExecuteNonQuery();
				}
				return numberOfRowsAffected;
			}
		}
		
		
		
		
		
	}
}
