using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilTms.Web.Areas.Tms.ViewModels
{

    public class PersonBankAccountListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int? ParentId { get; set; }
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string PersonTitle { get; set; }
        public string NationalCode { get; set; }

        public string BankTypeTitle { get; set; }

        public string CardNumber { get; set; }

        public string AccountNumber { get; set; }

        public string ShabaNumber { get; set; }

        public string AccessLevelTitle { get; set; }

    }

    public class PersonBankAccountEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }
        [StringLength(300)]
        public string BranchName { get; set; }
        [Range(0, int.MaxValue)]
        [Required] public int PersonId { get; set; }
        [Range(0, int.MaxValue)]
        [Required] public int BankType { get; set; }
        [StringLength(50)] public string CardNumber { get; set; }
        [StringLength(50)]
        [Required] public string AccountNumber { get; set; }
        [StringLength(50)] public string ShabaNumber { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue)]
        [Required] public int AccessLevelId { get; set; }
    }





    public class PersonBankAccountSimpleViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }

        public string Title { get; set; }
    }

}
