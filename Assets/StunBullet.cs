using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBullet : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Stage Hazard"))
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
 
        
    }
}
