using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public GameObject o;
    public Rigidbody2D Rb;
    public float xOffset;
    public float yOffset;
    public float CameraOffset;
    Vector3 oPosition;
    // Start is called before the first frame update
    void Start()
    {
        xOffset = 10f;
        yOffset = 3f;
        CameraOffset = gameObject.transform.position.y - o.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        oPosition = new Vector3(o.transform.position.x, o.transform.position.y, gameObject.transform.position.z);
        
        
        if (oPosition.x > gameObject.transform.position.x + xOffset)
        {
            oPosition.x -= xOffset;
            oPosition.y = gameObject.transform.position.y;
            gameObject.transform.position = oPosition;
        }
        if (oPosition.x < gameObject.transform.position.x - xOffset)
        {
            oPosition.x += xOffset;
            oPosition.y = gameObject.transform.position.y;
            gameObject.transform.position = oPosition;
        }
        if (oPosition.y > gameObject.transform.position.y + yOffset)
        {
            
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, oPosition.y - yOffset, gameObject.transform.position.z);
        }
        if (oPosition.y < gameObject.transform.position.y - yOffset)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, oPosition.y + yOffset, gameObject.transform.position.z);
        }
       
    }
}
