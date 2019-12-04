			using System; 
using Yashil.Common.Core.Interfaces;
namespace YashilBaseInfo.Web.Areas.BaseInf.ViewModels
{

        public class YashilConnectionStringListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Name { get; set; }
		
        public int DataProviderId { get; set; }
				public string DataProviderTitle { get; set; }	
		
        public string ConnectionString { get; set; }
		
        public string Description { get; set; }
		
        public bool IsActive { get; set; }
		
    }


    public class YashilConnectionStringViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public string Name { get; set; }
		
        public int DataProviderId { get; set; }
				public string DataProviderTitle { get; set; }	
		
        public string ConnectionString { get; set; }
		
        public string Description { get; set; }
		
        public bool IsActive { get; set; }
		
    }


	    public class YashilConnectionStringEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }
        public int Id { get; set; }
				
        public string Name { get; set; }
				
        public int DataProviderId { get; set; }
				public string DataProviderTitle { get; set; }	
				
        public string ConnectionString { get; set; }
				
        public string Description { get; set; }
				
        public bool IsActive { get; set; }
				
    }

  



public class YashilConnectionStringSimpleViewModel:IBaseViewModel
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
