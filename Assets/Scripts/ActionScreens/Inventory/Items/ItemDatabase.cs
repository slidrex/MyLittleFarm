using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PayDay/Databases/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField] private Item[] _items;
    public Dictionary<ushort, Item> Items;
    public void Setup()
    {
        Items = new Dictionary<ushort, Item>(_items.Length);
        for(int i = 0; i < _items.Length; i++)
        {
            ushort id = (ushort)(i + 1);
            Items[id] = _items[i];
            _items[i].Init(id);
        }
    }
}
