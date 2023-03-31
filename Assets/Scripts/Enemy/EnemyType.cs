using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    [SerializeField]string m_type;
    public string M_type
    {
        get{return m_type;}
        set{m_type = value;}
    }
    [SerializeField]int m_level,m_life;
    [SerializeField]float m_dropTimeMax, m_dropTimeMin;
    [SerializeField]GameObject[] m_ammoDropable;
    private EnemySpawn enemySpawn;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemySpawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawn>();

        gameObject.tag = m_type;
        switch(m_type)
        {
            case "EnemyOrganic":
            string hexColor = "#AFFF00";
            Color color = new Color();
            ColorUtility.TryParseHtmlString(hexColor, out color);            
            gameObject.GetComponent<Renderer>().material.color = color;
            gameObject.GetComponent<Renderer>().material.SetFloat("_Metallic",0);
            m_life = 3;
            StartCoroutine(BulletsDrop());
            break;
            case "EnemyMetal":
             hexColor = "#7089A4";
             color = new Color();
             ColorUtility.TryParseHtmlString(hexColor, out color);            
             gameObject.GetComponent<Renderer>().material.color = color;
             gameObject.GetComponent<Renderer>().material.SetFloat("_Metallic",1);
             m_life = 3;
             StartCoroutine(BulletsDrop());
            break;
            case "EnemyPlastic":
            hexColor = "#FF002F";
             color = new Color();
             ColorUtility.TryParseHtmlString(hexColor, out color);            
             gameObject.GetComponent<Renderer>().material.color = color;
             gameObject.GetComponent<Renderer>().material.SetFloat("_Metallic",0.3f);
             m_life = 3;
             StartCoroutine(BulletsDrop());
            break;
            case "EnemyBoss":
            hexColor = "#1A1A1A";
             color = new Color();
             ColorUtility.TryParseHtmlString(hexColor, out color);            
             gameObject.GetComponent<Renderer>().material.color = color;
             gameObject.GetComponent<Renderer>().material.SetFloat("_Metallic",0.5f);
             transform.localScale = transform.localScale * 2.5f;
             m_life = 20;
            break;

        } 
        
    }
    private void Update() 
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        switch(m_type)
        {
            case "EnemyOrganic":
            if(other.gameObject.tag == "BulletMetal" || other.gameObject.tag == "BulletPlastic")
            {
                    
                    m_life--;
                    Destroy(other.gameObject);
                    if (m_life <= 0)
                    {
                        Instantiate(m_ammoDropable[0], new Vector3(transform.position.x, m_ammoDropable[0].transform.position.y, transform.position.z), m_ammoDropable[0].transform.rotation);
                        Destroy(this.gameObject);
                    }
                
            }
            break;
            case "EnemyMetal":
            if(other.gameObject.tag == "BulletOrganic")
            {
                    
                    m_life--;
                    Destroy(other.gameObject);
                    if (m_life <= 0)
                    {
                        Instantiate(m_ammoDropable[1], new Vector3(transform.position.x, m_ammoDropable[0].transform.position.y, transform.position.z), m_ammoDropable[0].transform.rotation);                        
                        Destroy(this.gameObject);
                    }
            }            
            break;
            case "EnemyPlastic":
            if(other.gameObject.tag == "BulletOrganic")
            {
                    
                    m_life--;
                    Destroy(other.gameObject);
                    if (m_life <= 0)
                    {
                        Instantiate(m_ammoDropable[2], new Vector3(transform.position.x, m_ammoDropable[0].transform.position.y, transform.position.z), m_ammoDropable[0].transform.rotation);
                        Destroy(this.gameObject);
                    }
            }            
            break;
            case "EnemyBoss":
            if(other.gameObject.tag == "BulletMetal" || other.gameObject.tag == "BulletPlastic" || other.gameObject.tag == "BulletOrganic")
            {
                    
                    m_life--;
                    Destroy(other.gameObject);
                    Instantiate(m_ammoDropable[Random.Range(0,3)], new Vector3(transform.position.x, m_ammoDropable[0].transform.position.y, transform.position.z), m_ammoDropable[0].transform.rotation);
                    if (m_life <= 0)
                    {
                        Instantiate(m_ammoDropable[Random.Range(0,3)], new Vector3(transform.position.x, m_ammoDropable[0].transform.position.y, transform.position.z), m_ammoDropable[Random.Range(0,2)].transform.rotation);
                        enemySpawn.BossTime = false;
                        enemySpawn.SpawnerActivator();                        
                        Destroy(this.gameObject);
                    }
                
            }
            break;
        }
        
    }
    IEnumerator BulletsDrop()
    {
        switch(m_type)
        {
            case "EnemyOrganic":
            yield return new WaitForSeconds(Random.Range(m_dropTimeMin,m_dropTimeMax));
            Instantiate(m_ammoDropable[0],new Vector3(transform.position.x,m_ammoDropable[0].transform.position.y,transform.position.z),m_ammoDropable[0].transform.rotation);

            break;
            case "EnemyMetal":
            yield return new WaitForSeconds(Random.Range(m_dropTimeMin,m_dropTimeMax));
            Instantiate(m_ammoDropable[1],new Vector3(transform.position.x,m_ammoDropable[1].transform.position.y,transform.position.z),m_ammoDropable[1].transform.rotation);
            break;
            case "EnemyPlastic":
            yield return new WaitForSeconds(Random.Range(m_dropTimeMin,m_dropTimeMax));
            Instantiate(m_ammoDropable[2],new Vector3(transform.position.x,m_ammoDropable[2].transform.position.y,transform.position.z),m_ammoDropable[2].transform.rotation);
            break;
        }
        StartCoroutine(BulletsDrop());
    }    
}
