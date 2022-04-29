using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot_Bullet : MonoBehaviour
{
    public GameObject Bullet;
    public float Bullet_Speed;
    public GameObject Crosshair;
    public GameObject Pause;
    public float timer;
    public Vector2 PlayerScale;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        PlayerScale = transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && !Pause.GetComponent<PauseButItWillWork>().ispaused && !GetComponent<o>().GameOver && !GetComponent<o>().Stunned && timer > 0.5f)
        {
            timer = 0;
            GameObject Clone = Instantiate(Bullet);
            Clone.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Clone.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1f);
            Vector3 DirectionToTarget = (Crosshair.transform.position - gameObject.transform.position).normalized;
            float angle = Mathf.Atan2(DirectionToTarget.y, DirectionToTarget.x) * Mathf.Rad2Deg;
            Clone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Clone.GetComponent<Rigidbody2D>().AddForce(DirectionToTarget * Bullet_Speed, ForceMode2D.Force);
        }
    }
}
