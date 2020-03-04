			using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilBaseInfo.Web.Areas.BaseInf.ViewModels
{

   public class AppEntityAttributeMappingListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Code { get; set; }
		
        public int AppEntityId { get; set; }
				public string AppEntityTitle { get; set; }	
		
        public int AppEntityAttributeId { get; set; }
				public string AppEntityAttributeTitle { get; set; }	
		
        public bool IsRequired { get; set; }
		
        public int AttributeControlType { get; set; }
				public string AttributeControlTypeTitle { get; set; }	
		
        public int? DisplayOrder { get; set; }
		
        public int? ValidationMinLength { get; set; }
		
        public int? ValidationMaxLength { get; set; }
		
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
		
    }


	    public class AppEntityAttributeMappingEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[StringLength(300)]
					
        public string Code { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AppEntityId { get; set; }
				public string AppEntityTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AppEntityAttributeId { get; set; }
				public string AppEntityAttributeTitle { get; set; }	
				
					 [Required] 
				
        public bool IsRequired { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AttributeControlType { get; set; }
				public string AttributeControlTypeTitle { get; set; }	
				

        public int? DisplayOrder { get; set; }
				

        public int? ValidationMinLength { get; set; }
				

        public int? ValidationMaxLength { get; set; }
				

        public string DefaultValue { get; set; }
				

        public string AllowedValues { get; set; }
				

        public string Description { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int AccessLevelId { get; set; }
				public string AccessLevelTitle { get; set; }	
				
    }

  



public class AppEntityAttributeMappingSimpleViewModel:IBaseViewModel
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
