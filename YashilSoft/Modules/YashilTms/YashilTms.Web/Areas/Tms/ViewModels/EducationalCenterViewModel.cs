			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilTms.Web.Areas.Tms.ViewModels
{

    public class EducationalCenterListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public int? EstablishedLicenseType { get; set; }

        public string AccessLevelTitle { get; set; }
        public string EstablishedLicenseTypeTitle { get; set; }
    }


    public class EducationalCenterEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
				public int Id { get; set; }		
				[StringLength(300)]				public string Code { get; set; }		
				[StringLength(600)] 
				[Required]				public string Title { get; set; }		
				[StringLength(600)]				public string Address { get; set; }		
				public int? EstablishedLicenseType { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int AccessLevelId { get; set; }		
}

  



public class EducationalCenterSimpleViewModel:IBaseViewModel
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
