/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 22:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nthareneapi
{
	/// <summary>
	/// Description of settingdto.
	/// </summary>
	public class settingdto
	{
		public string setting_id { get; set; }
		public string setting_name { get; set; } 
		public string setting_value { get; set; } 
		public string setting_status { get; set; }
		public string created_date { get; set; }
		public override string ToString()
		{
			return string.Format(Environment.NewLine + "setting_id: [ {0} ], " + Environment.NewLine + " setting_name: [ {1} ], " + Environment.NewLine + " setting_value: [ {2} ], " + Environment.NewLine + " setting_status: [ {3} ], " + Environment.NewLine + " created date: [ {4} ]", setting_id, setting_name, setting_value, setting_status, created_date);
		}
	}
}


