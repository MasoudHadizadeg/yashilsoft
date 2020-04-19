	using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
	public class PostService : GenericService<Post,int>, IPostService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public PostService (IUnitOfWork unitOfWork, IPostRepository postRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, postRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_postRepository = postRepository;
			_userPrincipal = userPrincipal;
        }
    }
}      
 