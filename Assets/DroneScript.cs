using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour
{

    public int Health;
    public bool follow;
    public bool IsInDroneRange;
    public LayerMask PlayerLayer;
    public LayerMask DroneLayer;
    public LayerMask GroundLayer;
    public LayerMask WallLayer;
    Rigidbody2D rb2d;
    BoxCollider2D col2d;
    RaycastHit2D hitground;
    RaycastHit2D hitplayer;
    public bool DroneDebug;
    Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Health = 1;
        follow = false;
        IsInDroneRange = false;
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<BoxCollider2D>();
    }
    void OnDrawGizmosSelected()
    {
        if (hitplayer.collider != null)
        {
          Gizmos.DrawWireSphere(hitplayer.transform.position, 10f);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitlist = Physics2D.OverlapCircleAll(gameObject.transform.position, 20f, PlayerLayer);
        foreach (Collider2D enemy in hitlist)
        {
            if (hitlist.Length == 1)
            {
                IsInDroneRange = true;
            }
        }
        if (IsInDroneRange)
        {
            Debug.Log("in range");
            var degree = 0;
                hitground = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size * 20f, 0f, Vector2.down, 5f, GroundLayer);
                if (hitground.collider != null)
                {
                    rb2d.AddForce(Vector2.up * 0.5f, ForceMode2D.Impulse);
                }
            for(int i = 1; i <= 16; i++)
            {
                hitplayer = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size * 20f, Mathf.Sin(degree * Mathf.Deg2Rad), Vector2.right, 15f, PlayerLayer);
                if (hitplayer.collider != null)
                {
                    Debug.Log("Raycast");
                    Collider2D[] lookfordrone = Physics2D.OverlapCircleAll(hitplayer.transform.position, 10f, DroneLayer);
                    if (lookfordrone.Length > 0)
                    {
                        Debug.Log("lookfordrone");
                        transform.position = Vector2.MoveTowards(transform.position, hitplayer.transform.position, -10f * Time.deltaTime); 
                    }
                    Collider2D[] dronestayhere = Physics2D.OverlapCircleAll(hitplayer.transform.position, 11f, DroneLayer);
                    if (dronestayhere.Length <= 0)
                    {
                        transform.position = Vector2.SmoothDamp(transform.position, hitplayer.transform.position,ref velocity, 10f);
                    }
                }
                

                
                if (i % 4 == 1 || i % 4 == 0) 
                {
                    degree += 30;
                }
                else
                {
                    degree += 15;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectiles"))
        {
            Health -= 1;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}