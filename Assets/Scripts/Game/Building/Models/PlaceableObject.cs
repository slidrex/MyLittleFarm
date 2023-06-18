using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    private Action _sendPlaceRequest;
    public long Id { get; private set; }
    private Action<Collider2D, bool> _onTriggerEnter;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    public bool IsConstructed { get; private set; }
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }
    public void Construct(long id)
    {
        IsConstructed = true;
        Id = id;
    }
    public void StartCarring(Action onClick, Action<Collider2D, bool> onTriggerEnter)
    {
        _collider.isTrigger = true;
        _onTriggerEnter = onTriggerEnter;
        _sendPlaceRequest = onClick;
    }
    public void ChangeColor(Color32 color)
    {
        _spriteRenderer.color = color;
    }
    public void Place(long id)
    {
        IsConstructed = true;
        _collider.isTrigger = false;
        _onTriggerEnter = null;
        Id = id;
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
        if(IsConstructed == false)
            _sendPlaceRequest.Invoke();
    }
}
