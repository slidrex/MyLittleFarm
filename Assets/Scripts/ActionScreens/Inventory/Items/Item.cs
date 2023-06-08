using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Item : ScriptableObject
{
    public enum ItemType
    {
        MATERIAL,
        FOOD
    }
    public abstract ItemType Type { get; }
    public Sprite Sprite;
    public ushort ID { get; private set; }
    public string Name;
    public void Init(ushort id)
    {
        ID = id;
    }
}
