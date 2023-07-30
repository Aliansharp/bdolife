using BDOLife.Core.Entities;
using BDOLife.Core.Enums;
using BDOLife.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Application.Models
{
    public class TreeNodeViewModel
    {
        public Guid Id { get; private set; }
        public string Parent { get; private set; }
        public string Text { get; private set; }
        public string Icon { get; private set; }
        public long Quantity { get; set; }
        public LanguageEnum Language { get; private set; }
        public decimal RegularProc { get; private set; }
        public decimal RareProc { get; private set; }
        public TreeNodeStateViewModel State { get; private set; }
        public List<TreeNodeViewModel> Children { get; private set; }

        private void SetLanguage(ItemBase item, LanguageEnum language)
        {
            this.Language = language;

            if (language == LanguageEnum.PT)
                this.Text = item.Name;
            else
            {
                var languageSelected = item.Translates.SingleOrDefault(t => t.Lang == language.GetDescription());

                if (languageSelected != null)
                    this.Text = languageSelected.NameTranslated;
                else
                {
                    var englishTranslate = item.Translates.SingleOrDefault(t => t.Lang == LanguageEnum.US.GetDescription());
                    this.Text = englishTranslate.NameTranslated;
                    this.Language = LanguageEnum.US;
                }
            }
        }

        public TreeNodeViewModel(
            ItemBase item, 
            LanguageEnum language,
            long quantity,
            decimal regularProc,
            decimal rareProc,
            Guid? parentId)
        {
            this.Id = item.Id;
            this.Parent = parentId == null ? "#" : parentId.Value.ToString();
            this.Quantity = quantity;
            this.RegularProc = regularProc;
            this.RareProc = rareProc;

            SetLanguage(item, language);

            if (item.Discriminator == "Recipe")
            {
                var recipe = (Recipe)item;

                if (recipe.Material1 != null && recipe.QtdMaterial1 != null)
                    AddChildren(recipe.Material1, recipe.QtdMaterial1.Value);

                if (recipe.Material2 != null && recipe.QtdMaterial2 != null)
                    AddChildren(recipe.Material2, recipe.QtdMaterial2.Value);

                if (recipe.Material3 != null && recipe.QtdMaterial3 != null)
                    AddChildren(recipe.Material3, recipe.QtdMaterial3.Value);

                if (recipe.Material4 != null && recipe.QtdMaterial4 != null)
                    AddChildren(recipe.Material4, recipe.QtdMaterial4.Value);

                if (recipe.Material5 != null && recipe.QtdMaterial5 != null)
                    AddChildren(recipe.Material5, recipe.QtdMaterial5.Value);
            }
        }

        public void AddChildren(ItemBase item, long unitQuantity)
        {
            var quantityTotal = unitQuantity * this.Quantity;
            var quantityChildren = this.Parent == "#" ? quantityTotal : (long)Math.Ceiling(quantityTotal / this.RegularProc);  
            this.Children.Add(new TreeNodeViewModel(item, this.Language, quantityChildren, this.RegularProc, this.RareProc, this.Id));
        }
    }

    public class TreeNodeStateViewModel
    {
        public bool Opened { get; set; }
        public bool Selected { get; set; }
        public bool Disabled { get; set; }
    }
}
