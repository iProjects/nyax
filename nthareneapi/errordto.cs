/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 21:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nthareneapi
{
	/// <summary>
	/// Description of errordto.
	/// </summary>
	public class errordto
	{
		public event EventHandler<notificationmessageEventArgs> _notificationmessageEventArgs;
		private string _errormessage;
		public string errorstacktrace { get; set; }
		public string methodcausingerror { get; set; }
		public string classcausingerror { get; set; }
		 
		public string errormessage
		{
		get { return _errormessage; }
		set
		{
		var e = new notificationmessageEventArgs(value);
		Onnotificationmessage(e);
		_errormessage = value;
		}
		}
		protected void Onnotificationmessage(notificationmessageEventArgs e)
		{
		var handler = _notificationmessageEventArgs;
		if (handler != null)
		handler(this, e);
		}

	}
	

	
	
}
