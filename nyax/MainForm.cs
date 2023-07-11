/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/07/2018
 * Time: 23:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using nthareneapi;
using nthareneapp;

namespace nyax
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		 
	public string TAG;
	public string _apppath;
	public string _xmlpathfolder;
	public string _txtpathfolder;
	public string _xml_loga_file;
	public string _xml_loga_file_fluentsyntax;
	public string _txt_loga_file;
			
	//Event declaration:
	//public event EventHandler<EventArgsT> EventName;
	public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
    public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;
 
	public List<notificationdto> _lstnotificationdto = new List<notificationdto>();
	Stopwatch stopWatch = new Stopwatch();

	//a new getInstance(_notificationmessageEventname) of a backgroundWorker is created.
	BackgroundWorker bgWorker = new BackgroundWorker();

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			TAG = this.GetType().Name;
			
			AppDomain.CurrentDomain.UnhandledException += new
UnhandledExceptionEventHandler(UnhandledException);
			Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

			//Subscribing to the event: 
			//Dynamically:
			//EventName += HandlerName;
			_notificationmessageEventname += notificationmessageHandler;
			_progressBarNotificationEventname += progressBarNotificationHandler;
			
			_apppath = Application.StartupPath;
		    _xmlpathfolder = _apppath + @"\xmlloga\";
		    _txtpathfolder = _apppath + @"\txtloga\";
			_xml_loga_file = _xmlpathfolder + "xmllogautilz.xml";
			_xml_loga_file_fluentsyntax = _xmlpathfolder + "xmllogautilzfluentsyntax.xml";
			_txt_loga_file = _txtpathfolder + "txtlogautilz.txt";
			
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished form load", TAG));

		}
		
		void UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = (Exception)e.ExceptionObject;
			this._notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs(ex.Message, TAG)); 
		} 
				
		void ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			Exception ex = e.Exception;
			this._notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs(ex.Message, TAG)); 
		}
	
		//Event handler declaration:
		public void notificationmessageHandler(object sender, notificationmessageEventArgs args) {
		/* Handler logic */  
		
		notificationdto _notificationdto = new notificationdto();
		
	    DateTime currentDate = DateTime.Now; 
	    String dateTimenow = currentDate.ToString("dd-MM-yyyy HH:mm:ss");
	     
		String _logtext = Environment.NewLine + "[ " + dateTimenow + " ]   " + args.message;
		
		 _notificationdto._notification_message = _logtext;
		 _notificationdto._created_datetime = dateTimenow;
		 _notificationdto.TAG = args.TAG;
		 
		 _lstnotificationdto.Add(_notificationdto);
		 
		var _lstmsgdto = from msgdto in _lstnotificationdto
		orderby msgdto._created_datetime descending
		select msgdto._notification_message;
		  
	    String[] _logflippedlines = _lstmsgdto.ToArray();
			
		txtlog.Lines = _logflippedlines;
		
		notifyIconntharene.BalloonTipIcon = ToolTipIcon.Info;
		notifyIconntharene.BalloonTipText = _logtext;
		notifyIconntharene.Text = args.TAG;
		notifyIconntharene.BalloonTipTitle = args.TAG;
		notifyIconntharene.ShowBalloonTip(2000);
		notifyIconntharene.BalloonTipClicked += new EventHandler(notifyIconntharene_BalloonTipClicked);
		  	
		//nthareneapp.Program._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(_logtext, TAG));

		}

		void notifyIconntharene_BalloonTipClicked(object sender, EventArgs e)
		{
	
		}
		 
		//Event handler declaration:
		public void progressBarNotificationHandler(object sender, progressBarNotificationEventArgs args) {
		/* Handler logic */   
			toolStripProgressBar.Maximum = args.ProgressMaximum;
			
			if(args.ProgressPercentage == -1){ 
				toolStripProgressBar.Value = 0;
//				lblprogresscounta.Text = string.Empty;
			}else{ 
				Invoke(new Action(() => { 
              	toolStripProgressBar.PerformStep(); }));
			}
		}
	 
		void lstcropToolStripMenuItemClick(object sender, EventArgs e)
		{ 
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading cropslistform", TAG));
			cropslistform _cropslistform=new cropslistform(_notificationmessageEventname, _progressBarNotificationEventname);
			_cropslistform.ShowDialog();
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void BtncropslistClick(object sender, EventArgs e)
		{
			lstcropToolStripMenuItemClick(sender, e);
		}
		
		void BtncreatecropdiseaseClick(object sender, EventArgs e)
		{
			CropsdiseaseslistToolStripMenuItemClick(sender, e);
		}
		
		void CropsdiseaseslistToolStripMenuItemClick(object sender, EventArgs e)
		{
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading cropdiseaseslistform", TAG));
			cropdiseaseslistform _cropdiseaseslistform=new cropdiseaseslistform(_notificationmessageEventname, _progressBarNotificationEventname);
			_cropdiseaseslistform.ShowDialog();
		}
		 
		void AbouttoolStripMenuItemClick(object sender, EventArgs e)
		{
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading aboutform", TAG));
			aboutform _aboutform=new aboutform(_notificationmessageEventname);
			_aboutform.ShowDialog();
		}
		
		void HometoolStripMenuItemClick(object sender, EventArgs e)
		{
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading helpform", TAG));
			helpform _helpform=new helpform(_notificationmessageEventname);
			_helpform.ShowDialog();
		}
		
		void PestInsecticideToolStripMenuItemClick(object sender, EventArgs e)
		{
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading pestsinsecticideslistform", TAG));
			pestsinsecticideslistform _pestsinsecticideslistform=new pestsinsecticideslistform(_notificationmessageEventname, _progressBarNotificationEventname);
			_pestsinsecticideslistform.ShowDialog();
		}
		
		void BtnpestinsecticideClick(object sender, EventArgs e)
		{
			PestInsecticideToolStripMenuItemClick(sender, e);
		}
		
		void timer_Elapsed(object sender, EventArgs e)
		{ 
			DateTime currentDate = DateTime.Now; 
	   	    String dateTimenow = currentDate.ToString("dd(dddd)-MM(MMMM)-yyyy HH:mm:ss"); 
	        lbldatetime.Text = dateTimenow; 
	         
			lbltimelapsed.Text = String.Format("Time elapsed: {0:hh\\:mm\\:ss\\.fffffff}", stopWatch.Elapsed); 
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			try{
				imgerror.Visible = false;
				imgwarn.Visible = false;
				imginfo.Visible = false; 
				 
		        stopWatch = new Stopwatch();
				stopWatch.Start();
				
				// Timers namespace rather than Threading
				System.Timers.Timer timer = new System.Timers.Timer(); // Doesn't require any args
				timer.Interval = 1000; 
				timer.Elapsed += timer_Elapsed; // Uses an event instead of a delegate
				timer.Start(); // Start the timer
				 
				sqliteapisingleton.getInstance(_notificationmessageEventname).initializedb();
				
	//			checkdbconnectionsonbackgroundworker();
				checkdbconnections();
				
				string[] args = {"nyaxconsole"};
//				nyaxconsole.Program.Main(args);
					
				startcommandlineinterface();
				 
			}catch(Exception ex){ 
				msgboxform.Show(ex.Message, DBContract.error, msgtype.error);
			}
		}
		 
		void startcommandlineinterface()
		{
			try{
				
			    string base_dir = Environment.CurrentDirectory;
			    string process_name = "nthareneapp.exe";
			    string full_process_name_with_path = base_dir + @"\" + process_name;
			    
				string _process_path = @full_process_name_with_path;
				
				var _process_info = Process.Start(_process_path);
				
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(String.Format("successfully started process [ {0} ] with id [ {1} ] at [ {2} ] took [ {3} ] seconds.", _process_info.StartInfo.FileName, _process_info.Id, _process_info.StartTime, _process_info.TotalProcessorTime), TAG));

			}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void ManufacturerToolStripMenuItemClick(object sender, EventArgs e)
		{
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading manufacturerslistform", TAG));
			
			manufacturerslistform _manufacturerslistform=new manufacturerslistform(_notificationmessageEventname, _progressBarNotificationEventname);
			_manufacturerslistform.ShowDialog();
		}
		
		void BtnmanufacturersClick(object sender, EventArgs e)
		{
			ManufacturerToolStripMenuItemClick(sender, e);
		}
		
		void BtnsettingsClick(object sender, EventArgs e)
		{
			SettingsToolStripMenuItemClick(sender, e);
		}
		
		void SettingsToolStripMenuItemClick(object sender, EventArgs e)
		{
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading settingslistform", TAG));
			
			settingslistform _settingslistform=new settingslistform(_notificationmessageEventname, _progressBarNotificationEventname);
			_settingslistform.ShowDialog();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			try{

			savetotxt();
			savetoxml();
			savetoxmlfluentsyntax();

			}catch(Exception ex){ 
				msgboxform.Show(ex.Message, DBContract.error, msgtype.error);
			}
 
		}
		 
		public void savetotxt(){
			   try{
			if (!Directory.Exists(_txtpathfolder))
				Directory.CreateDirectory(_txtpathfolder);
							
			if(!File.Exists(_txt_loga_file))
				File.Create(_txt_loga_file).Close();
						
			using (FileStream _fileStream = new FileStream(_txt_loga_file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)){
								
			 StreamWriter sw = new StreamWriter(_fileStream);
			 
				 foreach (var _log in _lstnotificationdto){
				 
				 sw.WriteLine(".............................."); 
				 sw.WriteLine("TAG: " + _log.TAG);
				 sw.WriteLine("NOTIFICATION_MESSAGE: " + _log._notification_message); 
				 sw.WriteLine("..............................\n");
				 
				}
			 
			 //sw.Close(); This will close ms and when we try to use ms later it will cause an exception
			 sw.Flush();
			}
			 
			}catch(Exception ex){ 
				msgboxform.Show(ex.Message, TAG, msgtype.error);	
			}
 
		}
		
		public void savetoxml(){
			   try{
			if (!Directory.Exists(_xmlpathfolder))
				Directory.CreateDirectory(_xmlpathfolder);
			
			if(!File.Exists(_xml_loga_file))
				File.Create(_xml_loga_file).Close();
						
			using(FileStream _fileStream = new FileStream(_xml_loga_file, FileMode.OpenOrCreate,  FileAccess.ReadWrite, FileShare.ReadWrite)){ // you can write to the fileStream
 	
			var xmlDoc = new XmlDocument();
//			xml.Load(_fileStream);
			xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"); 
			var root = xmlDoc.CreateElement("com.tech.nyax");
			// Creates an attribute, so the element will now be "<element attribute='value' />"
			root.SetAttribute("APPLICATION_NAME", Application.ProductName);
			root.SetAttribute("APPLICATION_VERSION", Application.ProductVersion);
			// All XML documents must have one, and only one, root element
			xmlDoc.AppendChild(root);
			// Adding data to an XML document
			foreach (var _log in _lstnotificationdto)
			{
			var child = xmlDoc.CreateElement("LOG");
			child.SetAttribute("TAG", _log.TAG);
			child.SetAttribute("CREATED_DATE", _log._created_datetime);
			child.SetAttribute("NOTIFICATION_MESSAGE", _log._notification_message);
			//child.InnerText = _log._notification_message;
			// Don't forget to add the new value to the current document!
			root.AppendChild(child);
			}
			 
			// Displays the XML document in the screen; 
			// optionally can be saved to a file
			xmlDoc.Save(_fileStream);
 
			} 
			
			}catch(Exception ex){ 
				msgboxform.Show(ex.Message, TAG, msgtype.error);	
			}
 
		}
			
		public void savetoxmlfluentsyntax(){
			   try{
			if (!Directory.Exists(_xmlpathfolder))
				Directory.CreateDirectory(_xmlpathfolder);
			
			if(!File.Exists(_xml_loga_file_fluentsyntax))
				File.Create(_xml_loga_file_fluentsyntax).Close();
						
			using(FileStream _fileStream = new FileStream(_xml_loga_file_fluentsyntax, FileMode.OpenOrCreate,  FileAccess.ReadWrite, FileShare.ReadWrite)){ // you can write to the fileStream
  
			XNamespace xns = "http://com.tech.nyax";
			XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
			XDocument xDoc = new XDocument(xDeclaration);
			XElement xRoot = new XElement(xns + "com.tech.nyax"); 
			xDoc.Add(xRoot);

			foreach (var _log in _lstnotificationdto)
			{
				XElement xelparent = new XElement(xns + "LOG");
				XAttribute xAttribute1 = new XAttribute("APPLICATION_NAME", Application.ProductName);
				XAttribute xAttribute2 = new XAttribute("APPLICATION_VERSION", Application.ProductVersion);
				xelparent.Add(xAttribute1); 
				xelparent.Add(xAttribute2); 
				XElement xelchild1 = new XElement(xns + "TAG", _log.TAG);
				XElement xelchild2 = new XElement(xns + "CREATED_DATE", _log._created_datetime);
				XElement xelchild3 = new XElement(xns + "NOTIFICATION_MESSAGE", _log._notification_message);
				xelparent.Add(xelchild1);
				xelparent.Add(xelchild2);
				xelparent.Add(xelchild3);
				xRoot.Add(xelparent); 
			}
					
		   xDoc.Save(_fileStream);
			 
			} 
			
			}catch(Exception ex){
//				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				msgboxform.Show(ex.Message, TAG, msgtype.error);	
			}
 
		}
		
		void checkdbconnectionsonbackgroundworker()
		{
			toolStripProgressBar.Step = 1;
			//This allows the BackgroundWorker to be cancelled in between tasks
			bgWorker.WorkerSupportsCancellation = true;
			//This allows the worker to report progress between completion of tasks... 
			//this must also be used in conjunction with the ProgressChanged event
			bgWorker.WorkerReportsProgress = true; 
			//this assigns event handlers for the backgroundWorker
			/* This is the backgroundworker's "DoWork" event handler. This
				method is what will contain all the work you
				wish to have your program perform without blocking the UI. */
			bgWorker.DoWork += bgWorker_DoWork;
		/*This is the method that will be run once the BackgroundWorker has completed its tasks */
			bgWorker.RunWorkerCompleted += bgWorker_WorkComplete;
			/* When you wish to have something occur when a change in progress
				occurs, (like the completion of a specific task) the "ProgressChanged"
				event handler is used. Note that ProgressChanged events may be invoked
				by calls to bgWorker.ReportProgress(...) only if bgWorker.WorkerReportsProgress
				is set to true. */
			bgWorker.ProgressChanged += bgWorker_ProgressChanged;
			//tell the backgroundWorker to raise the "DoWork" event, thus starting it.
			//Check to make sure the background worker is not already running.
			
			if(!bgWorker.IsBusy)
			bgWorker.RunWorkerAsync();
		}
		
		private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			//this is the method that the backgroundworker will perform on in the background thread.
			/* One thing to note! A try catch is not necessary as any exceptions will terminate the
			backgroundWorker and report
			the error to the "RunWorkerCompleted" event */
			// Work to be done here 
			// To get a reference to the current Backgroundworker:
	//		BackgroundWorker worker = sender as BackgroundWorker;
			// The reference to the BackgroundWorker is often used to report progress
	//		worker.ReportProgress();
	
			string _checkdbconnections = System.Configuration.ConfigurationManager.AppSettings["checkdbconnections"];
	
			bool _checkconnections;
			bool _trycheckdbconnections = bool.TryParse(_checkdbconnections, out _checkconnections);
			if(_checkconnections)checkdbconnections();
		 	
		}
		
		private void bgWorker_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
		{
			//e.Error will contain any exceptions caught by the backgroundWorker
			if (e.Error != null)
			{
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(e.Error.Message, TAG));
			}
			else
			{
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("Background Worker Task Complete...!", TAG));	
				toolStripProgressBar.Value = 0;
			}
		}
		
		private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// Things to be done when a progress change has been reported
			/* The ProgressChangedEventArgs gives access to a percentage,
			allowing for easy reporting of how far along a process is*/
			int progress = e.ProgressPercentage;
			toolStripProgressBar.Value = progress;
		}
		
		// example method to perform a "long" running task.
		private void checkdbconnections()
		{
			int x = 0; 
			int maxProgress = 4;
			toolStripProgressBar.Maximum = maxProgress;
			
			while (x < maxProgress)
			{
				switch(x)
				{
					case 0: 
						x += 1;
						
						string _checkdbconnections = System.Configuration.ConfigurationManager.AppSettings["checkdbconnectioninmssql"];
	
						bool _checkconnections;
						bool _trycheckdbconnections = bool.TryParse(_checkdbconnections, out _checkconnections);
						if(_checkconnections)checkmssqldbconnections();
			 
					break;
					case 1: 
						x += 1;
						
						_checkdbconnections = System.Configuration.ConfigurationManager.AppSettings["checkdbconnectioninmysql"];
	 
						_trycheckdbconnections = bool.TryParse(_checkdbconnections, out _checkconnections);
						if(_checkconnections)checkmysqldbconnections();
			 
					break;
					case 2:  
						x += 1;
						
						_checkdbconnections = System.Configuration.ConfigurationManager.AppSettings["checkdbconnectioninsqlite"];
	 
						_trycheckdbconnections = bool.TryParse(_checkdbconnections, out _checkconnections);
						if(_checkconnections)checksqlitedbconnections();
			 
					break;
					case 3:  
						x += 1;
						
						_checkdbconnections = System.Configuration.ConfigurationManager.AppSettings["checkdbconnectioninpostgresql"];
	 
						_trycheckdbconnections = bool.TryParse(_checkdbconnections, out _checkconnections);
						if(_checkconnections)checkpostgresqldbconnections();
			 
					break;
				}
				
			}
		}
		
		void checkmssqldbconnections(){ 
			try{
				string query = DBContract.CROPS_SELECT_ALL_QUERY; 
				DataTable mssql_dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);
				 if (mssql_dt != null){
					if (mssql_dt.Rows.Count != 0){
					_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql datastore connection successfull ", TAG));
					_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql crops count: " + mssql_dt.Rows.Count, TAG));
					}else{
						_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mssql datastore connection successfull ", TAG));
					}
				 }else{
						
				} 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void checkmysqldbconnections(){
			try{
				string query = DBContract.CROPS_SELECT_ALL_QUERY;
				DataTable mysql_dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
			 	if (mysql_dt != null){
					if (mysql_dt.Rows.Count != 0){
					_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql datastore connection successfull ", TAG));
					_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql crops count: " + mysql_dt.Rows.Count, TAG));
					}else{
						_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("mysql datastore connection successfull ", TAG));
					} 
				}else{
					
				} 
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void checksqlitedbconnections(){
			try{
				string query = DBContract.CROPS_SELECT_ALL_QUERY;
				DataTable sqlite_dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query);
				 if (sqlite_dt != null){
					if (sqlite_dt.Rows.Count != 0){
					_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite datastore connection successfull ", TAG));
					_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite crops count: " + sqlite_dt.Rows.Count, TAG));
					}else{
						_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite datastore connection successfull ", TAG));
					}
				 }else{
						
				}
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		  
		void checkpostgresqldbconnections(){
			try{
				string query = DBContract.CROPS_SELECT_ALL_QUERY;
				DataTable postgresql_dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query); 
				 if (postgresql_dt != null){
					 if (postgresql_dt.Rows.Count != 0){
					_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql datastore connection successfull ", TAG));
					_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql crops count: " + postgresql_dt.Rows.Count, TAG));
					}else{
						_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("postgresql datastore connection successfull ", TAG));
					}
				 }else{
						
				}
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		  
		void BtnexitClick(object sender, EventArgs e)
		{
			this.Close();
		}
		 
		void PostgresToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void SqliteToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void MysqlToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void MssqlToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void ToolStripSplitButtoncheckdbconnectionsButtonClick(object sender, EventArgs e)
		{
			toolStripSplitButtoncheckdbconnections.ShowDropDown();
		}
		
		void CreateSqliteDatastoreToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{ 
				
				sqliteapisingleton.getInstance(_notificationmessageEventname).createdatabase();
				  
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void CreateMssqlDatastoreToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{ 
				
				mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createdatabase();
				  
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void CreateMysqlDatastoreToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{ 
				
				mysqlapisingleton.getInstance(_notificationmessageEventname).createdatabase();
				  
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void CreatePostgresqlDatastoreToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{ 
				
				postgresqlapisingleton.getInstance(_notificationmessageEventname).createdatabase();
				  
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		 
		void CheckpostgresqlconnectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			checkpostgresqldbconnections();
		}
		
		void ChecksqliteconnectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			checksqlitedbconnections();
		}
		
		void CheckmysqlconnectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			checkmysqldbconnections();
		}
		
		void CheckmssqlconnectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			checkmssqldbconnections();
		}
		 
		void UpdatepostgresqldbscemaToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{ 
				
				postgresqlapisingleton.getInstance(_notificationmessageEventname).updateexistingdbschema();
				  
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void UpdatesqlitedbschemaToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{ 
				
				sqliteapisingleton.getInstance(_notificationmessageEventname).updateexistingdbschema();
				  
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void UpdatemysqldbschemaToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{ 
				
				mysqlapisingleton.getInstance(_notificationmessageEventname).updateexistingdbschema();
				  
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void UpdatemssqldbschemaToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{ 
				
				mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).updateexistingdbschema();
				  
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		 
		void DatastoreconfigmanagerToolStripMenuItemClick(object sender, EventArgs e)
		{
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading databaseutilsform", TAG));
			databaseutilsform _databaseutilsform = new databaseutilsform(_notificationmessageEventname, _progressBarNotificationEventname);
			_databaseutilsform.ShowDialog();
		}
		 
		void DatastoreconfigmanagerutilsToolStripMenuItemClick(object sender, EventArgs e)
		{
			DatastoreconfigmanagerToolStripMenuItemClick(sender, e);
		}
		
		void BtncropsvarietieslistClick(object sender, EventArgs e)
		{
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading cropsvarietieslistform", TAG));
			cropsvarietieslistform _cropsvarietieslistform = new cropsvarietieslistform(_notificationmessageEventname, _progressBarNotificationEventname);
			_cropsvarietieslistform.ShowDialog();
		}
		
		void CropsvarietiesToolStripMenuItemClick(object sender, EventArgs e)
		{
			BtncropsvarietieslistClick(sender, e);
		}
		
		void CategoriesToolStripMenuItemClick(object sender, EventArgs e)
		{
			BtncategorieslistClick(sender, e);
		}
		
		void BtncategorieslistClick(object sender, EventArgs e)
		{
			_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading categorieslistform", TAG));
			categorieslistform _categorieslistform = new categorieslistform(_notificationmessageEventname, _progressBarNotificationEventname);
			_categorieslistform.ShowDialog();
		}
		 
		void BtndatabaseutilsClick(object sender, EventArgs e)
		{
			DatastoreconfigmanagerToolStripMenuItemClick(sender, e);
		}
		
		void updaterecordscount(){
			try{				 
				  
			}catch(Exception ex){
			_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void BtnsearchClick(object sender, EventArgs e)
		{
			try{				 
				_notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("loading searchform", TAG));
				searchform _searchform = new searchform(_notificationmessageEventname, _progressBarNotificationEventname);
				_searchform.ShowDialog();
			}catch(Exception ex){
				_notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));  
			}
		}
		
		void SearchToolStripMenuItemClick(object sender, EventArgs e)
		{
			BtnsearchClick(sender, e);
		}
	}
	
}
