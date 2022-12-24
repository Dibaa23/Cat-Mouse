using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public Image healthBorderimg;
    public Image healthBarimg;
    private float HP = 1f;
    private Vector3 offset = new Vector3(0, 1.45f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0f) {
            Destroy(gameObject);
        }
        HealthFill();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            HP -= 0.1f;
        }
    }

    public void HealthFill()
    {
        healthBorderimg.transform.position = transform.position + offset;
        healthBarimg.fillAmount = HP;
    }
}
