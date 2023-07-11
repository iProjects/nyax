/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/14/2018
 * Time: 09:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using nthareneapi;

namespace nyax
{
	/// <summary>
	/// Description of editcropdiseaseform.
	/// </summary>
	public partial class editcropdiseaseform : Form
	{
		public string TAG; 
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname; 
		public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
		public responsedto _responsedto = new responsedto();
		public cropdiseasedto _cropdiseasedto;
		public cropdiseaseslistform _cropdiseaseslistform;
		
		public editcropdiseaseform(cropdiseasedto cropdiseasedto, cropdiseaseslistform cropdiseaseslistform, EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			_cropdiseasedto = cropdiseasedto;
			_cropdiseaseslistform = cropdiseaseslistform;
			
			TAG = this.GetType().Name;
				
		    _notificationmessageEventname = notificationmessageEventname; 
			 _progressBarNotificationEventname = progressBarNotificationEventname;
			 
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded editcropdiseaseform", TAG));
				
		}
		
		void populatecontrols(){
			txtdiseasename.Text = _cropdiseasedto.crop_disease_name;
			cbocategory.SelectedValue = _cropdiseasedto.crop_disease_category; 
			cbostatus.SelectedValue = _cropdiseasedto.crop_disease_status; 
		}
		
		void EditcropdiseaseformLoad(object sender, EventArgs e)
		{
			 cbostatus.Items.AddRange(new [] {"active", "inactive" });
			 cbostatus.SelectedIndex=0;
			 
			 cbocategory.Items.AddRange(new [] {"PEST", "DISEASE" });
			 cbocategory.SelectedIndex = 0;
			 
			 this.AcceptButton = btnupdate;
			 this.CancelButton = btnclose;
			 txtdiseasename.Focus();
			 
			populatecontrols();
		}
		 
		void BtncloseClick(object sender, EventArgs e)
		{
			this.Close();	
		}
		
		void BtnupdateClick(object sender, EventArgs e)
		{
			if(validateuserinput()){
				_cropdiseaseslistform.populatecropsdiseaseslist();
				this.Close();
			}else{
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("record validation failed...", TAG));
			}
				
		}
		
		bool validateuserinput()
		{
			bool _isuserdetailsvalid=true;
			string _errormsg="";
			
			if(String.IsNullOrEmpty(txtdiseasename.Text)){
				_isuserdetailsvalid=false;
				_errormsg+="disease/pest name cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("disease/pest name cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbocategory.Text)){
				_isuserdetailsvalid=false;
				_errormsg+="category cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("category cannot be null.", TAG));
			} 
			if(String.IsNullOrEmpty(cbostatus.Text)){
				_isuserdetailsvalid=false;
				_errormsg+=Environment.NewLine+"status cannot be null.";
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("status cannot be null.", TAG));
			} 
			
			if(_isuserdetailsvalid){
			bool _isupdaterecordsuccessful = updatecropdiseaseindatabase();
			if(_isupdaterecordsuccessful){
				_cropdiseaseslistform.populatecropsdiseaseslist();	
				this.Close(); 
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error);	 
				txtdiseasename.Focus();
			}
			
			}else{
				msgboxform.Show(_errormsg, TAG, msgtype.error); 
				txtdiseasename.Focus();
			}
			return _isuserdetailsvalid;
		}
		 
		bool updatecropdiseaseindatabase(){
		try{
		 
				DateTime currentDate = DateTime.Now;
				string dateTimeString = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
	 
				cropdiseasedto _cropdisease_dto = new cropdiseasedto();
				_cropdisease_dto.crop_disease_id = _cropdiseasedto.crop_disease_id; 
				_cropdisease_dto.crop_disease_name = txtdiseasename.Text; 
				_cropdisease_dto.crop_disease_category = cbocategory.Text;  
				_cropdisease_dto.crop_disease_status = cbostatus.Text;
				_cropdisease_dto.created_date = dateTimeString; 
				  
				saveinmssqldb(_cropdisease_dto);
				saveinsqlitedb(_cropdisease_dto);
				saveinmysqldb(_cropdisease_dto);
				  
				return true; 
					
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG)); 
				return false;
			}
		}
		 
		
		void saveinmssqldb(cropdiseasedto _cropdiseasedto)
		{ 
			try{
				string saveinmssql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmssql", "false");
				  
				bool _saveinmssql;
				bool _trysaveinmssql = bool.TryParse(saveinmssql, out _saveinmssql);
					
				if(_saveinmssql){
					bool numberOfRowsAffected = false;
				    numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).updatecropdiseaseindatabase(_cropdiseasedto);
				    if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated crop disease/pest in mssql db { " +                                                                       Environment.NewLine + "disease/pest name: " + _cropdiseasedto.crop_disease_name + ","+
	 				Environment.NewLine + "category: " + _cropdiseasedto.crop_disease_category + ","+
					Environment.NewLine + "status: " + _cropdiseasedto.crop_disease_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinmysqldb(cropdiseasedto _cropdiseasedto)
		{ 
			try{
				string saveinmysql = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinmysql", "false");
				
				bool _saveinmysql;
				bool _trysaveinmysql = bool.TryParse(saveinmysql, out _saveinmysql);
					
				if(_saveinmysql){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).updatecropdiseaseindatabase(_cropdiseasedto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated crop disease/pest in mysql db { " +                                                                       Environment.NewLine + "disease/pest name: " + _cropdiseasedto.crop_disease_name + ","+
	 				Environment.NewLine + "category: " + _cropdiseasedto.crop_disease_category + ","+
					Environment.NewLine + "status: " + _cropdiseasedto.crop_disease_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void saveinsqlitedb(cropdiseasedto _cropdiseasedto)
		{ 
			try{
				string saveinsqlite = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("saveinsqlite", "false");
				
				bool _saveinsqlite;
				bool _trysaveinsqlite = bool.TryParse(saveinsqlite, out _saveinsqlite);
					
				if(_saveinsqlite){
					bool numberOfRowsAffected = false;
				  	numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).updatecropdiseaseindatabase(_cropdiseasedto);
				  	if(numberOfRowsAffected){
			    	_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("successfully updated crop disease/pest in sqlite db { " +                                                                       Environment.NewLine + "disease/pest name: " + _cropdiseasedto.crop_disease_name + ","+
	 				Environment.NewLine + "category: " + _cropdiseasedto.crop_disease_category + ","+
					Environment.NewLine + "status: " + _cropdiseasedto.crop_disease_status + " }.", TAG));
				    }
				}
			}catch(Exception ex){
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		
		
	}
}
