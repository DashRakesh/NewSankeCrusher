using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public List<Transform> bodyparts = new List<Transform>();

    [Range(0.0f, 1.0f)] public float smoothTime = 0.5f;
 
    private void FixedUpdate()
    {
        CamFollow();
    }

    public void CamFollow()
    {
        Transform camera = GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform;
        Vector3 cameraVelocity = Vector3.zero;
        camera.position = Vector3.SmoothDamp(camera.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10), ref cameraVelocity, smoothTime);
    }
}
