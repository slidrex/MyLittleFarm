using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : HoverableObject
{
    protected override void OnPointerDown(bool isOpen)
    {
        var screen = PlayerScreenController.Screen.Chest;
        if (isOpen == false) screen = PlayerScreenController.Screen.None;
        GamePointerHandler.Instance.PlayerScreenController.ActivateScreen(screen);
    }
}
