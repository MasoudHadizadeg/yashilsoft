using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yashil.Core.Interfaces;
using Yashil.Core.Interfaces.Data;
using Yashil.Dashboard.Web.Data;
using Yashil.SharedKernel.Interfaces;

namespace Yashil.Dashboard.Web.BaseClasses
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TK, TViewModel, TEditModel> : ControllerBase
      where TModel : class, IBaseEntity<TK>
    {
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

        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IGenericRepository<TModel> Repo;
        public readonly IMapper _mapper;

        public BaseController(IUnitOfWork unitOfWork, IGenericRepository<TModel> repo, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public object GetEntities(CustomDataSourceLoadOptions loadOptions)
        {
            return GetAll(loadOptions);
        }


        [HttpGet("GetForSelect")]
        public object GetForSelect(CustomDataSourceLoadOptions loadOptions)
        {
            return GetAllForSelect(loadOptions);
        }

        protected virtual Expression<Func<TModel, bool>> CustomFilter(CustomDataSourceLoadOptions loadOptions)
        {
            return model => true;
        }

        protected virtual Expression<Func<TModel, bool>> CustomFilterForSelect(CustomDataSourceLoadOptions loadOptions)
        {
            return model => true;
        }

        protected virtual LoadResult GetAll(CustomDataSourceLoadOptions loadOptions)
        {
            var filter = CustomFilter(loadOptions);
            var list = Repo.GetAll().Where(filter).OrderByDescending(x => x.Id);
            var loadResult =
              DataSourceLoader.Load(list.ProjectTo<TViewModel>(_mapper.ConfigurationProvider), loadOptions);
            return loadResult;
        }

        protected virtual LoadResult GetAllForSelect(CustomDataSourceLoadOptions loadOptions)
        {
            var filter = CustomFilterForSelect(loadOptions);
            var list = Repo.GetAll().Where(filter).OrderByDescending(x => x.Id);
            var loadResult =
              DataSourceLoader.Load(list.ProjectTo<TViewModel>(_mapper.ConfigurationProvider), loadOptions);
            return loadResult;
        }

        [HttpGet("{id}")]
        public TEditModel GetEntity([FromRoute] TK id)
        {
            try
            {
                var entity = Repo.GetAllIncluding(GetIncludes()).FirstOrDefault(x => Equals(x.Id, id));
                var model = _mapper.Map<TEditModel>(entity);
                CustomMapAfterSelectById(model);
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected virtual void CustomMapAfterSelectById(TEditModel model)
        {
        }

        protected virtual Expression<Func<TModel, object>>[] GetIncludes()
        {
            return new Expression<Func<TModel, object>>[] { };
        }

        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteEntity([FromRoute] TK id)
        {
            Repo.Delete(id);
            try
            {
                UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPost]
        public IActionResult PostEntity(TEditModel editModel)
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
            Repo.Add(entity);
            try
            {
                UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(@"بروز خطا در عملیات دخیره سازی");
            }

            AfterInsert(editModel, entity);
            return Accepted();
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

        [HttpPut]
        public HttpResponseMessage PutEntity(TEditModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                var entity = _mapper.Map<TEditModel, TModel>(editModel);
                CustomMapBeforeUpdate(editModel, entity);
                string[] notModifiedProperties = GetNotModifiedProperties(entity);
                Repo.Update(entity, entity.Id, notModifiedProperties);
                UnitOfWork.Commit();
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

        [NonAction]
        protected virtual void AfterUpdate(TEditModel editModel, TModel entity)
        {
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
                var entity = _mapper.Map<TEditModel, TModel>(editModel.EditModel);
                CustomMapBeforeUpdate(editModel.EditModel, entity);
                // string[] notModifiedProperties = GetNotModifiedProperties(entity);
                Repo.Update(entity, entity.Id, editModel.ChangedProps.ToArray());
                UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //return new HttpResponseMessage(HttpStatusCode.);
                throw;
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //        [HttpPost("UpdateCards/{id}")]
        //        public IActionResult UpdateCards(TK id, [FromBody] string values)
        //        {
        //            //            var employee = _data.Employees.First(a => a.ID == key);
        //            //            JsonConvert.PopulateObject(values, employee);
        //            //
        //            //            if (!TryValidateModel(employee))
        //            //                return BadRequest(ModelState.GetFullErrorMessage());
        //            //
        //            //            _data.SaveChanges();
        //
        //            return Ok();
        //        }

        protected virtual string[] GetNotModifiedProperties(TModel entity)
        {
            return null;
        }
    }
}
