using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiceAI : MonoBehaviour
{
    public GameObject Center;
    public GameObject Cat;
    public Rigidbody2D rb2D;
    public ParticleSystem dust;
    private float speed;
    private float size;
    private float HP;
    private float rotateRate1;
    private float rotateRate2;
    private float chargetime;
    private bool swarm;
    private bool swarmReady;
    private bool runAway;
    private bool boundrybreach;


    // Start is called before the first frame update
    void Start()
    {
        Cat = GameObject.Find("Cat");
        Center = GameObject.Find("Center");
        speed = Random.Range(5f, 15f);
        size = 10f / speed;
        transform.localScale = new Vector2(size, size);
        HP =  size / 2f;
        runAway = false;
        swarm = false;
        rotateRate1 = Random.Range(0.25f, 0.50f);
        rotateRate2 = Random.Range(2.5f, 5.0f);
        boundrybreach = false;
        swarm = false;
        swarmReady = true;
        chargetime = 5f;
        Debug.Log("Swarm : Ready");
        transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        transform.position = new Vector3(Random.Range(-26f, 26f), Random.Range(-17f, 17f), transform.position.z);
        InvokeRepeating("RotateSmall", 1f, rotateRate1);
        InvokeRepeating("RotateBig", 1f, rotateRate2);
    }

    // Update is called once per frame
    void Update()
    {
        thrust();
        Breach();
        Flee();
        //  Swarm();

        if (HP <= 0f)
        {
            Destroy(gameObject);
        }

        else if (Input.GetKeyDown("n") && swarmReady)
        {
            swarm = true;
            StartCoroutine(Normalize2(5));
        }

    }
    void RotateSmall()
    {
        if (!runAway || !boundrybreach)
        {
            transform.Rotate(0f, 0f, Random.Range(-22.5f, 22.5f));
        }
    }

    void RotateBig()
    {
        if (!runAway || !boundrybreach)
        {
            transform.Rotate(0f, 0f, Random.Range(-45, 45));  
        }
    }

    public void thrust()
    {
        rb2D.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        dust.Play();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Border")
        {
            boundrybreach = true;
            transform.Rotate(0f, 0f, 180);
            StartCoroutine(Normalize(Random.Range(0.5f, 2f)));
        }

        else if (col.gameObject.tag == "Bot" || col.gameObject.tag == "Mouse")
        {
            transform.Rotate(0f, 0f, 90);
        }
    }

    public void Flee()
    {
        if (Vector2.Distance(Cat.transform.position, transform.position) <= 10f && (!swarm))
        {
            runAway = true;
            transform.Rotate(0f, 0f, Random.Range(0f, 22.5f));
            transform.position = Vector2.MoveTowards(transform.position, Cat.transform.position, Time.deltaTime * (-4f * speed));
        }

        else
        {
            runAway = false;
        }
    }

    public void Breach()
    {
        if (boundrybreach)
        {
            transform.position = Vector2.MoveTowards(transform.position, Center.transform.position, Time.deltaTime * (0.25f * speed));
        }
    }

    IEnumerator Normalize(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        boundrybreach = false;
    }

    IEnumerator Normalize2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        swarm = false;
        Debug.Log("Swarm : Not Ready");
        yield return new WaitForSeconds(chargetime);
        swarmReady = true;
        Debug.Log("Ready");
    }

    public void Swarm()
    {
        if (Vector2.Distance(Cat.transform.position, transform.position) <= 10f && swarm)
        {
            Debug.Log("Swarm : In Progress");
            transform.position = Vector2.MoveTowards(transform.position, Cat.transform.position, (2 * speed) * Time.deltaTime);
            Vector2 direction = (Vector2)Cat.transform.position - (Vector2)transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle));
            swarmReady = false;
        }
    }
}
