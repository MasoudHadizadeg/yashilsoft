			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class ResourceAppActionViewModel
    {
        public int Id { get; set; }
		
        public int AppActionId { get; set; }
				public string AppActionTitle { get; set; }	
		
        public int ResourceId { get; set; }
				public string ResourceTitle { get; set; }	
		
        public int CreateBy { get; set; }
		
        public int? ModifyBy { get; set; }
		
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
    }


	    public class ResourceAppActionEditModel
    {
        public int Id { get; set; }
				
        public int AppActionId { get; set; }
				public string AppActionTitle { get; set; }	
				
        public int ResourceId { get; set; }
				public string ResourceTitle { get; set; }	
				
        public int CreateBy { get; set; }
				
        public int? ModifyBy { get; set; }
				
        public DateTime CreationDate { get; set; }
				
        public DateTime? ModificationDate { get; set; }
				
    }

}      
