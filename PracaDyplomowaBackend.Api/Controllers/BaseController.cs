using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowaBackend.Data.DbModels;
using PracaDyplomowaBackend.Service.Interfaces;

namespace PracaDyplomowaBackend.Api.Controllers
{    
    public class BaseController : Controller
    {
        public IActionResult Save<TEntity, TId>(IServiceBase<TEntity, TId> service, IActionResult successActionResult) where TEntity : EntityBase<TId>
        {
            return !service.Save() ? StatusCode(500, "Wystąpił błąd podczas zapisu.") : successActionResult;
        }
    }
}