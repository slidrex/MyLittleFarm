using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePointerController : MonoBehaviour
{
    public static GamePointerController Instance;
    private InteractableObject _objectInInteract;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        
    }
    public void TriggerObject(InteractableObject obj)
    {
        if (_objectInInteract != null && _objectInInteract != obj)
        {
            _objectInInteract.Trigger(true);
        }
        bool successfulTrigger = obj.Trigger(_objectInInteract == obj);
        if(successfulTrigger)
            _objectInInteract = obj;
    }
    public void DeactivateIfActive(InteractableObject obj)
    {
        if(_objectInInteract == obj)
        {
            _objectInInteract = null;
        }
    }
}
