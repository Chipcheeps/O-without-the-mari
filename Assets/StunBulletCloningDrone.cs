using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBulletCloningDrone : MonoBehaviour
{
    public float time;
    public GameObject StunBullet;
    public GameObject o;
    public GameObject Drone;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time >= 1f && !o.GetComponent<o>().Stunned && Drone.GetComponent<DroneScript>().IsInDroneRange)
        {
            time = Time.time;
            GameObject Clone = Instantiate(StunBullet, gameObject.transform, false);
            Vector3 DirectionToTarget = (o.transform.position - Drone.transform.position).normalized;
            float angle = Mathf.Atan2(DirectionToTarget.y, DirectionToTarget.x) * Mathf.Rad2Deg;
            Clone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Clone.GetComponent<Rigidbody2D>().AddForce(DirectionToTarget * 10);
            Clone.transform.position = new Vector3(Drone.transform.position.x, Drone.transform.position.y, 1f);
        }
        
    }
}
