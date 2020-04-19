using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class MainNews :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public int Id { get; set; }
        public int NewsStoreId { get; set; }
        public int NewsPropertyId { get; set; }
        public bool Simplenews { get; set; }
        public bool ShowInMainPageSlider { get; set; }
        public bool IsHotNews { get; set; }
        public bool SelectedNews { get; set; }
        public bool ServiceMainNews { get; set; }
        public bool ShowAsMultimedia { get; set; }
        public bool ShowAsImportantNews { get; set; }
        public bool EditorSelected { get; set; }
        public int DisplayOrder { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual CommonBaseData NewsProperty { get; set; }
        public virtual NewsStore NewsStore { get; set; }
    }
    }
