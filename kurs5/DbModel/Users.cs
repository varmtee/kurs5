namespace kurs5.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool? Manager { get; set; }
    }
}
