using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApplicationProvaNexo.Models
{
    public class Context: DbContext
    {

        public Context() : base("N2UConnectionString") { 
            
        }




        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer<DbContext>(null);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(a => a.Name == a.ReflectedType.Name + "ClienteId").Configure(a => a.IsKey());
            modelBuilder.Properties().Where(a => a.Name == a.ReflectedType.Name + "ProdutoId").Configure(a => a.IsKey());
            modelBuilder.Properties<string>().Configure(a => a.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(a => a.HasMaxLength(500));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}