using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyLittleFarm/Building Template")]
public class BuildingCardTemplate : ScriptableObject
{
    public Sprite IconImage;
    public string Name;
    public uint GoldPerSecond;
    public uint Price;
    public PlaceableObject Object;
}
