/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 17:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nthareneapi
{
	/// <summary>
	/// Description of manufacturerdto.
	/// </summary>
	public class manufacturerdto
	{ 
		public string manufacturer_id { get; set; }
		public string manufacturer_name { get; set; }
		public string manufacturer_status { get; set; }
		public string created_date { get; set; }
		public override string ToString()
		{
			return string.Format(Environment.NewLine + "manufacturer_id: [ {0} ], " + Environment.NewLine + " manufacturer_name: [ {1} ], " + Environment.NewLine + " manufacturer_status: [ {2} ], " + Environment.NewLine + " created date: [ {3} ]", manufacturer_id, manufacturer_name, manufacturer_status, created_date);
		}
	}
}
