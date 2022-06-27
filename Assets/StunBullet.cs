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
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
 
        
    }
}
