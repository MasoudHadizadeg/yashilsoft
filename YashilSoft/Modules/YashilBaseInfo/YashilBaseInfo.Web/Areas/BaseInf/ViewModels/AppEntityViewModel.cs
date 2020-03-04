			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilBaseInfo.Web.Areas.BaseInf.ViewModels
{

   public class AppEntityListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public bool GenerateTabForDescColumn { get; set; }
		
        public bool HasAttachmenet { get; set; }
		
        public int? SystemId { get; set; }
		
        public string TitlePropertyName { get; set; }
		
        public bool? IsLarge { get; set; }
		
        public bool IsVirtualEntity { get; set; }
		
        public string PersianTitle { get; set; }
		
        public string EnglishTitle { get; set; }
		
        public string ApplicationBased { get; set; }
		
    }


	    public class AppEntityEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(600)]
										 [Required] 
				
        public string Title { get; set; }
				
					 [Required] 
				
        public bool GenerateTabForDescColumn { get; set; }
				
					 [Required] 
				
        public bool HasAttachmenet { get; set; }
				

        public int? SystemId { get; set; }
				
					[StringLength(600)]
					
        public string TitlePropertyName { get; set; }
				

        public bool? IsLarge { get; set; }
				
					 [Required] 
				
        public bool IsVirtualEntity { get; set; }
				

        public string Description { get; set; }
				

        public string Props { get; set; }
				
					[StringLength(600)]
					
        public string PersianTitle { get; set; }
				
					[StringLength(600)]
					
        public string EnglishTitle { get; set; }
				
					[StringLength(20)]
					
        public string ApplicationBased { get; set; }
				
    }

  



public class AppEntitySimpleViewModel:IBaseViewModel
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
