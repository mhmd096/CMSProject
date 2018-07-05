using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YellowPagesDB;
using YellowPagesServices;
namespace YellowPages.Controllers
{
    
    public class CategoryController : Controller
    {
        public CategoryService catService;
        // GET: Category

        public async Task<ActionResult> Index(long id)
        {
            Session["id"] = id;
            List<Category> cat = null;
            try
            {
                catService = new CategoryService();
                var response = await catService.Gets(id);
                if (response.Status)
                {
                    cat = response.Data;
                }
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(cat);
        }
        //GETALL
        public async Task<ActionResult> GetAll()
        {
            List<Category> cat = null;
            try
            {
                catService = new CategoryService();
                var response = await catService.GetAll();
                if (response.Status)
                {
                    cat = response.Data;
                    ViewBag.cat = cat;
                }
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(cat);
        }
        //Add
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> create(HttpPostedFileBase Picturelink,Category c)
        {
            if (Picturelink != null)
            {
                c.Picturelink = System.IO.Path.GetFileName(Picturelink.FileName);
            }
            try
            {
                catService = new CategoryService();
                var response = await catService.Add(c);
                if (response.Status)
                {
                    if (Picturelink != null)
                    {
                        string pic = System.IO.Path.GetFileName(Picturelink.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Images"), pic);
                        Picturelink.SaveAs(path);
                        string temp = Server.MapPath(Request.ApplicationPath);
                        string tempPath= System.IO.Path.Combine(temp.Substring(0, (temp.Length - 12)), "YellowpagesCustomer\\img");
                        string filePath = System.IO.Path.Combine(tempPath, pic);
                        Picturelink.SaveAs(filePath);
                    }
                    return RedirectToAction("Index/" + Session["id"]);
                }
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(c);
        }
        //EDIT
        public async Task<ActionResult> Edit(long id)
        {
            Category c = null;
            try
            {
                catService = new CategoryService();
                var response = await catService.GetbyId(id);
                if (response.Status)
                    c = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(c);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(HttpPostedFileBase Picturelink,Category c)
        {
            if (Picturelink != null)
            {
                c.Picturelink = System.IO.Path.GetFileName(Picturelink.FileName);
            }
            try
            {
                catService = new CategoryService();
                var response = await catService.Update(c);
                if (response.Status)
                {
                    if (Picturelink != null)
                    {
                        string pic = System.IO.Path.GetFileName(Picturelink.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Images"), pic);
                        Picturelink.SaveAs(path);
                        string temp = Server.MapPath(Request.ApplicationPath);
                        string tempPath = System.IO.Path.Combine(temp.Substring(0, (temp.Length - 12)), "YellowpagesCustomer\\img");
                        string filePath = System.IO.Path.Combine(tempPath, pic);
                        Picturelink.SaveAs(filePath);
                    }
                    return RedirectToAction("Index/" + Session["id"]);
                }
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(c);
        }
        //Delete
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                catService = new CategoryService();
                var response = await catService.Delete(id);
                if (response.Status)
                    return RedirectToAction("Index/" + Session["id"]);
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction("Index/" + Session["id"]);
        }
    }
}