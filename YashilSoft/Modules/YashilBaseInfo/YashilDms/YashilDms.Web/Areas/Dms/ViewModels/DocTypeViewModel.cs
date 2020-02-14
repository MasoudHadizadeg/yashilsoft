			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilDms.Web.Areas.Dms.ViewModels
{

        public class DocTypeListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public int AppEntityId { get; set; }
				public string AppEntityTitle { get; set; }	
		
        public int? DisplayOrder { get; set; }
		
        public bool? SaveToDisk { get; set; }
		
        public int MaxSize { get; set; }
		
        public int MaxCount { get; set; }
		
        public int DocFormatId { get; set; }
				public string DocFormatTitle { get; set; }	
		
        public bool IsImage { get; set; }
		
        public bool CropImage { get; set; }
		
        public double AspectRatio { get; set; }
		
        public bool IsTitleRequired { get; set; }
		
        public bool IsCetegorized { get; set; }
		
        public int CreatorOrganizationId { get; set; }
		
    }


    public class DocTypeViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Title { get; set; }
		
        public string Description { get; set; }
		
        public int AppEntityId { get; set; }
				public string AppEntityTitle { get; set; }	
		
        public int? DisplayOrder { get; set; }
		
        public bool? SaveToDisk { get; set; }
		
        public int MaxSize { get; set; }
		
        public int MaxCount { get; set; }
		
        public int DocFormatId { get; set; }
				public string DocFormatTitle { get; set; }	
		
        public bool IsImage { get; set; }
		
        public bool CropImage { get; set; }
		
        public double AspectRatio { get; set; }
		
        public bool IsTitleRequired { get; set; }
		
        public bool IsCetegorized { get; set; }
		
        public int CreatorOrganizationId { get; set; }
		
    }


	    public class DocTypeEditModel:IBaseViewModel
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
				

        public string Description { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AppEntityId { get; set; }
				public string AppEntityTitle { get; set; }	
				

        public int? DisplayOrder { get; set; }
				

        public bool? SaveToDisk { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int MaxSize { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int MaxCount { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int DocFormatId { get; set; }
				public string DocFormatTitle { get; set; }	
				
					 [Required] 
				
        public bool IsImage { get; set; }
				
					 [Required] 
				
        public bool CropImage { get; set; }
				
					 [Required] 
				
        public double AspectRatio { get; set; }
				
					 [Required] 
				
        public bool IsTitleRequired { get; set; }
				
					 [Required] 
				
        public bool IsCetegorized { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int CreatorOrganizationId { get; set; }
				
    }

  



public class DocTypeSimpleViewModel:IBaseViewModel
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
