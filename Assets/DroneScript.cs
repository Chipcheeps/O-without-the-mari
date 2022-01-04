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
    Rigidbody2D rb2d;
    BoxCollider2D col2d;
    RaycastHit2D hit;
    public bool DroneDebug;
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
        if (hit.collider != null)
        {
          Gizmos.DrawWireSphere(hit.transform.position, 10f);
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
            for(int i = 1; i <= 16; i++)
            {
                hit = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size * 20f, Mathf.Sin(degree * Mathf.Deg2Rad), Vector2.right, 20f, PlayerLayer);
                //if (DroneDebug)
                //{
                //    Vector2 p1, p2, p3, p4, p5, p6, p7, p8;
                //    float w = col2d.bounds.size.x * 0.5f;
                //    float h = col2d.bounds.size.y * 0.5f;
                //    p1 = new Vector2(-w, h);
                //    p2 = new Vector2(w, h);
                //    p3 = new Vector2(w, -h);
                //    p4 = new Vector2(-w, -h);
                //    Quaternion q = Quaternion.AngleAxis(Mathf.Sin(degree * Mathf.Deg2Rad), new Vector3(0, 0, 1));
                //    p1 = q * p1;
                //    p2 = q * p2;
                //    p3 = q * p3;
                //    p4 = q * p4;
                //    p1 += (Vector2)col2d.bounds.center;
                //    p2 += (Vector2)col2d.bounds.center;
                //    p3 += (Vector2)col2d.bounds.center;
                //    p4 += (Vector2)col2d.bounds.center;
                //    Vector2 realdistance = Vector2.right * 20f;
                //    p5 = p1 + realdistance;
                //    p6 = p2 + realdistance; 
                //    p7 = p3 + realdistance;
                //    p8 = p4 + realdistance;
                //    Color castcolor = hit ? Color.green : Color.red;
                //    Debug.DrawLine(p1, p2, castcolor);
                //    Debug.DrawLine(p2, p3, castcolor);
                //    Debug.DrawLine(p3, p4, castcolor);
                //    Debug.DrawLine(p4, p1, castcolor);
                //    Debug.DrawLine(p5, p6, castcolor);
                //    Debug.DrawLine(p6, p7, castcolor);
                //    Debug.DrawLine(p7, p8, castcolor);
                //    Debug.DrawLine(p8, p5, castcolor);
                //    Debug.DrawLine(p1, p5, castcolor);
                //    Debug.DrawLine(p2, p6, castcolor);
                //    Debug.DrawLine(p3, p7, castcolor);
                //    Debug.DrawLine(p4, p8, castcolor);
                //}
                if (hit.collider != null)
                {
                    Debug.Log("Raycast");
                    Collider2D[] lookfordrone = Physics2D.OverlapCircleAll(hit.transform.position, 10f, DroneLayer);
                    if (lookfordrone.Length > 0)
                    {
                        Debug.Log("lookfordrone");
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