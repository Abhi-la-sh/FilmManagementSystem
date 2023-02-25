using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Sprint2_MVC.Models;
using System.Runtime.CompilerServices;
using Sprint2_WebApi.Models;

namespace Sprint2_MVC.Controllers
{
    public class FilmMVCController : Controller
    {
        // GET: FilmMVC
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            List<FilmViewModel> empList = null;
            var result = client.GetAsync("https://localhost:44337/api/film").Result;
            if (result.IsSuccessStatusCode)
            {
                empList = result.Content.ReadAsAsync<List<FilmViewModel>>().Result;
                return View(empList);
            }
            else
            {
                ViewBag.message = result.ReasonPhrase;
                return RedirectToAction("index", "home");
            }
        }

        // GET: FilmMVC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilmMVC/Create
        public ActionResult Create()
        {
            HttpClient client = new HttpClient();
            LanActorCategory lanActorCategory = null;
            var result = client.GetAsync("https://localhost:44337/api/lanactorcategory").Result;
            if (result.IsSuccessStatusCode)
            {
                lanActorCategory = result.Content.ReadAsAsync<LanActorCategory>().Result;
                SelectList languageSl = new SelectList(lanActorCategory.Languages,"LanguageId", "LanguageName");
                SelectList ActorSl = new SelectList(lanActorCategory.Actors, "ActorId", "ActorName");
                SelectList CategorySl = new SelectList(lanActorCategory.Categories, "CategoryId", "CategoryName");
                ViewData["Language"] = languageSl;
                ViewData["Actor"] = ActorSl;
                ViewData["Category"] = CategorySl;
            }
            return View();
        }

        // POST: FilmMVC/Create
        [HttpPost]
        public ActionResult Create(FilmDTO fm)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.PostAsJsonAsync("https://localhost:44337/api/film", fm).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(fm);
                    }
                }
                return View(fm);
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmMVC/Edit/5
        public ActionResult Edit(int id)
        {
            FilmDTO fm;
            LanActorCategory lanActorCategory = null;
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:44337/api/lanactorcategory").Result;
            var result2 = client.GetAsync("https://localhost:44337/api/film/" + id).Result;
            if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
            {
                lanActorCategory = result.Content.ReadAsAsync<LanActorCategory>().Result;
                SelectList languageSl = new SelectList(lanActorCategory.Languages, "LanguageId", "LanguageName");
                SelectList ActorSl = new SelectList(lanActorCategory.Actors, "ActorId", "ActorName");
                SelectList CategorySl = new SelectList(lanActorCategory.Categories, "CategoryId", "CategoryName");
                ViewData["Language"] = languageSl;
                ViewData["Actor"] = ActorSl;
                ViewData["Category"] = CategorySl;
                fm = result2.Content.ReadAsAsync<FilmDTO>().Result;
                return View(fm);
            }
            return RedirectToAction("Index");
        }

        // POST: FilmMVC/Edit/5
        [HttpPost]
        public ActionResult Edit(FilmDTO fm)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    var result = client.PutAsJsonAsync("https://localhost:44337/api/film/" + fm.FilmId,fm).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(fm);
                    }
                }
                return View(fm);
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmMVC/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var result = client.DeleteAsync("https://localhost:44337/api/film/" + id).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.message = result.ReasonPhrase;
                return RedirectToAction("index");
            }
        }

        // POST: FilmMVC/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
