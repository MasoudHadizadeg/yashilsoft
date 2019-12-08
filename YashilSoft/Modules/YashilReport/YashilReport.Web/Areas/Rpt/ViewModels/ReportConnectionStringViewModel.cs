			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilReport.Web.Areas.Rpt.ViewModels
{

        public class ReportConnectionStringListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int ReportId { get; set; }
				public string ReportTitle { get; set; }	
		
        public int ConnectionStringId { get; set; }
				public string ConnectionStringTitle { get; set; }	
		
    }


    public class ReportConnectionStringViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int ReportId { get; set; }
				public string ReportTitle { get; set; }	
		
        public int ConnectionStringId { get; set; }
				public string ConnectionStringTitle { get; set; }	
		
    }


	    public class ReportConnectionStringEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int ReportId { get; set; }
				public string ReportTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int ConnectionStringId { get; set; }
				public string ConnectionStringTitle { get; set; }	
				
    }

  



public class ReportConnectionStringSimpleViewModel:IBaseViewModel
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
