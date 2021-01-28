using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    public float speed;

    private Rigidbody2D rig;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity = Vector2.left * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D collison) {
        if (collison.CompareTag("Player")) {
            player.onHit(damage);
        }

        base.OnTriggerEnter2D(collison);
    }
}
