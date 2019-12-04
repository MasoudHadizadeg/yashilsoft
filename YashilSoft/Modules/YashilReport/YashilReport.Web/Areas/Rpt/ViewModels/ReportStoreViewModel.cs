			using System; 
using Yashil.Common.Core.Interfaces;
namespace YashilReport.Web.Areas.Rpt.ViewModels
{

        public class ReportStoreListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string CssClass { get; set; }
		
        public string Picture { get; set; }
		
        public string Color { get; set; }
		
        public bool? Animation { get; set; }
		
        public string Description { get; set; }
		
        public string ReportKey { get; set; }
		
        public string DesignString { get; set; }
		
        public string ModuleKey { get; set; }
		
        public int AccessLevel { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


    public class ReportStoreViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string CssClass { get; set; }
		
        public string Picture { get; set; }
		
        public string Color { get; set; }
		
        public bool? Animation { get; set; }
		
        public string Description { get; set; }
		
        public string ReportKey { get; set; }
		
        public string DesignString { get; set; }
		
        public string ModuleKey { get; set; }
		
        public int AccessLevel { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


	    public class ReportStoreEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
        public int Id { get; set; }
				
        public string Title { get; set; }
				
        public string CssClass { get; set; }
				
        public string Picture { get; set; }
				
        public string Color { get; set; }
				
        public bool? Animation { get; set; }
				
        public string Description { get; set; }
				
        public string ReportKey { get; set; }
				
        public string DesignString { get; set; }
				
        public string ModuleKey { get; set; }
				
        public int AccessLevel { get; set; }
				public string AccessLevelTitle { get; set; }	
				
    }

  



public class ReportStoreSimpleViewModel:IBaseViewModel
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
