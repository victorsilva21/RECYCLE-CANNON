using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    Renderer bulletRenderer;
    Camera cameraMain;
    // Start is called before the first frame update
    void Start()
    {
        bulletRenderer = GetComponent<Renderer>();
        cameraMain = Camera.main;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward);            
    }
    void Update()
    {
        Vector3 viewportPos = cameraMain.WorldToViewportPoint(bulletRenderer.bounds.center);
        bool isVisible = viewportPos.z > 0 && viewportPos.x > 0 && viewportPos.x < 1 && viewportPos.y > 0 && viewportPos.y < 1;
               
        if(isVisible != true)
        {
            Destroy(this.gameObject);
        }
    }
}
