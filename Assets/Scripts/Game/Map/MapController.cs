using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private MapModel _mapModel;
    public void InitMap(Vector2Int size)
    {
        _mapModel.InitMap(size);
    }
    public void ExpandMap(bool horizontal)
    {
        _mapModel.ExpandMap(horizontal);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlotRequestHandler.SendExpandRequest(horizontal: true);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlotRequestHandler.SendExpandRequest(horizontal: false);
        }
    }
}
