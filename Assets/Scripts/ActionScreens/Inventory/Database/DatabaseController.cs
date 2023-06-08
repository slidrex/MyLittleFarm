using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController : MonoBehaviour
{
    [SerializeField] private ItemDatabase _itemDatabase;
    private void Awake()
    {
        _itemDatabase.Setup();
    }
}
