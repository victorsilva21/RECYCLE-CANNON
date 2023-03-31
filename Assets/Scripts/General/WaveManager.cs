using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveManager : MonoBehaviour
{
    [SerializeField] EnemySpawn m_enemySpawn;
    int m_waveLevel = 1;
    [SerializeField] float m_multiplicator;
    [SerializeField] Text m_timeViewer, m_waveViewer;
    [SerializeField] PlayerLife[] m_playerLife = new PlayerLife[2];
    private float time = 60;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bossFight());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time > 0) time -= Time.deltaTime;
        m_timeViewer.text = "Tempo " + time.ToString("00");
        m_waveViewer.text = "Wave " + m_waveLevel.ToString();



    }
    IEnumerator bossFight()
    {
        yield return new WaitUntil(() => time <= 0);
        m_enemySpawn.BossTime = true;
        yield return new WaitUntil(() => m_enemySpawn.BossTime == false);
        time = 60;
        m_waveLevel++;

        m_playerLife[1].m_Life += 10;
        if (m_playerLife[1].m_Life > 20) m_playerLife[1].m_Life = 20;
        m_playerLife[0].m_Life = 3;
        m_playerLife[0].fillList();

        m_enemySpawn.m_SpawnTime /= m_multiplicator;
        StartCoroutine(bossFight());



    }
}
