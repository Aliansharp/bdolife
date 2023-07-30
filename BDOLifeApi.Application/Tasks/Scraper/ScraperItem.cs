using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Application.Tasks.Scraper
{
    public class ScraperItem
    {
        public long Id { get; set; }
        public long BDOReference { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Exp { get; set; }
        public string SubType { get; set; }
        //public List<int> Products { get; set; }
    }
}
