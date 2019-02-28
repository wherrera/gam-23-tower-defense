using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour {

    public float hp;
    public Vector3 moveDirection;

    public void ApplyDamage(float damage)
    {
        hp -= damage;

        if(hp <= 0f)
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.position += moveDirection * Time.deltaTime;
    }
}
