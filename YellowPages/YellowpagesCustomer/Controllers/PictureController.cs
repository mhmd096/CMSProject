using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YellowPagesDB;
using YellowPagesServices;
namespace YellowpagesCustomer.Controllers
{
    public class PictureController : Controller
    {
        PictureService pictureService;
        // GET: Picture
        public async Task<ActionResult> Index(long id)
        {
            List<Picture> pics = null;
            try
            {
                pictureService = new PictureService();
                var response = await pictureService.Gets(id);
                if (response.Status)
                    pics = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            pics = pics.OrderBy(p => p.Order).ToList();
            return View(pics);
        }
    }
}