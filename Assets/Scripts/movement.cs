using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public ParticleSystem dust;
    private float speed;
    private float stamina;
    public Image staminaBorderimg;
    public Image staminaBarimg;
    private Vector3 offset = new Vector3(0, 1.2f, 0);


    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        stamina = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
        thrust();
        StaminaFill();
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
        if (stamina > 0f && Input.GetKey(KeyCode.W))
        {
            speed = 20f;
            stamina -= (2 * Time.deltaTime);
        }

        else if (stamina < 10f && !Input.GetKey(KeyCode.W))
        {
            StartCoroutine("Regen", 3f);
        }

        else {

            speed = 10f;

        }
    }


    IEnumerator Regen(float duration)
    {
        speed = 10f;
        yield return new WaitForSeconds(duration);
        if (stamina < 10f && !Input.GetKey(KeyCode.W)) {
            stamina += Time.deltaTime;
        }
    }

    public void StaminaFill()
    {
        staminaBorderimg.transform.position = transform.position + offset;
        staminaBarimg.fillAmount = stamina / 10;
    }
}
