using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBulletCloningDrone : MonoBehaviour
{
    public float time;
    public GameObject StunBullet;
    public GameObject o;
    bool DroneCanShoot;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<DroneScript>().IsInDroneRange)
        {
            DroneCanShoot = true;
        }
        if (gameObject.GetComponent<DroneScript>().Health <= 0)
        {
            DroneCanShoot = false;
        }
        if (DroneCanShoot && Time.time - time >= 1f && o.GetComponent<o>().CanBeShot)
        {
            time = Time.time;
            GameObject Clone = Instantiate(StunBullet);
            Vector3 DirectionToTarget = (o.transform.position - gameObject.transform.position).normalized;
            float angle = Mathf.Atan2(DirectionToTarget.y, DirectionToTarget.x) * Mathf.Rad2Deg - 38f;
            //Debug.Log(angle);
            Clone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Clone.GetComponent<Rigidbody2D>().AddForce(DirectionToTarget * 10);
            Clone.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1f);
        }
    }
}
