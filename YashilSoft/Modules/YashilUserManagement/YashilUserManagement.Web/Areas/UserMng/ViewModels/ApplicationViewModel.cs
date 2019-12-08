			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{

        public class ApplicationListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public string Url { get; set; }
		
        public string AdditionalInfo { get; set; }
		
    }


    public class ApplicationViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public string Url { get; set; }
		
        public byte[] SecretKey { get; set; }
		
        public string AdditionalInfo { get; set; }
		
    }


	    public class ApplicationEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(400)]
					
        public string Title { get; set; }
				
					
					
        public string Description { get; set; }
				
					[StringLength(20)]
					
        public string Url { get; set; }
				

        public byte[] SecretKey { get; set; }
				
					
					
        public string AdditionalInfo { get; set; }
				
    }

  



public class ApplicationSimpleViewModel:IBaseViewModel
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
