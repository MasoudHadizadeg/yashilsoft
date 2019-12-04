			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class UserDashboardViewModel
    {
        public int Id { get; set; }
		
        public int UserId { get; set; }
		
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
		
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
		
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
        
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
        public int? ApplicationId { get; set; }
		
    }


	    public class UserDashboardEditModel
    {
        public int Id { get; set; }
				
        public int UserId { get; set; }
				
        public int DashboardId { get; set; }
				public string DashboardTitle { get; set; }	
				
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
				
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }

        public DateTime CreationDate { get; set; }
				
        public DateTime? ModificationDate { get; set; }
				
        public int? ApplicationId { get; set; }
				
    }

}      
