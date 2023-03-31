using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]Image lifeViewer;
    [SerializeField]List<GameObject> heartViewer = new List<GameObject>();
    [SerializeField]float m_life;
    [SerializeField]int m_playerType, heartViewerLives = 3;
    Rigidbody physicsManager;
    private float InitialLife;
    public float m_Life
    {
        get{return m_life;}
        set{m_life = value;}
    } 
    public int m_PlayerType
    {
        get{return m_PlayerType;}
        set{m_PlayerType = value;}
    }   
    // Start is called before the first frame update
    void Start()
    {
        if(m_playerType == 0) physicsManager = GetComponent<Rigidbody>();
       
        InitialLife = m_life;
        if(m_playerType == 0)fillList();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_playerType == 1)lifeViewer.fillAmount = m_life/InitialLife;
        if(m_playerType == 0 && heartViewerLives > m_life)
        {
            GameObject destructable = heartViewer[heartViewerLives - 1];
            heartViewerLives --;            
            destructable.SetActive(false);

        }
        if(m_life <=0)SceneManager.LoadScene("Level1");
        
    }
    public void fillList()
    {
        heartViewerLives = 3;
        
        foreach(GameObject g in heartViewer)
        {
            g.SetActive(true);

        }
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(m_playerType == 0 && other.gameObject.layer == 3)
        {
            Vector3 hitDirection = transform.position - other.gameObject.transform.position;            
            physicsManager.AddForce(hitDirection * 150,ForceMode.Impulse);
            
            
        }
        
    }
    

    
    
}
