using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public enum Direction
{
    Up, Left, Down, Right, None, Up_Left, Up_Right, Down_Left, Down_Right
}
public class o : MonoBehaviour
{
    float Speedx = 0;
    public Rigidbody2D whatever;
    public float Jumpvalue = 100;
    public bool isgroundedvar;
    [SerializeField] LayerMask mask;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public BoxCollider2D collider2D;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    // Start is called before the first frame update
    
    private float DashTime;
    public float StartTime;
    public Direction oDirection;
    private Vector2 oVelocity;
    public float dashspeed = 50;
    public bool isdashing;
    public float DashLimit;
    private float CurrentLimit;
    public bool CanDash;
    bool airdash = true;
    public int Health;
    public bool Stunned;
    public bool CanDamage;
    public bool GameOver;
    public Vector2 Checkpoint;
    public GameObject Camera;
    public bool CanBeShot;
    public LayerMask Walls;
    [SerializeField] bool IsCrouched;
    



    private void Slideleft()
    {
        
        
            gameObject.transform.localScale = new Vector3(1, 0.5f, 1);
            while (!isgroundedslide())
            {
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.285f, transform.position.z);
             //Debug.Log("Ajust");
            }

            Speedx += -7;
        //Debug.Log("Wuh?");
            oDirection = Direction.Left;
        
    }
    private void Slideright()
    {
        Speedx += 7;
        //Debug.Log("Huh?");
        oDirection = Direction.Right;
        gameObject.transform.localScale = new Vector3(1, 0.5f, 1);
        if (!isgroundedslide())
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.285f, transform.position.z);
        }
    }
    private void Crouch()
    {
        gameObject.transform.localScale = new Vector3(1, 0.5f, 1);
        if (!isgroundedslide())
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.285f, transform.position.z);
            
        }
        IsCrouched = true;
    }
    void Start()
    {
        DashTime = StartTime;
        isdashing = false;
        CurrentLimit = DashLimit;
        CanDash = false;
        Health = 100;
        Stunned = false;
        CanDamage = true;
        GameOver = false;
        Checkpoint = transform.position;
        CanBeShot = true;
        IsCrouched = false;
    }
    IEnumerator IsStunned()
    {
        Stunned = true;
        CanBeShot = false;
        whatever.velocity = new Vector2(0, whatever.velocity.y);
        Color oldcolor = gameObject.GetComponent<SpriteRenderer>().color;
        Color newcolor = new Color(1f, 1f, 0f, oldcolor.a);
        gameObject.GetComponent<SpriteRenderer>().color = newcolor;
        yield return new WaitForSeconds(3);
        Stunned = false;
        gameObject.GetComponent<SpriteRenderer>().color = oldcolor;
        if (CanDamage)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        yield return new WaitForSeconds(0.5f);
        CanBeShot = true;
    }
    public IEnumerator Hurt()
    {
        Debug.Log("hurt");
        CanDamage = false;
        Color oldcolor = gameObject.GetComponent<SpriteRenderer>().color;
        Color newcolor = new Color(oldcolor.r, oldcolor.g, oldcolor.b, 0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = newcolor;
        yield return new WaitForSeconds(3);
        CanDamage = true;
        if (Stunned)
        {
         gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f, 1f);
        }
        else
        {
         gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
    public void KnockBack(int Direction)
    {
        if (Direction == 1)
        {
            whatever.AddForce(-transform.right * 15f, ForceMode2D.Impulse);
        }
        else if (Direction == 2)
        {
            whatever.AddForce(transform.right * 15f, ForceMode2D.Impulse);
        }
    }
    public void Respawn()
    {
        transform.position = Checkpoint;
        Camera.transform.position = new Vector3(0f, 5f, -20f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        Health = 100;
        whatever.velocity = Vector2.zero;
        Stunned = false;
        CanDamage = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
         //NumOfCoins += 1;
         
        }
           
        if (collision.gameObject.CompareTag("Finish!"))
        {
            SceneManager.LoadScene(1);
        }
        if (collision.gameObject.CompareTag("Stun Projectiles"))
        {
            if (!Stunned)
            {
                StartCoroutine(IsStunned());
            }
            Debug.Log("WillStunBulletDelete?");
            Destroy(collision.gameObject);

        }
    }
    public void Invuln()
    {

    }
    // Update is called once per frame
    private bool isgrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0f, Vector2.down, 0.1f, mask);
        return raycastHit2D.collider != null;
    }
    private bool isgroundedslide()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0f, Vector2.down, 0.3f, mask);
        return raycastHit2D.collider != null;
    }
    void Update()
    {
        if (!Stunned && !GameOver)
        {
            Movement();
        }
    }
    void Movement()
    {
        Speedx = 0;

        isgroundedvar = isgrounded();
        oDirection = Direction.None;
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftControl) && isgroundedslide())
        {
            Slideleft();
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftControl) && isgroundedslide())
        {
            Slideright();
        }
        else if (Input.GetKey(KeyCode.LeftControl) && isgroundedslide())
        {
            Crouch();
        }
        else
        {
            if (!CheckForCeiling())
            {
                transform.localScale = new Vector3(1, 1, 1);
                IsCrouched = false;
            }
            else
            {
                Crouch();
            }
            if (Input.GetKey(KeyCode.D))
            {
                Speedx += (IsCrouched) ? 7 : 10 ;
                oDirection = Direction.Right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Speedx += (IsCrouched) ? -7 : -10;
                oDirection = Direction.Left;
            }
        }

        if (Input.GetKey(KeyCode.W) && !isgrounded())
        {
            oDirection = Direction.Up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            oDirection = Direction.Down;
        }
        if ((Input.GetKeyDown(KeyCode.Space)) && isgroundedvar && !(Input.GetKeyDown(KeyCode.LeftControl)))
        {
            whatever.velocity = Vector2.up * Jumpvalue;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && !isgrounded())
        {
            oDirection = Direction.Up_Left;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && !isgrounded())
        {
            oDirection = Direction.Up_Right;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            oDirection = Direction.Down_Left;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            oDirection = Direction.Down_Right;
        }

        whatever.velocity = new Vector3(Speedx, whatever.velocity.y, 0f);
        oVelocity = whatever.velocity;

        if (Input.GetKeyDown(KeyCode.LeftShift) && oDirection != Direction.None && CurrentLimit == DashLimit && isgrounded())
        {
            isdashing = true;
            CanDash = true;
        }
        else if (!isgrounded() && airdash && Input.GetKeyDown(KeyCode.LeftShift) && oDirection != Direction.None && CurrentLimit == DashLimit)
        {
            isdashing = true;
            CanDash = true;
            airdash = false;
        }
        if (isgrounded())
        {
            airdash = true;
        }
    }
    public bool CheckForCeiling()
    {
        RaycastHit2D Ceiling;
        Ceiling = Physics2D.BoxCast(gameObject.transform.position, new Vector2(2.5f, 5), 0f, Vector2.up, 1f, Walls);
        if (Ceiling.collider != null)
        {
            return true;
        }
        return false;
    }
    private void FixedUpdate()
    {
    //    if (CanDash)
    //    {


    //        if (CurrentLimit > 0)
    //        {
    //            CurrentLimit -= Time.deltaTime;
    //            if (isdashing)
    //            {

    //                if (DashTime <= 0)
    //                {
    //                    oDirection = Direction.None;
    //                    DashTime = StartTime;
    //                    whatever.velocity = oVelocity;
    //                    Debug.Log("Reset");
    //                    isdashing = false;
    //                }
    //                else
    //                {
    //                    Debug.Log("Move");
    //                    DashTime -= Time.deltaTime;
    //                    switch (oDirection)
    //                    {
    //                        case Direction.Right:
    //                            whatever.velocity = Vector2.right * dashspeed;
    //                            break;
    //                        case Direction.Left:
    //                            whatever.velocity = Vector2.left * dashspeed;
    //                            break;

    //                        case Direction.Up:
    //                            whatever.velocity = Vector2.up * dashspeed * 0.5f;
    //                            break;
    //                        case Direction.Down:
    //                            whatever.velocity = Vector2.down * dashspeed * 0.5f;
    //                            break;
    //                        case Direction.Up_Left:
    //                            whatever.velocity = new Vector2(-1, .5f) * dashspeed;
    //                            break;
    //                        case Direction.Up_Right:
    //                            whatever.velocity = new Vector2(1, .5f) * dashspeed;
    //                            break;
    //                        case Direction.Down_Left:
    //                            whatever.velocity = new Vector2(-1, -.5f) * dashspeed;
    //                            break;
    //                        case Direction.Down_Right:
    //                            whatever.velocity = new Vector2(1, -.5f) * dashspeed;
    //                            break;
    //                    }
    //                }
    //            }

    //            Debug.Log("Dash");

    //        }
    //        else
    //        {
    //            CurrentLimit = DashLimit;
    //            CanDash = false;
    //        }
    //    }
    }
}
