using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Yashil.Core.Entities;
namespace Yashil.Infrastructure.Data
{
    public partial class YashilAppDbContext : DbContext
    {
        public virtual DbSet<AccessLevel> AccessLevel { get; set; }
        public virtual DbSet<AppAction> AppAction { get; set; }
        public virtual DbSet<AppConfig> AppConfig { get; set; }
        public virtual DbSet<AppDocument> AppDocument { get; set; }
        public virtual DbSet<AppEntity> AppEntity { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<DashboardConnectionString> DashboardConnectionString { get; set; }
        public virtual DbSet<DashboardGroup> DashboardGroup { get; set; }
        public virtual DbSet<DashboardGroupDashboard> DashboardGroupDashboard { get; set; }
        public virtual DbSet<DashboardStore> DashboardStore { get; set; }
        public virtual DbSet<DocFormat> DocFormat { get; set; }
        public virtual DbSet<DocType> DocType { get; set; }
        public virtual DbSet<DocumentCategory> DocumentCategory { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<ReportConnectionString> ReportConnectionString { get; set; }
        public virtual DbSet<ReportGroup> ReportGroup { get; set; }
        public virtual DbSet<ReportGroupReport> ReportGroupReport { get; set; }
        public virtual DbSet<ReportStore> ReportStore { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<ResourceAppAction> ResourceAppAction { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleDashboard> RoleDashboard { get; set; }
        public virtual DbSet<RoleReport> RoleReport { get; set; }
        public virtual DbSet<RoleResourceAction> RoleResourceAction { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserDashboard> UserDashboard { get; set; }
        public virtual DbSet<UserReport> UserReport { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<YashilConnectionString> YashilConnectionString { get; set; }
        public virtual DbSet<YashilDataProvider> YashilDataProvider { get; set; }

        public YashilAppDbContext(DbContextOptions<YashilAppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=YashilDb;Persist Security Info=True;User ID=sa;Password=salam
;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLevel>(entity =>
            {
                entity.ToTable("AccessLevel", "base");

                entity.HasComment("سطح دسترسی");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیح");

                entity.Property(e => e.LevelValue).HasComment("مقدار سطح دسترسی");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasComment("عنوان");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.AccessLevelCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccessLevel_User");

                entity.HasOne(d => d.CreatorOrganization)
                    .WithMany(p => p.AccessLevel)
                    .HasForeignKey(d => d.CreatorOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccessLevel_Organization");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.AccessLevelModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_AccessLevel_User1");
            });

            modelBuilder.Entity<AppAction>(entity =>
            {
                entity.ToTable("AppAction", "um");

                entity.HasComment("عملیات");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasComment("عنوان");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AppAction)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_Action_Application");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.AppActionCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Action_User");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.AppActionModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_Action_User1");
            });

            modelBuilder.Entity<AppConfig>(entity =>
            {
                entity.ToTable("AppConfig", "um");

                entity.HasComment("تنظیمات");

                entity.HasIndex(e => new { e.ApplicationId, e.KeyTitle })
                    .HasName("IX_AppConfig");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.KeyTitle)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasComment("عنوان");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasComment("مقدار");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AppConfig)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppConfig_Application");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.AppConfigCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppConfig_User");

                entity.HasOne(d => d.CreatorOrganization)
                    .WithMany(p => p.AppConfig)
                    .HasForeignKey(d => d.CreatorOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppConfig_Organization");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.AppConfigModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_AppConfig_User1");
            });

            modelBuilder.Entity<AppDocument>(entity =>
            {
                entity.ToTable("AppDocument", "dms");

                entity.HasComment("اسناد");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.CreatorOrganizationId).HasComment("سازمان ایجاد کننده");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیح کامل");

                entity.Property(e => e.DisplayOrder).HasComment("ترتیب نمایش");

                entity.Property(e => e.DocTypeId).HasComment("نوع سند");

                entity.Property(e => e.DocumentCategoryId).HasComment("گروه سند");

                entity.Property(e => e.DocumentFile).HasComment("سند");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ObjectId).HasComment("کد مالک سند");

                entity.Property(e => e.OrginalName)
                    .HasMaxLength(200)
                    .HasComment("نام واقعی سند");

                entity.Property(e => e.ShortDescription).HasComment("توضیح کوتاه");

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .HasComment("عنوان");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AppDocument)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppDocument_Application");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.AppDocumentCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppDocument_User");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.AppDocument)
                    .HasForeignKey(d => d.DocTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppDocument_DocType");

                entity.HasOne(d => d.DocumentCategory)
                    .WithMany(p => p.AppDocument)
                    .HasForeignKey(d => d.DocumentCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppDocument_DocumentCategory");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.AppDocumentModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_AppDocument_User1");
            });

            modelBuilder.Entity<AppEntity>(entity =>
            {
                entity.ToTable("AppEntity", "base");

                entity.HasComment("موجودیت ها");

                entity.Property(e => e.ApplicationBased)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasDefaultValueSql("((1))")
                    .HasComment("رکورهای جدول به تفکیک برنامه می باشد");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.EnglishTitle)
                    .HasMaxLength(300)
                    .HasComment("عنوان انگلیسی جدول");

                entity.Property(e => e.IsLarge).HasComment("با تعداد رکوردهای بزرگتر از 1000");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ObjectId).HasComment("کد سیستمی جدول");

                entity.Property(e => e.PersianTitle)
                    .HasMaxLength(300)
                    .HasComment("عنوان فارسی جدول");

                entity.Property(e => e.Props).HasComment("فیلد json ویژگی ها");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasComment("عنوان انگلیسی جدول");

                entity.Property(e => e.TitlePropertyName)
                    .HasMaxLength(300)
                    .HasComment("عنوان ستون نمایشی");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Application", "um");

                entity.HasComment("برنامه ");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.AdditionalInfo)
                    .HasColumnType("xml")
                    .HasComment("اطلاعات تکمیلی");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.SecretKey).HasComment("کلید");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasComment("عنوان");

                entity.Property(e => e.Url)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("آدرس");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.ApplicationCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_User");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.ApplicationModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_Application_User1");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Application_Application");
            });

            modelBuilder.Entity<DashboardConnectionString>(entity =>
            {
                entity.ToTable("DashboardConnectionString", "dash");

                entity.HasComment("رشته های اتصال داشبورد");

                entity.HasIndex(e => new { e.ConnectionStringId, e.DashboardId })
                    .HasName("IX_DashboardConnectionString")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ConnectionStringId).HasComment("رشته اتصال");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.DashboardId).HasComment("داشبورد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.HasOne(d => d.ConnectionString)
                    .WithMany(p => p.DashboardConnectionString)
                    .HasForeignKey(d => d.ConnectionStringId)
                    .HasConstraintName("FK_DashboardConnectionString_YashilConnectionString");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.DashboardConnectionStringCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DashboardConnectionString_User");

                entity.HasOne(d => d.Dashboard)
                    .WithMany(p => p.DashboardConnectionString)
                    .HasForeignKey(d => d.DashboardId)
                    .HasConstraintName("FK_DashboardConnectionString_DashboardStore");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.DashboardConnectionStringModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_DashboardConnectionString_User1");
            });

            modelBuilder.Entity<DashboardGroup>(entity =>
            {
                entity.ToTable("DashboardGroup", "dash");

                entity.HasComment("گروه داشبورد");

                entity.HasIndex(e => e.EnglishTitle)
                    .HasName("IX_DashboardGroup_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.ApplicationId, e.Title })
                    .HasName("IX_DashboardGroup")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیح");

                entity.Property(e => e.EnglishTitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("عنوان انگلیسی");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("عنوان");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.DashboardGroup)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DashboardGroup_Application");

                entity.HasOne(d => d.CreatorOrganization)
                    .WithMany(p => p.DashboardGroup)
                    .HasForeignKey(d => d.CreatorOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DashboardGroup_Organization");
            });

            modelBuilder.Entity<DashboardGroupDashboard>(entity =>
            {
                entity.ToTable("DashboardGroupDashboard", "dash");

                entity.HasComment("گروه بندی داشبورد");

                entity.HasIndex(e => new { e.DashboardGroupId, e.DashboardStoreId })
                    .HasName("IX_DashboardGroupDashboard");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.DashboardGroupId).HasComment("گروه داشبورد");

                entity.Property(e => e.DashboardStoreId).HasComment("داشبورد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.DashboardGroupDashboardCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DashboardGroupDashboard_User");

                entity.HasOne(d => d.DashboardGroup)
                    .WithMany(p => p.DashboardGroupDashboard)
                    .HasForeignKey(d => d.DashboardGroupId)
                    .HasConstraintName("FK_DashboardGroupDashboard_DashboardGroup");

                entity.HasOne(d => d.DashboardStore)
                    .WithMany(p => p.DashboardGroupDashboard)
                    .HasForeignKey(d => d.DashboardStoreId)
                    .HasConstraintName("FK_DashboardGroupDashboard_DashboardStore");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.DashboardGroupDashboardModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_DashboardGroupDashboard_User1");
            });

            modelBuilder.Entity<DashboardStore>(entity =>
            {
                entity.ToTable("DashboardStore", "dash");

                entity.HasComment("داشبورد");

                entity.HasIndex(e => new { e.Title, e.ApplicationId })
                    .HasName("IX_DashboardStore")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("");

                entity.Property(e => e.AccessLevelId).HasComment("سطح دسترسی");

                entity.Property(e => e.Animation).HasComment("انیمیشن");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.Code)
                    .HasMaxLength(150)
                    .HasComment("کد");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("رنگ");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.CssClass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("کلاس");

                entity.Property(e => e.DashboardFile).HasComment("داشبورد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Picture).HasComment("تصویر");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasComment("عنوان");

                entity.HasOne(d => d.AccessLevel)
                    .WithMany(p => p.DashboardStore)
                    .HasForeignKey(d => d.AccessLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dashboard_AccessLevel");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.DashboardStore)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dashboard_Application");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.DashboardStoreCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dashboard_User");

                entity.HasOne(d => d.CreatorOrganization)
                    .WithMany(p => p.DashboardStore)
                    .HasForeignKey(d => d.CreatorOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DashboardStore_Organization");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.DashboardStoreModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_Dashboard_User1");
            });

            modelBuilder.Entity<DocFormat>(entity =>
            {
                entity.ToTable("DocFormat", "dms");

                entity.HasComment("فرمت سند");

                entity.HasIndex(e => e.Title)
                    .HasName("IX_DocFormat");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.Extensions)
                    .HasMaxLength(300)
                    .HasComment("فرمت های قابل قبول");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("عنوان");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.DocFormatCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocFormat_User");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.DocFormatModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_DocFormat_User1");
            });

            modelBuilder.Entity<DocType>(entity =>
            {
                entity.ToTable("DocType", "dms");

                entity.HasComment("نوع سند");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.AppEntityId)
                    .HasDefaultValueSql("((1))")
                    .HasComment("موجودیت");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.AspectRatio)
                    .HasDefaultValueSql("((1))")
                    .HasComment("نسبت تصویر");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.CreatorOrganizationId).HasComment("سازمان ایجاد کننده");

                entity.Property(e => e.CropImage).HasComment("آیا تصویر کراپ شود؟");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.DisplayOrder).HasComment("ترتیب نمایش");

                entity.Property(e => e.DocFormatId).HasComment("فرمت سند");

                entity.Property(e => e.IsCetegorized)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("آیا نیاز به دسته بندی سند وجود دارد؟");

                entity.Property(e => e.IsImage).HasComment("آیا فایل تصویر است؟");

                entity.Property(e => e.IsTitleRequired)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("آیا عنوان اجبرای است؟");

                entity.Property(e => e.MaxCount)
                    .HasDefaultValueSql("((1))")
                    .HasComment("حداکثر تعداد");

                entity.Property(e => e.MaxSize)
                    .HasDefaultValueSql("((1024))")
                    .HasComment("حداکثر اندازه");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.SaveToDisk).HasComment("آیا فایل روی دیسک ذخیره شود؟");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("عنوان");

                entity.HasOne(d => d.AppEntity)
                    .WithMany(p => p.DocType)
                    .HasForeignKey(d => d.AppEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocType_AppEntity");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.DocType)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocType_Application");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.DocTypeCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocType_User");

                entity.HasOne(d => d.DocFormat)
                    .WithMany(p => p.DocType)
                    .HasForeignKey(d => d.DocFormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocType_DocFormat");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.DocTypeModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_DocType_User1");
            });

            modelBuilder.Entity<DocumentCategory>(entity =>
            {
                entity.ToTable("DocumentCategory", "dms");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.AppEntityId).HasComment("موجودیت");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.CreatorOrganizationId).HasComment("سازمان ایجاد کننده سند");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیح کامل");

                entity.Property(e => e.DisplayOrder).HasComment("ترتیب نمایش");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال بودن");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ObjectId).HasComment("کد مالک");

                entity.Property(e => e.ParentId).HasComment("کد پدر");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("عنوان");

                entity.HasOne(d => d.AppEntity)
                    .WithMany(p => p.DocumentCategory)
                    .HasForeignKey(d => d.AppEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentCategory_AppEntity");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.DocumentCategory)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentCategory_Application");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.DocumentCategoryCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentCategory_User");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.DocumentCategoryModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_DocumentCategory_User1");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_DocumentCategory_DocumentCategory");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu", "um");

                entity.HasComment("منو");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.Badge)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("نشان");

                entity.Property(e => e.BadgeClass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("کلاس مشان");

                entity.Property(e => e.Class)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("کلاس");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("آیکون");

                entity.Property(e => e.IsExternalLink).HasComment("لینک خارجی");

                entity.Property(e => e.IsVirtual).HasComment("مجازی");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.OrderNo).HasComment("ترتیب");

                entity.Property(e => e.ParentId).HasComment("پدر");

                entity.Property(e => e.Path)
                    .HasMaxLength(300)
                    .HasComment("مسیر");

                entity.Property(e => e.ResourceId).HasComment("منبع");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasComment("عنوان");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.MenuCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_User1");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.MenuModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_Menu_User");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Menue_Menue");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK_Menue_Resource");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization", "um");

                entity.HasComment("سازمان");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ParentId).HasComment("سازمان پدر");

                entity.Property(e => e.ProvinceId).HasComment("استان");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasComment("عنوان");

                entity.Property(e => e.Type).HasComment("نوع سازمان");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organization_Application");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.OrganizationCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organization_User");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.OrganizationModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_Organization_User1");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Organization_Organization");
            });

            modelBuilder.Entity<ReportConnectionString>(entity =>
            {
                entity.ToTable("ReportConnectionString", "rpt");

                entity.HasComment("رشته های اتصال گزارش");

                entity.HasIndex(e => new { e.ReportId, e.ConnectionStringId })
                    .HasName("IX_ReportConnectionString")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ConnectionStringId).HasComment("رشته اتصال");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ReportId).HasComment("گزارش");

                entity.HasOne(d => d.ConnectionString)
                    .WithMany(p => p.ReportConnectionString)
                    .HasForeignKey(d => d.ConnectionStringId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportConnectionString_YashilConnectionString");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.ReportConnectionStringCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportConnectionString_User");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.ReportConnectionStringModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_ReportConnectionString_User1");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportConnectionString)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_ReportConnectionString_ReportStore");
            });

            modelBuilder.Entity<ReportGroup>(entity =>
            {
                entity.ToTable("ReportGroup", "rpt");

                entity.HasComment("گروه گزارش");

                entity.HasIndex(e => new { e.EnglishTitle, e.ApplicationId })
                    .HasName("IX_ReportGroup_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.Title, e.ApplicationId })
                    .HasName("IX_ReportGroup");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیح");

                entity.Property(e => e.EnglishTitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("عنوان انگلیسی");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("عنوان");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ReportGroup)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportGroup_Application");

                entity.HasOne(d => d.CreatorOrganization)
                    .WithMany(p => p.ReportGroup)
                    .HasForeignKey(d => d.CreatorOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportGroup_Organization");
            });

            modelBuilder.Entity<ReportGroupReport>(entity =>
            {
                entity.ToTable("ReportGroupReport", "rpt");

                entity.HasComment("گروه بندی گزارش");

                entity.HasIndex(e => new { e.ReportGroupId, e.ReportStoreId })
                    .HasName("IX_ReportGroupReport")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ReportGroupId).HasComment("گروه گزارش");

                entity.Property(e => e.ReportStoreId).HasComment("گزارش");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.ReportGroupReportCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportGroupReport_User");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.ReportGroupReportModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_ReportGroupReport_User1");

                entity.HasOne(d => d.ReportGroup)
                    .WithMany(p => p.ReportGroupReport)
                    .HasForeignKey(d => d.ReportGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportGroupReport_ReportGroup");

                entity.HasOne(d => d.ReportStore)
                    .WithMany(p => p.ReportGroupReport)
                    .HasForeignKey(d => d.ReportStoreId)
                    .HasConstraintName("FK_ReportGroupReport_ReportStore");
            });

            modelBuilder.Entity<ReportStore>(entity =>
            {
                entity.ToTable("ReportStore", "rpt");

                entity.HasComment("گزارش");

                entity.HasIndex(e => new { e.Title, e.ApplicationId })
                    .HasName("IX_ReportStore");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.AccessLevelId).HasComment("سطح دسترسی");

                entity.Property(e => e.Animation).HasComment("انیمیشن");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("رنگ");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.CssClass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("کلاس");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیح");

                entity.Property(e => e.DesignString).HasComment("طراحی");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ModuleKey)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasComment("ماژول");

                entity.Property(e => e.Picture).HasComment("تصویر");

                entity.Property(e => e.ReportFile).HasComment("گزارش");

                entity.Property(e => e.ReportKey)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasComment("کلید گزارش");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasComment("عنوان");

                entity.HasOne(d => d.AccessLevel)
                    .WithMany(p => p.ReportStore)
                    .HasForeignKey(d => d.AccessLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportStore_AccessLevel");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ReportStore)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportStore_Application");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.ReportStoreCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportStore_User");

                entity.HasOne(d => d.CreatorOrganization)
                    .WithMany(p => p.ReportStore)
                    .HasForeignKey(d => d.CreatorOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportStore_Organization");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.ReportStoreModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_ReportStore_User1");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource", "um");

                entity.HasComment("منابع");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasComment("توضیحات");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasComment("آدرس منبع");

                entity.Property(e => e.Type).HasComment("نوع");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.ResourceCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resource_User");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.ResourceModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_Resource_User1");
            });

            modelBuilder.Entity<ResourceAppAction>(entity =>
            {
                entity.ToTable("ResourceAppAction", "um");

                entity.HasComment("مجوز");

                entity.Property(e => e.AppActionId).HasComment("عملیات");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ResourceId).HasComment("منبع");

                entity.HasOne(d => d.AppAction)
                    .WithMany(p => p.ResourceAppAction)
                    .HasForeignKey(d => d.AppActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceAction_Action");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ResourceAppAction)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceAction_Resource");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "um");

                entity.HasComment("نقش");

                entity.HasIndex(e => new { e.Title, e.ApplicationId })
                    .HasName("IX_Role")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال بودن");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("عنوان");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Role)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Application");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.RoleCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_User");

                entity.HasOne(d => d.CreatorOrganization)
                    .WithMany(p => p.Role)
                    .HasForeignKey(d => d.CreatorOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Organization");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.RoleModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_Role_User1");
            });

            modelBuilder.Entity<RoleDashboard>(entity =>
            {
                entity.ToTable("RoleDashboard", "dash");

                entity.HasComment("داشبورد نقش ها");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.DashboardId).HasComment("داشبورد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.RoleId).HasComment("نقش");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.RoleDashboardCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleDashboard_User");

                entity.HasOne(d => d.Dashboard)
                    .WithMany(p => p.RoleDashboard)
                    .HasForeignKey(d => d.DashboardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleDashboard_Dashboard");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.RoleDashboardModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_RoleDashboard_User1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleDashboard)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleDashboard_Role");
            });

            modelBuilder.Entity<RoleReport>(entity =>
            {
                entity.ToTable("RoleReport", "rpt");

                entity.HasComment("تخصیص گزارش به نقش");

                entity.HasIndex(e => new { e.ReportId, e.RoleId })
                    .HasName("IX_RoleReport")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ReportId).HasComment("گزارش");

                entity.Property(e => e.RoleId).HasComment("نقش");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.RoleReportCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleReport_User");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.RoleReportModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_RoleReport_User1");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.RoleReport)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_RoleReport_Report");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleReport)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleReport_Role");
            });

            modelBuilder.Entity<RoleResourceAction>(entity =>
            {
                entity.ToTable("RoleResourceAction", "um");

                entity.HasComment("تخصیص نقش به مجوز");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ResourceActionId).HasComment("منبع عملیات");

                entity.Property(e => e.RoleId).HasComment("نقش");

                entity.HasOne(d => d.ResourceAction)
                    .WithMany(p => p.RoleResourceAction)
                    .HasForeignKey(d => d.ResourceActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleResourceAction_ResourceAction");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleResourceAction)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleResourceAction_Role");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "um");

                entity.HasComment("کاربران");

                entity.HasIndex(e => new { e.UserName, e.ApplicationId })
                    .HasName("IX_User")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.AccessLevelId).HasComment("سطح دسترسی");

                entity.Property(e => e.Address).HasComment("آدرس");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Email)
                    .HasMaxLength(300)
                    .HasComment("ایمیل");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("نام");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasComment("نام خانوادگی");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("شماره موبایل");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.NationalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("کد ملی");

                entity.Property(e => e.OrganizationId).HasComment("سازمان");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasComment("کلمه عبور");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("نام کاربری");

                entity.HasOne(d => d.AccessLevel)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.AccessLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_AccessLevel");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Application");

                entity.HasOne(d => d.CreatorOrganization)
                    .WithMany(p => p.UserCreatorOrganization)
                    .HasForeignKey(d => d.CreatorOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Organization1");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.UserOrganization)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Organization");
            });

            modelBuilder.Entity<UserDashboard>(entity =>
            {
                entity.ToTable("UserDashboard", "dash");

                entity.HasComment("داشبورد کاربران");

                entity.HasIndex(e => new { e.DashboardId, e.UserId })
                    .HasName("IX_UserDashboard")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.DashboardId).HasComment("داشبورد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.UserId).HasComment("کاربر");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.UserDashboardCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDashboard_User2");

                entity.HasOne(d => d.Dashboard)
                    .WithMany(p => p.UserDashboard)
                    .HasForeignKey(d => d.DashboardId)
                    .HasConstraintName("FK_UserDashboard_Dashboard");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.UserDashboardModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_UserDashboard_User");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDashboardUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDashboard_User3");
            });

            modelBuilder.Entity<UserReport>(entity =>
            {
                entity.ToTable("UserReport", "rpt");

                entity.HasComment("تخصیص گزارش به کاربر");

                entity.HasIndex(e => new { e.ReportId, e.UserId })
                    .HasName("IX_UserReport")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.ReportId).HasComment("گزارش");

                entity.Property(e => e.UserId).HasComment("کاربر");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.UserReportCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserReport_User2");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.UserReportModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_UserReport_User");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.UserReport)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_UserReport_Report");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserReportUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserReport_User3");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole", "um");

                entity.HasComment("نقش کاربران");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.RoleId).HasComment("نقش");

                entity.Property(e => e.UserId).HasComment("کاربر");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.UserRoleCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User1");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.UserRoleModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_UserRole_User2");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<YashilConnectionString>(entity =>
            {
                entity.ToTable("YashilConnectionString", "base");

                entity.HasComment("رشته اتصال");

                entity.HasIndex(e => new { e.Title, e.ApplicationId })
                    .HasName("IX_YashilConnectionString")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.AccessLevelId).HasComment("سطح دسترسی");

                entity.Property(e => e.ApplicationId).HasComment("برنامه");

                entity.Property(e => e.ConnectionString)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("رشته اتصال");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.DataProviderId).HasComment("تامین کننده داده");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیح");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال بودن");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("عنوان");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.YashilConnectionString)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_YashilConnectionString_Application");

                entity.HasOne(d => d.CreatorOrganization)
                    .WithMany(p => p.YashilConnectionString)
                    .HasForeignKey(d => d.CreatorOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_YashilConnectionString_Organization");

                entity.HasOne(d => d.DataProvider)
                    .WithMany(p => p.YashilConnectionString)
                    .HasForeignKey(d => d.DataProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_YashilConnectionString_YashilDataProvider");
            });

            modelBuilder.Entity<YashilDataProvider>(entity =>
            {
                entity.ToTable("YashilDataProvider", "base");

                entity.HasComment(" انواع تامین کننده داده");

                entity.Property(e => e.Id).HasComment("کد");

                entity.Property(e => e.BaseType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("نوع پایه");

                entity.Property(e => e.CreateBy).HasComment("ایجاد کننده");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان ایجاد");

                entity.Property(e => e.Deleted).HasComment("حذف شده");

                entity.Property(e => e.Description).HasComment("توضیح");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال بودن");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasComment("زمان تغییر");

                entity.Property(e => e.ModifyBy).HasComment("ویرایش کننده");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("عنوان");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.YashilDataProviderCreateByNavigation)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_YashilDataProvider_User");

                entity.HasOne(d => d.ModifyByNavigation)
                    .WithMany(p => p.YashilDataProviderModifyByNavigation)
                    .HasForeignKey(d => d.ModifyBy)
                    .HasConstraintName("FK_YashilDataProvider_User1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
