using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public ParticleSystem dust;
    private bool boost = false;
    private float speed = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
        thrust();
    }


    public void rotation() {
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(0f, 0f, 1f);
        }

        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(0f, 0f, -1f);
        }

        else
        {
            transform.Rotate(0f, 0f, Random.Range(-0.5f, 0.5f));
        }
    }

    public void thrust() {
        rb2D.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);

        if (Input.GetKeyDown("w"))
        {
            dust.Play();
            boost = true;
        }

        if (Input.GetKey("w") && boost)
        {
            speed = 20f;
        }

        else {
            speed = 10f;
        }

    }
}
