using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class City :IBaseEntity<int> 
    {
        public City()
        {
            InverseParent = new HashSet<City>();
            Representation = new HashSet<Representation>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int? ParentId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? CustomCategory { get; set; }
        public int CountryDivisionType { get; set; }
        public bool? ProvinceCenter { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }

        public virtual CommonBaseData CountryDivisionTypeNavigation { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual CommonBaseData CustomCategoryNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual City Parent { get; set; }
        public virtual ICollection<City> InverseParent { get; set; }
        public virtual ICollection<Representation> Representation { get; set; }
    }
    }
