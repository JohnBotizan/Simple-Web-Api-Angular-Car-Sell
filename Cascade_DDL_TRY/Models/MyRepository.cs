using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cascade_DDL_TRY.Models
{
    public interface IRepository
    {
        IQueryable<Make> AllMakes();
        IQueryable<Modelul> AllModels();
        IQueryable<Modelul> AllModelsFromMake(int makeId);
        IQueryable<Anunt> AllAnuntsFromModel(int? modelId);
        IQueryable<Anunt> AllAnuntsFromMake(int? makeId);
        
    }
    public class MyRepository : IRepository  
    {
        MyContext ctx;
        public MyRepository(MyContext _ctx)
        {
            ctx = _ctx;
        }


        public IQueryable<Make> AllMakes()
        {
            return ctx.MakeSet.Include("Modeluls.Anunts").OrderBy(p => p.MakeName);
        }

        public IQueryable<Modelul> AllModels()
        {
            return ctx.ModelulSet.OrderBy(p => p.ModelulName);
        }

        public IQueryable<Modelul> AllModelsFromMake(int makeId)
        {
            return ctx.ModelulSet.Include("Makeul").Include("Anunts").Where(p => p.MakeId == makeId).OrderBy(p => p.ModelulName);
        }

        public IQueryable<Anunt> AllAnuntsFromModel(int? modelId)
        {
            return ctx.Anunts.Include("Modelul").Include("Modelul.Makeul").Where(p => p.ModelulId == modelId).OrderBy(p => p.Price);
        }

        public IQueryable<Anunt> AllAnuntsFromMake(int? makeId)
        {
            return ctx.Anunts.Include("Modelul").Include("Modelul.Makeul").Where(p => p.Modelul.MakeId == makeId).OrderBy(p => p.Price);
        }
        
       
    }
}