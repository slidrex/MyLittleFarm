using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        if(_spriteRenderer == null )
            _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public Vector2Int GetTileSize()
    {
        if(_spriteRenderer == null ) _spriteRenderer = GetComponent<SpriteRenderer>();
        Bounds bounds =  _spriteRenderer.bounds;
        Vector2 dBounds = bounds.max - bounds.min;
        return new Vector2Int(Mathf.CeilToInt(dBounds.x), Mathf.CeilToInt(dBounds.y));
    }
}
