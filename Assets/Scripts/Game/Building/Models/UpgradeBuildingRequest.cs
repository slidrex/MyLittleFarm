using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Building.Models
{
    internal struct UpgradeBuildingRequest
    {
        public long buildingId { get; set; }

        public UpgradeBuildingRequest(long buildingId)
        {
            this.buildingId = buildingId;
        }
    }
}
