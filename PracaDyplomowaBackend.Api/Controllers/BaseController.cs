using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Data.DbModels;
using PracaDyplomowaBackend.Models.Models;
using PracaDyplomowaBackend.Models.ModelsDto;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Utilities.GlobalMessages;

namespace PracaDyplomowaBackend.Api.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Save<TEntity, TModel, TDto, TId>(IServiceBase<TEntity, TModel, TDto, TId> service, IActionResult successActionResult) where TEntity : EntityBase<TId> where TModel : ModelBase where TDto : DtoBase
        {
            return !service.Save() ? StatusCode(500, ErrorMessages.SaveFailed) : successActionResult;
        }

        public IActionResult Save<TEntity, TModel, TDto, TId>(IServiceBase<TEntity, TModel, TDto, TId> service, CreatedAtActionResult successActionResult, TEntity entity, string method) where TEntity : EntityBase<TId> where TModel : ModelBase where TDto : DtoBase
        {
            var saved = service.Save();

            var methodToInvoke = service.GetType().GetMethod(method);

            successActionResult.Value = methodToInvoke.Invoke(service, new object[] { entity.Id });      

            var result =  !saved ? StatusCode(500, ErrorMessages.SaveFailed) : successActionResult;
            
            return result;
        }

        public IActionResult Save<TEntity, TModel, TDto, TId>(IServiceBase<TEntity, TModel, TDto, TId> service, CreatedAtActionResult successActionResult, TId id, string method) where TEntity : EntityBase<TId> where TModel : ModelBase where TDto : DtoBase
        {
            var saved = service.Save();

            var methodToInvoke = service.GetType().GetMethod(method);

            successActionResult.Value = methodToInvoke.Invoke(service, new object[] { id });

            var result = !saved ? StatusCode(500, ErrorMessages.SaveFailed) : successActionResult;

            return result;
        }
    }
}