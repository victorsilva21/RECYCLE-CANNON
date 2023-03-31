using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    float time = 0;
    PlayerLife playerLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(time>0)
        {
            time -= Time.deltaTime;
        }
    }
    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Player" && time<=0 && this.gameObject.tag != "EnemyBoss")
        {
            playerLife = other.gameObject.GetComponent<PlayerLife>();
            playerLife.m_Life --;
            time = 1;

        }
        else if(other.gameObject.tag == "Player" && time<=0)
        {
            playerLife = other.gameObject.GetComponent<PlayerLife>();
            playerLife.m_Life -= 3;
            time = 1;
        }
        
    }
}
