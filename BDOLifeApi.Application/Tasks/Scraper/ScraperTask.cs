using BDOLife.Application.Tasks.Scraper;
using BDOLife.Core.Entities;
using BDOLife.Core.Enums;
using BDOLife.Core.Interfaces;
using BDOLife.Infra;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BDOLife.Application.Tasks
{
    public class ScraperTask
    {
        private readonly IConfiguration _configuration;
        private readonly IItemRepository _itemRepository;
        private readonly IMaterialGroupRepository _materialGroupRepository;
        private IWebDriver _driver;
        private readonly List<string> _languages;
        private readonly List<string> _linksItens;
        private readonly string _defaultLanguage = "pt";
        private readonly bool _disabled = false;
        private readonly DataContext _context;

        private readonly string _pathSaveDownloads = string.Empty;
        private readonly string _pathItems = string.Empty;
        private readonly string _pathMaterials = string.Empty;
        private readonly string _pathNpc = string.Empty;
        private readonly string _pathRecipesAlchemy = string.Empty;
        private readonly string _pathRecipesCooking = string.Empty;
        private readonly string _pathRecipesProcess = string.Empty;
        private readonly string _pathRecipesFull = string.Empty;

        public ScraperTask(
            IItemRepository itemRepository,
            IMaterialGroupRepository materialGroupRepository,
            IConfiguration configuration,
            DataContext context)
        {
            _configuration = configuration;
            _itemRepository = itemRepository;
            _materialGroupRepository = materialGroupRepository;
            _context = context;

            var pathDriver = Path.Combine(AppContext.BaseDirectory, _configuration.GetSection("Selenium")["Edge"]);
            _pathSaveDownloads = Path.Combine(AppContext.BaseDirectory, _configuration.GetSection("Selenium")["Save"]);
            _pathItems = _configuration.GetSection("Files")["Items"];
            _pathMaterials = _configuration.GetSection("Files")["Materials:Base"];
            _pathNpc = _configuration.GetSection("Files")["Materials:Npc"];
            _pathRecipesAlchemy = _configuration.GetSection("Files")["Recipes:Alchemy"];
            _pathRecipesCooking = _configuration.GetSection("Files")["Recipes:Cooking"];
            _pathRecipesProcess = _configuration.GetSection("Files")["Recipes:Process"];
            _pathRecipesFull = _configuration.GetSection("Files")["Recipes:Full"];

            _languages = new List<string> { "cn", "es", "fr", "id", "jp", "kr", "pt", "ru", "sp", "th", "tr", "tw", "us" };
            _linksItens = new List<string> {
                "https://bdocodex.com/pt/items/materials/",
                "https://bdocodex.com/pt/items/powerup/",
                "https://bdocodex.com/pt/items/consumables/",
                "https://bdocodex.com/pt/items/tools/",
                "https://bdocodex.com/pt/items/stones/",
                "https://bdocodex.com/pt/items/gems/",
                "https://bdocodex.com/pt/items/boat/",
                "https://bdocodex.com/pt/items/pearls/",
                "https://bdocodex.com/pt/items/mounts/",
                "https://bdocodex.com/pt/items/carriage/",
                "https://bdocodex.com/pt/items/furniture/"
            };


            var edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("--headless");
            edgeOptions.AddArgument("--disable-gpu");
            edgeOptions.AddArgument("--no-sandbox");
            edgeOptions.AddExcludedArgument("enable-automation");
            edgeOptions.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36 Edg/93.0.961.38");
            edgeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            //edgeOptions.AddArgument(@"--user-data-dir=C:\Users\Alisson\AppData\Local\Microsoft\Edge\User Data\Profile 5");
            edgeOptions.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
            edgeOptions.AddUserProfilePreference("download.default_directory", _pathSaveDownloads);

            _driver = new EdgeDriver(pathDriver, edgeOptions);
        }

        private void ClearFolderFiles()
        {
            foreach (string file in Directory.GetFiles(_pathSaveDownloads))
            {
                try
                {
                    File.Delete(file);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }

        public void ExtractItemsFromBDOCodex()
        {
            try
            {
                foreach (var lang in _languages)
                {
                    var link = $"https://bdocodex.com/{lang.ToLower()}/items";
                    var path = Path.Combine(AppContext.BaseDirectory, @"Tasks\Scraper\Scripts\Scraper.js");
                    var script = File.ReadAllText(path);
                    _driver.Navigate().GoToUrl(link);
                    Console.WriteLine($"Processing {link}");
                    Thread.Sleep(10000);
                    IJavaScriptExecutor driver = (IJavaScriptExecutor)this._driver;
                    driver.ExecuteScript(script);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ExtractBasicMaterialsFromBDOCodex()
        {
            var basicMaterials = new List<int>
            {
                9017,
                9018,
                9016,
                9059,
                9001,
                9005,
                9774,
                5535,
                9778,
                9019,
                54025,
                3717,
                16101,
                5867,
                4915,
                4922,
                4925,
                5651,
                9009,
                42353,
                9015,
                42352,
                9002
            };

            foreach (var materialId in basicMaterials)
            {
                var link = $"https://bdocodex.com/pt/item/{materialId}";
                foreach (var lang in _languages)
                {
                    var newLink = link.Remove(21, 2).Insert(21, lang.ToLower());
                    var path = Path.Combine(AppContext.BaseDirectory, @"Tasks\Scraper\Scripts\ScraperItem.js");
                    var script = File.ReadAllText(path);
                    _driver.Navigate().GoToUrl(newLink);
                    Console.WriteLine($"Processing {newLink}");
                    //Thread.Sleep(5000);
                    IJavaScriptExecutor driver = (IJavaScriptExecutor)this._driver;
                    driver.ExecuteScript(script);
                }
            }
        }

        public void ExtractRecipesProcessFromBDOCodex()
        {
            var link = "https://bdocodex.com/pt/mrecipes/";
            foreach (var lang in _languages)
            {
                var newLink = link.Remove(21, 2).Insert(21, lang.ToLower());
                var path = Path.Combine(AppContext.BaseDirectory, @"Tasks\Scraper\Scripts\Scraper.js");
                var script = File.ReadAllText(path);
                _driver.Navigate().GoToUrl(newLink);
                Console.WriteLine($"Processing {newLink}");
                Thread.Sleep(5000);
                IJavaScriptExecutor driver = (IJavaScriptExecutor)this._driver;
                driver.ExecuteScript(script);
            }
        }

        public void ExtractRecipesCookingAndAlchemyFromBDOCodex()
        {
            var link = "https://bdocodex.com/pt/recipes/";
            foreach (var lang in _languages)
            {
                var newLink = link.Remove(21, 2).Insert(21, lang.ToLower());
                var path = Path.Combine(AppContext.BaseDirectory, @"Tasks\Scraper\Scripts\Scraper.js");
                var script = File.ReadAllText(path);
                _driver.Navigate().GoToUrl(newLink);
                Console.WriteLine($"Processing {newLink}");
                Thread.Sleep(5000);
                IJavaScriptExecutor driver = (IJavaScriptExecutor)this._driver;
                driver.ExecuteScript(script);
            }
        }

        public async Task ExtractRecipeFullBDOCodex()
        {
            var recipes = await _itemRepository.GetRecipesByType(RecipeTypeEnum.Cooking);
            var recipesAlchemy = await _itemRepository.GetRecipesByType(RecipeTypeEnum.Alchemy);
            var recipesProcess = await _itemRepository.GetRecipesByType(RecipeTypeEnum.Process);

            recipes.AddRange(recipesAlchemy);

            foreach (var recipe in recipes)
            {
                var link = $"https://bdocodex.com/pt/recipe/{recipe.BDOReference}/";
                var path = Path.Combine(AppContext.BaseDirectory, @"Tasks\Scraper\Scripts\ScraperRecipe.js");
                var script = File.ReadAllText(path);
                _driver.Navigate().GoToUrl(link);
                Console.WriteLine($"Processing {link}");
                //Thread.Sleep(3000);
                IJavaScriptExecutor driver = (IJavaScriptExecutor)this._driver;
                driver.ExecuteScript(script);
            }

            //recipesProcess = recipesProcess.Skip(586).ToList();
            foreach (var recipe in recipesProcess)
            {
                var link = $"https://bdocodex.com/pt/mrecipe/{recipe.BDOReference}/";
                var path = Path.Combine(AppContext.BaseDirectory, @"Tasks\Scraper\Scripts\ScraperRecipe.js");
                var script = File.ReadAllText(path);
                _driver.Navigate().GoToUrl(link);
                Console.WriteLine($"Processing {link}");
                //Thread.Sleep(3000);
                IJavaScriptExecutor driver = (IJavaScriptExecutor)this._driver;
                driver.ExecuteScript(script);
            }
        }

        public async Task ProcessRecipeFull(RecipeTypeEnum type)
        {
            var recipes = await _itemRepository.GetRecipesByType(type);

            var fileNamePattern = string.Empty;
            switch (type)
            {
                case RecipeTypeEnum.Process:
                    fileNamePattern = "mrecipe";
                    break;
                case RecipeTypeEnum.Alchemy:
                case RecipeTypeEnum.Cooking:
                    fileNamePattern = "recipe";
                    break;
            }

            foreach (var recipe in recipes)
            {
                //var path = Path.Combine(AppContext.BaseDirectory, @"Tasks\Scraper\Files\Recipes\Full\Recipe\", $"recipe_{recipe.BDOReference}_{_defaultLanguage}.json");
                var path = Path.Combine(AppContext.BaseDirectory, _pathSaveDownloads, $"{fileNamePattern}_{recipe.BDOReference}_{_defaultLanguage}.json");

                using (StreamReader file = File.OpenText(path))
                {
                    var json = file.ReadToEnd();
                    var recipeBDOCodex = JsonConvert.DeserializeObject<ScraperRecipe>(json);
                    var recipeDb = (Recipe)await _itemRepository.GetRecipeByReferenceAndType(recipeBDOCodex.Id.ToString(), type);
                    var index = 1;

                    foreach (var material in recipeBDOCodex.Materials)
                    {
                        Guid materialId = Guid.Empty;
                        int quantity = material.Quantity;
                        var mG = false;

                        if (material.ItemId != null && material.MaterialGroupId == null && material.SubRecipeId == null)
                        {
                            var item = await _itemRepository.GetByReference(material.ItemId.ToString(), "Item");
                            if (item != null)
                                materialId = item.Id;
                        }

                        if (material.ItemId != null && material.SubRecipeId != null && material.MaterialGroupId == null)
                        {
                            if (material.RecipeType == "mrecipe") //Process
                            {
                                var mrec = await _itemRepository.GetRecipeByReferenceAndType(material.SubRecipeId.ToString(), RecipeTypeEnum.Process);
                                if (mrec != null)
                                    materialId = mrec.Id;
                            }
                            else if (material.RecipeType == "recipe") //Cooking or Alchemy
                            {
                                var rec = await _itemRepository.GetRecipeByReferenceAndType(material.SubRecipeId.ToString(), RecipeTypeEnum.AlchemyOrCooking);
                                if (rec != null)
                                    materialId = rec.Id;
                            }
                        }

                        if ((material.MaterialGroupId != null && material.ItemId == null && material.SubRecipeId == null) || (material.MaterialGroupId != null && material.SubRecipeId != null && material.ItemId == null))
                        {
                            var materialGroup = await _materialGroupRepository.GetByReference(material.MaterialGroupId.ToString());
                            if (materialGroup != null)
                            {
                                mG = true;
                                materialId = materialGroup.Id;
                            }
                        }

                        if (quantity != 0 && materialId != Guid.Empty)
                        {

                            switch (index)
                            {
                                case 1:
                                    recipe.QtdMaterial1 = quantity;
                                    if (mG)
                                        recipe.MaterialGroup1Id = materialId;
                                    else
                                        recipe.Material1Id = materialId;

                                    break;
                                case 2:
                                    recipe.QtdMaterial2 = quantity;
                                    if (mG)
                                        recipe.MaterialGroup2Id = materialId;
                                    else
                                        recipe.Material2Id = materialId;
                                    break;
                                case 3:
                                    recipe.QtdMaterial3 = quantity;
                                    if (mG)
                                        recipe.MaterialGroup3Id = materialId;
                                    else
                                        recipe.Material3Id = materialId;
                                    break;
                                case 4:
                                    recipe.QtdMaterial4 = quantity;
                                    if (mG)
                                        recipe.MaterialGroup4Id = materialId;
                                    else
                                        recipe.Material4Id = materialId;
                                    break;
                                case 5:
                                    recipe.QtdMaterial5 = quantity;
                                    if (mG)
                                        recipe.MaterialGroup5Id = materialId;
                                    else
                                        recipe.Material5Id = materialId;
                                    break;
                            }
                        }
                        index++;

                    }

                    index = 1;
                    foreach (var product in recipeBDOCodex.Products)
                    {
                        var item = await _itemRepository.GetByReference(product.Id.ToString(), "Item");

                        if (item != null)
                        {
                            switch (index)
                            {
                                case 1:
                                    recipe.Product1Id = item.Id;
                                    break;
                                case 2:
                                    recipe.Product2Id = item.Id;
                                    break;
                            }
                        }

                        index++;
                    }

                    await _itemRepository.UpdateAsync(recipe);
                }
            }
        }

        public async Task Extract()
        {
            //ClearFolderFiles();
            
            //ExtractItemsFromBDOCodex();
            //await ProcessItemsAsync();

            //ExtractBasicMaterialsFromBDOCodex();
            //await ProcessMaterialsAsync();
            
            //ExtractRecipesProcessFromBDOCodex();
            //await ProcessRecipeAsync(RecipeTypeEnum.Process);

            //ExtractRecipesCookingAndAlchemyFromBDOCodex();
            //await ProcessRecipeAsync(RecipeTypeEnum.Cooking);
            //await ProcessRecipeAsync(RecipeTypeEnum.Alchemy);

            //await ExtractRecipeFullBDOCodex();

            //await ProcessRecipeFull(RecipeTypeEnum.Process);
            await ProcessRecipeFull(RecipeTypeEnum.Cooking);
            await ProcessRecipeFull(RecipeTypeEnum.Alchemy);
        }

        public void MoveFiles()
        {

            var files = Directory.GetFiles(_configuration.GetSection("Selenium")["Save"]);
            foreach (var file in files)
            {
                var path = string.Empty;
                var filename = Path.GetFileName(file);

                if (file.Contains("items"))
                    path = $"{_pathItems}{filename}";
                else if (file.Contains("mrecipe"))
                    path = $"{_pathRecipesFull}{filename}";
                //else if(file.Contains("recipes"))
                //    path = $"{_pathReci}

                File.Move(file, path);
            }
        }

        public async Task ProcessMaterialsAsync()
        {
            if (_disabled == false)
            {

                try
                {
                    var materialsCategories = new List<string> {
                        "boat",
                        "carriage",
                        "consumables",
                        "furniture",
                        "gems",
                        "materials",
                        "mounts",
                        "pearls",
                        "powerup",
                        "stones",
                        "tools"
                    };

                    var materialsLanguages = new Dictionary<string, List<ScraperItem>>();
                    foreach (var categorie in materialsCategories)
                    {
                        foreach (var lang in _languages.Select(l => l.ToLower()))
                        {
                            var path = Path.Combine(AppContext.BaseDirectory, _pathMaterials, $"{categorie}_{lang}.json");
                            using (StreamReader file = File.OpenText(path))
                            {
                                var json = file.ReadToEnd();
                                var mainList = JsonConvert.DeserializeObject<List<ScraperItem>>(json);
                                mainList = mainList.OrderBy(m => m.BDOReference).ToList();
                                materialsLanguages.Add($"{categorie}_{lang}", mainList);
                            }
                        }
                    }
                    foreach (var categorie in materialsCategories)
                    {
                        foreach (var item in materialsLanguages[$"{categorie}_{_defaultLanguage.ToLower()}"])
                        {

                            var newItem = new Item
                            {
                                Id = Guid.NewGuid(),
                                BDOReference = item.BDOReference.ToString(),
                                Name = item.Name.Replace("\"", ""),
                                Visible = true,
                                Image = item.Image,
                                //Product1 = item.Products != null && item.Products.Count >= 1 ? _itemRepository.Get
                            };

                            var newsTranslates = new List<ItemTranslate>();
                            foreach (var lang in _languages.Select(l => l.ToLower()))
                            {
                                if (lang != _defaultLanguage)
                                {
                                    var translates = materialsLanguages[$"{categorie}_{lang}"].ToList();
                                    var translate = translates.SingleOrDefault(t => t.BDOReference.ToString() == newItem.BDOReference);
                                    if (translate != null)
                                    {
                                        newsTranslates.Add(new ItemTranslate
                                        {
                                            Id = Guid.NewGuid(),
                                            ItemId = newItem.Id,
                                            NameTranslated = translate.Name.Replace("\"", ""),
                                            Lang = lang.ToUpper()
                                        });
                                    }
                                }
                            }

                            var itemDB = (Item)await _itemRepository.GetByReference(item.BDOReference.ToString(), nameof(Item));
                            if (itemDB != null)
                            {
                                if (!itemDB.Name.Equals(newItem.Name))
                                    itemDB.Name = newItem.Name;

                                if (!itemDB.Image.Equals(newItem.Image))
                                    itemDB.Image = newItem.Image;

                                var translates = itemDB.Translates.ToList();
                                if (translates.Count() != newsTranslates.Count())
                                {
                                    newsTranslates = newsTranslates.Where(nt => !translates.Any(t => t.Lang == nt.Lang)).ToList();
                                    newsTranslates.ForEach(n => _context.Entry(n).State = Microsoft.EntityFrameworkCore.EntityState.Added);
                                    itemDB.Translates.AddRange(newsTranslates);
                                }

                                await _itemRepository.UpdateAsync(itemDB);
                            }
                            else
                            {
                                newItem.Translates = newsTranslates;
                                newItem = (Item)_itemRepository.AddAsync(newItem).Result;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async Task ProcessItemsAsync()
        {
            if (_disabled == false)
            {
                var updatedItems = new List<ItemBase>();
                var addedItems = new List<ItemBase>();

                try
                {
                    var itensLanguages = new Dictionary<string, List<ScraperItem>>();
                    foreach (var lang in _languages)
                    {
                        var langLower = lang.ToLower();
                        //var path = Path.Combine(AppContext.BaseDirectory, @"Tasks\Scraper\Files\Itens", $"{lang}.json");
                        var path = Path.Combine(AppContext.BaseDirectory, _pathSaveDownloads, $"items_{langLower}.json");

                        using (StreamReader file = File.OpenText(path))
                        {
                            var json = file.ReadToEnd();
                            var mainList = JsonConvert.DeserializeObject<List<ScraperItem>>(json);
                            mainList = mainList.OrderBy(m => m.BDOReference).ToList();
                            itensLanguages.Add(langLower, mainList);
                        }
                    }

                    var count = 0;

                    var itemsDb = await _itemRepository.GetAsync(predicate: x => x.Discriminator == nameof(Item), orderBy: null, includeString: nameof(Item.Translates), disableTracking: false);

                    foreach (var item in itensLanguages[_defaultLanguage])
                    {
                        var newItem = new Item
                        {
                            Id = Guid.NewGuid(),
                            BDOReference = item.BDOReference.ToString(),
                            Name = item.Name,
                            Visible = true,
                            Image = item.Image,
                            //Product1 = item.Products != null && item.Products.Count >= 1 ? _itemRepository.Get
                        };

                        var newsTranslates = new List<ItemTranslate>();
                        foreach (var lang in _languages)
                        {
                            if (lang != _defaultLanguage)
                            {
                                var translates = itensLanguages[lang].ToList();
                                var translate = translates.SingleOrDefault(t => t.BDOReference.ToString() == newItem.BDOReference);
                                if (translate != null)
                                {
                                    newsTranslates.Add(new ItemTranslate
                                    {
                                        Id = Guid.NewGuid(),
                                        ItemId = newItem.Id,
                                        NameTranslated = translate.Name,
                                        Lang = lang
                                    });
                                }
                            }
                        }

                        var itemDB = (Item)itemsDb.FirstOrDefault(x => x.BDOReference.Equals(newItem.BDOReference));

                        if (itemDB == null)
                        {
                            newItem.Translates = newsTranslates;
                            addedItems.Add(newItem);
                            Console.WriteLine($"{count} - {newItem.Name} (ADDED)");
                        }
                        else
                        {
                            var itemChanged = false;

                            if (!itemDB.Name.Equals(newItem.Name))
                            {
                                itemDB.Name = newItem.Name;
                                itemChanged = true;
                            }

                            if (!itemDB.Image.Equals(newItem.Image))
                            {
                                itemDB.Image = newItem.Image;
                                itemChanged = true;
                            }

                            var translates = itemDB.Translates.ToList();
                            if (translates.Count() != newsTranslates.Count())
                            {
                                newsTranslates = newsTranslates.Where(nt => !translates.Any(t => t.Lang == nt.Lang)).ToList();
                                newsTranslates.ForEach(n => _context.Entry(n).State = Microsoft.EntityFrameworkCore.EntityState.Added);
                                itemDB.Translates.AddRange(newsTranslates);
                                itemChanged = true;
                            }

                            if (itemChanged)
                            {
                                updatedItems.Add(itemDB);
                                Console.WriteLine($"{count} - {itemDB.Name} (UPDATED)");
                            }
                            else
                            {
                                Console.WriteLine($"{count} - {newItem.Name} (NOT CHANGED)");
                            }
                        }
                        count++;
                    }

                    if (addedItems?.Count > 0)
                    {
                        await _itemRepository.AddBulkAsync(addedItems);
                        Console.WriteLine($"TOTAL ITEMS ADDED: {addedItems.Count}");
                    }

                    if (updatedItems?.Count > 0)
                    {
                        await _itemRepository.UpdateBulkAsync(updatedItems);
                        Console.WriteLine($"TOTAL ITEMS UPDATED: {updatedItems.Count}");
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async Task ExtractBasicItemsAsync()
        {
            if (!_disabled)
            {
                var basicMaterials = new List<int> {
                                            9017,
                                            9018,
                                            9016,
                                            9059,
                                            9001,
                                            9005,
                                            9774,
                                            5535,
                                            9778,
                                            9019,
                                            54025,
                                            3717,
                                            16101,
                                            5867,
                                            4915,
                                            4922,
                                            4925,
                                            5651,
                                            9009,
                                            42353,
                                            9015,
                                            42352,
                                            9002,
                                        };

                try
                {
                    var itemLanguages = new Dictionary<string, List<ScraperItem>>();
                    foreach (var material in basicMaterials)
                    {
                        foreach (var lang in _languages.Select(l => l.ToLower()))
                        {
                            var path = Path.Combine(AppContext.BaseDirectory, _pathNpc, $"item_{material}_{lang}.json");
                            using (StreamReader file = File.OpenText(path))
                            {
                                var json = file.ReadToEnd();
                                var item = JsonConvert.DeserializeObject<ScraperItem>(json);
                                if (!itemLanguages.ContainsKey(lang))
                                    itemLanguages.Add(lang, new List<ScraperItem>());

                                itemLanguages[lang].Add(item);
                            }
                        }
                    }

                    foreach (var item in itemLanguages[_defaultLanguage])
                    {
                        var newItem = new Item
                        {
                            Id = Guid.NewGuid(),
                            BDOReference = item.Id.ToString(),
                            Name = item.Name,
                            Visible = true,
                            Image = item.Image,
                        };
                        var newsTranslates = new List<ItemTranslate>();
                        foreach (var lang in _languages.Select(l => l.ToLower()))
                        {
                            if (lang != _defaultLanguage)
                            {
                                var translates = itemLanguages[lang].ToList();
                                var translate = translates.SingleOrDefault(t => t.Id.ToString() == newItem.BDOReference);
                                if (translate != null)
                                {
                                    newsTranslates.Add(new ItemTranslate
                                    {
                                        Id = Guid.NewGuid(),
                                        ItemId = newItem.Id,
                                        NameTranslated = translate.Name,
                                        Lang = lang.ToUpper()
                                    });
                                }
                            }
                        }

                        var itemDB = (Item)await _itemRepository.GetByReference(newItem.BDOReference, nameof(Item));
                        if (newItem != null)
                        {
                            if (!newItem.Name.Equals(newItem.Name))
                                newItem.Name = newItem.Name;

                            if (!newItem.Image.Equals(newItem.Image))
                                newItem.Image = newItem.Image;

                            var translates = itemDB.Translates.ToList();
                            if (translates != null && translates.Count() != newsTranslates.Count())
                            {
                                newsTranslates = newsTranslates.Where(nt => !translates.Any(t => t.Lang == nt.Lang)).ToList();
                                newsTranslates.ForEach(n => _context.Entry(n).State = Microsoft.EntityFrameworkCore.EntityState.Added);
                                itemDB.Translates.AddRange(newsTranslates);
                            }
                            else if (translates == null)
                            {
                                newsTranslates.ForEach(n => _context.Entry(n).State = Microsoft.EntityFrameworkCore.EntityState.Added);
                                itemDB.Translates = newsTranslates;
                            }

                            await _itemRepository.UpdateAsync(newItem);
                        }
                        else
                        {
                            newItem.Translates = newsTranslates;
                            newItem = (Item)await _itemRepository.AddAsync(newItem);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        public async Task ProcessRecipeAsync(RecipeTypeEnum type)
        {
            if (_disabled == false)
            {
                try
                {
                    var fileNamePattern = string.Empty;
                    switch (type)
                    {
                        case RecipeTypeEnum.Process:
                            fileNamePattern = "mrecipes";
                            break;
                        case RecipeTypeEnum.Alchemy:
                        case RecipeTypeEnum.Cooking:
                            fileNamePattern = "recipes";
                            break;
                    }

                    var updatedRecipes = new List<ItemBase>();
                    var addedRecipes = new List<ItemBase>();

                    var languages = new Dictionary<string, List<ScraperItem>>();
                    foreach (var lang in _languages)
                    {
                        var path = Path.Combine(AppContext.BaseDirectory, _pathSaveDownloads, $"{fileNamePattern}_{lang}.json");
                        using (StreamReader file = File.OpenText(path))
                        {
                            var json = file.ReadToEnd();
                            var mainList = JsonConvert.DeserializeObject<List<ScraperItem>>(json);
                            mainList = mainList.OrderBy(m => m.BDOReference).ToList();
                            languages.Add(lang, mainList);
                        }
                    }

                    var count = 0;

                    var recipesDb = await _itemRepository.GetAsync(predicate: x => x.Discriminator == nameof(Recipe) && ((Recipe)x).Type == type, orderBy: null, includeString: nameof(Item.Translates), disableTracking: false);

                    var query = languages[_defaultLanguage].AsQueryable();

                    if (type == RecipeTypeEnum.Cooking)
                        query = query.Where(x => x.SubType == "Culinária");

                    if(type == RecipeTypeEnum.Alchemy)
                        query = query.Where(x => x.SubType == "Alquimia");

                    foreach (var item in query.ToList())
                    {
                        var newRecipe = new Recipe
                        {
                            Id = Guid.NewGuid(),
                            BDOReference = item.BDOReference.ToString(),
                            Name = item.Name,
                            Visible = true,
                            Type = type,
                            EXP = item.Exp,
                            SubType = GetSubType(item.SubType),
                        };

                        var newsTranslates = new List<ItemTranslate>();
                        foreach (var lang in _languages)
                        {
                            if (lang != _defaultLanguage)
                            {
                                var translates = languages[lang].ToList();
                                var translate = translates.SingleOrDefault(t => t.BDOReference.ToString() == newRecipe.BDOReference);
                                if (translate != null)
                                {
                                    newsTranslates.Add(new ItemTranslate
                                    {
                                        Id = Guid.NewGuid(),
                                        ItemId = newRecipe.Id,
                                        NameTranslated = translate.Name,
                                        Lang = lang
                                    });
                                }
                            }
                        }

                        var recipeDb = (Recipe)recipesDb.FirstOrDefault(x => x.BDOReference.Equals(newRecipe.BDOReference));

                        if (recipeDb == null)
                        {
                            newRecipe.Translates = newsTranslates;
                            addedRecipes.Add(newRecipe);
                            Console.WriteLine($"{count} - {newRecipe.Name} (ADDED)");
                        }
                        else
                        {
                            var recipeChange = false;

                            if (recipeDb.Name != newRecipe.Name)
                            {
                                recipeDb.Name = newRecipe.Name;
                                recipeChange = true;
                            }

                            if (recipeDb.Image != newRecipe.Image)
                            {
                                recipeDb.Image = newRecipe.Image;
                                recipeChange = true;
                            }

                            if (recipeDb.EXP != newRecipe.EXP)
                            {
                                recipeDb.EXP = newRecipe.EXP;
                                recipeChange = true;
                            }

                            var translates = recipeDb.Translates.ToList();
                            if (translates != null && translates.Count() != newsTranslates.Count())
                            {
                                newsTranslates = newsTranslates.Where(nt => !translates.Any(t => t.Lang == nt.Lang)).ToList();
                                newsTranslates.ForEach(n => _context.Entry(n).State = Microsoft.EntityFrameworkCore.EntityState.Added);
                                recipeDb.Translates.AddRange(newsTranslates);
                                recipeChange = true;
                            }

                            if (recipeChange)
                            {
                                updatedRecipes.Add(recipeDb);
                                Console.WriteLine($"{count} - {recipeDb.Name} (UPDATED)");
                            }
                            else
                            {
                                Console.WriteLine($"{count} - {newRecipe.Name} (NOT CHANGED)");
                            }
                        }
                        count++;
                    }

                    if (addedRecipes?.Count > 0)
                    {
                        await _itemRepository.AddBulkAsync(addedRecipes);
                        Console.WriteLine($"TOTAL RECIPES ADDED: {addedRecipes.Count}");
                    }

                    if (updatedRecipes?.Count > 0)
                    {
                        await _itemRepository.UpdateBulkAsync(updatedRecipes);
                        Console.WriteLine($"TOTAL RECIPES UPDATED: {updatedRecipes.Count}");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private ProcessingTypeEnum? GetSubType(string subtype)
        {
            switch (subtype)
            {
                case "Fábrica":
                    return ProcessingTypeEnum.Manufacture;
                case "Alquimia Simples":
                    return ProcessingTypeEnum.SimpleAlchemy;
                case "Empacotar Culinária Imperial":
                    return ProcessingTypeEnum.ImperialCuisine;
                case "Cozinha Simples":
                    return ProcessingTypeEnum.SimpleCooking;
                case "Moagem":
                    return ProcessingTypeEnum.Grinding;
                case "Fabricação de Guilda":
                    return ProcessingTypeEnum.GuildProcessing;
                case "Aquecimento":
                    return ProcessingTypeEnum.Heating;
                case "Chacoalhar":
                    return ProcessingTypeEnum.Shaking;
                case "Corte":
                    return ProcessingTypeEnum.Chopping;
                case "Desidratação":
                    return ProcessingTypeEnum.Drying;
                case "Empacotar Alquimia Imperial":
                    return ProcessingTypeEnum.ImperialAlchemy;
                case "Filtragem":
                    return ProcessingTypeEnum.Filtering;
            }

            return null;
        }

    }
}
