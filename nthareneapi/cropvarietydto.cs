/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 10/23/2018
 * Time: 20:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nthareneapi
{
	/// <summary>
	/// Description of cropvarietydto.
	/// </summary>
	public class cropvarietydto
	{
		public string crop_variety_id { get; set; }
		public string crop_variety_name { get; set; }
		public string crop_variety_status { get; set; }
		public string created_date { get; set; }
		
		public string crop_variety_crop_id { get; set; }
		public string crop_variety_manufacturer_id { get; set; }
		public override string ToString()
		{
			return string.Format(Environment.NewLine + "crop_variety_id: [ {0} ], " + Environment.NewLine + " crop_variety_name: [ {1} ], " + Environment.NewLine + " crop_variety_status: [ {2} ], " + Environment.NewLine + " created_date: [ {3} ], " + Environment.NewLine + " crop_variety_crop_id: [ {4} ]" + Environment.NewLine + " crop_variety_manufacturer_id: [ {5} ]", crop_variety_id, crop_variety_name, crop_variety_status, created_date, crop_variety_crop_id, crop_variety_manufacturer_id);
		}
	}
}
