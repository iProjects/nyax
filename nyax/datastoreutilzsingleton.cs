/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 10/08/2018
 * Time: 03:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.SqlClient;
using nthareneapi;

namespace nyax
{
	/// <summary>
	/// Description of datastoreutilzsingleton.
	/// </summary>
	public sealed class datastoreutilzsingleton
	{
		// Because the _instance member is made private, the only way to get the single
		// instance is via the static Instance property below. This can also be similarly
		// achieved with a GetInstance() method instead of the property.
		private static datastoreutilzsingleton singleInstance;
			 
	    public static datastoreutilzsingleton getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname) {
			// The first call will create the one and only instance.
	        if (singleInstance == null)
	            singleInstance = new datastoreutilzsingleton(notificationmessageEventname);
	        // Every call afterwards will return the single instance created above.
	        return singleInstance;
	    }
		  
		private event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
		private string TAG;
		
		private datastoreutilzsingleton(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
		{
			_notificationmessageEventname = notificationmessageEventname;
			try{ 
				TAG = this.GetType().Name; 
			}catch(Exception ex){  
				this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));				
			}
		}
		
		private datastoreutilzsingleton()
		{
			 
		}
		 
		
		
	}
}
