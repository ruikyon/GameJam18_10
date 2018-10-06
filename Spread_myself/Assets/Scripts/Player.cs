using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Factor {
    public static Player instance;
    [SerializeField]
    protected Factor prefab;
    [SerializeField]
    protected float moveSpeed, shotSpeed;
    protected Vector2 dir = new Vector2(0, 1);

    protected override void Start()
    {
        base.Start();
        baseDamage *= 2f;
        transform.position = new Vector3(Field.min + 1, Field.min + 1);
        instance = this;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Fire1") && power > 1.5)
        {
            var temp = Instantiate(prefab, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = dir * shotSpeed;
            power -= 1f;
        }

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0) dir = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = new Vector3(x, y) * moveSpeed;
    }

    public float GetPower()
    {
        return power;
    }
}
