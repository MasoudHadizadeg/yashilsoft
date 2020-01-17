using System;
using System.Collections.Generic;
using System.Text;

namespace Yashil.Core.CustomViewModels
{
    /// <summary>
    /// this Class Use For Present Report Or Dashboard  
    /// </summary>
    public class StoreCustomViewModel
    {
        public StoreCustomViewModel()
        {
            Groups = new List<int>();
        }

        public List<int> Groups { get; set; }
        public int Id { get; set; }

        public string Title { get; set; }
        public string CssClass { get; set; }

        public byte[] Picture { get; set; }

        public string Color { get; set; }

        public string Description { get; set; }
    }
}