using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace kurs5.DbModel
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model21")
        {
        }

        public virtual DbSet<Knigi> Knigi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
