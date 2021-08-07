using Newtonsoft.Json;
using PersonaFrontEnd.Dao;
using PersonaFrontEnd.Models;
using PersonaFrontEnd.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace PersonaFrontEnd.Services
{
    public class PersonaService : IPersonaDao
    {
        string BaseUrl = "http://localhost:55459/api/";

        public async Task<OperationResponse> Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55459/api/");

                    var deleteTask = client.DeleteAsync($"persona/" + id.ToString());
                    deleteTask.Wait();
                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        await Task.Delay(1000);
                        return new OperationResponse(1);
                    }
                    else
                    {
                        await Task.Delay(1000);
                        return new OperationResponse(0);
                    }
                }
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public async Task<OperationResponse> GetAll()
        {
            try
            {
                List<PersonaModel> persona = new List<PersonaModel>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.GetAsync("persona");
                    if (res.IsSuccessStatusCode)
                    {
                        var personaResponse = res.Content.ReadAsStringAsync().Result;
                        persona = JsonConvert.DeserializeObject<List<PersonaModel>>(personaResponse);

                    }

                    return new OperationResponse(1, persona);
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }

        }

        public async Task<OperationResponse> GetById(int id)
        {
            try
            {
                PersonaModel persona = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55459/api/");

                    var responseTask = client.GetAsync("persona/" + id.ToString());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<PersonaModel>();
                        readTask.Wait();
                        persona = readTask.Result;
                    }
                }

                return new OperationResponse(1,persona);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OperationResponse> Save(PersonaModel t)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55459/api/persona");
                    var postTask = client.PostAsJsonAsync<PersonaModel>("persona", t);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        await Task.Delay(1000);
                        return new OperationResponse(1);
                    }
                    else
                    {
                        await Task.Delay(1000);
                        return new OperationResponse(0);
                    }
                }
             
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public async Task<OperationResponse> Update(int id, PersonaModel t)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55459/api/");

                    var putTask = client.PutAsJsonAsync($"persona/{t.IdPersona}", t);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        await Task.Delay(1000);
                        return new OperationResponse(1);
                    }
                    else
                    {
                        await Task.Delay(1000);
                        return new OperationResponse(0);
                    }
                }
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }
    }
}