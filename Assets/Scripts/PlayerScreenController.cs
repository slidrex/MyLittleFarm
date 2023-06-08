using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScreenController : MonoBehaviour
{
    [SerializeField] private ItemRepository _itemRepository;
    public enum Screen
    {
        None,
        Chest,
        Workbench
    }
    [Serializable]
    private struct ScreenObject
    {
        public Screen Screen;
        public GameObject ScreenObj;
    }
    [SerializeField] private ScreenObject[] _playerScreens;
    private readonly Dictionary<Screen, GameObject> _screens = new();
    public Screen CurrentScreen { get; private set; }
    private InventoryAdapter<Item> _currentAdapter;
    private void Awake()
    {
        LoadScreens();
    }
    private void LoadScreens()
    {
        foreach(var screen in _playerScreens)
        {
            _screens.Add(screen.Screen, screen.ScreenObj);
        }
    }
    public void ActivateScreen(Screen screen)
    {
        if (CurrentScreen != Screen.None)
        {
            _screens[CurrentScreen].gameObject.SetActive(false);
        }
        
        CurrentScreen = screen;
        if(screen != Screen.None)
        {
            var newScreen = _screens[screen];
            newScreen.SetActive(true);
            if(newScreen.TryGetComponent<IInventory<Item>>(out var inv))
            {
                _currentAdapter = new(inv, _itemRepository);
                _currentAdapter.Start();
            }
        }
        else
        {
            _currentAdapter?.Stop();
            _currentAdapter = null;
        }
    }
}
