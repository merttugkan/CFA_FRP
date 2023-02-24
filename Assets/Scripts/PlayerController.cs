using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed; 
    public Rigidbody2D player;
    public CapsuleCollider2D myCollider;
    public PhotonView myView;
    public TMP_Text nametag;
    public Transform animSyncObj;


    public Vector3 startPos;
    // Start is called before the first frame update
    private void Start()
    {
        nametag.text = myView.Owner.NickName;
        GameObject prefab = PlayerManager.me.FindCharacter(myView.Owner.NickName);
        GameObject character = Instantiate(prefab, transform);
        animSyncObj.GetComponent<AnimationSync>().Setup(character.GetComponent<Animator>());

        if (!myView.IsMine)
        {
            nametag.text = myView.Owner.NickName;
            Destroy(player);
            Destroy(myCollider);
            Destroy(this);
        }
        else
        {
            PlayerManager.me.myPlayer = gameObject;
            startPos = transform.position;
        }

    }

    void FixedUpdate()
    {
        if (!myView.IsMine)
        {
            nametag.text = myView.Owner.NickName;
            Destroy(player);
            Destroy(myCollider);
            Destroy(this);
        }

        player.velocity = new Vector3(Input.GetAxis("Horizontal") * playerSpeed, Input.GetAxis("Vertical") * playerSpeed);
        animSyncObj.position = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), animSyncObj.position.z);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
