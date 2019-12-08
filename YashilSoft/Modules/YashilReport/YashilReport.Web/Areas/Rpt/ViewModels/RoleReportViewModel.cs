			using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilReport.Web.Areas.Rpt.ViewModels
{

        public class RoleReportListViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
		
        public int ReportId { get; set; }
				public string ReportTitle { get; set; }	
		
    }


    public class RoleReportViewModel:IBaseViewModel
    {
		public int ViewModelId
	        {
	            get => Id;
	            set => Id = value;
	        }
        public int Id { get; set; }
		
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
		
        public int ReportId { get; set; }
				public string ReportTitle { get; set; }	
		
    }


	    public class RoleReportEditModel:IBaseViewModel
        {
	        public int ViewModelId
	            {
	                get => Id;
	                set => Id = value;
	            }

        public int Id { get; set; }
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int RoleId { get; set; }
				public string RoleTitle { get; set; }	
				
					[Range(0,int.MaxValue)]
										 [Required] 
				
        public int ReportId { get; set; }
				public string ReportTitle { get; set; }	
				
    }

  



public class RoleReportSimpleViewModel:IBaseViewModel
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
