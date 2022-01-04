using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntSwordScript : MonoBehaviour
{
    public GameObject AgreeableGrunt;
    private Vector3 OffsetL;
    private Vector3 OffsetR;
    private Vector3 Offset;
    public GruntDirection gruntD;
    
    // Start is called before the first frame update
    void Start()
    {
        OffsetL = AgreeableGrunt.transform.position - gameObject.transform.position;
        OffsetR = gameObject.transform.position - AgreeableGrunt.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        gruntD = AgreeableGrunt.GetComponent<GruntScript>().GruntLook;
        if(gruntD == GruntDirection.Left)
        {
            Offset = OffsetL;
        }
        else
        {
            Offset = OffsetR;
        }
        gameObject.transform.position = AgreeableGrunt.transform.position + Offset.x * Vector3.right; 
        
    }
   
   
}
