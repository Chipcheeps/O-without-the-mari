using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crosshair : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public Vector3 direction;
    void Start()
    {
        gameObject.transform.position = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Input.mousePosition;
        Vector3 mouseposition = Input.mousePosition;
        Vector3 Screenpoint = Camera.main.ScreenToWorldPoint(mouseposition);
        direction = new Vector3(Screenpoint.x, Screenpoint.y, 1f);
        gameObject.transform.position = direction;
    }
}
