			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{

        public class ResourceAppActionListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int AppActionId { get; set; }
				public string AppActionTitle { get; set; }	
		
        public int ResourceId { get; set; }
				public string ResourceTitle { get; set; }	
		
    }


    public class ResourceAppActionViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int AppActionId { get; set; }
				public string AppActionTitle { get; set; }	
		
        public int ResourceId { get; set; }
				public string ResourceTitle { get; set; }	
		
    }


	    public class ResourceAppActionEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AppActionId { get; set; }
				public string AppActionTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int ResourceId { get; set; }
				public string ResourceTitle { get; set; }	
				
    }

  



public class ResourceAppActionSimpleViewModel:IBaseViewModel
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
