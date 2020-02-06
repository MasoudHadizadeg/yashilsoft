using System;
using System.Collections.Generic;
using System.Text;

namespace Yashil.Core.CustomViewModels
{
   public class AssignableListEditModel
    {
        public int[] SelectedItems { get; set; }
        public int GroupId { get; set; }
        public bool Assign { get; set; }
    }
}
