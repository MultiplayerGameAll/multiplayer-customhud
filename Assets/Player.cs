using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public float moveSpeed = 0.2f;
    public float moveRotation = 20;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed);
            transform.Rotate(0, Input.GetAxis("Horizontal") * moveRotation, 0);
        }
    }

}
