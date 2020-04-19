			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilNews.Web.Areas.News.ViewModels
{

   public class NewsStoreListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
		public int? ParentId { get; set; }
        public int Id { get; set; }

        public string Code { get; set; }

        public string ServiceTitle { get; set; }

        public string NewsTypeTitle { get; set; }

        public string Deck { get; set; }

        public string Kicker { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Led { get; set; }

        public int? EffluenceTime { get; set; }

        public int? EffluenceDateInt { get; set; }

        public int? ViewCount { get; set; }

        public int? ExpireDateInt { get; set; }

        public int? ExpireTime { get; set; }

        public string LanguageTitle { get; set; }

        public bool IsOtherSiteNews { get; set; }

        public string NewsWebSiteCode { get; set; }

        public DateTime? ExpireDate { get; set; }

        public DateTime? EffluenceDate { get; set; }

        public bool Confirmed { get; set; }

        public string KeywordStr { get; set; }

        public Int64? OtherSiteNewsId { get; set; }

        public string AccessLevelTitle { get; set; }

    }


	    public class NewsStoreEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
				public int Id { get; set; }		
				[StringLength(300)]				public string Code { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int ServiceId { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int NewsType { get; set; }		
				[StringLength(1000)]				public string Deck { get; set; }		
				[StringLength(1000)]				public string Kicker { get; set; }		
				[StringLength(2000)] 
				[Required]				public string Title { get; set; }		
				[StringLength(4000)]				public string SubTitle { get; set; }		
				[StringLength(7800)] 
				[Required]				public string Led { get; set; }		
				public string Body { get; set; }		
				public int? EffluenceTime { get; set; }		
				public int? EffluenceDateInt { get; set; }		
				public int? ViewCount { get; set; }		
				public int? ExpireDateInt { get; set; }		
				public int? ExpireTime { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int Language { get; set; }		
				public bool IsOtherSiteNews { get; set; }		
				[StringLength(600)]				public string NewsWebSiteCode { get; set; }		
				public DateTime? ExpireDate { get; set; }		
				public DateTime? EffluenceDate { get; set; }		
				public bool Confirmed { get; set; }		
				[StringLength(600)]				public string KeywordStr { get; set; }		
				public Int64? OtherSiteNewsId { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int AccessLevelId { get; set; }		
}

  



public class NewsStoreSimpleViewModel:IBaseViewModel
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
