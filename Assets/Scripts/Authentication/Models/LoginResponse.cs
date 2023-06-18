using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LoginResponse
{
    public string Login { get; set; }
    public long Gold { get; set; }
    public PlotModel Plot { get; set; }
}
public struct PlotModel
{
    public int SizeX { get; set; }
    public int SizeY { get; set; }
    public long UserID { get; set; }
    public long PlotID { get; set; }
    public BuildingModel[] Buildings { get; set; }
}
public struct BuildingModel
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Level { get; set; }
    public int BuildingId { get; set; }
    public int BuildingTempalteId { get; set; }
}