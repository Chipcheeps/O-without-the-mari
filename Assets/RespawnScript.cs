using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public Vector2 SpawnPoint;
    public GameObject GruntFolder;
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
        if (gameObject.name.Equals("*Agreeable Grunt*"))
        {
            GruntFolder.SetActive(false);
            gameObject.GetComponent<GruntScript>().Health = 10;
            gameObject.GetComponent<GruntScript>().Armour = 1;
        }
    }
}
