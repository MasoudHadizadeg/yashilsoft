			using System; 
using Yashil.Common.Core.Interfaces;
namespace YashilDashboard.Web.Areas.Dash.ViewModels
{

        public class DashboardConnectionStringListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
		
        public int ConnectionStringId { get; set; }
				public string ConnectionStringTitle { get; set; }	
		
    }


    public class DashboardConnectionStringViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
		
        public int ConnectionStringId { get; set; }
				public string ConnectionStringTitle { get; set; }	
		
    }


	    public class DashboardConnectionStringEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
        public int Id { get; set; }
				
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
				
        public int ConnectionStringId { get; set; }
				public string ConnectionStringTitle { get; set; }	
				
    }

  



public class DashboardConnectionStringSimpleViewModel:IBaseViewModel
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
