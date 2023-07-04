using Fiorello.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fiorello.UI.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using(HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7171/api/category/all"))
                {
                    if(response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<CategoryGetAllResponseItem>>(content);
                        return View(data);
                    }
                }
            }
            return View("error");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateRequest category)
        {
            if(!ModelState.IsValid) { return View(); }
            using(var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(category), System.Text.Encoding.UTF8);
                using (var response = await client.PostAsync("https://localhost:7171/api/category",content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index"); 
                    }
                    else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<ErrorResponseModel>(responseContent);
                        foreach (var item in error.Errors)
                        {
                            ModelState.AddModelError(item.Key, item.Message);
                        }
                        return View();

                    }
                }
            }
            return View("error");

        }

        public async Task<IActionResult> Edit(int id)
        {
            using(var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"https://localhost:7171/api/category/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CategoryGetResponse>(responseContent);
                        var vm = new CategoryUpdateRequest { Name = data.Name };
                        return View(vm);
                    }
                }
            }
            return View("error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryUpdateRequest category)
        {
            if(!ModelState.IsValid) { return View(); }
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(category),System.Text.Encoding.UTF8,"application/json");
                using(var response = await client.PutAsync($"https://localhost:7171/api/category/{id}",content))
                {
                    if(response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<ErrorResponseModel>(responseContent);
                        foreach (var item in error.Errors)
                        {
                            ModelState.AddModelError(item.Key, item.Message);
                        }
                        return View();
                    }
                  
                }
            }
            return View("error");
        }


        public async Task<IActionResult> Delete(int id) 
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.DeleteAsync($"https://localhost:7171/api/category/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    { 
                        return RedirectToAction("index");
                    }
                }
            }
            return View("error");
        }

    
    }
}
