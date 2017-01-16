using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Cascade_DDL_TRY.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
     public enum Fuel
     {
         Diesel=0 ,
         Benzina=1 , 
         Gaz=2 , 
         Electric=3
     }
    public class Make
    {
        public Make()
        {
            Modeluls = new List<Modelul>();
        }
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public virtual ICollection<Modelul> Modeluls { get; set; }
    }
    public class Modelul
    {
        public Modelul()
        {
            Anunts = new List<Anunt>();
        }
        public int ModelulId { get; set; }
        public string ModelulName { get; set; }
        public int MakeId { get; set; }
        public virtual Make Makeul { get; set; }
        public virtual  ICollection<Anunt> Anunts { get; set; }
    }
    //extension in case JsonConverter doesnt work
    //public static class FuelString
    //{
    //    public static T EnumParse<T>(this string theFuel)
    //    {
    //        return (T)Enum.Parse(typeof(T), theFuel, true);
    //    }
    //}

    public class Anunt
    {
        public Anunt()
        {
            AditionalFeatures = new List<AnuntAditionalFeatures>();
        }
        public int AnuntId { get; set; }
        public string AnuntName { get; set; }

        public decimal Price { get; set; }
        public int Year { get; set; }
        //[Column("Fuel")]
        //public string FuelString
        //{
        //    get { return Fuel.ToString(); }
        //    set { Fuel = value.EnumParse<Fuel>(); }
        //}

        //[NotMapped]
        public Fuel Fuel { get; set; }
        public virtual Modelul Modelul { get; set; }
        public int ModelulId { get; set; }
        public virtual ICollection<AnuntAditionalFeatures> AditionalFeatures { get; set; }
    }
       
    public class AnuntAditionalFeatures
    {
        public int AnuntAditionalFeaturesId { get; set;}
        public int AnuntId { get; set; }
        public virtual Anunt Anunt { get; set; }
        public int AditionalFeatureId { get; set; }
        public virtual AditionalFeature AditionalFeature { get; set; }
    }

    public class AditionalFeature
    {
        public AditionalFeature()
        {
            Anunts = new List<AnuntAditionalFeatures>();
        }
        [Key]
        public int AditionalFeatureId { get; set; }
        public string NameAditionalFeature { get; set; }

        public virtual ICollection<AnuntAditionalFeatures> Anunts { get; set; }
    }

}