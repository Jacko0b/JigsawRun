using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float smoothTime =0.3f;
    public Vector3 velocity = Vector3.zero;
    public Vector3 offset;
    private void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }

}
