using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Serializable]
    public struct ScreenObject
    {
        public GameObject ScreenGameObject;
        public UIScreen ScreenType;
    }
    public static UIController Instance;
    [SerializeField] private ScreenObject[] _UIScreens;
    private int _currentScreen;
    private void Awake()
    {
        Instance = this;
    }
    public enum UIScreen
    {
        None,
        Shop,
        BuildingUpgradeMenu
    }
    private void Start()
    {
        EnableScreen(UIScreen.None);
    }
    public GameObject EnableScreen(UIScreen screen)
    {
        _UIScreens[_currentScreen].ScreenGameObject.SetActive(false);
        for(int i = 0; i  < _UIScreens.Length; i++)
        {
            if (_UIScreens[i].ScreenType == screen)
            {
                _currentScreen = i;
                _UIScreens[i].ScreenGameObject.SetActive(true);
                return _UIScreens[i].ScreenGameObject;
            }
        }
        return null;
    }
    public bool CloseScreenIfActive(UIScreen screen)
    {
        var _screen = _UIScreens[_currentScreen];
        bool isActive = _screen.ScreenGameObject.activeSelf;
        _screen.ScreenGameObject.SetActive(false);
        return isActive;
    }
}