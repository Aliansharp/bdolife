using BDOLife.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Application.Interfaces
{
    public interface IRecipeService
    {
        Task<TreeNodeViewModel> CalculateTree(Guid recipeId, Guid masteryId, long quantity);
    }
}
