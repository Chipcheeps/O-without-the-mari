using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneEdgeCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drone Detection Zone"))
        {
            gameObject.GetComponentInParent<DroneScript>().inzone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drone Detection Zone"))
        {
            gameObject.GetComponentInParent<DroneScript>().inzone = false;
        }
    }
}
