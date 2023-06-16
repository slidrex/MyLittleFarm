using Riptide;
using Riptide.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ServerToClient : ushort
{
    SEND_AUTH_STATUS,
    PLOT_EXPAND_RESULT,
    ADD_PLAYER_GOLD
}
public enum ClientToServer : ushort
{
    AUTH_REQUEST,
    BUILD_REQUEST,
    PLOT_EXPAND_REQUEST
}

public class ClientManager : MonoBehaviour
{
    public const string SERVER_HOST = "127.0.0.1:8098";
    public static LoginResponse TargetResponse = default(LoginResponse);
    public static Client Client;
    private void Awake()
    {
        Client = new Client();
        DontDestroyOnLoad(gameObject);
    }
    public void Connect()
    {
        RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);
        Client.Connect(SERVER_HOST);
    }
    public void Logout()
    {
        Client.Disconnect();
        SceneManager.LoadScene(0);
    }
    private void FixedUpdate()
    {
        Client.Update();
    }
    private void OnApplicationQuit()
    {
        Client.Disconnect();
    }
}
