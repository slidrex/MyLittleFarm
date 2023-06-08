using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public Inventory Inventory { get; private set; }
    [field: SerializeField] public PlayerMovement Movement { get; private set; }
}
