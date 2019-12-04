			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; }
				public string Title { get; set; }	
		
        public string Path { get; set; }

        public string Icon { get; set; }
		
        public string Class { get; set; }
		
        public string Badge { get; set; }
		
        public string BadgeClass { get; set; }
		
        public bool? IsExternalLink { get; set; }
		
        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
		
        public int? ResourceId { get; set; }
				public string ResourceTitle { get; set; }	
		
        public bool IsVirtual { get; set; }
		
        public int? OrderNo { get; set; }
		
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
		
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
		
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
        public int? ApplicationId { get; set; }
				public string ApplicationTitle { get; set; }	
		
    }


	    public class MenuEditModel
    {
        public int Id { get; set; }
				public string Title { get; set; }	
				
        public string Path { get; set; }

        public string Icon { get; set; }
				
        public string Class { get; set; }
				
        public string Badge { get; set; }
				
        public string BadgeClass { get; set; }
				
        public bool? IsExternalLink { get; set; }
				
        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
				
        public int? ResourceId { get; set; }
				public string ResourceTitle { get; set; }	
				
        public bool IsVirtual { get; set; }
				
        public int? OrderNo { get; set; }
				
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
