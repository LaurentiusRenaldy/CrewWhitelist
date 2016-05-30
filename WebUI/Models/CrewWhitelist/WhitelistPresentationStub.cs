using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Entities;

namespace WebUI.Models.CrewWhitelist
{
    public class WhitelistPresentationStub
    {
		// Example model value from scaffolder script: 0
        public int Id { get; set; }
        public long Barcode { get; set; }
        public DateTime TanggalAwal { get; set; }
        public DateTime TanggalAkhir { get; set; }
		
		public WhitelistPresentationStub() { }

        public WhitelistPresentationStub(Whitelist dbItem)
        {
            this.Id = dbItem.id;
            this.Barcode = dbItem.barcode;
			this.TanggalAwal = dbItem.tanggal_awal;
			this.TanggalAkhir = dbItem.tanggal_akhir;
		}

		public List<WhitelistPresentationStub> MapList(List<Whitelist> dbItems)
        {
            List<WhitelistPresentationStub> retList = new List<WhitelistPresentationStub>();

            foreach (Whitelist dbItem in dbItems)
                retList.Add(new WhitelistPresentationStub(dbItem));

            return retList;
        }
	}
}

