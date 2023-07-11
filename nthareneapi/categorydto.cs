/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 12/18/2018
 * Time: 10:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nthareneapi
{
	/// <summary>
	/// Description of categorydto.
	/// </summary>
	public class categorydto
	{
		public string category_id { get; set; }
		public string category_name { get; set; }	
		public string category_status { get; set; }
		public string created_date { get; set; }
		public override string ToString()
		{
			return string.Format(Environment.NewLine + "category_id: [ {0} ], " + Environment.NewLine + " category_name: [ {1} ], " + Environment.NewLine + " category_status: [ {2} ], " + Environment.NewLine + " created date: [ {3} ]", category_id, category_name, category_status, created_date);
		}
	}
}
