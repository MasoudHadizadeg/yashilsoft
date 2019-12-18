using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

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

        public int? MobileNumber { get; set; }

        public int? OrganizationId { get; set; }
        public string OrganizationTitle { get; set; }

        public string Address { get; set; }

        public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
    }


    public class UserViewModel : IBaseViewModel
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

        public byte[] Password { get; set; }

        public bool IsActive { get; set; }

        public int? MobileNumber { get; set; }

        public int? OrganizationId { get; set; }
        public string OrganizationTitle { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Address { get; set; }

        public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
    }


    public class UserEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        [StringLength(400)] [Required] public string UserName { get; set; }

        [StringLength(1000)] [Required] public string FirstName { get; set; }

        [StringLength(20)] [Required] public string LastName { get; set; }

        [StringLength(20)] public string NationalCode { get; set; }

        [StringLength(600)] public string Email { get; set; }


        public byte[] Password { get; set; }

        [Required] public bool IsActive { get; set; }


        public int? MobileNumber { get; set; }


        public int? OrganizationId { get; set; }
        public string OrganizationTitle { get; set; }


        public byte[] PasswordSalt { get; set; }


        public string Address { get; set; }

        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
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