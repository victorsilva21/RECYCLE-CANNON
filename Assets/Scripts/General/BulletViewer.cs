using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletViewer : MonoBehaviour
{
    [SerializeField]BulletStorage bulletStorage;
    [SerializeField]ShootBullets shootBullets;
    Image bulletView;
    [SerializeField]Text bulletCount; 
    // Start is called before the first frame update
    void Start()
    {
        bulletView = GetComponent<Image>();
        bulletCount.text = "0";        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(bulletStorage.BulletQueue.Count>0)bulletCount.text = shootBullets.BulletsQuantity.ToString();
        if(bulletStorage.BulletQueue.Count<=0)
        {
           string hexColor = "#FFFFFF";
            Color color = new Color();
            ColorUtility.TryParseHtmlString(hexColor, out color);
            bulletView.color = color; 
        }
        if(bulletStorage.BulletQueue.Count>0)
        {
            switch(bulletStorage.BulletQueue.Peek())
        {
            
            case 0:
            string hexColor = "#6F2100";
            Color color = new Color();
            ColorUtility.TryParseHtmlString(hexColor, out color);
            bulletView.color = color;
            break;
            case 1:
            hexColor = "#C5C300";
            color = new Color();
            ColorUtility.TryParseHtmlString(hexColor, out color);
            bulletView.color = color;
            break;
            case 2:
            hexColor = "#CA0004";
            color = new Color();
            ColorUtility.TryParseHtmlString(hexColor, out color);
            bulletView.color = color;
            break;
        }

        }
        
        
        
        
    }
}
