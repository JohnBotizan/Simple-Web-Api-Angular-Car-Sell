using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cascade_DDL_TRY.Models
{
    public class ModelFactory
    {
        public MakeViewModel Create(Make make)
        {
            int numberOfAnunts=0;
           List<Modelul> tempModels = make.Modeluls.ToList();
            foreach(var p in tempModels)
            {
                numberOfAnunts += p.Anunts.Count;
            }
                
            return new MakeViewModel
            {
                MakeId = make.MakeId,
                MakeName = make.MakeName,
                Modeluls = make.Modeluls.Select(m => Create(m)) ,
                AdsNumberInMake = numberOfAnunts
            };
        }
        public ModelulViewModel Create(Modelul modelul)
        {
            return new ModelulViewModel
            {
                 ModelId = modelul.ModelulId,
                 ModelulName = modelul.ModelulName ,
                 Anunts = modelul.Anunts.Select(a => Create(a)) ,
                 AdsNumberInModel = modelul.Anunts.Count
            };
        }

        public AnuntViewModel Create(Anunt anuntul)
        {
            return new AnuntViewModel
            {
                   AnuntId = anuntul.AnuntId,
                   Price = anuntul.Price,
                   Description =  anuntul.AnuntName ,
                   NameAnunt = anuntul.Modelul.Makeul.MakeName +" "+anuntul.Modelul.ModelulName, 
                   Fuel = anuntul.Fuel, 
                   AdFeatures = anuntul.AditionalFeatures.Select(p=> Create(p))
            };
        }
        public AditionalFeaturesViewModel Create(AditionalFeature feature)
        {
            return new AditionalFeaturesViewModel
            {
                 AditionalFeaturesId= feature.AditionalFeatureId,
                  FeatureName = feature.NameAditionalFeature
            };
        }
        


    }
}