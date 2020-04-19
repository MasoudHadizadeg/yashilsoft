			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilTms.Web.Areas.Tms.ViewModels
{

   public class RepresentationCourseCategoryListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
		public int? ParentId { get; set; }
        public int Id { get; set; }

        public string RepresentationTitle { get; set; }

        public string CourseCategoryTitle { get; set; }

        public string AccessLevelTitle { get; set; }

    }


	    public class RepresentationCourseCategoryEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
				public int Id { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int RepresentationId { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int CourseCategoryId { get; set; }		
				public string Description { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int AccessLevelId { get; set; }		
}

  



public class RepresentationCourseCategorySimpleViewModel:IBaseViewModel
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
