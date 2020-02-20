using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
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
        public ActionResult Edit(string name)
        {
            return View();
        }

        public ActionResult S_CSV()
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

<<<<<<< HEAD
        //Search on C# LinkedList players with the same club
        public ActionResult Index_club()
        {
            return View(Storage.Instance.S_CurrentplayerList);
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
                foreach (var item in Storage.Instance.S_playerList)
                {
                    if (item.Club == idClub)
                    {
                        var current = new PlayerModel();
                        current = item;
                        Storage.Instance.S_CurrentplayerList.AddLast(current);
                    }
                }
                return RedirectToAction("Index_club");
            }
            catch
            {
                return View();
            }
=======
        [HttpPost]
        public ActionResult CSV(HttpPostedFileBase postedfile)
        {
            string FilePath;
            if (postedfile != null)
            {
                string Path = Server.MapPath("~/Subidas/");
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                FilePath = Path + System.IO.Path.GetFileName(postedfile.FileName);
                postedfile.SaveAs(FilePath);
                string csvData = System.IO.File.ReadAllText(FilePath);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        try
                        {

                            var player = new PlayerModel
                            {
                                Name = row.Split(',')[2],
                                LastName = row.Split(',')[1],
                                Club = row.Split(',')[0],
                                Position = row.Split(',')[3],
                                Salary = Convert.ToInt32(Convert.ToDouble(row.Split(',')[4])),

                            };
                            PlayerModel.S_Save(player);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return RedirectToAction("Index");
>>>>>>> 9d74e68f2ed4cd4982267d297ecac181bf56b333
        }

    }
}
