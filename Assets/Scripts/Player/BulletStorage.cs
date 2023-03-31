using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStorage : MonoBehaviour
{
    [SerializeField]BulletCollect m_bulletCollect;
    [SerializeField]TapDetection m_tapDetection;
    [SerializeField]Material m_objectColor;
    private Queue<int>bulletQueue = new Queue<int>();
    [SerializeField] int[]bulletQueueView;
    private GameObject container;
    private bool canDeposit=false;
    public Queue<int>BulletQueue
    {
        get{return bulletQueue;}        
    }
    public int[]BulletQueueView
    {
        get{return bulletQueueView;}
        set{bulletQueueView = value;}
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update() 
    {
        
        if(container != null)
        {
            bool organicBullet = m_bulletCollect.BulletType == 1 && m_tapDetection.TouchPos() == 2;
        bool metalicBullet = m_bulletCollect.BulletType == 2 && m_tapDetection.TouchPos() == 2;
        bool plasticBullet = m_bulletCollect.BulletType == 3 && m_tapDetection.TouchPos() == 2;
        if(canDeposit && container.tag == "ConteinerOrganic" && organicBullet)
        {
            bulletQueue.Enqueue(0);
            bulletQueueView = bulletQueue.ToArray();
            string hexColor = "#FFFFFF";
            Color color = new Color();
            ColorUtility.TryParseHtmlString(hexColor, out color);
            m_objectColor.color = color;
            m_bulletCollect.BulletType = 0;
        }
        if(canDeposit && container.tag == "ConteinerMetal" && metalicBullet)
        {
            bulletQueue.Enqueue(1);
            bulletQueueView = bulletQueue.ToArray();
            string hexColor = "#FFFFFF";
            Color color = new Color();
            ColorUtility.TryParseHtmlString(hexColor, out color);
            m_objectColor.color = color;
            m_bulletCollect.BulletType = 0;

        }
        if(canDeposit && container.tag == "ConteinerPlastic" && plasticBullet)
        {
            bulletQueue.Enqueue(2);
            bulletQueueView = bulletQueue.ToArray();
            string hexColor = "#FFFFFF";
            Color color = new Color();
            ColorUtility.TryParseHtmlString(hexColor, out color);
            m_objectColor.color = color;
            m_bulletCollect.BulletType = 0;

        }
        }
        

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        canDeposit = true;
        container = other.gameObject;              
    }
    private void OnTriggerStay(Collider other) 
    {
        canDeposit = true;
    }
    private void OnTriggerExit(Collider other) 
    {
        canDeposit = false;
        
    }
}
