using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    private EnemyIA m_enemyDecisions;
    private EnemyType enemyType;
    private GameObject[] m_FollowTargets = new GameObject[2];
    [SerializeField] float m_movementSpeed;    
    // Update is called once per frame
    void Start()
    {
        m_enemyDecisions = GetComponent<EnemyIA>();
        enemyType = GetComponent<EnemyType>();
        m_FollowTargets[0] = GameObject.Find("Coletor");
        m_FollowTargets[1] = GameObject.Find("Cannon");        
    }
    void FixedUpdate()
    {
        if(enemyType.M_type != "EnemyBoss")
        {
            switch(m_enemyDecisions.Decisions())
        {
            case 0:
            transform.position = Vector3.MoveTowards(transform.position,m_FollowTargets[0].transform.position,m_movementSpeed * Time.deltaTime* 2f);
            
            break;

            case 1:
            transform.position = Vector3.MoveTowards(transform.position,m_FollowTargets[1].transform.position,m_movementSpeed * Time.deltaTime );           
            break;
        } 

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,m_FollowTargets[1].transform.position,m_movementSpeed * Time.deltaTime / 3); 
        }
               
    }
}
