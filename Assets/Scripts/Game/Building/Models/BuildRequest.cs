using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BuildRequest
{
    public BuildRequest(long plotId, int positionX, int positionY, int buildingID)
    {
        this.plotId = plotId;
        this.positionX = positionX;
        this.positionY = positionY;
        this.buildingID = buildingID;
    }

    public long plotId { get; set; }
    public int positionX { get; set; }
    public int positionY { get; set; }
    public int buildingID { get; set; }
}