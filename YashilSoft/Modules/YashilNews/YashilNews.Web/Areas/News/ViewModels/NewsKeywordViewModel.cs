			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilNews.Web.Areas.News.ViewModels
{

   public class NewsKeywordListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
		public int? ParentId { get; set; }
        public int Id { get; set; }

        public string Title { get; set; }

        public string NewsStoreTitle { get; set; }

        public string KeywordTitle { get; set; }

        public string AccessLevelTitle { get; set; }

    }


	    public class NewsKeywordEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
				public int Id { get; set; }		
				[StringLength(600)] 
				[Required]				public string Title { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int NewsStoreId { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int KeywordId { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int AccessLevelId { get; set; }		
}

  



public class NewsKeywordSimpleViewModel:IBaseViewModel
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
