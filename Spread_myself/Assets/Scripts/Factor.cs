using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factor : MonoBehaviour {
    protected float power = 1, prePower, baseDamage=0.05f, max = 3;

	// Use this for initialization
	protected virtual void Start () {
        prePower = power;
	}

    // Update is called once per frame
    protected virtual void Update()
    {
        if (prePower != power)
        {
            transform.localScale = new Vector3(power, power, 1);
            prePower = power;
        }
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("stay");
        if ((tag == "Player" && collision.tag == "Enemy") || (tag == "Enemy" && collision.tag == "Player"))
        {
            power -= baseDamage;
            
            Debug.Log("power: " + power);
            if (power < 0.15f)
            {
                if (this == GameController.instance.player) GameController.instance.GameOver();
                else if (this == GameController.instance.enemy) GameController.instance.EnemyDead();
                else if (tag == "Enemy")
                {
                    GameController.instance.children--;
                    if (GameController.instance.children == 0) GameController.instance.GameClear();
                }
                Destroy(gameObject);
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            if (tag != "Enemy")
            {
                power += collision.GetComponent<Food>().GetValuie();
                if (power > max) power = max;
            }

            Destroy(collision.gameObject);
            FoodManager.instance.foodCount--;
        }
        else if (collision.tag == "WallLR")
        {
            Debug.Log("WallLR");
            var temp = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-temp.x, temp.y);
        }
        else if (collision.tag == "WallUD")
        {
            Debug.Log("WallUD");
            var temp = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x, -temp.y);
        }
    }
}
