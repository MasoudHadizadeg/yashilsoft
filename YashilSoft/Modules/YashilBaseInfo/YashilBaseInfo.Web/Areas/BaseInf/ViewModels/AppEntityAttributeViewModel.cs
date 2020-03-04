			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilBaseInfo.Web.Areas.BaseInf.ViewModels
{

   public class AppEntityAttributeListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Code { get; set; }
		
        public string Title { get; set; }
		
        public bool IsSystemProp { get; set; }
		
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


	    public class AppEntityAttributeEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(300)]
					
        public string Code { get; set; }
				
					[StringLength(600)]
										 [Required] 
				
        public string Title { get; set; }
				

        public string AllowedValues { get; set; }
				

        public string Description { get; set; }
				
					 [Required] 
				
        public bool IsSystemProp { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
				
    }

  



public class AppEntityAttributeSimpleViewModel:IBaseViewModel
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
