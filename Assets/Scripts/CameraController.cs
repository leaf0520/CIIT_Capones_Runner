using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // reference to the player object
    public Vector3 offset; // the camera's offset from the player

    void LateUpdate()
    {
        // set the camera's position to the player's position plus the offset
        transform.position = player.position + offset;
    }
}
