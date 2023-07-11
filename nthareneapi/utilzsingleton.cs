/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 20:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace nthareneapi
{
	/// <summary>
	/// Description of utilzsingleton.
	/// </summary>
	public sealed class utilzsingleton
	{
		// Because the _instance member is made private, the only way to get the single
		// instance is via the static Instance property below. This can also be similarly
		// achieved with a GetInstance() method instead of the property. 
		private static utilzsingleton singleInstance;
			 
	    public static utilzsingleton getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname) {
			// The first call will create the one and only instance.
	        if (singleInstance == null)
	            singleInstance = new utilzsingleton(notificationmessageEventname);
	        // Every call afterwards will return the single instance created above.
	        return singleInstance;
	    }
 
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;		
		public string TAG;
		
		private utilzsingleton(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
		{
			TAG = this.GetType().Name;				
			_notificationmessageEventname = notificationmessageEventname; 
		}
		
		private utilzsingleton()
		{
			
		}
		
		public Color AlternatingRowsDefaultCellStyleBackColor = Color.Chocolate;
		public Color AlternatingRowsDefaultCellStyleForeColor = Color.Black;
		
		public string CryptographyMD5(string source){
			// Creates an instance of the default implementation of the MD5 hash algorithm.
			using (var md5Hash = MD5.Create())
			{
				// Byte array representation of source string
				var sourceBytes = Encoding.UTF8.GetBytes(source);
				// Generate hash value(Byte Array) for input data
				var hashBytes = md5Hash.ComputeHash(sourceBytes);
				// Convert hash byte array to string
				var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
				// Output the MD5 hash
				Console.WriteLine("The MD5 hash of " + source + " is: " + hash);
				return hash;
			}
		}
		
		public string CryptographySHA1(string source){ 
			using (SHA1 sha1Hash = SHA1.Create())
			{
			//From String to byte array
			byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
			byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
			string hash = BitConverter.ToString(hashBytes).Replace("-",String.Empty);
			Console.WriteLine("The SHA1 hash of " + source + " is: " + hash);
			return hash;
			}
		}
		
		public string CryptographySHA256(string source){ 
			using (SHA256 sha256Hash = SHA256.Create())
			{
			//From String to byte array
			byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
			byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
			string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
			Console.WriteLine("The SHA256 hash of " + source + " is: " + hash);
			return hash;
			}
		}
		
		public string CryptographySHA384(string source){ 
			using (SHA384 sha384Hash = SHA384.Create())
			{
			//From String to byte array
			byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
			byte[] hashBytes = sha384Hash.ComputeHash(sourceBytes);
			string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
			Console.WriteLine("The SHA384 hash of " + source + " is: " + hash);
			return hash;
			}
		}
		
		public string CryptographySHA512(string source){ 
			using (SHA512 sha512Hash = SHA512.Create())
			{
			//From String to byte array
			byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
			byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
			string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
			Console.WriteLine("The SHA512 hash of " + source + " is: " + hash);
			return hash;
			}
		}
		
		public static byte[] GenerateRandomData(int length)
		{
		var rnd = new byte[length];
		using (var rng = new RNGCryptoServiceProvider())
		rng.GetBytes(rnd);
		return rnd;
		} 
		
		public static int GenerateRandomInt(int minVal=0, int maxVal=100)
		{
		var rnd = new byte[4];
		using (var rng = new RNGCryptoServiceProvider())
		rng.GetBytes(rnd);
		var i = Math.Abs(BitConverter.ToInt32(rnd, 0));
		return Convert.ToInt32(i % (maxVal - minVal + 1) + minVal);
		} 
		
		public static string GenerateRandomString(int length, string allowableChars=null)
		{
		if (string.IsNullOrEmpty(allowableChars))
		allowableChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		// Generate random data
		var rnd = new byte[length];
		using (var rng = new RNGCryptoServiceProvider())
		rng.GetBytes(rnd); 
		// Generate the output string
		var allowable = allowableChars.ToCharArray();
		var l = allowable.Length;
		var chars = new char[length];
		for (var i = 0; i < length; i++)
		chars[i] = allowable[rnd[i] % l];
		return new string(chars);
		}
 
		public string getappsettinggivenkey(string key = "", string defaultvalue = ""){
			try{
				
				string configvalue = "";
				
				configvalue = System.Configuration.ConfigurationManager.AppSettings[key]; 
					  
				if(configvalue == null || String.IsNullOrEmpty(configvalue)){
					return defaultvalue;
				}else{
					return configvalue;
				}
				
			}catch(Exception ex){  
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, this.TAG));
				return defaultvalue;
			}
		}
		
		public cropdto buildcropdtogivendatatable(DataTable dt, int _index)
		{
			cropdto _crop_dto = new cropdto();
			_crop_dto.crop_id = Convert.ToString(dt.Rows[_index]["crop_id"]);
			_crop_dto.crop_name = Convert.ToString(dt.Rows[_index]["crop_name"]); 
			_crop_dto.crop_status = Convert.ToString(dt.Rows[_index]["crop_status"]);
			_crop_dto.created_date = Convert.ToString(dt.Rows[_index]["created_date"]);

			return _crop_dto;
		}
		
		public cropvarietydto buildcropvarietydtogivendatatable(DataTable dt, int _index)
		{
			cropvarietydto _cropvarietydto = new cropvarietydto();
			_cropvarietydto.crop_variety_id = Convert.ToString(dt.Rows[_index]["crop_variety_id"]);
			_cropvarietydto.crop_variety_name = Convert.ToString(dt.Rows[_index]["crop_variety_name"]); 
			_cropvarietydto.crop_variety_status = Convert.ToString(dt.Rows[_index]["crop_variety_status"]);
			_cropvarietydto.created_date = Convert.ToString(dt.Rows[_index]["created_date"]);
			
			_cropvarietydto.crop_variety_crop_id = Convert.ToString(dt.Rows[_index]["crop_variety_crop_id"]);
			_cropvarietydto.crop_variety_manufacturer_id = Convert.ToString(dt.Rows[_index]["crop_variety_manufacturer_id"]);

			return _cropvarietydto;
		}
		
		public cropdiseasedto buildcropdiseasedtogivendatatable(DataTable dt, int _index)
		{
			cropdiseasedto _cropdiseasedto = new cropdiseasedto();
			_cropdiseasedto.crop_disease_id = Convert.ToString(dt.Rows[_index]["crop_disease_id"]);
			_cropdiseasedto.crop_disease_name = Convert.ToString(dt.Rows[_index]["crop_disease_name"]);
			_cropdiseasedto.crop_disease_category = Convert.ToString(dt.Rows[_index]["crop_disease_category"]);
			_cropdiseasedto.crop_disease_status = Convert.ToString(dt.Rows[_index]["crop_disease_status"]);
			_cropdiseasedto.created_date = Convert.ToString(dt.Rows[_index]["created_date"]);

			return _cropdiseasedto;
		}
		
		public manufacturerdto buildmanufacturerdtogivendatatable(DataTable dt, int _index)
		{
			manufacturerdto _manufacturerdto = new manufacturerdto();
			_manufacturerdto.manufacturer_id = Convert.ToString(dt.Rows[_index]["manufacturer_id"]);
			_manufacturerdto.manufacturer_name = Convert.ToString(dt.Rows[_index]["manufacturer_name"]); 
			_manufacturerdto.manufacturer_status = Convert.ToString(dt.Rows[_index]["manufacturer_status"]);
			_manufacturerdto.created_date = Convert.ToString(dt.Rows[_index]["created_date"]);

			return _manufacturerdto;
		}
		
		public pestinsecticidedto buildpestinsecticidedtogivendatatable(DataTable dt, int _index)
		{
			pestinsecticidedto _pestinsecticidedto = new pestinsecticidedto();
			_pestinsecticidedto.pestinsecticide_id = Convert.ToString(dt.Rows[_index]["pestinsecticide_id"]);
			_pestinsecticidedto.pestinsecticide_name = Convert.ToString(dt.Rows[_index]["pestinsecticide_name"]);
			_pestinsecticidedto.pestinsecticide_category = Convert.ToString(dt.Rows[_index]["pestinsecticide_category"]);
			_pestinsecticidedto.pestinsecticide_crop_disease_id = Convert.ToString(dt.Rows[_index]["pestinsecticide_crop_disease_id"]);			
			_pestinsecticidedto.pestinsecticide_manufacturer_id = Convert.ToString(dt.Rows[_index]["pestinsecticide_manufacturer_id"]);
			_pestinsecticidedto.pestinsecticide_status = Convert.ToString(dt.Rows[_index]["pestinsecticide_status"]);
			_pestinsecticidedto.created_date = Convert.ToString(dt.Rows[_index]["created_date"]);

			return _pestinsecticidedto;
		}
		
		public settingdto buildsettingdtogivendatatable(DataTable dt, int _index)
		{
			settingdto _settingdto = new settingdto();
			_settingdto.setting_id = Convert.ToString(dt.Rows[_index]["setting_id"]);
			_settingdto.setting_name = Convert.ToString(dt.Rows[_index]["setting_name"]);
			_settingdto.setting_value = Convert.ToString(dt.Rows[_index]["setting_value"]); 
			_settingdto.setting_status = Convert.ToString(dt.Rows[_index]["setting_status"]);
			_settingdto.created_date = Convert.ToString(dt.Rows[_index]["created_date"]);

			return _settingdto;
		}
		
		public categorydto buildcategorydtogivendatatable(DataTable dt, int _index)
		{
			categorydto _category_dto = new categorydto();
			_category_dto.category_id = Convert.ToString(dt.Rows[_index]["category_id"]);
			_category_dto.category_name = Convert.ToString(dt.Rows[_index]["category_name"]); 
			_category_dto.category_status = Convert.ToString(dt.Rows[_index]["category_status"]);
			_category_dto.created_date = Convert.ToString(dt.Rows[_index]["created_date"]);

			return _category_dto;
		}
		
		
		
	}
}
