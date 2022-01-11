using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBulletCloning : MonoBehaviour
{
    public float time;
    public GameObject Stunbullet;
    public GameObject o;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.GetComponent<GruntScript>().follow);
        if (!gameObject.GetComponent<GruntScript>().follow && Time.time - time >= 1f && gameObject.GetComponent<GruntScript>().isInGruntRange && !o.GetComponent<o>().Stunned)
        {
           time = Time.time;
           // Debug.Log(gameObject.GetComponent<GruntScript>().follow);
            GameObject Clone = Instantiate(Stunbullet, gameObject.transform, false);
            Clone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30));
            if (gameObject.transform.position.x < o.transform.position.x)
            {
                Clone.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 15);
                Clone.transform.position = new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y , 1f);
            }
            else
            {
                Clone.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 15);
                Clone.transform.position = new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y, 1f);
            }
            Debug.Log("stunyou");
        }
        
    }
}
