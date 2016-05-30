using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Entities;

namespace WebUI.Models.CrewWhitelist
{
    public class CrewPresentationStub
    {
		// Example model value from scaffolder script: 0
		public long Barcode{ get; set; }
		public string Name { get; set; }
		public DateTime TanggalDaftar { get; set; }
		public string Status { get; set; }
		public string Airport { get; set; }
		public string CompanyAirways { get; set; }
		
		public CrewPresentationStub() { }

		public CrewPresentationStub(Crew dbItem) { 
			this.Barcode = dbItem.barcode;
			this.Name = dbItem.name;
			this.TanggalDaftar = dbItem.tanggal_daftar;
            this.Status = dbItem.status;
            this.Airport = dbItem.airport;
            this.CompanyAirways = dbItem.company_airways;
		}

		public List<CrewPresentationStub> MapList(List<Crew> dbItems)
        {
            List<CrewPresentationStub> retList = new List<CrewPresentationStub>();

            foreach (Crew dbItem in dbItems)
                retList.Add(new CrewPresentationStub(dbItem));

            return retList;
        }
	}
}

