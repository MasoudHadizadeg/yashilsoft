			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilTms.Web.Areas.Tms.ViewModels
{

   public class CourseCategoryListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
		
        public string Code { get; set; }
		
        public string Title { get; set; }
		
        public int EducationalCenterId { get; set; }
				public string EducationalCenterTitle { get; set; }	
		
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


	    public class CourseCategoryEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				

        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
				
					[StringLength(300)]
					
        public string Code { get; set; }
				
					[StringLength(600)]
										 [Required] 
				
        public string Title { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int EducationalCenterId { get; set; }
				public string EducationalCenterTitle { get; set; }	
				

        public string Description { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
				
    }

  



public class CourseCategorySimpleViewModel:IBaseViewModel
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
