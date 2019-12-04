			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class UserRoleViewModel
    {
        public int Id { get; set; }
		
        public int UserId { get; set; }
				public string UserTitle { get; set; }	
		
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
		
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
		
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
		
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
    }


	    public class UserRoleEditModel
    {
        public int Id { get; set; }
				
        public int UserId { get; set; }
				public string UserTitle { get; set; }	
				
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
				
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
				
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
				
        public DateTime CreationDate { get; set; }
				
        public DateTime? ModificationDate { get; set; }
				
    }

}      
