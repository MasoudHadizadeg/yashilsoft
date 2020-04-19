	using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class RepresentationTeacherService : GenericService<RepresentationTeacher,int>, IRepresentationTeacherService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IRepresentationTeacherRepository _representationTeacherRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public RepresentationTeacherService (IUnitOfWork unitOfWork, IRepresentationTeacherRepository representationTeacherRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, representationTeacherRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_representationTeacherRepository = representationTeacherRepository;
			_userPrincipal = userPrincipal;
        }
                 
        public IQueryable<RepresentationTeacher> GetByCustomFilter( int? personId)
        {
            return _representationTeacherRepository.GetByCustomFilter(personId);
        }
           

    }
}      
 