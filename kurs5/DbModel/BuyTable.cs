namespace kurs5.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BuyTable")]
    public partial class BuyTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_pok { get; set; }

        public string Nazvanie { get; set; }

        public string Price { get; set; }

        public string Status { get; set; }
    }
}
