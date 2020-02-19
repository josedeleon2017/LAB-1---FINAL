using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LAB1_FINAL.Models;
using LAB1_FINAL.Helpers;

namespace LAB1_FINAL.Controllers
{
    public class C_PlayerController : Controller
    {
        // GET: C_Player
        public ActionResult Index()
        {
            var player1 = new PlayerModel { Name = "José", LastName = "De Leon", Position = "MD", Club = "CHI", Salary = 30000, };
            PlayerModel.C_Save(player1);
            return View(Storage.Instance.C_playerList);
        }

        // GET: C_Player/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: C_Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: C_Player/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {          
                // TODO: Add insert logic here
                try
                {
                    var player = new PlayerModel
                    {
                        Name = collection["Name"],
                        LastName = collection["LastName"],
                        Club = collection["Club"],
                        Position = collection["Position"],
                        Salary = int.Parse(collection["Salary"]),
                    };

                    PlayerModel.C_Save(player);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }                     
        }

        // GET: C_Player/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: C_Player/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: C_Player/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: C_Player/Delete/5
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
