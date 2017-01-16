using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Cascade_DDL_TRY.Models
{
    public class MakeConfiguration : EntityTypeConfiguration<Make>
    {
        public MakeConfiguration()
        {
            Property(p => p.MakeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
    public class ModelulConfiguration : EntityTypeConfiguration<Modelul>
    {
        public ModelulConfiguration()
        {
            Property(p => p.ModelulId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
    //public class AditionalFeaturesConfiguration: EntityTypeConfiguration<AditionalFeatures>
    //{
    //    public AditionalFeaturesConfiguration()
    //    {
    //        Property(p => p.AditionalFeaturesId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    //    }
    //}

}