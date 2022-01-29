using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start()
    {
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(100f,0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            collision.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }

    public void go(float x, float y)
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y));
    }
}
