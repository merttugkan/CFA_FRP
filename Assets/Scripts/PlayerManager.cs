using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager me;
    public GameObject myPlayer;

    public GameObject baseCharacter;
    public List<CustomCharacter> customCharacterList;

    // Start is called before the first frame update
    void Awake()
    {
        me = this;
    }

    public GameObject FindCharacter(string name)
    {
        foreach (CustomCharacter customChar in customCharacterList) 
        {
            if (customChar.name == name)
            {
                return customChar.prefab;
            }
        }
        return baseCharacter;
    }

    public PhotonView myView;

    private void Start()
    {
        if (myView.IsMine)
        {
            myPlayer = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        }
    }
}

[System.Serializable]
public class CustomCharacter 
{
    public string name;
    public GameObject prefab;
}
