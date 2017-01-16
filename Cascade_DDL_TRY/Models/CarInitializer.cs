using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Cascade_DDL_TRY.Models
{
    public class CarInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            try
            {
                MakeList().ForEach(a => context.MakeSet.Add(a));
                ModelulList().ForEach(a => context.ModelulSet.Add(a));
                AnuntsList().ForEach(a => context.Anunts.Add(a));
                AditFeaturesList().ForEach(a => context.AditionalFeatures.Add(a));
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        static List<Make> MakeList()
        {
            return new List<Make>{
                new Make{ MakeId=1 , MakeName ="Dacia"},
                new Make{MakeId=2  , MakeName = "BMW"},
                new Make{MakeId =3 , MakeName = "Mercedes"},
                new Make{MakeId=4 , MakeName = "Renault"}
            };
        }
        static List<Modelul> ModelulList()
        {
            return new List<Modelul>
            {
                new Modelul{ ModelulId=1 , ModelulName="Sandero", MakeId=1 },
                new Modelul{ ModelulId=2 , ModelulName="Logan", MakeId=1 },
                new Modelul{ ModelulId=3 , ModelulName="Duster", MakeId=1 },
                new Modelul{ ModelulId=4 , ModelulName="MCV Logan", MakeId=1 },
                new Modelul{ ModelulId=5 , ModelulName="Sandero", MakeId=1 },
                new Modelul{ModelulId=6 , ModelulName="Seria 3", MakeId=2},
                new Modelul{ModelulId=7 , ModelulName="X 6", MakeId=2},
                new Modelul{ModelulId=8 , ModelulName="GLK", MakeId=3},
                new Modelul{ModelulId=9 , ModelulName="Laguna", MakeId=4},
                new Modelul{ModelulId=10 , ModelulName="Megane", MakeId=4}

            };
        }

        static List<Anunt> AnuntsList()
        {
            return new List<Anunt>(){
                new Anunt{ AnuntName="Fancy and cheap " , ModelulId=5 , Price=12500M , Year=1999 ,/* FuelString="Diesel"*/ Fuel = Fuel.Diesel},
                new Anunt{ AnuntName="Fancy dasdasdasdaand cheap " , ModelulId=3 , Price=9500M , Year=2001, /*FuelString="Diesel" */ Fuel = Fuel.Diesel},
                new Anunt{ AnuntName="Fanasdasdasdasdasdasdas and cheap " , ModelulId=1 , Price=32500M, Year=2010, /*FuelString = "Benzina"*/ Fuel= Fuel.Benzina},
                new Anunt{ AnuntName="Fancydasdasdasda and cheap " , ModelulId=3 , Price=22500M, Fuel= Fuel.Diesel , Year=2011},
                new Anunt{ AnuntName="Fancy and cheap " , ModelulId=7 , Price=5600M, Fuel= Fuel.Diesel, Year=2013},
                new Anunt{ AnuntName="Fandasdasdascy and cheap " , ModelulId=7 , Price=5000M, Fuel= Fuel.Diesel, Year=2014},
                new Anunt{ AnuntName="Fancy aasdasdasdasnd cheap " , ModelulId=1 , Price=4500M , Fuel = Fuel.Benzina, Year=2012},
                new Anunt{ AnuntName="Fancy andadadasdd cheap " , ModelulId=4 , Price=5000M,  Fuel= Fuel.Diesel, Year=2013},
                new Anunt{ AnuntName="Fancyasdasdasda and cheap " , ModelulId=8 , Price=16500M,  Fuel = Fuel.Electric, Year=2014},
                new Anunt{ AnuntName="Fadasdasdadncy and cheap " , ModelulId=9 , Price=1200M, Fuel= Fuel.Diesel, Year=2015},
                new Anunt{ AnuntName="Fancy adasdasdasdnd cheap " , ModelulId=2 , Price=500M, Fuel= Fuel.Diesel, Year=2009},
                new Anunt{ AnuntName="Fancy asdasdasd cheap " , ModelulId=6 , Price=2500M , Fuel= Fuel.Benzina , Year=2010},
                new Anunt{ AnuntName="Fandasdsadasdasdacy and cheap " , ModelulId=7 , Price=7600M , Fuel= Fuel.Diesel, Year=2010}


            };
        }
        static List<AditionalFeature> AditFeaturesList()
        {
            return new List<AditionalFeature>()
            {
                new AditionalFeature{ AditionalFeatureId=1 , NameAditionalFeature="Cutie Automata"},
                new AditionalFeature{ AditionalFeatureId=2  , NameAditionalFeature="Camera Spate"},
                new AditionalFeature{AditionalFeatureId=3 , NameAditionalFeature="Senzori parcare fata"},
                new AditionalFeature{AditionalFeatureId=4 , NameAditionalFeature="Senzori parcare spate"},
                new AditionalFeature{ AditionalFeatureId=5 , NameAditionalFeature="ABS"},
                new AditionalFeature{ AditionalFeatureId=6 , NameAditionalFeature="ESP"}
            };
        }
    }
}