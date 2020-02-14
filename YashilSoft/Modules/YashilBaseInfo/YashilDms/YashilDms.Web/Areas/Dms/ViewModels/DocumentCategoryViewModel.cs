			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilDms.Web.Areas.Dms.ViewModels
{

        public class DocumentCategoryListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
		
        public int AppEntityId { get; set; }
				public string AppEntityTitle { get; set; }	
		
        public Int64 ObjectId { get; set; }
		
        public int? DisplayOrder { get; set; }
		
        public string Description { get; set; }
		
        public bool IsActive { get; set; }
		
        public int CreatorOrganizationId { get; set; }
		
    }


    public class DocumentCategoryViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
		
        public int AppEntityId { get; set; }
				public string AppEntityTitle { get; set; }	
		
        public Int64 ObjectId { get; set; }
		
        public int? DisplayOrder { get; set; }
		
        public string Description { get; set; }
		
        public bool IsActive { get; set; }
		
        public int CreatorOrganizationId { get; set; }
		
    }


	    public class DocumentCategoryEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(100)]
										 [Required] 
				
        public string Title { get; set; }
				

        public int? ParentId { get; set; }
				public string ParentTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AppEntityId { get; set; }
				public string AppEntityTitle { get; set; }	
				
					 [Required] 
				
        public Int64 ObjectId { get; set; }
				

        public int? DisplayOrder { get; set; }
				

        public string Description { get; set; }
				
					 [Required] 
				
        public bool IsActive { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int CreatorOrganizationId { get; set; }
				
    }

  



public class DocumentCategorySimpleViewModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
        public int Id { get; set; }

			        public string Title { get; set; }

			        public int ParentId { get; set; }

			    }

}      
