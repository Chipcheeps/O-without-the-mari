using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntActivator : MonoBehaviour
{
    public GameObject GruntFolder;
    // Start is called before the first frame update
    void Start()
    {
        GruntFolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activation()
    {
        GruntFolder.SetActive(true);
    }
}
