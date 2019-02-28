using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject bullet;
    public float bulletForce;

    private Creep m_Target;
    private float m_FireDelay;

    void FaceTarget(Creep creep)
    {
        Vector2 toward = (creep.transform.position - transform.position);

        float angle = Vector2.SignedAngle(new Vector2(0, 1f), toward);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

	// Use this for initialization
	void Start ()
    {
        Creep[] creeps = FindObjectsOfType<Creep>();

        if (creeps.Length > 0)
            m_Target = creeps[0];

        if (m_Target != null)
            FaceTarget(m_Target);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_Target != null)
        {
            m_FireDelay += Time.deltaTime;

            FaceTarget(m_Target);

            if (m_FireDelay > 2f)
            {
                m_FireDelay = 0;

                GameObject instantiated = Instantiate(bullet);

                Vector2 toward = (m_Target.transform.position - transform.position);

                instantiated.GetComponent<Rigidbody2D>().AddForce(toward * bulletForce);
            }
        }
    }
}
