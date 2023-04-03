namespace _4TL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        
        [Required(ErrorMessage ="Vui long nhap tieu de")]
        public string Title { get; set; }

        public decimal? Price { get; set; }

        [StringLength(200)]
        public string FeatureImage { get; set; }
        [ForeignKey("Category")]

        public int CateId { get; set; }

        [StringLength(50)]
        public string Des { get; set; }
        public int Year { get; set; }
        public virtual Category Category { get; set; }
    }
}
