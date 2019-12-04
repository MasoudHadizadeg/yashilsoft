			using System;

            namespace Yashil.Dashboard.Web.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
		
        public string UserName { get; set; }
		
        public string FirstName { get; set; }
		
        public string LastName { get; set; }
		
        public string NationalCode { get; set; }
		
        public string Email { get; set; }
		
        public byte[] Password { get; set; }
		
        public bool IsActive { get; set; }
		
        public int? MobileNumber { get; set; }
		
        public int OrganizationId { get; set; }
				public string OrganizationTitle { get; set; }	
		
        public int CreateTime { get; set; }
		
        public int CreateDate { get; set; }
		
        public byte[] PasswordSalt { get; set; }
		
        public string Address { get; set; }
		
        public int? CreateBy { get; set; }
		
        public int? ModifyBy { get; set; }
		
        public DateTime CreationDate { get; set; }
		
        public DateTime? ModificationDate { get; set; }
		
        public int? ApplicationId { get; set; }
				public string ApplicationTitle { get; set; }	
		
        public int AccessLevel { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


	    public class UserEditModel
    {
        public int Id { get; set; }
				
        public string UserName { get; set; }
				
        public string FirstName { get; set; }
				
        public string LastName { get; set; }
				
        public string NationalCode { get; set; }
				
        public string Email { get; set; }
				
        public byte[] Password { get; set; }
				
        public bool IsActive { get; set; }
				
        public int? MobileNumber { get; set; }
				
        public int OrganizationId { get; set; }
				public string OrganizationTitle { get; set; }	
				
        public int CreateTime { get; set; }
				
        public int CreateDate { get; set; }
				
        public byte[] PasswordSalt { get; set; }
				
        public string Address { get; set; }
				
        public int? CreateBy { get; set; }
				
        public int? ModifyBy { get; set; }
				
        public DateTime CreationDate { get; set; }
				
        public DateTime? ModificationDate { get; set; }
				
        public int? ApplicationId { get; set; }
				public string ApplicationTitle { get; set; }	
				
        public int AccessLevel { get; set; }
				public string AccessLevelTitle { get; set; }
        public string PasswordStr { get; set; }
    }

}      
