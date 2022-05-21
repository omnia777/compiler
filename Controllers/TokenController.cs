using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Services;
using WebApplication3.ViewModels;
using Newtonsoft.Json;
namespace WebApplication3.Controllers
{
    public class TokenController : Controller
    {
        Compiler Compiler = new Compiler() ;

       


       [HttpGet]
        public ActionResult SaveRecord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveRecord(String content, HttpPostedFileBase browse)
        {
            if (browse != null)
            {


            string pic = System.IO.Path.GetFileName(browse.FileName);
            string path = System.IO.Path.Combine(Server.MapPath("~/files/"),pic);
            browse.SaveAs(path);
            string sas = "C:\\Users\\Ahmed\\Desktop\\WebApplication3\\WebApplication3\\WebApplication3\\files\\" + pic;
            string s = Compiler.getCodeFromFile(sas);

            var list = Compiler.DisplayTokens(s);
            ViewBag.Emp_data = list;
            }
            else if (content!=null)
            {
                string s = Compiler.getCodeFromFile(content);

                var list = Compiler.DisplayTokens(s);
                ViewBag.Emp_data = list;
            }
            return View();
        }

    }
}