using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    [SerializeField] TapDetection m_tapDetect;
    [SerializeField] GameObject[] m_Bullets;
    [SerializeField] BulletStorage m_bulletStorage;
    bool shootInput;
    int bulletsQuantity = 3;
    public int BulletsQuantity
    {
        get{return bulletsQuantity;}
        set{bulletsQuantity = value;}
    }

    bool shooted = false;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {

        shootInput = m_tapDetect.TouchPos() == 1 && m_bulletStorage.BulletQueue.Count > 0;
        if (shootInput && !shooted) StartCoroutine(bulletSelection());





    }
    IEnumerator bulletSelection()
    {
        
        if (shootInput && m_bulletStorage.BulletQueue.Peek() == 0)
        {
            shooted = true;

            Instantiate(m_Bullets[0], gameObject.transform.position, transform.rotation);
            bulletsQuantity --;
            yield return new WaitForSeconds(0.8f);
            shooted = false;
            if (bulletsQuantity <= 0)
            {
                m_bulletStorage.BulletQueue.Dequeue();
                m_bulletStorage.BulletQueueView = m_bulletStorage.BulletQueue.ToArray();
                bulletsQuantity = 3;

                yield return new WaitForSeconds(0.8f);
                shooted = false;
                

            }



        }
        if (shootInput && m_bulletStorage.BulletQueue.Peek() == 1)
        {
            shooted = true;
            Instantiate(m_Bullets[1], gameObject.transform.position, transform.rotation);
            bulletsQuantity --;
            yield return new WaitForSeconds(0.8f);
            shooted = false;
            if (bulletsQuantity <= 0)
            {
                m_bulletStorage.BulletQueue.Dequeue();
                m_bulletStorage.BulletQueueView = m_bulletStorage.BulletQueue.ToArray();
                bulletsQuantity = 3;
                yield return new WaitForSeconds(0.8f);
                shooted = false;
                

            }


        }
        if (shootInput && m_bulletStorage.BulletQueue.Peek() == 2)
        {
            shooted = true;
            Instantiate(m_Bullets[2], gameObject.transform.position, transform.rotation);
            bulletsQuantity --;
            yield return new WaitForSeconds(0.8f);
            shooted = false;
            if (bulletsQuantity <= 0)
            {
                m_bulletStorage.BulletQueue.Dequeue();
                m_bulletStorage.BulletQueueView = m_bulletStorage.BulletQueue.ToArray();
                bulletsQuantity = 3;
                yield return new WaitForSeconds(0.8f);
                shooted = false;
                

            }


        }

    }
}
