using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Dtos;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Common.Web.Infrastructure.BaseClasses
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<TModel, TK, TListViewModel, TEditModel, TSelectViewModel> : ControllerBase
        where TModel : class, IBaseEntity<TK> 
    {
        private readonly IGenericService<TModel, TK> _genericService;
        private readonly IMapper _mapper;

        protected int? CurrentUserId
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    return Convert.ToInt32(User.Identity.Name);
                }

                return null;
            }
        }

        public BaseController(IGenericService<TModel, TK> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<LoadResult> GetEntities(CustomDataSourceLoadOptions loadOptions)
        {
            var entities = _genericService.GetAll(true);
            return await DataSourceLoader.LoadAsync(entities.ProjectTo<TListViewModel>(_mapper.ConfigurationProvider),
                loadOptions);
        }

        [HttpGet("GetForSelect")]
        public Task<LoadResult> GetForSelect(CustomDataSourceLoadOptions loadOptions)
        {
            return GetAllForSelect(loadOptions);
        }

        [HttpGet("{id}")]
        public async Task<TEditModel> GetEntity([FromRoute] TK id)
        {
            try
            {
                return await GetEntityForEdit(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("GetPropertyByName/{id}/{propName}")]
        public DescriptionEditModel<TK> GetPropertyByName([FromRoute] TK id, string propName)
        {
            try
            {
                var entityDescription = _genericService.GetEntityDescriptionByPropName(id, propName);
                return new DescriptionEditModel<TK>
                {
                    Description = entityDescription,
                    Id = id,
                    PropertyName = propName
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("UpdateEntityDescription")]
        public async Task<HttpResponseMessage> UpdateEntityDescription(DescriptionEditModel<TK> descEditModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                var res = await _genericService.UpdateEntityDescription(descEditModel);
                if (!res)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        protected virtual async Task<TEditModel> GetEntityForEdit(TK id)
        {
            var entity = await _genericService.GetAsync(id, true);
            return _mapper.Map<TEditModel>(entity);
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> DeleteEntity([FromRoute] TK id)
        {
            try
            {
                await _genericService.Delete(id, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPost]
        public async Task<IActionResult> PostEntity(TEditModel editModel)
        {
            var msg = CustomValidateBeforeInsert(editModel);
            if (!string.IsNullOrEmpty(msg))
            {
                return BadRequest(msg);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(@"مقادیر وارد شده صحیح نیست");
            }

            var entity = _mapper.Map<TEditModel, TModel>(editModel);
            CustomMapBeforeInsert(editModel, entity);
            try
            {
                if (CurrentUserId != null) entity.CreateBy = CurrentUserId.Value;
                entity.CreationDate = DateTime.Now;

                await _genericService.AddAsync(entity, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(@"بروز خطا در عملیات دخیره سازی");
            }

            AfterInsert(editModel, entity);
            return Accepted(entity.Id);
        }


        [HttpPut]
        public async Task<HttpResponseMessage> PutEntity(TEditModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                var entity = _mapper.Map<TEditModel, TModel>(editModel);

                entity.ModifyBy = CurrentUserId;
                entity.ModificationDate = DateTime.Now;

                CustomMapBeforeUpdate(editModel, entity);

                var modifyProps = GetPropertiesForApplyOrIgnoreUpdate(entity, editModel, out var props);
                await UpdateAsync(entity, editModel, entity.Id, props, modifyProps);

                AfterUpdate(editModel, entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //return new HttpResponseMessage(HttpStatusCode.);
                throw;
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        ///  لیستی از ویژگی های موجودیت برای بروز رسانی یا عدم بروز رسانی.هنگام فراخوانی متد بروز رسانی سرویس از طریق پارامتر ورودی نوع آن را مشخص کنید 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="editModel"></param>
        /// <param name="props"></param>
        /// <returns>در صورتی که می خواهید  لیست ویژگی ها بروز نشود مقدار نادرست و در غیر این صورت مقدار درست را برگردانید</returns>
        [NonAction]
        protected virtual bool GetPropertiesForApplyOrIgnoreUpdate(TModel entity, TEditModel editModel, out List<string> props)
        {
            var myPropertyInfo = editModel.GetType().GetProperties();
            props = myPropertyInfo.Select(t => t.Name).ToList();

            return true;
        }


        private Expression<Func<TModel, bool>> CustomFilter(CustomDataSourceLoadOptions loadOptions)
        {
            return model => true;
        }

        private Expression<Func<TModel, bool>> CustomFilterForSelect(CustomDataSourceLoadOptions loadOptions)
        {
            return model => true;
        }

        private async Task<LoadResult> GetAllForSelect(CustomDataSourceLoadOptions loadOptions)
        {
            var entities = _genericService.GetAll(true);
            return await DataSourceLoader.LoadAsync(entities.ProjectTo<TSelectViewModel>(_mapper.ConfigurationProvider),
                loadOptions);
        }

        private Expression<Func<TModel, object>>[] GetIncludes()
        {
            return new Expression<Func<TModel, object>>[] { };
        }

        [NonAction]
        protected virtual void CustomMapAfterSelectById(TEditModel model)
        {
        }

        protected virtual string CustomValidateBeforeInsert(TEditModel editModel)
        {
            return null;
        }

        [NonAction]
        protected virtual void AfterInsert(TEditModel editModel, TModel entity)
        {
        }

        [NonAction]
        protected virtual void CustomMapBeforeInsert(TEditModel editModel, TModel entity)
        {
        }

        [NonAction]
        protected virtual void CustomMapBeforeUpdate(TEditModel editModel, TModel entity)
        {
        }

        [NonAction]
        protected virtual void AfterUpdate(TEditModel editModel, TModel entity)
        {
        }

        [NonAction]
        protected virtual async Task UpdateAsync(TModel entity, TEditModel editModel, TK entityId,
            List<string> props, bool modifyProps = true)
        {
            await _genericService.UpdateAsync(entity, entity.Id, props, modifyProps, true);
        }

    }
}