			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class ResourceActionViewModel
    {
        public int Id { get; set; }
		
        public int ActionId { get; set; }
				public string ActionTitle { get; set; }	
		
        public int ResourceId { get; set; }
				public string ResourceTitle { get; set; }	
		
        public int CreateBy { get; set; }
		
        public int? ModifyBy { get; set; }
		
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
    }


	    public class ResourceActionEditModel
    {
        public int Id { get; set; }
				
        public int ActionId { get; set; }
				public string ActionTitle { get; set; }	
				
        public int ResourceId { get; set; }
				public string ResourceTitle { get; set; }	
				
        public int CreateBy { get; set; }
				
        public int? ModifyBy { get; set; }
				
        public DateTime CreationDate { get; set; }
				
        public DateTime? ModificationDate { get; set; }
				
    }

}      
