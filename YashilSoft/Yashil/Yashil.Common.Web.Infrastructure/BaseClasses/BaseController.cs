using System;
using System.Collections.Generic;
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
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Interfaces;

namespace Yashil.Common.Web.Infrastructure.BaseClasses
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<TModel, TK, TListViewModel, TViewModel, TEditModel, TSelectViewModel> : ControllerBase
        where TModel : class, IBaseEntity<TK>
    {
        private readonly IGenericService<TModel> _genericService;
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

        public BaseController(IGenericService<TModel> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<LoadResult> GetEntities(CustomDataSourceLoadOptions loadOptions)
        {
            var entities = _genericService.GetAll(true);
            return await DataSourceLoader.LoadAsync(entities.ProjectTo<TViewModel>(_mapper.ConfigurationProvider),
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
            return Accepted();
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
                var notModifiedProperties = GetModifiedProperties(entity);
                await UpdateAsync(entity, editModel, entity.Id, notModifiedProperties);

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


        [HttpPut("PutEntityCustom")]
        public HttpResponseMessage PutEntityCustom(EditableViewModel<TEditModel> editModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                //var entity = _mapper.Map<TEditModel, TModel>(editModel.EditModel);
                //CustomMapBeforeUpdate(editModel.EditModel, entity);
                //Repo.Update(entity, entity.Id, editModel.ChangedProps.ToArray());
                //UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
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
            List<string> notModifiedProperties)
        {
            await _genericService.UpdateAsync(entity, entity.Id, notModifiedProperties, true);
        }

        [NonAction]
        protected List<string> GetModifiedProperties(TModel entity)
        {
            return new List<string>();
        }
    }
}