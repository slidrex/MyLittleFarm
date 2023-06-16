using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerConnector : MonoBehaviour
{
    [SerializeField] private ClientManager _clientManager;
    private void Awake()
    {
        _clientManager.Connect();
    }
}
