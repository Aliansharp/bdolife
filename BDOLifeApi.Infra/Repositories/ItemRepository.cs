using BDOLife.Core.Entities;
using BDOLife.Core.Enums;
using BDOLife.Core.Interfaces;
using BDOLife.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Infra.Repositories
{
    public class ItemRepository : Repository<ItemBase>, IItemRepository
    {
        public ItemRepository(DataContext dataContext) : base(dataContext) 
        {
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            return await _dataContext.Itens.Where(i => i.Discriminator == "Recipe").Cast<Recipe>().ToListAsync();
        }

        public async Task<List<ItemBase>> GetByReference(string reference)
        {
            return await _dataContext.Itens.Include(i => i.Translates).Where(i => i.BDOReference == reference).ToListAsync();
        }

        public async Task<ItemBase> GetByReference(string reference, string discriminator, string name = null)
        {
            return await _dataContext.Itens.Include(i => i.Translates).SingleOrDefaultAsync(i => i.BDOReference == reference && i.Discriminator == discriminator);
        }

        public async Task<Recipe> GetByReference(string reference, string discriminator, RecipeTypeEnum type, string name = null)
        {
            return await _dataContext.Itens.Cast<Recipe>().Include(i => i.Translates).SingleOrDefaultAsync(i => i.BDOReference == reference && i.Discriminator == discriminator && i.Type == type);
        }

        public async Task<Recipe> GetRecipeByReferenceAndType(string reference, RecipeTypeEnum type)
        {
            var query = _dataContext.Itens.Cast<Recipe>();
            if (type == RecipeTypeEnum.AlchemyOrCooking)
                return await query.SingleOrDefaultAsync(i => i.BDOReference == reference && (i.Type == RecipeTypeEnum.Cooking || i.Type == RecipeTypeEnum.Alchemy));
         
            return await query.SingleOrDefaultAsync(i => i.BDOReference == reference && i.Type == type);
        }

        public async Task<List<Recipe>> GetRecipesByType(RecipeTypeEnum type)
        {
            return await _dataContext.Itens.Cast<Recipe>().Where(i => i.Type == type).ToListAsync();
        }
    }
}
