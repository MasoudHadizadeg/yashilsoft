			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public string Url { get; set; }
		
        public byte[] SecretKey { get; set; }
		
        public string AdditionalInfo { get; set; }
		
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
		
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
		
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
    }


	    public class ApplicationEditModel
    {
        public int Id { get; set; }
				
        public string Title { get; set; }
				
        public string Description { get; set; }
				
        public string Url { get; set; }
				
        public byte[] SecretKey { get; set; }
				
        public string AdditionalInfo { get; set; }
				
        public int CreateBy { get; set; }
				public string CreateByTitle { get; set; }	
				
        public int? ModifyBy { get; set; }
				public string ModifyByTitle { get; set; }	
				
        public DateTime CreationDate { get; set; }
				
        public DateTime? ModificationDate { get; set; }
				
    }

}      
