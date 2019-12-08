			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{

        public class RoleResourceActionListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int ResourceActionId { get; set; }
				public string ResourceActionTitle { get; set; }	
		
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
		
    }


    public class RoleResourceActionViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int ResourceActionId { get; set; }
				public string ResourceActionTitle { get; set; }	
		
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
		
    }


	    public class RoleResourceActionEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int ResourceActionId { get; set; }
				public string ResourceActionTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
				
    }

  



public class RoleResourceActionSimpleViewModel:IBaseViewModel
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
