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
    }
}