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
    RaycastHit2D hitwallLeft;
    RaycastHit2D hitwallRight;
    RaycastHit2D hitplayer;
    Vector2 velocity = Vector2.zero;
    public float Timer;
    Vector2 Target;
    public GameObject DetectionZone1;
    Vector3 followedpoint;
    public bool ifhitwall;
    public bool inzone;
    // Start is called before the first frame update
    void Start()
    {
        Health = 1;
        follow = false;
        IsInDroneRange = false;
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<BoxCollider2D>();
        Timer = 0;
        inzone = false;
    }
   
   
    void OnDrawGizmosSelected()
    {
        if (hitplayer.collider != null)
        {
          Gizmos.DrawWireSphere(hitplayer.transform.position, 5f);
          Gizmos.DrawWireSphere(hitplayer.transform.position, 50f);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (IsInDroneRange)
        {
            Debug.Log("in range");
            var degree = 0;
            hitground = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size, 0f, Vector2.down, 5f, GroundLayer);
            if (hitground.collider != null)
            {
                Debug.Log("Ground Detected");
                rb2d.AddForce(Vector2.up * 6f * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }
            if (Mathf.Abs(rb2d.velocity.x) < 0.5f && !ifhitwall)
            {
                if (Target.normalized.x < 0)
                {
                    rb2d.velocity += new Vector2(Target.normalized.x - 10f, 0);
                }
                else
                {
                    rb2d.velocity += new Vector2(Target.normalized.x + 10f, 0);
                }

            }
            for (int i = 1; i <= 16; i++)
            {
                hitplayer = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size * 300f, Mathf.Sin(degree * Mathf.Deg2Rad), Vector2.right, 300f, PlayerLayer);
                followedpoint = hitplayer.transform.position;
                if (hitplayer.collider != null)
                {
                    Debug.Log("Raycast");
                    Collider2D[] followntplayer = Physics2D.OverlapCircleAll(followedpoint, 5f, DroneLayer);
                    if (followntplayer.Length > 0)
                    {
                        Debug.Log("lookfordrone");

                        //while (followntplayer.Length > 0)
                        //{
                        rb2d.AddForce(Target.normalized * 0.5f * Time.fixedDeltaTime, ForceMode2D.Impulse);
                        //followntplayer = Physics2D.OverlapCircleAll(hitplayer.transform.position, 10f, DroneLayer);
                        //if (Timer > Random.Range)
                        //}                        
                    }
                    else
                    {
                        Target = transform.position - followedpoint;
                        Target.x *= -1;
                    }
                    Collider2D[] followplayer = Physics2D.OverlapCircleAll(followedpoint, 50f, DroneLayer);
                    if (followplayer.Length > 0)
                    {
                        Debug.Log("followplayer");
                        Vector2 TowardsPlayer = followedpoint - transform.position;
                        Vector2 Strafe = new Vector2(Random.Range(-1, 1), 1);
                        //TowardsPlayer = Vector2.Scale(Strafe, TowardsPlayer);
                        rb2d.AddForce(TowardsPlayer.normalized * 0.49f * Time.fixedDeltaTime, ForceMode2D.Impulse);
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
        if (DetectionZone1.GetComponent<Detection_Zone>().InZone)
        {
           

        
        Collider2D[] hitlist = Physics2D.OverlapCircleAll(gameObject.transform.position, 15f, PlayerLayer);
        Timer += Time.deltaTime;
        
        if (hitlist.Length == 1)
        {
            IsInDroneRange = true;
        }
        else if (hitlist.Length == 0)
        {
            Debug.Log("nothing in range");
            IsInDroneRange = false;
        }
        ifhitwall = false;
        
        hitwallLeft = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size, 0f, Vector2.left, 0.1f, WallLayer);
        if (hitwallLeft.collider != null)
        {
            Debug.Log("WallLeft Detected");
            rb2d.velocity += new Vector2(1f, 0);
            ifhitwall = true;
        }
        hitwallRight = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size, 0f, Vector2.right, 0.1f, WallLayer);
        if (hitwallRight.collider != null)
        {
            Debug.Log("WallRight Detected");
            rb2d.velocity += new Vector2(-1f, 0);
            ifhitwall = true;
        }
        if (inzone)
        {
            rb2d.AddForce(Vector2.down * 6f * Time.fixedDeltaTime, ForceMode2D.Impulse);
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
                gameObject.SetActive(false);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drone Detection Zone"))
        {
            inzone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drone Detection Zone"))
        {
            inzone = false;
        }
    }
}