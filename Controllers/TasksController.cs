using Lab5_ED1.Helpers;
using Lab5_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5_ED1.Controllers
{
    public class TasksController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                Storage.Instance.CurrentUser = collection["search"].ToLower();
                var position = collection["Position"];
                if (position == "manager")
                {
                    return RedirectToAction("DevelopersList");  
                }
                else
                {
                    //Btn obtener task
                    //Ingresar task
                    var user = Storage.Instance.Developers.Find(x => x.User == Storage.Instance.CurrentUser);
                    if (user == null)
                    {
                        var NewUser = new Developer() { User = Storage.Instance.CurrentUser };
                        Storage.Instance.Developers.Add(NewUser);
                    }
                    else
                    {

                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DevelopersList()
        {
            return View(Storage.Instance.Developers);
        }

        public ActionResult DeveloperProfile()
        {
            return View();
        }

        public ActionResult DeveloperReview(Developer developer)
        {
            //var taskList = new List<TasksModel>();
            //for (int i = 0; i < developer.Tasks.TasksQuantity; i++)
            //{
            //    taskList.Add(developer.Tasks.Delete);
            //}
            //var dev = new DeveloperForReview() { User = developer.User, Tasks = taskList };
            return View(developer);
        }
    }
}
