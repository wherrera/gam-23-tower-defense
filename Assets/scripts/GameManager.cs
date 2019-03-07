using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Manager<GameManager> {

    public Waypoint startPosition;
    public Stage stage;
    public Wave[] waves;
    public Text killsText;

    private int m_CurrentWave;
    private int m_Kills;

    public void AddKills()
    {
        m_Kills++;
        killsText.text = m_Kills.ToString();
    }

    IEnumerator StartWave()
    {
        Wave wave = waves[m_CurrentWave];

        for(int i=0;i<wave.count;i++)
        {
            Creep creep = Instantiate<Creep>(wave.creep, startPosition.transform.position, Quaternion.identity);

            creep.waypoints = stage.waypoints;

            yield return new WaitForSeconds(1f);
        }
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(StartWave());
	}
}
