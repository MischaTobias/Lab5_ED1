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
                    var user = Storage.Instance.Developers.Find(x => x.User == Storage.Instance.CurrentUser);
                    if (user == null)
                    {
                        var NewUser = new Developer() { User = Storage.Instance.CurrentUser };
                        Storage.Instance.Developers.Add(NewUser);
                    }
                    return RedirectToAction("DeveloperProfile");
                }
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

        public ActionResult DeveloperProfile(int? change)
        {
            int changeTask = (change ?? 0);
            foreach (var developer in Storage.Instance.Developers)
            {
                if (developer.User == Storage.Instance.CurrentUser)
                {
                    if (changeTask == 1)
                    {
                        developer.Tasks.Delete();
                    }
                    developer.CurrentTask = Storage.Instance.Hash.Search(developer.Tasks.Root.Key).Value;
                    return View(developer);
                }
            }
            return View();
        }

        public ActionResult DeveloperReview(Developer developer)
        {
            var taskList = new List<TasksModel>();
            var developerCopy = new Developer() { Tasks = developer.Tasks, User = developer.User };
            for (int i = 0; i < developerCopy.Tasks.TasksQuantity; i++)
            {
                taskList.Add((Storage.Instance.Hash.Search(developerCopy.Tasks.Delete().Key).Value);
            }
            var dev = new DeveloperForReview() { User = developer.User, Tasks = taskList };
            return View(developer);
        }
    }
}
