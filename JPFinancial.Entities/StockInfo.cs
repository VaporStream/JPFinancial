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
        public int Id { get; set; }

        public int CompanyId { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Display(Name = "Stock Price")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? Price { get; set; }

        [Display(Name = "Previous Day Close")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? CloseYest { get; set; }

        [Display(Name = "Open Price")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? OpenPrice { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? High { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? Low { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n0}")]
        [Column(TypeName = "numeric")]
        public decimal? Volume { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n0}")]
        [Display(Name = "Volume Avg")]
        public decimal? AverageVolume { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n0}")]
        [Display(Name = "Market Cap")]
        public decimal? MarketCap { get; set; }

        public decimal? PE { get; set; }

        public decimal? EPS { get; set; }

        [Display(Name = "52 Week High")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? High52 { get; set; }

        [Display(Name = "52 Week Low")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? Low52 { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? Change { get; set; }

        [Display(Name = "Change (%)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:p}")]
        public decimal? ChangePct { get; set; }

        public decimal? Beta { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n0}")]
        public decimal? Shares { get; set; }

        [StringLength(8)]
        public string Currency { get; set; }

        public virtual Company Company { get; set; }
    }
}
