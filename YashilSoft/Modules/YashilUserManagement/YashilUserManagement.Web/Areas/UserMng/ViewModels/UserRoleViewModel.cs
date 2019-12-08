			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{

        public class UserRoleListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int UserId { get; set; }
				public string UserTitle { get; set; }	
		
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
		
    }


    public class UserRoleViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int UserId { get; set; }
				public string UserTitle { get; set; }	
		
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
		
    }


	    public class UserRoleEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int UserId { get; set; }
				public string UserTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
				
    }

  



public class UserRoleSimpleViewModel:IBaseViewModel
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
