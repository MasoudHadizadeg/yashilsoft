using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.CustomViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{
    public class UserListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalCode { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string MobileNumber { get; set; }

        public string OrganizationTitle { get; set; }

        public string Address { get; set; }

        public string AccessLevelTitle { get; set; }
    }

    public class UserEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public List<object> AdditionalInfoList { get; set; }
        public int Id { get; set; }

        [Required] [StringLength(200)] public string UserName { get; set; }
        [Required] [StringLength(200)] public string FirstName { get; set; }
        [Required] [StringLength(400)] public string LastName { get; set; }
        [StringLength(10)] public string NationalCode { get; set; }
        [StringLength(300)] public string Email { get; set; }
        public bool? IsActive { get; set; }
        [StringLength(20)] public string MobileNumber { get; set; }
        public int OrganizationId { get; set; }
        public string Address { get; set; }
        public int AccessLevelId { get; set; }
        public string PasswordStr { get; set; }
    }

    public class UserSimpleViewModel : IBaseViewModel
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