			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{

        public class ResourceListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public int? Type { get; set; }
		
    }


    public class ResourceViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public int? Type { get; set; }
		
    }


	    public class ResourceEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(300)]
										 [Required] 
				
        public string Title { get; set; }
				
					
										 [Required] 
				
        public string Description { get; set; }
				

        public int? Type { get; set; }
				
    }

  



public class ResourceSimpleViewModel:IBaseViewModel
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
