/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 09/10/2018
 * Time: 07:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nthareneapi
{
	/// <summary>
	/// Description of pestinsecticidedto.
	/// </summary>
	public class pestinsecticidedto
	{
		public string pestinsecticide_id { get; set; }
		public string pestinsecticide_name { get; set; } 
		public string pestinsecticide_category { get; set; }  
		public string pestinsecticide_status { get; set; }
		public string created_date { get; set; }
		
		public string pestinsecticide_crop_disease_id; 
		public string pestinsecticide_manufacturer_id;
		public override string ToString()
		{
			return string.Format(Environment.NewLine + "pestinsecticide_id: [ {0} ], " + Environment.NewLine + " pestinsecticide_name: [ {1} ], " + Environment.NewLine + " pestinsecticide_category: [ {2} ], " + Environment.NewLine + " pestinsecticide_status: [ {3} ], " + Environment.NewLine + " created date: [ {4} ]" + Environment.NewLine + " pestinsecticide_crop_disease_id: [ {4} ]" + Environment.NewLine + " pestinsecticide_manufacturer_id: [ {4} ]", pestinsecticide_id, pestinsecticide_name, pestinsecticide_category, pestinsecticide_status, created_date, pestinsecticide_crop_disease_id, pestinsecticide_manufacturer_id);
		}
	}
	

}
