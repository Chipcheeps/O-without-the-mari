using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntSwordHitbox : MonoBehaviour
{
    public GameObject oplayer;
    public GameObject Grunt;
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
        if (oplayer.GetComponent<o>().CanDamage)
        {

        
            if (collision.gameObject.CompareTag("Player"))
            {
                
                
                oplayer.GetComponent<o>().Health -= 50;
                    
                StartCoroutine(oplayer.GetComponent<o>().Hurt());
                if (Grunt.GetComponent<GruntScript>().GruntLook == GruntDirection.Left)
                {
                    oplayer.GetComponent<o>().KnockBack(1); 
                }
                else
                {
                    oplayer.GetComponent<o>().KnockBack(2);
                }
                    
                
                //Debug.Log(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime%1);
            }
        }
    }
}
