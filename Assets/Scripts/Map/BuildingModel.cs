using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class BuildingModel : MonoBehaviour
{
    [SerializeField] private Transform _buildingContainer;
    [Serializable]
    public class Building
    {
        public Vector2Int MinPosition { get; private set; }
        public Vector2Int MaxPosition { get; private set; }
        public PlaceableObject BuildingObject;
        public Building(PlaceableObject obj, Vector2Int minPosition)
        {
            MinPosition = minPosition;
            BuildingObject = obj;
            MaxPosition = minPosition + BuildingObject.GetTileSize();
        }
        public bool IsInsideBuilding(Vector2Int minPos, Vector2Int tileSize)
        {
            Vector2Int maxPos = minPos + tileSize;
            return (MinPosition.x < minPos.x && MinPosition.y < minPos.y && MaxPosition.x > minPos.x && MaxPosition.y > minPos.y) ||
                (MinPosition.x < maxPos.x && MinPosition.y < maxPos.y && MaxPosition.x > minPos.x && MaxPosition.y > maxPos.y);
        }
    }
    [Header("Startup")]
    [SerializeField] private PlaceableObject[] _buildings;
    private List<Building> _spawnedBuildings = new List<Building>();
    public void SpawnInitialBuildings(MapModel map)
    {
        foreach(var obj in _buildings)
        {
            SpawnBuilding(obj, map.GetRandomSpacePosition(obj.GetTileSize()));
        }
    }
    public void SpawnBuilding(PlaceableObject building, Vector2Int position)
    {
        var obj = Instantiate(building, (Vector2)position, Quaternion.identity, _buildingContainer);
        _spawnedBuildings.Add(new Building(obj, position));
    }
    public bool IsSpaceFree(Vector2Int space, Vector2Int tileSize)
    {
        foreach (var building in _spawnedBuildings)
        {
            if (building.IsInsideBuilding(space, tileSize)) return false;
        }
        return true;
    }

}
