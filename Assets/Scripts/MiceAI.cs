using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiceAI : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public ParticleSystem dust;
    private float speed;
    private float size;
    private float turn;
    private float HP;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5f, 15f);
        size = 10f / speed;
        transform.localScale = new Vector2(size, size);
        HP =  size / 2f;
        transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        transform.position = new Vector3(Random.Range(-12f, 12f), Random.Range(-7f, 7f), transform.position.z);
        InvokeRepeating("Rando", 1.0f, Random.Range(0.25f, 0.75f));
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
        if (turn >= 8f)
        {
            transform.Rotate(0f, 0f, Random.Range(0.5f, 1f));
        }

        if (turn <= -8f)
        {
            transform.Rotate(0f, 0f, Random.Range(-1f, -0.5f));
        }

        if (turn == 3) {

            transform.Rotate(0f, 0f, Random.Range(1f, 2f));
        }

        else
        {
            transform.Rotate(0f, 0f, Random.Range(-0.5f, 0.5f));
        }
    }

    void Rando() {

        turn = Random.Range(-10.0f, 10.0f);

    }

    public void thrust()
    {
        rb2D.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        dust.Play();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Player" || col.gameObject.tag == "Bot")
        {
            turn = 3;
        }
    }
}
