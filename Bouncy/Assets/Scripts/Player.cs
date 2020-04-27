using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 movement;

    public float speed;
    public float range;
    public float health;
    public float damage;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {

        // movement
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }

    public void changeHealth(int increment) {
        this.health += increment;
    }

    public float getRange() {
        return range;
    }

    public float getSpeed() {
        return speed;
    }
}
