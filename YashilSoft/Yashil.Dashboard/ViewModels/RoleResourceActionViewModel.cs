			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class RoleResourceActionViewModel
    {
        public int Id { get; set; }
		
        public int ResourceActionId { get; set; }
				public string ResourceActionTitle { get; set; }	
		
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
		
        public int CreateBy { get; set; }
		
        public int? ModifyBy { get; set; }
		
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
    }


	    public class RoleResourceActionEditModel
    {
        public int Id { get; set; }
				
        public int ResourceActionId { get; set; }
				public string ResourceActionTitle { get; set; }	
				
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
				
        public int CreateBy { get; set; }
				
        public int? ModifyBy { get; set; }
				
        public DateTime CreationDate { get; set; }
				
        public DateTime? ModificationDate { get; set; }
				
    }

}      
