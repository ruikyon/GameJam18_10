using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Factor {
    public static Enemy instance;
    [SerializeField]
    protected Factor prefab;
    private Vector2 center;
    private int r = 4, counter = 0;
    //public int children = 0;
    [SerializeField]
    private int degSpeed, interval;
    [SerializeField]
    private float moveSpeed;
    private float rad = 0, radSpeed;
    private float def;

    protected override  void Start()
    {
        base.Start();
        instance = this;
        power = 2.5f;
        def = power;
        baseDamage *= 0.2f;
        center = new Vector2(Field.max - r - 3, Field.max - r - 3);
        radSpeed = degSpeed * 2 * Mathf.PI / 360;
    }

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();
        counter++;
        if (counter == interval)
        {
            counter = 0;
            if (GameController.instance.children < (10+(int) def/(power+0.5)))
            {
                var temp = Instantiate(prefab, transform);
                temp.transform.parent = null;
                temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Sin(rad), Mathf.Cos(rad)) * moveSpeed;
                GameController.instance.children++;
            }
        }
        transform.position = center + r * new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        rad += radSpeed;
        if (rad > 2 * Mathf.PI) rad -= 2 * Mathf.PI;
	}

    public float GetPower()
    {
        return power;
    }
}
