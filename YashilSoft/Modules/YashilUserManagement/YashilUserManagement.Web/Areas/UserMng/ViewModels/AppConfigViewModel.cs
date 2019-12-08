			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{

        public class AppConfigListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string KeyTitle { get; set; }
		
        public string Value { get; set; }
		
        public string Description { get; set; }
		
    }


    public class AppConfigViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string KeyTitle { get; set; }
		
        public string Value { get; set; }
		
        public string Description { get; set; }
		
    }


	    public class AppConfigEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(300)]
										 [Required] 
				
        public string KeyTitle { get; set; }
				
					[StringLength(300)]
										 [Required] 
				
        public string Value { get; set; }
				
					
					
        public string Description { get; set; }
				
    }

  



public class AppConfigSimpleViewModel:IBaseViewModel
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
