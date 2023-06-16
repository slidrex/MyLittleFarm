using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    private Action _sendPlaceRequest;
    private Action<Collider2D, bool> _onTriggerEnter;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private bool _isCarring;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }
    public void StartCarring(Action onClick, Action<Collider2D, bool> onTriggerEnter)
    {
        _collider.isTrigger = true;
        _onTriggerEnter = onTriggerEnter;
        _sendPlaceRequest = onClick;
        _isCarring = true;
    }
    public void ChangeColor(Color32 color)
    {
        _spriteRenderer.color = color;
    }
    public void StopCarring()
    {
        _collider.isTrigger = false;
        _onTriggerEnter = null;
        _isCarring = false;
        _sendPlaceRequest = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onTriggerEnter.Invoke(collision, true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _onTriggerEnter.Invoke(collision, false);
    }
    private void OnMouseDown()
    {
        if(_isCarring)
            _sendPlaceRequest.Invoke();
    }
}
