using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MapModel : MonoBehaviour
{
    [Header("Map")]
    [SerializeField] private SpriteRenderer _mapSpriteRenderer;
    [SerializeField] private Grid _mapGrid;
    [SerializeField] private GridLayout _mapLayout;
    public static Vector2Int MapSize { get; private set; }
    public static Vector2Int MinFreeMapPosition { get; private set; }
    public static Vector2Int MaxFreeMapPosition { get; private set; }
    public void InitMap(Vector2Int mapSize)
    {
        SetMapSize(mapSize);
    }
    public void ExpandMap(bool horizontal)
    {
        Vector2Int size = MapSize + (horizontal ? Vector2Int.right : Vector2Int.up) * 2;
        SetMapSize(size);
    }
    public void SetMapSize(Vector2Int mapSize)
    {
        Vector2 availableSpaceMap = mapSize - Vector2.one / 2;
        _mapSpriteRenderer.size = availableSpaceMap;

        MinFreeMapPosition = new Vector2Int((int)_mapSpriteRenderer.bounds.min.x, (int)_mapSpriteRenderer.bounds.min.y);
        MaxFreeMapPosition = new Vector2Int((int)_mapSpriteRenderer.bounds.max.x, (int)_mapSpriteRenderer.bounds.max.y);
        MapSize = mapSize;
        _mapSpriteRenderer.size = mapSize + Vector2Int.one * 2;
    }
    public Vector2Int GetRandomSpacePosition(Vector2Int tileSize)
    {
        Vector2Int position = new Vector2Int(Random.Range(MinFreeMapPosition.x, MaxFreeMapPosition.x - tileSize.x + 2), Random.Range(MinFreeMapPosition.y, MaxFreeMapPosition.y - tileSize.y + 2));
        return position;
    }
    public static bool IsInsidePlot(Vector2 position) => position.x >= MinFreeMapPosition.x && position.x <= MaxFreeMapPosition.x && position.y <= MaxFreeMapPosition.y && position.x >= MinFreeMapPosition.y;
}