			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilNews.Web.Areas.News.ViewModels
{

   public class MainNewsListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
		public int? ParentId { get; set; }
        public int Id { get; set; }

        public string NewsStoreTitle { get; set; }

        public string NewsPropertyTitle { get; set; }

        public bool Simplenews { get; set; }

        public bool ShowInMainPageSlider { get; set; }

        public bool IsHotNews { get; set; }

        public bool SelectedNews { get; set; }

        public bool ServiceMainNews { get; set; }

        public bool ShowAsMultimedia { get; set; }

        public bool ShowAsImportantNews { get; set; }

        public bool EditorSelected { get; set; }

        public int DisplayOrder { get; set; }

    }


	    public class MainNewsEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
				public int Id { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int NewsStoreId { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int NewsPropertyId { get; set; }		
				public bool Simplenews { get; set; }		
				public bool ShowInMainPageSlider { get; set; }		
				public bool IsHotNews { get; set; }		
				public bool SelectedNews { get; set; }		
				public bool ServiceMainNews { get; set; }		
				public bool ShowAsMultimedia { get; set; }		
				public bool ShowAsImportantNews { get; set; }		
				public bool EditorSelected { get; set; }		
				[Range(0,int.MaxValue)] 
				[Required]				public int DisplayOrder { get; set; }		
}

  



public class MainNewsSimpleViewModel:IBaseViewModel
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
