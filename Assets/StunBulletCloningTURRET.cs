using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBulletCloningTURRET : MonoBehaviour
{
    public float time;
    public GameObject StunBullet;
    public GameObject PressurePlate;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PressurePlate.GetComponent<PressurePlateScript>().PressurePlateActivated && Time.time - time >= 1f)
        {
            time = Time.time;
            GameObject Clone = Instantiate(StunBullet, gameObject.transform, false);
            Clone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30));
            Clone.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 15);
            Clone.transform.position = new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y, 1f);
        }
    }
}
