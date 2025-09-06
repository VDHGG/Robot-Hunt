using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float XMovement = 0f;
    [SerializeField] float YMoevement = 0f;
    [SerializeField] float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletVelocity = 10f;
    public int maxHealth = 4;
    public GameObject explosionPrefab;
    public int currentEnemyDeath;
    [SerializeField] Text currentEnemyKillText;

    void Start()
    {
        
    }

    
    void Update()
    { 
        if(maxHealth <= 0)
        {
            Die();
            
        }

        currentEnemyKillText.text = currentEnemyDeath.ToString();
        XMovement = Input.GetAxis("Horizontal");
        YMoevement = Input.GetAxis("Vertical");
        transform.position += new Vector3(XMovement, YMoevement, 0f).normalized * moveSpeed * Time.deltaTime;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
       
        void Shoot()
        {
            GameObject tempBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation * Quaternion.Euler(0f, 0f, 90f));
            tempBullet.GetComponent<Rigidbody2D>().velocity = shootPoint.up * bulletVelocity;
            Destroy(tempBullet, 2f);
        }    
    }

    public void PlayerTakeDamage(int damage)
    {
        if(maxHealth <=0)
        {
            return;
        }
        maxHealth -= damage;
        FindAnyObjectByType<CameraShake>().Shake(.12f, 1f); 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            PlayerTakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    void Die()
    {
        FindObjectOfType<GameManager>().isGameActive = false;
        FindAnyObjectByType<CameraShake>().Shake(.12f, 1f);
        GameObject tempExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity); 
        Destroy(tempExplosion, .7f);
        Destroy(this.gameObject);
    }
   
}
