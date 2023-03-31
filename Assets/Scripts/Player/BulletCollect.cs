using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollect : MonoBehaviour
{
    [SerializeField] TapDetection tapDetection;
    [SerializeField] Material m_objectColor;
    private int bulletType = 0;
    private GameObject bullet;
    private bool canCollect = false;
    // Start is called before the first frame update
    void Start()
    {
        string hexColor = "#FFFFFF";
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hexColor, out color);
        m_objectColor.color = color;


    }

    // Update is called once per frame
    void Update()
    {
        if (canCollect && bulletType == 0 && tapDetection.TouchPos() == 2)
        {
            switch (bullet.tag)
            {
                case "Organic":
                    bulletType = 1;
                    string hexColor = "#6F2100";
                    Color color = new Color();
                    ColorUtility.TryParseHtmlString(hexColor, out color);
                    m_objectColor.color = color;
                    Destroy(bullet.gameObject);

                    break;
                case "Metal":
                    bulletType = 2;
                    hexColor = "#C5C300";
                    color = new Color();
                    ColorUtility.TryParseHtmlString(hexColor, out color);
                    m_objectColor.color = color;
                    Destroy(bullet.gameObject);
                    break;
                case "Plastic":
                    bulletType = 3;
                    hexColor = "#CA0004";
                    color = new Color();
                    ColorUtility.TryParseHtmlString(hexColor, out color);
                    m_objectColor.color = color;
                    Destroy(bullet.gameObject);
                    break;


            }
        }

    }
    public int BulletType
    {
        get { return bulletType; }
        set { bulletType = value; }

    }

    private void OnTriggerEnter(Collider other)
    {
        canCollect = true;
        bullet = other.gameObject;
    }
    private void OnTriggerStay(Collider other) 
    {
        canCollect = true;        
    }
    private void OnTriggerExit(Collider other) 
    {
        canCollect = false;        
    }

}
