	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class PostController : BaseController<Post ,int,PostListViewModel, PostEditModel,PostSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        public PostController(IPostService postService, IMapper mapper) : base(postService, mapper)
        {
            _mapper=mapper;
            _postService=postService;
        }
    }
}      