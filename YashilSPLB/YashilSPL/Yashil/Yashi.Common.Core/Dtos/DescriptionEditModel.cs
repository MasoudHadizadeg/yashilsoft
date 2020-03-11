using System;
using System.Collections.Generic;
using System.Text;

namespace Yashil.Common.Core.Dtos
{
    public class DescriptionEditModel<TK>
    {
        public TK Id { get; set; }
        public string Description { get; set; }
        public string PropertyName { get; set; }
    }
}
