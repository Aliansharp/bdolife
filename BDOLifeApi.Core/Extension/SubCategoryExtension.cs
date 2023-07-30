using BDOLife.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Core.Extension
{
    public static class SubCategoryExtension
    {
        public static List<KeyValuePair<string, int>> GetSubCategories(this MainCategoryEnum main)
        {
            if(main == MainCategoryEnum.MainWeapon)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Longsword", 1),
                    new KeyValuePair<string, int>("Longbow", 2),
                    new KeyValuePair<string, int>("Amulet", 3),
                    new KeyValuePair<string, int>("Axe", 4),
                    new KeyValuePair<string, int>("Shortsword", 5),
                    new KeyValuePair<string, int>("Blade", 6),
                    new KeyValuePair<string, int>("Staff", 7),
                    new KeyValuePair<string, int>("Kriegsmesser", 8),
                    new KeyValuePair<string, int>("Gauntlet", 9),
                    new KeyValuePair<string, int>("Crescent Pendulum", 10),
                    new KeyValuePair<string, int>("Crossbow", 11),
                    new KeyValuePair<string, int>("Florang", 12),
                    new KeyValuePair<string, int>("Battle Axe", 13),
                    new KeyValuePair<string, int>("Shamshir", 14),
                    new KeyValuePair<string, int>("Morning Star", 15),
                    new KeyValuePair<string, int>("Kyve", 16),
                    new KeyValuePair<string, int>("Serenaca", 16),
                };
            }
            
            if(main == MainCategoryEnum.SubWeapon)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Shield", 1),
                    new KeyValuePair<string, int>("Dagger", 2),
                    new KeyValuePair<string, int>("Talisman", 3),
                    new KeyValuePair<string, int>("Ornamental Knot", 4),
                    new KeyValuePair<string, int>("Trinket", 5),
                    new KeyValuePair<string, int>("Horn Bow", 6),
                    new KeyValuePair<string, int>("Kunai", 7),
                    new KeyValuePair<string, int>("Shuriken", 8),
                    new KeyValuePair<string, int>("Vambrace", 9),
                    new KeyValuePair<string, int>("Noble Sword", 10),
                    new KeyValuePair<string, int>("Ra'ghon", 11),
                    new KeyValuePair<string, int>("Vitclari", 12),
                    new KeyValuePair<string, int>("Haladie", 13),
                    new KeyValuePair<string, int>("Quoratum", 14),
                    new KeyValuePair<string, int>("Mareca", 15),
                };
            }

            if (main == MainCategoryEnum.AwakeningWeapon)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Great Sword", 1),
                    new KeyValuePair<string, int>("Scythe", 2),
                    new KeyValuePair<string, int>("Iron Buster", 3),
                    new KeyValuePair<string, int>("Kamasylven Sword", 4),
                    new KeyValuePair<string, int>("Celestial Bo Staff", 5),
                    new KeyValuePair<string, int>("Lancia", 6),
                    new KeyValuePair<string, int>("Crescent Blade", 7),
                    new KeyValuePair<string, int>("Kerispear", 8),
                    new KeyValuePair<string, int>("Sura Katana", 9),
                    new KeyValuePair<string, int>("Sah Chakram", 10),
                    new KeyValuePair<string, int>("Aad Sphera", 11),
                    new KeyValuePair<string, int>("Godr Sphera", 12),
                    new KeyValuePair<string, int>("Vediant", 13),
                    new KeyValuePair<string, int>("Gardbrace", 14),
                    new KeyValuePair<string, int>("Cestus", 15),
                    new KeyValuePair<string, int>("Crimson Glaives", 16),
                    new KeyValuePair<string, int>("Greatbow", 17),
                    new KeyValuePair<string, int>("Jordun", 19),
                    new KeyValuePair<string, int>("Dual Glaives", 20),
                    new KeyValuePair<string, int>("Sting", 21),
                    new KeyValuePair<string, int>("Kibelius", 22)
                };
            }

            if (main == MainCategoryEnum.Armor)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Helmet", 1),
                    new KeyValuePair<string, int>("Armor", 2),
                    new KeyValuePair<string, int>("Gloves", 3),
                    new KeyValuePair<string, int>("Shoes", 4),
                    new KeyValuePair<string, int>("Functional Clothes", 5),
                    new KeyValuePair<string, int>("Crafted Clothes", 6),
                };
            }

            if (main == MainCategoryEnum.Accessory)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Ring", 1),
                    new KeyValuePair<string, int>("Necklace", 2),
                    new KeyValuePair<string, int>("Earring", 3),
                    new KeyValuePair<string, int>("Belt", 4),
                };
            }

            if (main == MainCategoryEnum.Material)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Ore/Gem", 1),
                    new KeyValuePair<string, int>("Plants", 2),
                    new KeyValuePair<string, int>("Seed/Fruit", 3),
                    new KeyValuePair<string, int>("Leather", 4),
                    new KeyValuePair<string, int>("Blood", 5),
                    new KeyValuePair<string, int>("Meat", 6),
                    new KeyValuePair<string, int>("Seafood", 7),
                    new KeyValuePair<string, int>("Misc.", 8),
                };
            }

            if (main == MainCategoryEnum.EnhancementUpgrade)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Black Stone", 1),
                    new KeyValuePair<string, int>("Upgrade", 2),
                };
            }

            if (main == MainCategoryEnum.Consumables)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Offensive Elixir", 1),
                    new KeyValuePair<string, int>("Defensive Elixir", 2),
                    new KeyValuePair<string, int>("Functional Elixir", 3),
                    new KeyValuePair<string, int>("Food", 4),
                    new KeyValuePair<string, int>("Potion", 5),
                    new KeyValuePair<string, int>("Siege Items", 6),
                    new KeyValuePair<string, int>("Item Parts", 7),
                    new KeyValuePair<string, int>("Other Consumables", 8),
                };
            }

            if (main == MainCategoryEnum.LifeTools)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Lumbering Axe", 1),
                    new KeyValuePair<string, int>("Fluid Collector", 2),
                    new KeyValuePair<string, int>("Butcher Knife", 3),
                    new KeyValuePair<string, int>("Pickaxe", 4),
                    new KeyValuePair<string, int>("Hoe", 5),
                    new KeyValuePair<string, int>("Tanning Knife", 6),
                    new KeyValuePair<string, int>("Fishing Tools", 7),
                    new KeyValuePair<string, int>("Matchlock", 8),
                    new KeyValuePair<string, int>("Alchemy/Cooking", 9),
                    new KeyValuePair<string, int>("Other Tools", 10),
                };
            }

            if (main == MainCategoryEnum.AlchemyStone)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Destruction", 1),
                    new KeyValuePair<string, int>("Protection", 2),
                    new KeyValuePair<string, int>("Life", 3),
                    new KeyValuePair<string, int>("Spirit Stone", 4),
                };
            }

            if (main == MainCategoryEnum.MagicCrystal)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Main Weapon", 1),
                    new KeyValuePair<string, int>("Sub-weapon", 2),
                    new KeyValuePair<string, int>("Helmet", 3),
                    new KeyValuePair<string, int>("Armor", 4),
                    new KeyValuePair<string, int>("Gloves", 5),
                    new KeyValuePair<string, int>("Shoes", 6),
                    new KeyValuePair<string, int>("Versatile", 7),
                    new KeyValuePair<string, int>("Awakening Weapon", 8),
                };
            }

            if (main == MainCategoryEnum.PearlItems)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Male Apparel (Set)", 1),
                    new KeyValuePair<string, int>("Female Apparels (Set)", 2),
                    new KeyValuePair<string, int>("Male Apparel (Individual)", 3),
                    new KeyValuePair<string, int>("Female Apparel (Individual)", 4),
                    new KeyValuePair<string, int>("Class-based Apparel (Set)", 5),
                    new KeyValuePair<string, int>("Functional", 6),
                    new KeyValuePair<string, int>("Mount", 7),
                    new KeyValuePair<string, int>("Pet", 8),
                };
            }

            if (main == MainCategoryEnum.Dye)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Basic", 1),
                    new KeyValuePair<string, int>("Olvia", 2),
                    new KeyValuePair<string, int>("Velia", 3),
                    new KeyValuePair<string, int>("Heidelian", 4),
                    new KeyValuePair<string, int>("Keplan", 5),
                    new KeyValuePair<string, int>("Calpheon", 6),
                    new KeyValuePair<string, int>("Mediah", 7),
                    new KeyValuePair<string, int>("Valencia", 8),
                };
            }

            if (main == MainCategoryEnum.Mount)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Registration", 1),
                    new KeyValuePair<string, int>("Feed", 2),
                    new KeyValuePair<string, int>("Champron", 3),
                    new KeyValuePair<string, int>("Barding", 4),
                    new KeyValuePair<string, int>("Saddle", 5),
                    new KeyValuePair<string, int>("Stirrups", 6),
                    new KeyValuePair<string, int>("Horseshoe", 7),
                    new KeyValuePair<string, int>("[Elephant] Stirrups", 9),
                    new KeyValuePair<string, int>("[Elephant] Armor", 10),
                    new KeyValuePair<string, int>("[Elephant] Mask", 11),
                    new KeyValuePair<string, int>("[Elephant] Saddle", 12),
                    new KeyValuePair<string, int>("Courser Training", 13),

                };
            }

            if (main == MainCategoryEnum.Ship)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Registration", 1),
                    new KeyValuePair<string, int>("Cargo", 2),
                    new KeyValuePair<string, int>("Prow", 3),
                    new KeyValuePair<string, int>("Decoration", 4),
                    new KeyValuePair<string, int>("Totem", 5),
                    new KeyValuePair<string, int>("Prow Statue", 6),
                    new KeyValuePair<string, int>("Plating", 7),
                    new KeyValuePair<string, int>("Cannon", 8),
                    new KeyValuePair<string, int>("Sail", 9),
                };
            }

            if (main == MainCategoryEnum.Wagon)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Registration", 1),
                    new KeyValuePair<string, int>("Wheel", 2),
                    new KeyValuePair<string, int>("Cover", 3),
                    new KeyValuePair<string, int>("Flag", 4),
                    new KeyValuePair<string, int>("Emblem", 5),
                    new KeyValuePair<string, int>("Lamp", 6),
                };
            }

            if (main == MainCategoryEnum.Furniture)
            {
                return new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("Bed", 1),
                    new KeyValuePair<string, int>("Bedside Table/Table", 2),
                    new KeyValuePair<string, int>("Wardrobe/Bookshelf", 3),
                    new KeyValuePair<string, int>("Sofa/Chair", 4),
                    new KeyValuePair<string, int>("Chandelier", 5),
                    new KeyValuePair<string, int>("Floor/Carpet", 6),
                    new KeyValuePair<string, int>("Wall/Curtain", 7),
                    new KeyValuePair<string, int>("Decoration", 8),
                    new KeyValuePair<string, int>("Others", 9),
                };
            }

            return null;
        }
    }
}
