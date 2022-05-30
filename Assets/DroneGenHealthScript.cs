using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DroneGenHealthScript : MonoBehaviour
{
    public GameObject DroneGen;
    public Slider GruntHealthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GruntHealthBar.value = DroneGen.GetComponent<Drone_Generator>().Health;
    }
}
