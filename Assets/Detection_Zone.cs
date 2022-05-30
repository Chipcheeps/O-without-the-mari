using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_Zone : MonoBehaviour
{
    public bool InZone;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        InZone = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(obj.tag) && collision is EdgeCollider2D)
        {
            InZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(obj.tag) && collision is EdgeCollider2D)
        {
            InZone = false;
        }
        
    }
}
