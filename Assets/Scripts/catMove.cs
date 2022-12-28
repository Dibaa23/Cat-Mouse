using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class catMove : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private float speed;
    private Vector3 offset = new Vector3(0, 1.2f, 0);


    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
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
    }

    public void thrust() {
		rb2D.AddForce(transform.right * speed * Time.deltaTime, ForceMode2D.Impulse);      
    }
}
