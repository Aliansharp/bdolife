using BDOLife.Core.Entities;
using BDOLife.Core.Interfaces;
using BDOLife.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Infra.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
