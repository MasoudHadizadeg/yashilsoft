using System;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
    public class CourseRepository : GenericApplicationBasedRepository<Course, int>, ICourseRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
        public CourseRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }
        public string GetDescription(int id)
        {
            return DbSet.Where(x => x.Id == id).Select(x => x.Description).FirstOrDefault();
        }
        public string GetTopic(int id)
        {
            var property = typeof(Course).GetProperty("Toddpic");
            if (property!=null)
            {
                
            }
            // var propertyInfo = DbSet.GetType().GetProperty("Topic");
            var propName = DbSet.Where(x => x.Id == id).Select(x => EF.Property<string>(x, "Topic")).FirstOrDefault();
            return propName;
            //return DbSet.Where(x => x.Id == id).Select(x => x.Topic).FirstOrDefault();
        }

        public string GetPrerequisite(int id)
        {
            return DbSet.Where(x => x.Id == id).Select(x => x.Prerequisite).FirstOrDefault();
        }
        public string GetTarget(int id)
        {
            return DbSet.Where(ApplicationBasedDefaultFilter()).Where(x => x.Id == id).Select(x => x.Target).FirstOrDefault();
        }
        public string GetRequirements(int id)
        {
            return DbSet.Where(x => x.Id == id).Select(x => x.Requirements).FirstOrDefault();
        }
        public string GetSkill(int id)
        {
            return DbSet.Where(x => x.Id == id).Select(x => x.Skill).FirstOrDefault();
        }
        public string GetAudience(int id)
        {
            return DbSet.Where(x => x.Id == id).Select(x => x.Audience).FirstOrDefault();
        }

    }
}
