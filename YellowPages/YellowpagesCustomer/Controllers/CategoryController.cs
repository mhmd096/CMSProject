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
    public class CategoryController : Controller
    {
        CategoryService categoryService;
        // GET: Category
        public async Task<ActionResult> Index(long id)
        {
            Category cat = null;
            try
            {
                categoryService = new CategoryService();
                var response = await categoryService.GetbyId(id);
                if (response.Status)
                    cat = response.Data;
                else
                    ModelState.AddModelError(string.Empty, response.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(cat);
        }
    }
}