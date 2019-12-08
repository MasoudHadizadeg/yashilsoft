			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilDashboard.Web.Areas.Dash.ViewModels
{

        public class DashboardGroupDashboardListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int DashboardStoreId { get; set; }
				public string DashboardStoreTitle { get; set; }	
		
        public int DashboardGroupId { get; set; }
				public string DashboardGroupTitle { get; set; }	
		
    }


    public class DashboardGroupDashboardViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int DashboardStoreId { get; set; }
				public string DashboardStoreTitle { get; set; }	
		
        public int DashboardGroupId { get; set; }
				public string DashboardGroupTitle { get; set; }	
		
    }


	    public class DashboardGroupDashboardEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int DashboardStoreId { get; set; }
				public string DashboardStoreTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int DashboardGroupId { get; set; }
				public string DashboardGroupTitle { get; set; }	
				
    }

  



public class DashboardGroupDashboardSimpleViewModel:IBaseViewModel
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
