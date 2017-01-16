using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cascade_DDL_TRY.Models
{
    public class MakeViewModel
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public IEnumerable<ModelulViewModel> Modeluls { get; set; }
        public   int AdsNumberInMake { get; set;}
    }
    public class ModelulViewModel
    {
        public int ModelId { get; set;}
        public string ModelulName { get; set; }
        public IEnumerable<AnuntViewModel> Anunts { get; set; }

        public int AdsNumberInModel { get; set; }
    }
    public class AnuntViewModel
    {
        public int AnuntId { get; set; }
        public string NameAnunt { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
                
        public Fuel Fuel { get; set; }
    }
    public class SearchAnunt
    {
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }

        public string Fuel { get; set; }
    }
}

