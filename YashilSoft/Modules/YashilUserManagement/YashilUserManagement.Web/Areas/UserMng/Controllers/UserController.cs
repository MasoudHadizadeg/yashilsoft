using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.SharedKernel.Helpers;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.ControllersExtenders;
using Yashil.Core.Entities;
using Yashil.Core.Enums;
using YashilUserManagement.Core.Services;
using YashilUserManagement.Web.Areas.UserMng.Helper;
using YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
    public class UserController : BaseController<User, int, UserListViewModel, UserEditModel,
        UserSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUserControllerExtender _userCustomService;

        public UserController(IUserControllerExtender userCustomService, IUserService userService,
            IMapper mapper) : base(
            userService, mapper)
        {
            _userCustomService = userCustomService;
            _mapper = mapper;
            _userService = userService;
        }

        protected override async Task<UserEditModel> GetEntityForEdit(int id)
        {
            var entityForEdit = base.GetEntityForEdit(id);
            entityForEdit.Result.AdditionalInfoList =  _userCustomService.GetCustomProps(id);
            return await entityForEdit;
        }

        protected override void CustomMapBeforeInsert(UserEditModel editModel, User entity)
        {
            _userCustomService?.BeforeInsert(entity,editModel.AdditionalInfoList, editModel.Id);
            SetAccessLevel(editModel, entity);
            SetPassword(editModel, entity);
            base.CustomMapBeforeInsert(editModel, entity);
        }

        private void SetAccessLevel(UserEditModel editModel, User entity)
        {
            // در صورتی که سطح دسترسی ست نشده باشد، سطح دسترسی عادی تعریف میشود
            if (editModel.AccessLevelId == 0)
            {
                entity.AccessLevelId = (int)AccessLevelEnum.Normal;
            }
            else
            {
                // سطح دسترسی کاربر جدید باید کمتر یا مساوی سطح دسترسی کاربر  جاری باشد
                var currentUserAccessLevelId = _userService.GetCurrentUserInfo().AccessLevelId;
                if (editModel.AccessLevelId > currentUserAccessLevelId)
                {
                    entity.AccessLevelId = currentUserAccessLevelId;
                }
            }
        }

        protected override void CustomMapBeforeUpdate(UserEditModel editModel, User entity)
        {
            _userCustomService?.BeforeUpdate(editModel.AdditionalInfoList, editModel.Id);
            SetAccessLevel(editModel, entity);
            if (!string.IsNullOrEmpty(editModel.PasswordStr))
            {
                SetPassword(editModel, entity);
            }

            base.CustomMapBeforeUpdate(editModel, entity);
        }

        private void SetPassword(UserEditModel editModel, User entity)
        {
            // entity.Password = Encoding.UTF8.GetBytes(editModel.PasswordStr+ editModel.UserName);
            CryptographyHelper.CreatePasswordHash(editModel.PasswordStr + editModel.UserName, out var passwordHash,
                out var passwordSalt);
            entity.Password = passwordHash;
            entity.PasswordSalt = passwordSalt;
        }

        protected override bool GetPropertiesForApplyOrIgnoreUpdate(User entity, UserEditModel editModel,
            out List<string> props)
        {
            props = new List<string> { "NationalCode", "UserName" };
            if (string.IsNullOrEmpty(editModel.PasswordStr))
            {
                props.Add("PasswordSalt");
                props.Add("Password");
            }

            return false;
        }

        [HttpGet("CheckUserName")]
        public object CheckUserName(string userName)
        {
            return !_userService.CheckExistsUserName(userName);
        }

        [HttpGet("CheckNationalCode")]
        public object CheckNationalCode(string nationalCode)
        {
            if (_userService.CheckExistsNationalCode(nationalCode))
            {
                return false;
            }

            return nationalCode.IsValidNationalCode();
        }

        [HttpGet("GetCurrentUserInfo")]
        public UserSimpleViewModel GetCurrentUserInfo()
        {
            return _mapper.Map<UserSimpleViewModel>(_userService.GetCurrentUserInfo());
        }
    }
}