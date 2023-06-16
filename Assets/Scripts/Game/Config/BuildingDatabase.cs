using Assets.Scripts.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyLittleFarm/Config-Handlers/Building")]
public class BuildingDatabase : ScriptableObject
{
    [Serializable]
    public class Building
    {
        public ushort BuildingID;
        public PlaceableObject Object;
    }
    [SerializeField]
    private Building[] _buildings;
    private Dictionary<ushort, Building> _buildingsMap;
    public void Init()
    {
        _buildingsMap = new();
        foreach (var building in _buildings)
        {
            _buildingsMap.Add(building.BuildingID, building);
        }
    }
    public Building GetBuilding(ushort handler)
    {
        if (_buildingsMap.ContainsKey(handler) == false) throw new BuildingTemplateNotExistException();
        return _buildingsMap[handler];
    }
}
