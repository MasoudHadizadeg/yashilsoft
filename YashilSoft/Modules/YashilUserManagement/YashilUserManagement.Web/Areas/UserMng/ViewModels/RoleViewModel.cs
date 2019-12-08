			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{

        public class RoleListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public bool IsActive { get; set; }
		
    }


    public class RoleViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public bool IsActive { get; set; }
		
    }


	    public class RoleEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(100)]
										 [Required] 
				
        public string Title { get; set; }
				
					
					
        public string Description { get; set; }
				
					 [Required] 
				
        public bool IsActive { get; set; }
				
    }

  



public class RoleSimpleViewModel:IBaseViewModel
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
