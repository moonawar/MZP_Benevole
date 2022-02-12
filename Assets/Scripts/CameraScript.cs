using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CameraScript : MonoBehaviour
{
    private void Start() {
        float orthoSize = 18 * Screen.height / Screen.width *0.5f;

        Camera.main.orthographicSize = orthoSize;    
    }



}
