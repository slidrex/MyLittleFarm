using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogOutViewModel : MonoBehaviour
{
    [SerializeField] private Button[] _logoutButtons;
    private void OnEnable()
    {
        foreach(var button in _logoutButtons)
        {
            button.onClick.AddListener(() => LogOut());
        }
    }
    private void OnDisable()
    {
        foreach (var button in _logoutButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
    private void LogOut()
    {
        FarmCompositeRoot.Instance.ClientManager.Logout();
    }
}
