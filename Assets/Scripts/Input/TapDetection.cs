using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetection : MonoBehaviour
{
    Vector3 lastPos;
    
    // Update is called once per frame
    public int TouchPos()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began)
                {
                    lastPos = t.position;
                }                
                else if (t.phase == TouchPhase.Ended)
                {
                    float screenArea = t.position.x / Screen.width;
                    float touchDistance = Vector3.Distance(lastPos, t.position);                    
                    if (screenArea < 0.5f && touchDistance < 0.2f)
                    {
                        Debug.Log("Toque na parte esquerda da tela!");
                        return 1;
                    }
                    else if (screenArea >= 0.5f && touchDistance < 0.2f)
                    {
                        Debug.Log("Toque na parte direita da tela!");
                        return 2;
                    }
                }
            }
        }
        return 0;
    }
    
}
