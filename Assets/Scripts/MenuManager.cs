using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    public static MenuManager me;

    public List<PlayerLogins> ids;

    [Header("Nickname & Password")]
    public TMP_InputField nickname;
    public TMP_InputField password;

    public void LoginID()
    {
        bool idExists = false;
        bool loginSuccess = false;
        foreach (PlayerLogins item in ids)
        {
            if (item.nickname == nickname.text)
            {
                idExists = true;
            }
            loginSuccess = item.CheckPassword(password.text);
        }
        if (idExists && loginSuccess)
        {
            PhotonNetwork.NickName = nickname.text;
            PlayerPrefs.SetString("myname", nickname.text);
        }
        else if (!idExists)
        {
            if (nickname.text == "nickname" || string.IsNullOrEmpty(nickname.text) || string.IsNullOrWhiteSpace(nickname.text))
            {
                return;
                //error try another username
            }
            PhotonNetwork.NickName = nickname.text;
            PlayerPrefs.SetString("myname", nickname.text);
            //basemesh
        }
        else
        {
            return;
            //error try another username
        }
    }

    void Awake()
    {
        me = this;
        nickname.text = PlayerPrefs.GetString("myname", "nickname");
        password.text = PlayerPrefs.GetString("mypassword", "password");
    }

    private void FixedUpdate()
    {
        CCU();

        if (Lobby.activeSelf)
        {
            DisplayPlayersOnTheGame();
        }

        Loading.SetActive(!PhotonNetwork.IsConnected);
    }


    [Header("Pages")]
    public GameObject Loading;
    public GameObject Start;
    public GameObject Settings;
    [Space]
    public GameObject CreateJoin;
    public GameObject Lobby;
    [Space]
    public GameObject Error;




    //these elements are in the lobby page
    [Header("Lobby")]
    public TMP_Text[] playerNames;
    int pc = 0;
    public void DisplayPlayersOnTheGame()
    {
        if (pc == PhotonNetwork.PlayerList.Length)
        {
            return;
        }
        else
        {
            pc = PhotonNetwork.PlayerList.Length;
        }

        int a = 0;
        foreach (Photon.Realtime.Player item in PhotonNetwork.PlayerList)
        {
            playerNames[a].text = item.NickName;
            a++;
        }
        for (; a < 10; a++)
        {
            playerNames[a].text = string.Empty;
        }
    }

    [Header("Game Id Input")]
    public TMP_InputField gameid;

    [Header("Game Name Button")]
    public TMP_Text gamename;

    string roomCode;
    public void Create()
    {
        int a = Random.Range(100, 999);
        string GameName = a.ToString();
        GameManager.me.CreateRoom(GameName);
        roomCode = GameName;
        gamename.text = roomCode;
    }

    public void Join()
    {
        if (string.IsNullOrEmpty(gameid.text) || string.IsNullOrWhiteSpace(gameid.text))
        {
            return;
        }
        GameManager.me.JoinRoom(gameid.text);
        roomCode = gameid.text;
        gamename.text = roomCode;
    }
    public void Leave()
    {
        GameManager.me.LeaveRoom();
        Lobby.SetActive(false);
        //JoinOrCreate.SetActive(true);
    }

    public void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SceneManager.LoadScene(1);
        }
    }

    //pages




    //[Header("General")]
    //public TMP_Text CCU_Text;
    public void CCU()
    {
        Debug.Log("CCU: " + PhotonNetwork.CurrentRoom.PlayerCount.ToString());
        //CCU_Text.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }
}

public class PlayerLogins
{
    public string nickname;
    string password;

    public bool CheckPassword(string pass)
    {
        if (pass == password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
