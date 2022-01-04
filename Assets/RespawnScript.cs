using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public Vector2 SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Return()
    {
        transform.position = SpawnPoint;
    }
}
