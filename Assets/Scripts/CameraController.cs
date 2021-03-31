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
        Zoom(100f);
        Rotation();
    }

    void Zoom(float mult)
    {
        float zoomSpeed = mult*Time.deltaTime;
        float scrollWheel = -Input.mouseScrollDelta.y;

        zoomSpeed*=scrollWheel;
        cam.fieldOfView+=zoomSpeed;

        if(cam.fieldOfView > 45){
            cam.fieldOfView = 45;
        }
        if(cam.fieldOfView < 5){
            cam.fieldOfView = 5f;
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


            float MultBasedOnZoom = (0.01f+Mathf.InverseLerp(0f,30f,cam.fieldOfView))*200f;
            float ConstrainBasedOnZoom = (1.01f-Mathf.InverseLerp(5f,45f,cam.fieldOfView))*75f;

            xRotation += Vector3.right*(direction.y*MultBasedOnZoom);
            xRotation.x = Mathf.Clamp(xRotation.x,-15-ConstrainBasedOnZoom,15+ConstrainBasedOnZoom);

            yRotation += Vector3.up*(-direction.x*MultBasedOnZoom);

            Vector3 finalRotation = xRotation+yRotation;

            TranslateCamera(finalRotation,new Vector3(0,0,-10));
            CamPreviousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    public void TranslateCamera(Vector3 rotation, Vector3 position)
    {
        cam.transform.rotation = Quaternion.Euler(rotation);
        cam.transform.Translate(position);
    }

}
