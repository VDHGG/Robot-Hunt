using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] float attackRange = 5f;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] Transform playerTransform;
    [SerializeField] float chaseSpeed = 5f;
    [SerializeField] float retrieveDistance = 7f;

    public GameObject enemyBulletPrefab;
    public Transform shootPoint;
    public float bulletVelocity = 10f;

    public float startTime = 1.5f;
    private float timeBetweenShot;

    public int maxHealth = 3;
    public GameObject explosionPrefab;
    


    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShot = startTime;
    }

    // Update is called once per frame
    void Update()
    {

        if(maxHealth <=0)
        {
            Die();
        }
        Collider2D collInfor = Physics2D.OverlapCircle(transform.position, attackRange, targetLayer);

        if (collInfor)
        {
            if(FindObjectOfType<Player>() != null)
            {
                playerTransform = FindObjectOfType<Player>().transform;
            }

            Vector2 direction = playerTransform.position - transform.position;
            transform.up = direction;

            if(Vector2.Distance(transform.position, playerTransform.position) > retrieveDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, chaseSpeed * Time.deltaTime);
            }
            else
            {
               if(timeBetweenShot <= 0f)
                {
                    Shoot();
                    timeBetweenShot = startTime;
                }
                else
                {
                    timeBetweenShot -= Time.deltaTime;
                }
            }
            
        }
    }

    void Shoot()
    {
        GameObject tempBullet = Instantiate(enemyBulletPrefab, shootPoint.position, shootPoint.rotation * Quaternion.Euler(0f,0f,90f));
        tempBullet.GetComponent<Rigidbody2D>().velocity = shootPoint.up * bulletVelocity;
        Destroy(tempBullet,3f);
    }

    public void EnemyTakeDamage( int damage)
    {
        if(maxHealth <= 0)
        {
            return;
        }
        maxHealth -= damage;
        FindAnyObjectByType<CameraShake>().Shake(.12f,1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet")
        {
            EnemyTakeDamage(1);
            Destroy(collision.gameObject);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void Die()
    {
        FindObjectOfType<Player>().currentEnemyDeath += 1;
        GameObject tempExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(tempExplosion, .7f);
        FindAnyObjectByType<CameraShake>().Shake(.12f, 1f);
        Destroy(this.gameObject);

    }
}
