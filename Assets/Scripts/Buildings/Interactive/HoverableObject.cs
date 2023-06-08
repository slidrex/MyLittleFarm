using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class HoverableObject : MonoBehaviour
{
    public Sprite PointerSprite;
    private bool isActivate;
    public void OnMouseEnter()
    {
        GamePointerHandler.Instance.SetHoveredObject(this);
    }
    public void OnMouseDown()
    {
        isActivate = !isActivate;
        GamePointerHandler.Instance.ActivateHoveredObject(this);
        OnPointerDown(isActivate);
    }
    public void OnMouseExit()
    {
        GamePointerHandler.Instance.UnhoverHoveredObject(this);
    }
    protected abstract void OnPointerDown(bool isOpen);
}
