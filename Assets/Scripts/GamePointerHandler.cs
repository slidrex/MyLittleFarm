using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GamePointerHandler : MonoBehaviour
{
    [SerializeField] private Image _pointerImage;
    public static GamePointerHandler Instance;
    public PlayerScreenController PlayerScreenController;
    private HoverableObject _hoverableObject;
    private void Awake()
    {
        if (Instance == null) Instance = this;

    }
    public void SetHoveredObject(HoverableObject obj)
    {
        _hoverableObject = obj;
        _pointerImage.gameObject.SetActive(true);
        _pointerImage.sprite = obj.PointerSprite;
    }
    public void ActivateHoveredObject(HoverableObject obj)
    {

        _hoverableObject = obj;
    }
    public void UnhoverHoveredObject(HoverableObject obj)
    {
        _pointerImage.gameObject.SetActive(false);
        _hoverableObject = null;
    }
    private void Update()
    {
        if(_hoverableObject != null) UpdatePointerImage();
    }
    private void UpdatePointerImage()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePosition = new Vector2(mousePos.x + 0.5f, mousePos.y - 0.5f);
        
        if ((Vector2)_pointerImage.transform.position != mousePosition)
            _pointerImage.transform.position = mousePosition;

    }
}
