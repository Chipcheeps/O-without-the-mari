using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GruntDirection
{
    Left, Right
}
public class GruntScript : MonoBehaviour
{
    public GameObject o;
    public LayerMask PlayerLayer;
    public Animator anim;
    public GruntDirection GruntLook;
    public int Health;
    public int Armour;
    public GameObject GruntSword;
    Collider2D[] hitlist;
    Collider2D[] hitntlist;
    // Start is called before the first frame update
    void Start()
    {
        Armour = 1;
        Health = 10;
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), o.gameObject.GetComponent<Collider2D>());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       hitlist = Physics2D.OverlapCircleAll(gameObject.transform.position, 10f, PlayerLayer);
       hitntlist = Physics2D.OverlapCircleAll(gameObject.transform.position, 1f, PlayerLayer);

        if (hitntlist.Length > 0)
        {
            Debug.Log("runaway");
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(o.transform.position.x, transform.position.y, transform.position.z), -2f * Time.deltaTime);
        }
        else if (hitlist.Length > 0 && o.GetComponent<o>().Stunned)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(o.transform.position.x, transform.position.y, transform.position.z), 6.5f * Time.deltaTime);
            Looking();
            Debug.Log("Follow");
        }

    }
    private void Update()
    {
        if (hitlist != null)
        {
            if (hitlist.Length > 0 && 
            hitntlist.Length == 0 && 
            !o.GetComponent<o>().Stunned)
            {
            anim.SetBool("IsAttacking", false);
            Looking();
            }
            if (hitntlist.Length > 0 && o.GetComponent<o>().Stunned)
            {
            anim.SetBool("IsAttacking", true);  
            Looking();
            }
        }
        
    }
    public void Looking()
    {
        if (o.transform.position.x < transform.position.x)
        {
            GruntLook = GruntDirection.Left;
            anim.SetBool("IsRight", false);
        }
        else
        {
            GruntLook = GruntDirection.Right;
            anim.SetBool("IsRight", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectiles"))
        {
            if (Armour > 0)
            {
                Health -= 1;
                if (Health <= 0)
                {
                    Destroy(gameObject);
                    Destroy(GruntSword);
                }
            }
            
            
        }
       
    }
    
}
