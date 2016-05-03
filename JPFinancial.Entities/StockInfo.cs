namespace JPFinancial.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockInfo")]
    public partial class StockInfo
    {
        public int ID { get; set; }

        public int CompanyID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public decimal? Price { get; set; }

        public decimal? CloseYest { get; set; }

        public decimal? OpenPrice { get; set; }

        public decimal? High { get; set; }

        public decimal? Low { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Volume { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AverageVolume { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MarketCap { get; set; }

        public decimal? PE { get; set; }

        public decimal? EPS { get; set; }

        public decimal? High52 { get; set; }

        public decimal? Low52 { get; set; }

        public decimal? Change { get; set; }

        public decimal? ChangePct { get; set; }

        public decimal? Beta { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Shares { get; set; }

        [StringLength(25)]
        public string Currency { get; set; }

        public virtual Company Company { get; set; }
    }
}
