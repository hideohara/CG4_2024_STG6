using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        float moveSpeed = 4;
        rb.velocity = new Vector3(0, 0, moveSpeed);
        Destroy(gameObject, 5); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
