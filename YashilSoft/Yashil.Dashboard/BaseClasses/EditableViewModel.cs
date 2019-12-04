using System.Collections.Generic;

namespace Yashil.Dashboard.Web.BaseClasses
{
    public class EditableViewModel<TEditModel>
    {
        public TEditModel EditModel { get; set; }
        public List<string> ChangedProps { get; set; }
    }
}