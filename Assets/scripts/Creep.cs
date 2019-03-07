using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour {

    public float hp;
    public float speed;
    public Vector3 moveDirection;
    public GameObject explosion;

    public Waypoint[] waypoints;
    private int m_CurrentWaypoint;

    public void ApplyDamage(float damage)
    {
        hp -= damage;

        if(hp <= 0f)
        {
            GameManager.Instance.AddKills();

            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    void FaceTarget(Waypoint waypoint)
    {
        Vector2 toward = (waypoint.transform.position - transform.position);

        float angle = Vector2.SignedAngle(new Vector2(0, 1f), toward);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

	// Update is called once per frame
	void Update () {

        if (m_CurrentWaypoint > waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 target = waypoints[m_CurrentWaypoint].transform.position;

        FaceTarget(waypoints[m_CurrentWaypoint]);

        Vector3 dir = (target - transform.position).normalized;

        transform.position += speed * dir * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target);

        if ( distance < 0.1f )
        {
            m_CurrentWaypoint++;
        }
    }
}
