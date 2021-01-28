using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rig;
    public int damage;

    public GameObject explosionFxPrefab;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate() {
        rig.velocity = Vector2.right * speed;
    }

    public void OnHit() {
        GameObject explosion = Instantiate(explosionFxPrefab, transform.position, transform.rotation);
        Destroy(explosion, 0.3f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 8) {
            OnHit();
        }
    }
    
}
