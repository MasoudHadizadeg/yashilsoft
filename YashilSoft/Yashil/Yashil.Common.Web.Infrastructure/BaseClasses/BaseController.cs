using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;

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
            return await _genericService.GetAllAsync<TListViewModel>(_mapper, loadOptions, true);
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
                return await _genericService.GetAsync<TEditModel>(_mapper, id, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
                entity.CreateBy = CurrentUserId.Value;
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
                List<string> notModifiedProperties = GetNotModifiedProperties(entity);
                await _genericService.UpdateAsync(entity, entity.Id, notModifiedProperties, true);
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

        private Task<LoadResult> GetAll(CustomDataSourceLoadOptions loadOptions)
        {
            // var filter = CustomFilter(loadOptions);
            // var list = Repo.GetAll().Where(filter).OrderByDescending(x => x.Id);
            //var loadResult = DataSourceLoader.Load(list.ProjectTo<TViewModel>(_mapper.ConfigurationProvider), loadOptions);
            //return loadResult;
            return _genericService.GetAllAsync<TViewModel>(_mapper, loadOptions, true);
        }

        private async Task<LoadResult> GetAllForSelect(CustomDataSourceLoadOptions loadOptions)
        {
            return await _genericService.GetAllAsync<TSelectViewModel>(_mapper, loadOptions, true);
        }

        private Expression<Func<TModel, object>>[] GetIncludes()
        {
            return new Expression<Func<TModel, object>>[] { };
        }

        [NonAction]
        private void CustomMapAfterSelectById(TEditModel model)
        {
        }

        private string CustomValidateBeforeInsert(TEditModel editModel)
        {
            return null;
        }

        [NonAction]
        private void AfterInsert(TEditModel editModel, TModel entity)
        {
        }

        [NonAction]
        private void CustomMapBeforeInsert(TEditModel editModel, TModel entity)
        {
        }

        [NonAction]
        private void CustomMapBeforeUpdate(TEditModel editModel, TModel entity)
        {
        }

        [NonAction]
        private void AfterUpdate(TEditModel editModel, TModel entity)
        {
        }

        private List<string> GetNotModifiedProperties(TModel entity)
        {
            return new List<string>();
        }
    }
}