using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace kurs5.DbModel
{
    public partial class Model3 : DbContext
    {
        public Model3()
            : base("name=Model31")
        {
        }

        public virtual DbSet<BuyTable> BuyTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
