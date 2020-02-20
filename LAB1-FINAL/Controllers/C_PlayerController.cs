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
            var player1 = new PlayerModel { Name = "José", LastName = "De Leon", Position = "MD", Club = "CHI", Salary = 1, };

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
            return RedirectToAction("Index");
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

        //Delete method implemented wtih Node<T>
        public ActionResult Delete(string id)
        {
            try
            {
                var player = new PlayerModel();
                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Name == id )
                    {
                        player = item;
                    }
                }
                Storage.Instance.C_playerList.Delete(player);
                return RedirectToAction("Index");

            }
            catch 
            {
                return RedirectToAction("Index");
            }
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

                foreach (var item in Storage.Instance.C_playerList)
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

        //Search on Custom LinkedList players with the same position
        public ActionResult Index_positions()
        {
            return View(Storage.Instance.C_CurrentplayerList);
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
                Storage.Instance.C_CurrentplayerList.Clear();
                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Position == idPosition)
                    {
                        var current = new PlayerModel();
                        current = item;
                        Storage.Instance.C_CurrentplayerList.AddLast(current);
                    }
                }
                return RedirectToAction("Index_positions");
            }
            catch
            {
                return View();
            }
        }

        //Search on Custom LinkedList players with the same club
        public ActionResult Index_club()
        {
            return View(Storage.Instance.C_CurrentplayerList);
        }
        // GET: S_Player/SearchByPosition/5
        public ActionResult SearchByClub()
        {
            return View();
        }
        // POST: S_Player/SearchByPosition
        [HttpPost]
        public ActionResult SearchByClub(FormCollection collection)
        {
            // TODO: Add insert logic here
            try
            {
                string idClub = collection["Club"];
                Storage.Instance.C_CurrentplayerList.Clear();
                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Club == idClub)
                    {
                        var current = new PlayerModel();
                        current = item;
                        Storage.Instance.C_CurrentplayerList.AddLast(current);
                    }
                }
                return RedirectToAction("Index_club");
            }
            catch
            {
                return View();
            }
        }
       

    }
}
