namespace kurs5.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Knigi")]
    public partial class Knigi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_book { get; set; }

        public string Kniga { get; set; }

        public string Avtor { get; set; }

        public string Cena { get; set; }
    }
}
