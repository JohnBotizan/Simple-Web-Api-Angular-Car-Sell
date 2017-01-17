using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cascade_DDL_TRY.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("myconnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MakeConfiguration());
            modelBuilder.Configurations.Add(new ModelulConfiguration());
            //modelBuilder.Configurations.Add(new AditionalFeaturesConfiguration());
            modelBuilder.Entity<Anunt>()
                        .HasMany<AditionalFeature>(p => p.AditionalFeatures)
                        .WithMany(a => a.Anunts)
                        .Map(p =>
                        {
                            p.MapLeftKey("AnuntReferenceId").MapRightKey("AditionalFeatureReferenceId").ToTable("AnuntAditionalFeature");
                        });
        
        
        }
        public DbSet<Make> MakeSet { get; set; }
        public DbSet<Modelul> ModelulSet { get; set; }
        public DbSet<Anunt> Anunts { get; set; }
        public DbSet<AditionalFeature> AditionalFeatures { get; set; }

        public DbSet<AnuntAditionalFeatures> AnuntAditionalFeatures { get; set; }
    }
}