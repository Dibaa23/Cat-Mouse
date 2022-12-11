using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiceAI : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public ParticleSystem dust;
    private float speed;
    public float random;
    private float HP = 1f;
    private Vector3 offset = new Vector3(0, 1.25f, 0);


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(8f, 12f);
        InvokeRepeating("Rando", 1.0f, Random.Range(0.1f, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
        thrust();
        if (HP <= 0f)
        {
            Destroy(gameObject);
        }

    }
    public void rotation()
    {
        if (random >= Random.Range(7f, 9f))
        {
            transform.Rotate(0f, 0f, 1f);
        }

        if (random <= Random.Range(-9f, -7f))
        {
            transform.Rotate(0f, 0f, -1f);
        }

        if (random == 3) {

            transform.Rotate(0f, 0f, Random.Range(2f, 4f));
        }

        else
        {
            transform.Rotate(0f, 0f, Random.Range(-0.5f, 0.5f));
        }
    }

    void Rando() {

        random = Random.Range(-10.0f, 10.0f);

    }

    public void thrust()
    {
        rb2D.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Player" || col.gameObject.tag == "Bot")
        {
            random = 3;
        }
    }
}
