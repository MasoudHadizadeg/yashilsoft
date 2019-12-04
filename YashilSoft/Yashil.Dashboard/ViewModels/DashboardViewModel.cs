			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class DashboardViewModel
    {
        public int Id { get; set; }
		
        public string Code { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public byte[] DashboardFile { get; set; }
		
        public string CssClass { get; set; }
		
        public string Picture { get; set; }
		
        public string Color { get; set; }
		
        public bool? Animation { get; set; }
		
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
		
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
		
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
        public int? ApplicationId { get; set; }
				public string ApplicationTitle { get; set; }	
		
        public int AccessLevel { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


	    public class DashboardEditModel
    {
        public int Id { get; set; }
				
        public string Code { get; set; }
				
        public string Title { get; set; }
				
        public string Description { get; set; }
				
        public byte[] DashboardFile { get; set; }
				
        public string CssClass { get; set; }
				
        public string Picture { get; set; }
				
        public string Color { get; set; }
				
        public bool? Animation { get; set; }
				
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
				
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
				
        public DateTime CreationDate { get; set; }
				
        public DateTime? ModificationDate { get; set; }
				
        public int? ApplicationId { get; set; }
				public string ApplicationTitle { get; set; }	
				
        public int AccessLevel { get; set; }
				public string AccessLevelTitle { get; set; }	
				
    }

}      
