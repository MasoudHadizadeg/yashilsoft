			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilDms.Web.Areas.Dms.ViewModels
{

        public class AppDocumentListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int DocTypeId { get; set; }
				public string DocTypeTitle { get; set; }	
		
        public string Title { get; set; }
		
        public string OrginalName { get; set; }
		
        public int DocumentCategoryId { get; set; }
				public string DocumentCategoryTitle { get; set; }	
		
        public Int64 ObjectId { get; set; }
		
        public string ShortDescription { get; set; }
		
        public int? DisplayOrder { get; set; }
		
        public string Description { get; set; }
		
    }


	    public class AppDocumentEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int DocTypeId { get; set; }
				public string DocTypeTitle { get; set; }	
				
					[StringLength(600)]
					
        public string Title { get; set; }
				
					[StringLength(400)]
					
        public string OrginalName { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int DocumentCategoryId { get; set; }
				public string DocumentCategoryTitle { get; set; }	
				
					 [Required] 
				
        public Int64 ObjectId { get; set; }
				

        public byte[] DocumentFile { get; set; }
				

        public string ShortDescription { get; set; }
				

        public int? DisplayOrder { get; set; }
				

        public string Description { get; set; }
				
    }

  



public class AppDocumentSimpleViewModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
        public int Id { get; set; }

			        public string Title { get; set; }

			    }

}      
