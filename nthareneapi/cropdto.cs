/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 17:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nthareneapi
{
	/// <summary>
	/// Description of cropdto.
	/// </summary>
	public class cropdto
	{
		public string crop_id { get; set; }
		public string crop_name { get; set; } 
		public string crop_status { get; set; }
		public string created_date { get; set; }
		public override string ToString()
		{
			return string.Format(Environment.NewLine + "crop_id: [ {0} ], " + Environment.NewLine + " crop_name: [ {1} ], " + Environment.NewLine + " crop_status: [ {2} ], " + Environment.NewLine + " created date: [ {3} ]", crop_id, crop_name, crop_status, created_date);
		}
	}
}
