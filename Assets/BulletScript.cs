using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    bool CanDelete;
    // Start is called before the first frame update
    void Start()
    {
        CanDelete = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
            CanDelete = true;
            Debug.Log(CanDelete);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(CanDelete);
        
        if (CanDelete && (collision.gameObject.CompareTag("Surface") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Projectiles")))
        {
            Debug.Log(collision.gameObject.name + " Trig");
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(CanDelete);
            CanDelete = false;
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Surface") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Projectiles"))
    //    {
    //        Debug.Log(collision.gameObject.name + " Col");
    //        Destroy(gameObject);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {

    }
}
