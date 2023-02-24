using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSync : MonoBehaviour
{


    public Animator controller;
    public SpriteRenderer myrendererfront;
    public SpriteRenderer myrendererback;

    public Transform animSyncObj;
    public bool flip = false;

    public void Setup(Animator cont) 
    {
        controller = cont;
    }

    void Update()
    {

        //scale -1 will work better with the animations 
        if (animSyncObj.transform.position.x > 0.1f)
        {
            controller.SetBool("Walking", true);
            controller.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
        }
        else if (animSyncObj.transform.position.x < -0.1f)
        {
            controller.SetBool("Walking", true);
            controller.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }
        else if (Mathf.Abs(animSyncObj.transform.position.y) > 0.1f)
        {
            controller.SetBool("Walking", true);
        }
        else
        {
            controller.SetBool("Walking", false);
        }

        if (animSyncObj.transform.position.y > 0.1f)
        {
            controller.SetBool("Back", true);
        }
        else if (animSyncObj.transform.position.y < -0.1f)
        {
            controller.SetBool("Back", false);
        }


        if (animSyncObj.transform.position.z > 0.1f && animSyncObj.transform.position.z < 1.1f)
        {
            controller.SetBool("Attack", true);
        }
        else
        {
            controller.SetBool("Attack", false);
        }
    }
}
