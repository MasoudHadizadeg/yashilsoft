			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilBaseInfo.Web.Areas.BaseInf.ViewModels
{

        public class YashilConnectionStringListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public int DataProviderId { get; set; }
				public string DataProviderTitle { get; set; }	
		
        public string ConnectionString { get; set; }
		
        public string Description { get; set; }
		
        public bool IsActive { get; set; }
		
        public int AccessLevelId { get; set; }
		
    }


    public class YashilConnectionStringViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public int DataProviderId { get; set; }
				public string DataProviderTitle { get; set; }	
		
        public string ConnectionString { get; set; }
		
        public string Description { get; set; }
		
        public bool IsActive { get; set; }
		
        public int AccessLevelId { get; set; }
		
    }


	    public class YashilConnectionStringEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(200)]
										 [Required] 
				
        public string Title { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int DataProviderId { get; set; }
				public string DataProviderTitle { get; set; }	
				
					[StringLength(500)]
										 [Required] 
				
        public string ConnectionString { get; set; }
				
					
					
        public string Description { get; set; }
				
					 [Required] 
				
        public bool IsActive { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AccessLevelId { get; set; }
				
    }

  



public class YashilConnectionStringSimpleViewModel:IBaseViewModel
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
