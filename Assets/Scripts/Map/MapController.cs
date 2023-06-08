using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private MapModel _mapModel;
    [SerializeField] private Vector2Int _mapSize;
    private void Awake()
    {
        _mapModel.InitMap(_mapSize);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _mapModel.ExpandMap(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _mapModel.ExpandMap(false);
        }
    }
}
