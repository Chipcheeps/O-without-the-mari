using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DroneHealthScript : MonoBehaviour
{
    public GameObject Drone;
    public Slider DroneHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DroneHealthBar.value = Drone.GetComponent<DroneScript>().Health;
    }
}
