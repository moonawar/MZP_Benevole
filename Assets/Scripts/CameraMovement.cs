using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 touchStart; bool panAllowed = true; bool isPanning;
    float dampEndTime; Vector3 cameraTargetPos, direction; 
    public float zoomMax = 10f;
    public float zoomMin = 3.9f;
    Vector3 velocity = Vector3.zero;
    private void Awake() {
        
    }
    
    void Zoom(float increment){
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize-increment, zoomMin, zoomMax);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            panAllowed = true;
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
        if (Input.touchCount == 2){
            panAllowed = false;
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroFirstPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneFirstPos = touchOne.position - touchOne.deltaPosition;

            float firstMagnitude = (touchZeroFirstPos - touchOneFirstPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude-firstMagnitude;
            Zoom(difference*0.001f);

        }
        else if ((Input.GetMouseButton(0) && panAllowed) || (Time.time < dampEndTime && panAllowed)){
            if (Input.GetMouseButton(0)){
                direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                cameraTargetPos = Camera.main.transform.position + direction;
                dampEndTime = Time.time + 1f;
            }
          
            if (!Input.GetMouseButton(0)){
                Camera.main.transform.position = 
                    Vector3.SmoothDamp(Camera.main.transform.position, cameraTargetPos+direction, 
                    ref velocity, 0.25f);
            } else {
                Camera.main.transform.position = 
                    Vector3.SmoothDamp(Camera.main.transform.position, cameraTargetPos, 
                    ref velocity, 0.25f);
            }
            
        }
    }
}
