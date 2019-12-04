			using System; 
using Yashil.Common.Core.Interfaces;
namespace YashilDashboard.Web.Areas.Dash.ViewModels
{

        public class DashboardStoreListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Code { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public string CssClass { get; set; }
		
        public string Picture { get; set; }
		
        public string Color { get; set; }
		
        public bool? Animation { get; set; }
		
        public int AccessLevel { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


    public class DashboardStoreViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Code { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public byte[] DashboardFile { get; set; }
		
        public string CssClass { get; set; }
		
        public string Picture { get; set; }
		
        public string Color { get; set; }
		
        public bool? Animation { get; set; }
		
        public int AccessLevel { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


	    public class DashboardStoreEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
        public int Id { get; set; }
				
        public string Code { get; set; }
				
        public string Title { get; set; }
				
        public string Description { get; set; }
				
        public byte[] DashboardFile { get; set; }
				
        public string CssClass { get; set; }
				
        public string Picture { get; set; }
				
        public string Color { get; set; }
				
        public bool? Animation { get; set; }
				
        public int AccessLevel { get; set; }
				public string AccessLevelTitle { get; set; }	
				
    }

  



public class DashboardStoreSimpleViewModel:IBaseViewModel
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
