using Newtonsoft.Json;
using Riptide;
using System.Collections;
using TMPro;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AuthenticationUI : MonoBehaviour
{
    public enum AuthRequestType
    {
        LOGIN, REGISTER
    }
    public enum AuthStatus
    {
        OK, NOT_OK
    }
    [SerializeField] private TMP_InputField _usernameField;
    [SerializeField] private TMP_InputField _passwordField;
    [SerializeField] private TextMeshProUGUI _serverOutput;
    [SerializeField] private Button _loginButton;
    [SerializeField] private Button _registerButton;
    private const string LOGIN_ENDPOINT = "http://localhost:8080/auth/register";
    public class RegisterStatus
    {
        public string Status { get; set; }
    }
    private class LoginRequest
    {
        public string login;
        public string password;
        public LoginRequest(string username, string _password)
        {
            login = username;
            password = _password;
        }
    }
    private void Awake()
    {
        _loginButton.onClick.AddListener(() => Login());
        _registerButton.onClick.AddListener(() => Register());
    }

    public void SendAuthStatus(AuthStatus status, AuthRequestType type, string content)
    {
        if(status == AuthStatus.NOT_OK || type == AuthRequestType.REGISTER)
        {
            if(type == AuthRequestType.REGISTER && status == AuthStatus.OK) { _serverOutput.text = (Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterStatus>(content).Status); }
            
            else _serverOutput.text = content;
        }
        else
        {
            LoginResponse resp = JsonConvert.DeserializeObject<LoginResponse>(content);
            ClientManager.TargetResponse = resp;
            SceneManager.LoadScene(1);
        }
    }
    private void Login()
    {
        SendAuthRequest(AuthRequestType.LOGIN, _usernameField.text, _passwordField.text);
    }
    private void Register()
    {
        SendAuthRequest(AuthRequestType.REGISTER, _usernameField.text, _passwordField.text);
    }
    private void SendAuthRequest(AuthRequestType type, string login, string password)
    {
        var msg = Message.Create(MessageSendMode.Reliable, ClientToServer.AUTH_REQUEST);
        msg.AddUShort((ushort)type);
        msg.AddString(login);
        msg.AddString(password);
        ClientManager.Client.Send(msg);
    }
    [MessageHandler((ushort)ServerToClient.SEND_AUTH_STATUS)]
    private static void AuthRequestHandler(Message message)
    {
        var authStatus = (AuthStatus)message.GetUShort();
        var authType = (AuthRequestType)message.GetUShort();
        FindObjectOfType<AuthenticationUI>().SendAuthStatus(authStatus, authType, message.GetString());
    }
}
