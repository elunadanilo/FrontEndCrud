using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PersonaFrontEnd.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PersonaFrontEnd.Services;
using PersonaFrontEnd.Dao;
using PersonaFrontEnd.Utils;

namespace PersonaFrontEnd.Controllers
{
    public class PersonaController : Controller
    {
        private IPersonaDao personadao = new PersonaService();
        string BaseUrl = "http://localhost:55459/api/";

        public async Task<ActionResult> Index()
        {
            OperationResponse response = await personadao.GetAll();

            if (response.Code == 1)
            {
                return View(response.Data);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(PersonaModel oPersona)
        {

            if (!ModelState.IsValid)
            {
                return View(oPersona);
            } else
            {
                OperationResponse response = await personadao.Save(oPersona);
                if (response.Code == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }

        }

        public async Task<ActionResult> Edit(int id)
        {
            OperationResponse response = await personadao.GetById(id);

            if (response.Code == 1)
            {
                return View(response.Data);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(PersonaModel oPersona)
        {
            if (!ModelState.IsValid)
            {
                return View(oPersona);
            }
            int IdPersona = oPersona.IdPersona;

            OperationResponse response = await personadao.Update(IdPersona,oPersona);
            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(oPersona);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            OperationResponse response = await personadao.GetById(id);

            if (response.Code == 1)
            {
                return View(response.Data);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(PersonaModel oPersona, int id)
        {
            OperationResponse response = await personadao.Delete(id);
            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(oPersona);
            }          
        }

        public async Task<ActionResult> Disable(int id)
        {
            OperationResponse response = await personadao.GetById(id);

            if (response.Code == 1)
            {
                return View(response.Data);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Disable(PersonaModel oPersona)
        {
            if (!ModelState.IsValid)
            {
                return View(oPersona);
            }
            int IdPersona = oPersona.IdPersona;

            OperationResponse response = await personadao.Update(IdPersona, oPersona);
            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(oPersona);
            }
        }
    }
}