using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Application.Tasks.Scraper
{
    public class ScraperRecipe
    {
        public long Id { get; set; }
        public List<ScraperRecipeMaterial> Materials { get; set; }
        public List<ScraperRecipeProduct> Products { get; set; }
    }

    public class ScraperRecipeMaterial
    {
        public long? ItemId { get; set; }
        public long? MaterialGroupId { get; set; }
        public long? SubRecipeId { get; set; }
        public int Quantity { get; set; }
        public string RecipeType { get; set; }
        public float? Weight { get; set; }
    }

    public class ScraperRecipeProduct
    {
        public long Id { get; set; }
    }
}
