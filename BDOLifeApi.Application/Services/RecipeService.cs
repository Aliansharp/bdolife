using BDOLife.Application.Interfaces;
using BDOLife.Application.Models;
using BDOLife.Core.Entities;
using BDOLife.Core.Enums;
using BDOLife.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMasteryCookingRepository _masteryCookingRepository;
        private readonly IMasteryAlchemyRepository _masteryAlchemyRepository;
        public RecipeService(IRecipeRepository recipeRepository,
            IMasteryCookingRepository masteryCookingRepository,
            IMasteryAlchemyRepository masteryAlchemyRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<TreeNodeViewModel> CalculateTree(
            Guid recipeId,
            Guid masteryId,
            RecipeTypeEnum type,
            long quantity)
        {
            var recipe = await _recipeRepository.GetByIdAsync(recipeId);

            if (type == RecipeTypeEnum.Cooking)
                return await CalculateTreeCooking(recipe, masteryId, quantity);

            if (type == RecipeTypeEnum.Alchemy)
                return await CalculateTreeAlchemy(recipe, masteryId, quantity);

            if (type == RecipeTypeEnum.Process)
                return await CalculateTreeProcess(recipe, masteryId, quantity);

            return null;
        }

        private async Task<TreeNodeViewModel> CalculateTreeCooking(Recipe recipe, Guid masteryId, long quantity)
        {
            var mastery = await _masteryCookingRepository.GetByIdAsync(masteryId);



            throw new Exception();
        }

        private async Task<TreeNodeViewModel> CalculateTreeAlchemy(Recipe recipe, Guid masteryId, long quantity)
        {
            var mastery = await _masteryAlchemyRepository.GetByIdAsync(masteryId);
            throw new Exception();
        }

        private async Task<TreeNodeViewModel> CalculateTreeProcess(Recipe recipe, Guid masteryId, long quantity)
        {
            throw new Exception();
        }

        public Task<TreeNodeViewModel> CalculateTree(Guid recipeId, Guid masteryId, long quantity)
        {
            throw new NotImplementedException();
        }
    }
}
