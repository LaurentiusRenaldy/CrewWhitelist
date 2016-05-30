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
    public class WhitelistFormStub
    {
		// Example model value from scaffolder script: 0
		[DisplayName("Id")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.MyGlobalErrors))]
		public int Id { get; set; }

		[DisplayName("Barcode")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.MyGlobalErrors))]
		public long Barcode { get; set; }

		[DisplayName("Tanggal Awal")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.MyGlobalErrors))]
        public DateTime TanggalAwal { get; set; }

        [DisplayName("Tanggal Akhir")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.MyGlobalErrors))]
        public DateTime TanggalAkhir { get; set; }

		public WhitelistFormStub() { }


        public WhitelistFormStub(Whitelist dbItem)
			: this()
		{
            this.Id = dbItem.id;
			this.Barcode = dbItem.barcode;
			this.TanggalAwal = dbItem.tanggal_awal;
            this.TanggalAkhir = dbItem.tanggal_akhir;
		}

		public Whitelist GetDbObject(Whitelist dbItem) {
            dbItem.id = this.Id;
			dbItem.barcode = this.Barcode;
            dbItem.tanggal_awal = this.TanggalAwal;
            dbItem.tanggal_akhir = this.TanggalAkhir;
			return dbItem;
		}

		#region options


		#endregion

	}
}

