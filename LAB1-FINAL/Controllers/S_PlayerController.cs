using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LAB1_FINAL.Models;
using LAB1_FINAL.Helpers;

namespace LAB1_FINAL.Controllers
{
    public class S_PlayerController : Controller
    {
        // GET: S_Player
        public ActionResult Index()
        {
            var player1 = new PlayerModel { Name = "José", LastName = "De Leon", Position = "MD", Club = "CHI", Salary = 30000, };
            PlayerModel.S_Save(player1);
            return View(Storage.Instance.S_playerList);
        }

        // GET: S_Player/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: S_Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: S_Player/Create
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

                PlayerModel.S_Save(player);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: S_Player/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: S_Player/Edit/5
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

        // GET: S_Player/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                var player = new PlayerModel();
                foreach (var item in Storage.Instance.S_playerList)
                {
                    if (item.Name == id)
                    {
                        player = item;
                    }
                }
                Storage.Instance.S_playerList.Remove(player);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // POST: S_Player/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            return View();
        }

        //Search on LinkedList of C# players with espcific name 
       public ActionResult SearchByName()
        {
            return View();
        }
        public ActionResult Index_player(FormCollection collection)
        {
            try
            {
                string idName = collection["Name"];
                PlayerModel player = new PlayerModel();

                foreach (var item in Storage.Instance.S_playerList)
                {
                    if (item.Name == idName || item.LastName == idName)
                    {
                        player = item;
                    }
                }
                return View(player);
            }
            catch 
            {
                return View();
            }
        }

        //Search on LinkedList of C# players with the same position 
        public ActionResult Index_positions()
        {
            return View(Storage.Instance.S_CurrentplayerList);
        }
        // GET: S_Player/SearchByPosition/5
        public ActionResult SearchByPosition()
        {
            return View();
        }
        // POST: S_Player/SearchByPosition
        [HttpPost]
        public ActionResult SearchByPosition(FormCollection collection)
        {
            // TODO: Add insert logic here
            try
            {
                string idPosition = collection["Position"];
                Storage.Instance.S_CurrentplayerList.Clear();
                foreach (var item in Storage.Instance.S_playerList)
                {
                    if (item.Position == idPosition)
                    {
                        var current = new PlayerModel();
                        current = item;
                        Storage.Instance.S_CurrentplayerList.AddLast(current);
                    }
                }
                return RedirectToAction("Index_positions");
            }
            catch
            {
                return View();
            }
        }

    }
}
