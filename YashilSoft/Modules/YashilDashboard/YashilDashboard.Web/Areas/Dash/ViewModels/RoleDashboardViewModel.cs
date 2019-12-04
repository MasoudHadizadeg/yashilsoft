			using System; 
using Yashil.Common.Core.Interfaces;
namespace YashilDashboard.Web.Areas.Dash.ViewModels
{

        public class RoleDashboardListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
		
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
		
    }


    public class RoleDashboardViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
		
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
		
    }


	    public class RoleDashboardEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
        public int Id { get; set; }
				
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
				
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
				
    }

  



public class RoleDashboardSimpleViewModel:IBaseViewModel
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
