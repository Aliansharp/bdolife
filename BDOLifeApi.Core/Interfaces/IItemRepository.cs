using BDOLife.Core.Entities;
using BDOLife.Core.Enums;
using BDOLife.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Core.Interfaces
{
    public interface IItemRepository : IRepository<ItemBase>
    {
        Task<List<ItemBase>> GetByReference(string reference);
        Task<ItemBase> GetByReference(string reference, string discriminator, string name = null);
        Task<Recipe> GetByReference(string reference, string discriminator, RecipeTypeEnum type, string name = null);

        Task<List<Recipe>> GetAllRecipes();
        Task<List<Recipe>> GetRecipesByType(RecipeTypeEnum type);
        Task<Recipe> GetRecipeByReferenceAndType(string reference, RecipeTypeEnum type);

        //Task<List<ItemBase>> GetByReferenceAndName(string reference);

    }
}
