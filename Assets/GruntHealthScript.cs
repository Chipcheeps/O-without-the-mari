using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GruntHealthScript : MonoBehaviour
{
    public GameObject Grunt;
    public Slider GruntHealthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GruntHealthBar.value = Grunt.GetComponent<GruntScript>().Health;
    }
}
