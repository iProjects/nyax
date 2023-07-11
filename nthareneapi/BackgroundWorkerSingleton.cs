/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/14/2018
 * Time: 15:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace nthareneapi
{
	/// <summary>
	/// Description of BackgroundWorkerSingleton.
	/// </summary>
	public sealed class BackgroundWorkerSingleton
	{
		// Because the _instance member is made private, the only way to get the single
		// instance is via the static Instance property below. This can also be similarly
		// achieved with a GetInstance() method instead of the property.
		private static BackgroundWorkerSingleton singleInstance;
			 
	    public static BackgroundWorkerSingleton getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname) {
			// The first call will create the one and only instance.
	        if (singleInstance == null)
	            singleInstance = new BackgroundWorkerSingleton(notificationmessageEventname);
	        // Every call afterwards will return the single instance created above.
	        return singleInstance;
	    }
		
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		public string TAG; 
		//a new instance of a backgroundWorker is created.
		BackgroundWorker bgWorker = new BackgroundWorker();
		  
		private BackgroundWorkerSingleton(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
		{
			_notificationmessageEventname = notificationmessageEventname;
			TAG = this.GetType().Name;	
			
			//this assigns event handlers for the backgroundWorker
			bgWorker.DoWork += bgWorker_DoWork;
			bgWorker.RunWorkerCompleted += bgWorker_WorkComplete;
			//tell the backgroundWorker to raise the "DoWork" event, thus starting it.
			//Check to make sure the background worker is not already running.
			if(!bgWorker.IsBusy)
			bgWorker.RunWorkerAsync();
		}
		
		private BackgroundWorkerSingleton()
		{
		 
		}
		
		private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			//this is the method that the backgroundworker will perform on in the background thread.
			/* One thing to note! A try catch is not necessary as any exceptions will terminate the
			backgroundWorker and report
			the error to the "RunWorkerCompleted" event */ 
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
			}
		}
		 
	}
	
	
	public enum msgtype { 
		info = 0, 
		warn = 1, 
		error = 2 
	}
	
	
}
