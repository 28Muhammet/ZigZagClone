using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public static Vector3 direction;
    public static float speed;
    public SpawnerGround spawn;
    public static bool fell;
    public static bool click;
    public float addSpeed;
    public GameObject baseAnim;
    public AudioSource[] source;

    private int groundCounter;

    private void Start()
    {
        groundCounter = 0;
        speed = 3.8f;
        fell = false;
        click = false;
    }

    private void Update()
    {
        if(transform.position.y <= 1.03f)
        {
            fell = true;
            source[1].Play();
        }

        if(fell == true)
        {
            return;
        }

        if(click == true)
        {
            Movement();
        }
    }

    public void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (direction.x == 0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }

            source[0].Play();
        }
    }

    private void FixedUpdate()
    {
        Vector3 hareket = direction * Time.deltaTime * speed;
        transform.position += hareket;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Score.score++;
            groundCounter++;
            collision.gameObject.AddComponent<Rigidbody>();
            StartCoroutine(DeleteGrounds(collision.gameObject));
            spawn.crate_Ground();
            
            if(groundCounter == 50)
            {
                speed += addSpeed * Time.deltaTime;
                groundCounter = 0;
            }
        }

        if (collision.gameObject.tag == "Base")
        {
            baseAnim.GetComponent<Animator>().enabled = true;
        }
    }

    IEnumerator DeleteGrounds(GameObject deleteGround)
    {
        yield return new WaitForSeconds(3f);
        Destroy(deleteGround);
    }
}
