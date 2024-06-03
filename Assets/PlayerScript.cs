using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public GameObject bullet;
    private int bulletTimer=0;
    public GameObject gameManager;
    private GameManagerScript gameManagerScript; // Script‚ª“ü‚é•Ï”

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        // Script‚ğæ“¾‚·‚é
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 2.0f;
        float stageMax = 4.0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < stageMax)
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);
            }
            animator.SetBool("move", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -stageMax)
            {
                rb.velocity = new Vector3(-moveSpeed, 0, 0);
            }
            animator.SetBool("move", true);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetBool("move", false);
        }
    }

    void FixedUpdate()
    {
        if (bulletTimer == 0)
        {
            // ’e”­Ë
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 position = transform.position;
                position.y += 0.8f;
                position.z += 1.0f;
                Instantiate(bullet, position, Quaternion.identity);
            }
            bulletTimer = 1;
        }
        else
        {
            bulletTimer++;
            if (bulletTimer > 20)
            {
                bulletTimer = 0;
            }
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameManagerScript.GameOverStart();
        }
    }

}
