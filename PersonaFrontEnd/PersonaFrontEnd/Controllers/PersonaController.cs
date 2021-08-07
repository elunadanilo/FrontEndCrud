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
        // GET: Persona
        //public async Task<ActionResult> Index()
        //{
        //    List<PersonaModel> persona = new List<PersonaModel>();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(BaseUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage res = await client.GetAsync("persona");
        //        if (res.IsSuccessStatusCode) {
        //            var personaResponse = res.Content.ReadAsStringAsync().Result;
        //            persona = JsonConvert.DeserializeObject<List<PersonaModel>>(personaResponse);

        //        }

        //        return View(persona);
        //    }
        //}
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

        //[HttpPost]
        //public ActionResult Add(PersonaModel oPersona)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:55459/api/persona");
        //        var postTask = client.PostAsJsonAsync<PersonaModel>("persona", oPersona);
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    ModelState.AddModelError(string.Empty, "Error al grabar persona");
        //    return View(oPersona);
        //}

        [HttpPost]
        public async Task<ActionResult> Add(PersonaModel oPersona)
        {
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:55459/api/persona");
            //    var postTask = client.PostAsJsonAsync<PersonaModel>("persona", oPersona);
            //    postTask.Wait();

            //    var result = postTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}
            //ModelState.AddModelError(string.Empty, "Error al grabar persona");
            //return View(oPersona);
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

        //public ActionResult Edit(int id)
        //{
        //    PersonaModel persona = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:55459/api/");

        //        var responseTask = client.GetAsync("persona/" + id.ToString());
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<PersonaModel>();
        //            readTask.Wait();
        //            persona = readTask.Result;
        //        }
        //    }

        //    return View(persona);
        //}

        public async Task<ActionResult> Edit(int id)
        {
            //PersonaModel persona = null;
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:55459/api/");

            //    var responseTask = client.GetAsync("persona/" + id.ToString());
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<PersonaModel>();
            //        readTask.Wait();
            //        persona = readTask.Result;
            //    }
            //}

            //return View(persona);

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

        //[HttpPost]
        //public ActionResult Edit(PersonaModel oPersona)
        //{
        //    using (var client = new HttpClient()) {
        //        client.BaseAddress = new Uri("http://localhost:55459/api/");

        //        var putTask = client.PutAsJsonAsync($"persona/{oPersona.IdPersona}", oPersona);
        //        putTask.Wait();

        //        var result = putTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    return View(oPersona);
        //}

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


            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:55459/api/");

            //    var putTask = client.PutAsJsonAsync($"persona/{oPersona.IdPersona}", oPersona);
            //    putTask.Wait();

            //    var result = putTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}

            //return View(oPersona);
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

        //public ActionResult Delete(int id)
        //{
        //    PersonaModel persona = null;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:55459/api/");
        //        var responseTask = client.GetAsync("persona/" + id.ToString());
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<PersonaModel>();
        //            readTask.Wait();
        //            persona = readTask.Result;
        //        }
        //    }

        //    return View(persona);
        //}

        //[HttpPost]
        //public ActionResult Delete(PersonaModel oPersona, int id)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:55459/api/");

        //        var deleteTask = client.DeleteAsync($"persona/" + id.ToString());
        //        deleteTask.Wait();
        //        var result = deleteTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    return View(oPersona);
        //}


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


            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:55459/api/");

            //    var putTask = client.PutAsJsonAsync($"persona/{oPersona.IdPersona}", oPersona);
            //    putTask.Wait();

            //    var result = putTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}

            //return View(oPersona);
        }
    }
}