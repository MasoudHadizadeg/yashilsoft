			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilBaseInfo.Web.Areas.BaseInf.ViewModels
{

   public class AppEntityAttributeValueListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Code { get; set; }
		
        public int AppEntityAttributeMappingId { get; set; }
				public string AppEntityAttributeMappingTitle { get; set; }	
		
        public int ObjectId { get; set; }
		
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


	    public class AppEntityAttributeValueEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(300)]
					
        public string Code { get; set; }
				
					 [Required] 
				
        public string Value { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AppEntityAttributeMappingId { get; set; }
				public string AppEntityAttributeMappingTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int ObjectId { get; set; }
				

        public string Description { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
				
    }

  



public class AppEntityAttributeValueSimpleViewModel:IBaseViewModel
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
