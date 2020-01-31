using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.SharedKernel.Helpers;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using YashilUserManagement.Web.Areas.UserMng.Helper;
using YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
    public class UserController : BaseController<User, int, UserListViewModel, UserViewModel, UserEditModel,
        UserSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        protected override void CustomMapBeforeInsert(UserEditModel editModel, User entity)
        {
            entity.Password = Encoding.UTF8.GetBytes(editModel.PasswordStr);
            CryptographyHelper.CreatePasswordHash(editModel.PasswordStr, out var passwordHash, out var passwordSalt);

            entity.Password = passwordHash;
            entity.PasswordSalt = passwordSalt;

            base.CustomMapBeforeInsert(editModel, entity);
        }

        protected override void CustomMapBeforeUpdate(UserEditModel editModel, User entity)
        {
            if (!string.IsNullOrEmpty(editModel.PasswordStr))
            {
                entity.Password = Encoding.UTF8.GetBytes(editModel.PasswordStr);
                CryptographyHelper.CreatePasswordHash(editModel.PasswordStr, out var passwordHash,
                    out var passwordSalt);
                entity.Password = passwordHash;
                entity.PasswordSalt = passwordSalt;
            }

            base.CustomMapBeforeUpdate(editModel, entity);
        }

        // protected override List<string> GetNotModifiedProperties(User entity)
        // {
        //     var notModifiedProperties = new List<string>();
        //     if (entity.Password == null)
        //     {
        //         notModifiedProperties.Add("Password");
        //         notModifiedProperties.Add("PasswordSalt");
        //     }
        //
        //     if (entity.Id != 0)
        //     {
        //         notModifiedProperties.Add("UserName");
        //     }
        //
        //     return entity.Password == null ? new List<string>(notModifiedProperties) : null;
        // }

        [HttpGet("CheckUserName")]
        public object CheckUserName(string userName)
        {
            return !_userService.CheckExistsUserName(userName);
        }

        [HttpGet("CheckNationalCode")]
        public object CheckNationalCode(string nationalCode)
        {
            return nationalCode.IsValidNationalCode();
        }
    }
}