using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsPositions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * aspectRatio;
        float screenLimitsX = cameraWidth / 2.5f;
        
        transform.position = new Vector3(screenLimitsX,transform.position.y,transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
