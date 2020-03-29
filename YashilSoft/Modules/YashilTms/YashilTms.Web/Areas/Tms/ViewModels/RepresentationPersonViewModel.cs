			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilTms.Web.Areas.Tms.ViewModels
{

   public class RepresentationPersonListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }

        public string Code { get; set; }

        public string RepresentationTitle { get; set; }

        public string PersonTitle { get; set; }

        public string PostTitle { get; set; }

        public string CooperationTypeTitle { get; set; }

        public int? FromDate { get; set; }

        public int? ToDate { get; set; }

        public string AccessLevelTitle { get; set; }

    }


	    public class RepresentationPersonEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
				public int Id { get; set; }		
				[StringLength(300)]				public string Code { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int RepresentationId { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int PersonId { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int PostId { get; set; }		
				public int? CooperationType { get; set; }		
				public int? FromDate { get; set; }		
				public int? ToDate { get; set; }		
				public string Description { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int AccessLevelId { get; set; }		
}

  



public class RepresentationPersonSimpleViewModel:IBaseViewModel
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
