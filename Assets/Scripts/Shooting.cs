using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform ball;
    public GameObject bullet;
    public bool ready = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            shoot();
        }
    }

    void shoot()
    {
        if (!ready)
        {
            return;
        }
        StartCoroutine(CD());
    }
         
    public IEnumerator CD()
    {
        ready = false;
        GameObject clone = (GameObject) Instantiate(bullet, ball.position, ball.rotation);
        Debug.Log(ball.rotation);
        yield return new WaitForSeconds(0.25f);
        ready = true;
        Destroy(clone, 3f);
    }
}
