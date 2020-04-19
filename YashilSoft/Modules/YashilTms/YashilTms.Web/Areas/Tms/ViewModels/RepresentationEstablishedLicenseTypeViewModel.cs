			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilTms.Web.Areas.Tms.ViewModels
{

   public class RepresentationEstablishedLicenseTypeListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
		public int? ParentId { get; set; }
        public int Id { get; set; }

        public string RepresentationTitle { get; set; }

        public string EstablishedLicenseTypeTitle { get; set; }

        public string AccessLevelTitle { get; set; }

    }


	    public class RepresentationEstablishedLicenseTypeEditModel:IBaseViewModel
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
				[Required]				public int EstablishedLicenseType { get; set; }		
				public string Description { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int AccessLevelId { get; set; }		
}

  



public class RepresentationEstablishedLicenseTypeSimpleViewModel:IBaseViewModel
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
