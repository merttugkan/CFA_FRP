using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager me;

    //there used to be a myplayer attribute for the camera,
    //now it is at player manager

    private void Awake()
    {
        if (GameManager.me != null)
        {
            Destroy(this);
            Destroy(gameObject);
        }
        else
        {
            me = this;
            DontDestroyOnLoad(this);
            Connect();
        }
    }

    // Start is called before the first frame update
    void Connect()
    {
        PhotonNetwork.GameVersion = "0.0.1";
        //PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        if (MenuManager.me != null)
        {
            MenuManager.me.Loading.SetActive(false);
        }
        Debug.Log("Connected to Server");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        MenuManager.me.Loading.SetActive(true);
        Debug.Log("Disconnected from Server " + cause);
        //Invoke("Connect", 3f);
        base.OnDisconnected(cause);
    }

    public void CreateRoom(string RoomCode)
    {
        PhotonNetwork.CreateRoom(RoomCode);
    }

    public void JoinRoom(string RoomCode)
    {
        PhotonNetwork.JoinRoom(RoomCode);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void LeaveInGame()
    {
        PhotonNetwork.Disconnect();
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
            Connect();
        }
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Disconnected from room ");

        base.OnLeftRoom();
    }

    public override void OnJoinedRoom()
    {
        MenuManager.me.Lobby.SetActive(true);
        PhotonNetwork.AutomaticallySyncScene = true;
        base.OnJoinedRoom();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        //
        if (scene.buildIndex == 1)
        {
            PhotonNetwork.Instantiate("PlayerManager", Vector3.zero, Quaternion.identity);
        }
        //
    }
}
