using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 10.0f;
    public float rotationSpeed = 200.0f;
    public GameObject player;

    public void TakeDamage(int damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        
        Destroy(gameObject);
    }

    private void Update()
    {
            float randomMove = Random.Range(0f, 1f);

            float translation = randomMove * speed * Time.deltaTime;
            Vector3 direction = (player.transform.position - transform.position).normalized;

            if (transform.name != "Boss")
                this.transform.Translate(0, translation * -direction.y, 0);
            this.transform.up = direction;
        
    }
}
