using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;
    Transform Earth;
    Vector3 CamPreviousPosition;
    Vector3 xRotation, yRotation;

    void Start()
    {
        cam = this.GetComponent<Camera>();
        Earth = GameObject.FindWithTag("EarthTag").transform;
    }

    void Update() 
    {
        Zoom(50f);
        Rotation();
    }

    void Zoom(float mult)
    {
        float zoomSpeed = mult*Time.deltaTime;
        float scrollWheel = -Input.mouseScrollDelta.y;

        zoomSpeed*=scrollWheel;

        cam.orthographicSize+=zoomSpeed;

        if(cam.orthographicSize > 6){
            cam.orthographicSize = 6;
        }
        if(cam.orthographicSize < 0.5){
            cam.orthographicSize = 0.5f;
        }
    }

    void Rotation()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CamPreviousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 direction = CamPreviousPosition - cam.ScreenToViewportPoint(Input.mousePosition);
            cam.transform.position = Vector3.zero;


            float MultBasedOnZoom = (0.01f+Mathf.InverseLerp(0f,6f,cam.orthographicSize))*200f;
            float ConstrainBasedOnZoom = (1.01f-Mathf.InverseLerp(0.5f,6f,cam.orthographicSize))*75f;

            xRotation += Vector3.right*(direction.y*MultBasedOnZoom);
            xRotation.x = Mathf.Clamp(xRotation.x,-15-ConstrainBasedOnZoom,15+ConstrainBasedOnZoom);

            yRotation += Vector3.up*(-direction.x*MultBasedOnZoom);

            Vector3 finalRotation = xRotation+yRotation;

            cam.transform.rotation = Quaternion.Euler(finalRotation);
            cam.transform.Translate(new Vector3(0,0,-10));
            CamPreviousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }

}
