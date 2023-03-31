using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    private GameObject colectorP;
    [SerializeField] float m_detectionDistance;
    // Start is called before the first frame update
    void Start()
    {
        
        colectorP = GameObject.Find("Coletor");
    }
    
    public int Decisions()
    {
        if(Vector3.Distance(colectorP.transform.position,transform.position) < m_detectionDistance)
        {
            return 0;
        }
        else
        {
            return 1;
        }        
    }
}
