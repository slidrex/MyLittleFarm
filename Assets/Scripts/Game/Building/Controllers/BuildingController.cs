using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField] private BuildingDatabase _database;
    [SerializeField] private PlayerBuildingController _playerBuilding;
    private void Awake()
    {
        _database.Init();
    }
    public void InstantiateBuildings(BuildingModel[] buildings)
    {
        foreach (BuildingModel building in buildings)
        {
            InstantiateBuilding(building);

        }
    }
    public void InstantiateBuilding(BuildingModel building)
    {
        var templateObj = _database.GetBuilding((ushort)building.BuildingTempalteId);
        Vector2 position = new Vector2(building.PositionX, building.PositionY);
        var obj = Instantiate(templateObj.Object, position, Quaternion.identity);
        obj.Construct(building.BuildingId);
    }
}
