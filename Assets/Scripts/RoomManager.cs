using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using LootLocker.Requests;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager me;

    void Awake()
    {
        if (me != null)
        {
            Destroy(this);
        }
        else
        {
            me = this;
            DontDestroyOnLoad(this);
            
        }
    }

}
