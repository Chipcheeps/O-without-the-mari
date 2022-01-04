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
    public bool follow;
    public LayerMask PlayerLayer;
    public Animator anim;
    public GruntDirection GruntLook;
    public int Health;
    public GameObject GruntSword;
    public bool isAttacking;
    public bool isInGruntRange;
    // Start is called before the first frame update
    void Start()
    {
        follow = false;
        Health = 10;
        isAttacking = false;
        isInGruntRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitlist = Physics2D.OverlapCircleAll(gameObject.transform.position, 10f, PlayerLayer);
        foreach (Collider2D enemy in hitlist)
        {
            if (hitlist.Length == 1)
            {
                o = enemy.gameObject;
                isInGruntRange = true;
            }
        }
        Collider2D[] hitntlist = Physics2D.OverlapCircleAll(gameObject.transform.position, 1f, PlayerLayer);
        foreach (Collider2D enemy in hitntlist)
        {
            if (hitntlist.Length == 1)
            {
                
            } 
        }
        if (o.GetComponent<o>().Stunned)
        {
            follow = true;
            isInGruntRange = false;
        }
        else
        {
            follow = false;
        }
        if (hitlist.Length == 1)
        {
            anim.SetBool("IsAttacking", false);
            isAttacking = false;
            Looking();
        }
        else
        {
            anim.SetBool("IsAttacking", false);
            isAttacking = false;
        }
        if (hitntlist.Length == 1 && o.GetComponent<o>().Stunned)
        {
            follow = false;
            anim.SetBool("IsAttacking", true);
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(o.transform.position.x, transform.position.y, transform.position.z), -2f * Time.deltaTime);
            isAttacking = true;
            Looking();
        }
        if (o != null && follow)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(o.transform.position.x, transform.position.y, transform.position.z), 6.5f * Time.deltaTime);

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectiles"))
        {
            Health -= 1;
            if (Health <= 0)
            {
                Destroy(gameObject);
                Destroy(GruntSword);
            }
            
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
    
}
