using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Generator : MonoBehaviour
{
    public float time;
    public GameObject DetectionZone3;
    public GameObject Drone;
    public int DroneCount;
    private static int MAX_COUNT;
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        MAX_COUNT = 3;
        Health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectionZone3.GetComponent<Detection_Zone>().InZone && Time.time - time >= 3f && DroneCount < MAX_COUNT)
        {
            time = Time.time;
            GameObject Clone = Instantiate(Drone);
            Clone.transform.position = gameObject.transform.position;
            Clone.GetComponent<DroneScript>().enabled = true;
            DroneCount++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectiles"))
        {
            Health -= 1;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}