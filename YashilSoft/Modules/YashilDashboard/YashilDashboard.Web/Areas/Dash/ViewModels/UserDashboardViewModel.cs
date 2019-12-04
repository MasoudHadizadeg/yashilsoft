			using System; 
using Yashil.Common.Core.Interfaces;
namespace YashilDashboard.Web.Areas.Dash.ViewModels
{

        public class UserDashboardListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int UserId { get; set; }
				public string UserTitle { get; set; }	
		
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
		
    }


    public class UserDashboardViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int UserId { get; set; }
				public string UserTitle { get; set; }	
		
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
		
    }


	    public class UserDashboardEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
        public int Id { get; set; }
				
        public int UserId { get; set; }
				public string UserTitle { get; set; }	
				
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
				
    }

  



public class UserDashboardSimpleViewModel:IBaseViewModel
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
