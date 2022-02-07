using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private void Start() {
        float orthoSize = 18 * Screen.height / Screen.width *0.5f;

        Camera.main.orthographicSize = orthoSize;    
    }
}
