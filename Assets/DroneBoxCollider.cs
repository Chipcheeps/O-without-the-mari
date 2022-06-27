using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBoxCollider : MonoBehaviour
{
    public GameObject Drone;
    public GameObject FirstPersonGunThingText;
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
        if (collision.gameObject.CompareTag("Projectiles"))
        {
            gameObject.GetComponentInParent<DroneScript>().Health -= 1;
            if (gameObject.GetComponentInParent<DroneScript>().Health <= 0)
            {
                //gameObject.SetActive(false);
                if (!gameObject.GetComponentInParent<DroneScript>().GruntFolder.activeSelf)
                {
                    gameObject.GetComponentInParent<DroneScript>().GruntFolder.SetActive(true);
                    FirstPersonGunThingText.SetActive(true);
                }
                
                try
                {
                    Debug.Log("Drone Count Down");
                    gameObject.GetComponentInParent<DroneScript>().DroneGenerator.GetComponent<Drone_Generator>().DroneCount--;
                    
                }
                catch (MissingReferenceException MRE)
                {
                    Debug.Log("MRE");
                }
                Destroy(Drone);
            }
        }
    }
}
