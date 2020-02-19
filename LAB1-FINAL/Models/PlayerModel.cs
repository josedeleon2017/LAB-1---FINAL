using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LAB1_FINAL.Helpers;

namespace LAB1_FINAL.Models
{
    public class PlayerModel : IComparable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
        public int Salary { get; set; }

        public static void C_Save(PlayerModel player)
        {
            Storage.Instance.C_playerList.Insert(player);
        }

        public static void S_Save(PlayerModel player)
        {
            Storage.Instance.S_playerList.AddLast(player);
        }

        public int CompareTo(object obj)
        {
            var comparable = (PlayerModel)obj;
            return Name.CompareTo(comparable.Name);
        }
    }
}