/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/09/2018
 * Time: 22:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nthareneapi
{
	/// <summary>
	/// Description of cropdiseasedto.
	/// </summary>
	public class cropdiseasedto
	{
		public string crop_disease_id { get; set; }
		public string crop_disease_name { get; set; }
		public string crop_disease_category { get; set; }		
		public string crop_disease_status { get; set; }
		public string created_date { get; set; }
		public override string ToString()
		{
			return string.Format(Environment.NewLine + "crop_disease_id: [ {0} ], " + Environment.NewLine + " crop_disease_name: [ {1} ], " + Environment.NewLine + " crop_disease_category: [ {2} ], " + Environment.NewLine + " crop_disease_status: [ {3} ], " + Environment.NewLine + " created date: [ {4} ]", crop_disease_id, crop_disease_name, crop_disease_category, crop_disease_status, created_date);
		}
	}
}
