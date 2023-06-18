using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        GamePointerController.Instance.TriggerObject(this);
    }
    public bool Trigger(bool isRepeated)
    {
        if (isRepeated)
        {
            GamePointerController.Instance.DeactivateIfActive(this);
        }
        return OnActivate(!isRepeated);
    }
    protected void DeactivateIfActive() => GamePointerController.Instance.DeactivateIfActive(this);
    protected abstract bool OnActivate(bool isActive);
}
