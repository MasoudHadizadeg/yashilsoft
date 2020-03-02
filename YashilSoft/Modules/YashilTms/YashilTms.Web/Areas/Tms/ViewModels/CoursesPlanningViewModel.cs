			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilTms.Web.Areas.Tms.ViewModels
{

   public class CoursesPlanningListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Code { get; set; }
		
        public int RepresentationId { get; set; }
				public string RepresentationTitle { get; set; }	
		
        public bool Organizational { get; set; }
		
        public int CourceStatus { get; set; }
				public string CourceStatusTitle { get; set; }	
		
        public int? RepresentationPerson { get; set; }
		
        public int? Price { get; set; }
		
        public int CourseId { get; set; }
				public string CourseTitle { get; set; }	
		
        public int? AgeCategory { get; set; }
		
        public int ImplementaionType { get; set; }
				public string ImplementaionTypeTitle { get; set; }	
		
        public int CourceType { get; set; }
				public string CourceTypeTitle { get; set; }	
		
        public int RunType { get; set; }
		
        public int StartDate { get; set; }
		
        public int CustomGender { get; set; }
				public string CustomGenderTitle { get; set; }	
		
        public int MaxCapacity { get; set; }
		
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


	    public class CoursesPlanningEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(300)]
					
        public string Code { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int RepresentationId { get; set; }
				public string RepresentationTitle { get; set; }	
				
					 [Required] 
				
        public bool Organizational { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int CourceStatus { get; set; }
				public string CourceStatusTitle { get; set; }	
				

        public int? RepresentationPerson { get; set; }
				

        public int? Price { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int CourseId { get; set; }
				public string CourseTitle { get; set; }	
				

        public int? AgeCategory { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int ImplementaionType { get; set; }
				public string ImplementaionTypeTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int CourceType { get; set; }
				public string CourceTypeTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int RunType { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int StartDate { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int CustomGender { get; set; }
				public string CustomGenderTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int MaxCapacity { get; set; }
				

        public string Description { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
				
    }

  



public class CoursesPlanningSimpleViewModel:IBaseViewModel
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
