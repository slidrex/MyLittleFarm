public class Workbench : HoverableObject
{
    protected override void OnPointerDown(bool isOpen)
    {
        var screen = PlayerScreenController.Screen.Workbench;
        if (isOpen == false) screen = PlayerScreenController.Screen.None;
        GamePointerHandler.Instance.PlayerScreenController.ActivateScreen(screen);
    }
}
