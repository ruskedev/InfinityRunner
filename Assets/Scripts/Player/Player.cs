using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int health;
    public float jumpForce;
    public float speed;
    
    private bool isJumping;
    private Rigidbody2D rig;
    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            OnJump();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            OnShoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.layer == 8) {
            anim.SetBool("jumping", false);
            isJumping = false;
        }
    }

    public void onHit(int damage) {
        health -= damage;

        if (health <= 0) {
            GameController.instance.ShowGameOver();
        }
    }

    public void OnShoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void OnJump() {
        if (isJumping) {
            return;
        }

        rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        anim.SetBool("jumping", true);
        isJumping = true;
    }
}
