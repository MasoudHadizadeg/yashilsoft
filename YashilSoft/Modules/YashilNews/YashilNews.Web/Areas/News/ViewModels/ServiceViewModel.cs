			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilNews.Web.Areas.News.ViewModels
{

   public class ServiceListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
		public int? ParentId { get; set; }
        public int Id { get; set; }

        public string ParentTitle { get; set; }

        public string Title { get; set; }

        public string AppEntityTitle { get; set; }

        public Int64? ObjectId { get; set; }

        public bool IsMain { get; set; }

        public string EnglishTitle { get; set; }

        public bool? ShowInMainPage { get; set; }

        public int DisplayOrder { get; set; }

        public string AccessLevelTitle { get; set; }

    }


	    public class ServiceEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
				public int Id { get; set; }		
				public int? ParentId { get; set; }		
				[StringLength(600)] 
				[Required]				public string Title { get; set; }		
				public string Description { get; set; }		
				public int? AppEntityId { get; set; }		
				public Int64? ObjectId { get; set; }		
				public bool IsMain { get; set; }		
				[StringLength(1000)] 
				[Required]				public string EnglishTitle { get; set; }		
				public bool? ShowInMainPage { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int DisplayOrder { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int AccessLevelId { get; set; }		
}

  



public class ServiceSimpleViewModel:IBaseViewModel
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
