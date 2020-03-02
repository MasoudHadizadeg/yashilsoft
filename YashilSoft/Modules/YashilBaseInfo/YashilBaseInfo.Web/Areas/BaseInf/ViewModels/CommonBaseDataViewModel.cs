			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilBaseInfo.Web.Areas.BaseInf.ViewModels
{

        public class CommonBaseDataListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Code { get; set; }
		
        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
		
        public string Title { get; set; }
		
        public int Value { get; set; }
		
        public string ExtendedProps { get; set; }
		
        public int CommonBaseTypeId { get; set; }
				public string CommonBaseTypeTitle { get; set; }	
		
        public string Description { get; set; }
		
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
		
        public bool IsSystemProp { get; set; }
		
    }


	    public class CommonBaseDataEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(300)]
					
        public string Code { get; set; }
				

        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
				
					[StringLength(600)]
										 [Required] 
				
        public string Title { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int Value { get; set; }
				

        public string ExtendedProps { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int CommonBaseTypeId { get; set; }
				public string CommonBaseTypeTitle { get; set; }	
				

        public string Description { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
				
					 [Required] 
				
        public bool IsSystemProp { get; set; }
				
    }

  



public class CommonBaseDataSimpleViewModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
        public int Id { get; set; }

			        public int ParentId { get; set; }

			        public string Title { get; set; }

			    }

}      
