using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollowScript : MonoBehaviour
{
    [SerializeField]
    public Transform player1;
    [SerializeField]
    public Transform player2;
    public float smoothTime = 0.5f;

    private Vector3 velocity;

    void LateUpdate()
    {
        if (player1 != null && player2 != null)
        {
            // Find the midpoint between the two players
            Vector3 midpoint = (player1.position + player2.position) / 2f;

            // Set the camera's position to the midpoint with a smooth follow
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(midpoint.x, midpoint.y, transform.position.z), ref velocity, smoothTime);
        }
    }
}
