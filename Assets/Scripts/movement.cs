using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);

        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0) {
            transform.Rotate(0f, 0f, 1f);
        }

        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0) {
            transform.Rotate(0f, 0f, -1f);
        }

        else {
            transform.Rotate(0f, 0f, Random.Range(-0.5f, 0.5f));
        }
    }
}
