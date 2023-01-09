using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBot : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private float speed;
    private Vector3 offset = new Vector3(0, 1.2f, 0);
    public List<GameObject> mice = new List<GameObject>();
    public GameObject closestMice;


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

    public void FindMice()
    {
        GameObject closest = null;
        float distance = 1000.0f;
        Vector3 position = transform.position;
        foreach (GameObject g in mice)
        {
            Vector3 diff = g.transform.position - position;
            if (diff.sqrMagnitude < distance)
            {
                closest = g;
                distance = diff.sqrMagnitude;
            }
            
        }

        closestMice = closest;
    }


    public void rotation()
    {
        FindMice();
        double x = transform.position.x - closestMice.transform.position.x + 2;
        double y = transform.position.y - closestMice.transform.position.y;
        double deg = Math.Atan(y / x) * 2 / 3.1415926;
        if (deg > 0)
        {
            deg -= 1;
        }
        else
        {
            deg += 1;
        }

        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(transform.rotation.z);
        Debug.Log(deg);

        if (deg - transform.rotation.z > 0)
        {
            transform.Rotate(0f, 0f, 1f);
        }

        if (deg - transform.rotation.z < 0)
        {
            transform.Rotate(0f, 0f, -1f);
        }
    }

    public void thrust() {
        rb2D.AddForce(transform.right * speed * Time.deltaTime, ForceMode2D.Impulse);      
    }
}
