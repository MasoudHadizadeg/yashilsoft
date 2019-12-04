			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class AppActionViewModel
    {
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public bool SystemAction { get; set; }
		
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
		
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
		
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
        public int? ApplicationId { get; set; }
				public string ApplicationTitle { get; set; }	
		
    }


	    public class AppActionEditModel
    {
        public int Id { get; set; }
				
        public string Title { get; set; }
				
        public string Description { get; set; }
				
        public bool SystemAction { get; set; }
				
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
				
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
				
        public DateTime CreationDate { get; set; }
				
        public DateTime? ModificationDate { get; set; }
				
        public int? ApplicationId { get; set; }
				public string ApplicationTitle { get; set; }	
				
    }

}      
