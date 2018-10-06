using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factor : MonoBehaviour {
    protected float power = 1, prePower, baseDamage=0.01f;

	// Use this for initialization
	void Start () {
        prePower = power;
	}

    // Update is called once per frame
    protected void Update()
    {
        if (prePower != power)
        {
            transform.localScale = new Vector3(power, power, 1);
            prePower = power;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((gameObject.tag == "Player" && collision.tag == "Enemy") || (gameObject.tag == "Enemy" && collision.tag == "Player"))
        {
            power -= baseDamage;
            if (power < 0) Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "food")
        {
            power += collision.GetComponent<Food>().GetValuie();
        }
    }
}
