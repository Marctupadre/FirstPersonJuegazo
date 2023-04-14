using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Cllimb : MonoBehaviour
{
    public float jumpforce = 4f;
    public float slideForce = 1.5f;
    public float sliderTimer = 0.2f;
    private float lastJumpTimer = 0f;
    private Rigidbody rb;
    public bool isJumping = false;
    public bool isSliding = false;

    private Vector3 jumpdirection;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.useGravity = false; 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Ha colisionado");
            Vector3 hit = collision.contacts[0].normal;
            if (hit.y < 0.1f)
            {
                Debug.Log("Touched Wall");
                return;
            }
            
            jumpdirection = Vector3.Reflect(rb.velocity.normalized, hit).normalized;
            isSliding = true;
            isJumping = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isSliding == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("esta saltando");
            isJumping = true;
            rb.velocity = Vector3.zero;
            lastJumpTimer = Time.time;    
            rb.AddForce(jumpdirection * jumpforce, ForceMode.Impulse);
        }
        if (Time.time > lastJumpTimer + sliderTimer)
        {
               isSliding = false;
        }
        if (isSliding)
        {
            rb.velocity = new Vector3 (rb.velocity.x, -slideForce, rb.velocity.z);
        }
    }
}
