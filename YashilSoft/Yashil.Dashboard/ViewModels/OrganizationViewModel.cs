			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class OrganizationViewModel
    {
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public bool IsActive { get; set; }
		
        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
		
        public Int64? UniqueId { get; set; }
		
        public string CodePath { get; set; }
		
        public int? Type { get; set; }
		
        public int? ProvinceId { get; set; }
		
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
		
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
		
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
        public int? ApplicationId { get; set; }
				public string ApplicationTitle { get; set; }	
		
    }


	    public class OrganizationEditModel
    {
        public int Id { get; set; }
				
        public string Title { get; set; }
				
        public string Description { get; set; }
				
        public bool IsActive { get; set; }
				
        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
				
        public Int64? UniqueId { get; set; }
				
        public string CodePath { get; set; }
				
        public int? Type { get; set; }
				
        public int? ProvinceId { get; set; }
				
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
