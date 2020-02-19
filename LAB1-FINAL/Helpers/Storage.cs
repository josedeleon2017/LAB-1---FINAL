﻿using System;
using System.Linq;
using System.Web;
using LAB1_FINAL.Models;
using System.Collections.Generic;

namespace LAB1_FINAL.Helpers
{
    public class Storage
    {
        private static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        //AGREGAR ESTRUCTURA AQUI
        public LinealStructures.Structures.LinkedList<PlayerModel> C_playerList = new LinealStructures.Structures.LinkedList<PlayerModel>();
        public LinkedList<PlayerModel> S_playerList = new LinkedList<PlayerModel>();
    }
}