using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform follow;
    public float dampAmount;

    public Camera myCam;

    private void Start()
    {
        if (PlayerManager.me.myPlayer != null) //
        {
            follow = PlayerManager.me.myPlayer.transform; // PlayerManager.me.myPlayer.transform;
        }
    }

    public Vector3 cameraOffset;
    Vector3 velocity = Vector3.zero;
    void LateUpdate()
    {
        float temp = myCam.orthographicSize;
        temp -= Input.GetAxis("Mouse ScrollWheel") * 10;
        if (temp <= 20)
        {
            temp = 20;
        }
        else if (temp >= 60)
        {
            temp = 60;
        }
        myCam.orthographicSize = temp;

        if (follow == null)
        {
            if (PlayerManager.me.myPlayer != null) //
            {
                follow = PlayerManager.me.myPlayer.transform; // PlayerManager.me.myPlayer.transform;
            }
            return;
        }

        transform.position = Vector3.SmoothDamp(transform.position, follow.position + cameraOffset, ref velocity, dampAmount, 20);

    }
}
