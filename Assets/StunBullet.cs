using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBullet : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    
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
