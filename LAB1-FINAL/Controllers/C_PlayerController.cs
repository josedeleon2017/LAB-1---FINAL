﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
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

        public ActionResult C_CSV()
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
        public ActionResult Delete(string id)
        {
            try
            {
                var player = new PlayerModel();
                foreach (var item in Storage.Instance.C_playerList)
                {
                    if (item.Name == id)
                    {
                        player = item;
                    }
                }
                //AGREGAR DELETE
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

        //Search on LinkedList of C# players with the same position
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
                Storage.Instance.S_CurrentplayerList.Clear();
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
                            PlayerModel.C_Save(player);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }

    }
}
