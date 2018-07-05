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
    public class PictureController : Controller
    {
        PictureService pictureService;
        // GET: Picture
        public async Task<ActionResult> Index(long id)
        {
            Session["itemid"] = id;
            IEnumerable<Picture> pics = null;
            try
            {
                pictureService = new PictureService();
                var response = await pictureService.Gets(id);
                if (response.Status)
                    pics = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(pics);
        }
        //Add
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> create(HttpPostedFileBase Picturelink, HttpPostedFileBase Thumblink, Picture p)
        {
            if (Picturelink != null)
            {
                p.Picturelink = System.IO.Path.GetFileName(Picturelink.FileName);
            }
            if (Thumblink != null)
                p.ThumbLink = System.IO.Path.GetFileName(Thumblink.FileName);
            try
            {
                pictureService = new PictureService();
                var response = await pictureService.Add(p);
                if (response.Status)
                {
                    if (Picturelink != null)
                    {
                        string pic = System.IO.Path.GetFileName(Picturelink.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Images/Items"), pic);
                        Picturelink.SaveAs(path);
                        string temp = Server.MapPath(Request.ApplicationPath);
                        string tempPath = System.IO.Path.Combine(temp.Substring(0, (temp.Length - 12)), "YellowpagesCustomer\\img\\Items");
                        string filePath = System.IO.Path.Combine(tempPath, pic);
                        Picturelink.SaveAs(filePath);
                    }
                    if (Thumblink != null)
                    {
                        string pic = System.IO.Path.GetFileName(Thumblink.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Images/Items"), pic);
                        Thumblink.SaveAs(path);
                        string temp = Server.MapPath(Request.ApplicationPath);
                        string tempPath = System.IO.Path.Combine(temp.Substring(0, (temp.Length - 12)), "YellowpagesCustomer\\img\\Items");
                        string filePath = System.IO.Path.Combine(tempPath, pic);
                        Thumblink.SaveAs(filePath);
                    }
                    return RedirectToAction("Index/" + Session["itemid"]);
                }
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(p);
        }
        //EDIT
        public async Task<ActionResult> Edit(long id)
        {
            Picture p = null;
            try
            {
                pictureService = new PictureService();
                var response = await pictureService.GetbyId(id);
                if (response.Status)
                    p = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(p);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(HttpPostedFileBase Picturelink, HttpPostedFileBase Thumblink, Picture p)
        {
            if (Picturelink != null)
            {
                p.Picturelink = System.IO.Path.GetFileName(Picturelink.FileName);
            }
            if (Thumblink != null)
                p.ThumbLink = System.IO.Path.GetFileName(Thumblink.FileName);
            try
            {
                pictureService = new PictureService();
                var response = await pictureService.Update(p);
                if (response.Status)
                {
                    if (Picturelink != null)
                    {
                        string pic = System.IO.Path.GetFileName(Picturelink.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Images/Items"), pic);
                        Picturelink.SaveAs(path);
                        string temp = Server.MapPath(Request.ApplicationPath);
                        string tempPath = System.IO.Path.Combine(temp.Substring(0, (temp.Length - 12)), "YellowpagesCustomer\\img\\Items");
                        string filePath = System.IO.Path.Combine(tempPath, pic);
                        Picturelink.SaveAs(filePath);
                    }
                    if (Thumblink != null)
                    {
                        string pic = System.IO.Path.GetFileName(Thumblink.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Images/Items"), pic);
                        Thumblink.SaveAs(path);
                        string temp = Server.MapPath(Request.ApplicationPath);
                        string tempPath = System.IO.Path.Combine(temp.Substring(0, (temp.Length - 12)), "YellowpagesCustomer\\img\\Items");
                        string filePath = System.IO.Path.Combine(tempPath, pic);
                        Thumblink.SaveAs(filePath);
                    }
                    return RedirectToAction("Index/" + Session["itemid"]);
                }
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(p);
        }
        //Delete
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                pictureService = new PictureService();
                var response = await pictureService.Delete(id);
                if (response.Status)
                    return RedirectToAction("Index/" + Session["itemid"]);
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction("Index/" + Session["itemid"]);
        }
    }
}