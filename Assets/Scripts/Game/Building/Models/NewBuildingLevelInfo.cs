using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Building.Models
{
    internal struct NewBuildingLevelInfo
    {
        public int oldGoldPerSecond { get; set; }
        public string buildingName { get; set; }
        public long buildingId { get; set; }
        public int newGoldPerSecond { get; set; }
        public int newLevel { get; set; }
        public int cost { get; set; }
    }
}
