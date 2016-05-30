using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Entities;

namespace WebUI.Models.CrewWhitelist
{
    public class CrewFormStub
    {
		// Example model value from scaffolder script: 0
		[DisplayName("Barcode")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.MyGlobalErrors))]
		public long Barcode { get; set; }

		[DisplayName("Name")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.MyGlobalErrors))]
		public string Name { get; set; }

		[DisplayName("Tanggal Daftar")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.MyGlobalErrors))]
		public DateTime TanggalDaftar { get; set; }

		[DisplayName("Status")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.MyGlobalErrors))]
		public string Status { get; set; }

        [DisplayName("Airport")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.MyGlobalErrors))]
		public string Airport { get; set; }

        [DisplayName("CompanyAirways")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.MyGlobalErrors))]
		public string CompanyAirways { get; set; }

		public CrewFormStub() { }


		public CrewFormStub(Crew dbItem)
			: this()
		{
			this.Barcode = dbItem.barcode;
			this.Name = dbItem.name;
			this.TanggalDaftar = dbItem.tanggal_daftar;
            this.Status = dbItem.status;
            this.Airport = dbItem.airport;
            this.CompanyAirways = dbItem.company_airways;
		}

		public Crew GetDbObject(Crew dbItem) {
			dbItem.barcode = this.Barcode;
			dbItem.name = this.Name;
			dbItem.tanggal_daftar = this.TanggalDaftar;
            dbItem.status = this.Status;
            dbItem.airport = this.Airport;
            dbItem.company_airways = this.CompanyAirways;
			return dbItem;
		}

		#region options


		#endregion

	}
}

