			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilBaseInfo.Web.Areas.BaseInf.ViewModels
{

   public class CityListViewModel:IBaseViewModel
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
		
        public double? Latitude { get; set; }
		
        public double? Longitude { get; set; }
		
        public int? CustomCategory { get; set; }
				public string CustomCategoryTitle { get; set; }	
		
        public int CountryDivisionType { get; set; }
				public string CountryDivisionTypeTitle { get; set; }	
		
        public bool? ProvinceCenter { get; set; }
		
        public string Title { get; set; }
		
    }


	    public class CityEditModel:IBaseViewModel
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
				

        public double? Latitude { get; set; }
				

        public double? Longitude { get; set; }
				

        public int? CustomCategory { get; set; }
				public string CustomCategoryTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int CountryDivisionType { get; set; }
				public string CountryDivisionTypeTitle { get; set; }	
				

        public bool? ProvinceCenter { get; set; }
				
					[StringLength(600)]
										 [Required] 
				
        public string Title { get; set; }
				

        public string Description { get; set; }
				
    }

  



public class CitySimpleViewModel:IBaseViewModel
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
