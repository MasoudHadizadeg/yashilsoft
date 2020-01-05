using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilBaseInfo.Web.Areas.BaseInf.ViewModels
{

    public class YashilDataProviderListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string BaseType { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

    }


    public class YashilDataProviderViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string BaseType { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

    }


    public class YashilDataProviderEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        [StringLength(20)]
        [Required]

        public string Title { get; set; }

        [StringLength(20)]
        [Required]

        public string BaseType { get; set; }



        public string Description { get; set; }

        [Required]

        public bool IsActive { get; set; }

    }

    public class YashilDataProviderSimpleViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }

}
