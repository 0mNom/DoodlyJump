using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    
    [SerializeField] private float sideSpeed;
    [SerializeField] private GameObject cam;
    public GameObject highP, bullet,muzzle;
    public UI ui;
    public Sprite shoot, normal;
    public SpriteRenderer player;

    public AutoLock enem;

    void Start()
    {
        player.sprite = normal; 
        
    }

    // Update is called once per frame
    void FixedUpdate() //tilt to move left and right 
    {

        if (Input.acceleration.x > 0.03) //right
        {
            float temp = this.transform.position.x;
            temp += sideSpeed * Time.deltaTime* Input.acceleration.x;

            Vector3 pos = Vector3.Lerp(this.transform.position, new Vector3(temp, this.transform.position.y, this.transform.position.z), .6f);
            this.transform.position = pos;

            this.GetComponent<SpriteRenderer>().flipX = false;

        }

        if (Input.acceleration.x < -0.03) //Left
        {
            float temp = this.transform.position.x;
            temp -= sideSpeed * Time.deltaTime* -Input.acceleration.x;


            Vector3 pos = Vector3.Lerp(this.transform.position, new Vector3(temp, this.transform.position.y, this.transform.position.z), .6f);
            this.transform.position = pos;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        
        Touch touch = Input.GetTouch(0); //need a failsafe here
        if (touch.phase == TouchPhase.Began) Shoot();
    }


    public void Shoot()
    {
        StopCoroutine("shooting");
        StartCoroutine("shooting");

       
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DeathBox"|| collision.gameObject.tag == "enemy")
        {
            Debug.Log("YOU ARE DEAD");
            
            Instantiate(highP, new Vector3(5.5f, ui.highest, 0f), Quaternion.identity);
            
            this.transform.position = new Vector3(-0.09f, 1.57f, 0f);
            cam.transform.position = new Vector3(0f, 6.95f, -10f);
        }

        if (collision.gameObject.name == "Walls")
        {
                this.transform.position = new Vector3(-this.transform.position.x, this.transform.position.y, this.transform.position.z);
        }

        if(collision.gameObject.tag == "END")
        {
            //you won 
            //go back to menu 
        }

        
    }

    IEnumerator shooting()
    {
        GameObject go = Instantiate(bullet, muzzle.transform);
       // go.GetComponent<Bullet>().go(enem.closestEnemy.transform.position.x, enem.closestEnemy.transform.position.y);
        //Debug.Log(enem.closestEnemy.transform.position.x );
      //  Debug.Log(enem.closestEnemy.transform.position.y );
        player.sprite = shoot;
        
        yield return new WaitForSecondsRealtime(.2f);
        player.sprite = normal; 
    }
}
