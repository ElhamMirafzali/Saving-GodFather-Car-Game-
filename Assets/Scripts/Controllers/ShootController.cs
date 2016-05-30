using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour
{

    private float shotX;
    private float shotY;
    public float shotSpeed=0.8f;
    private float shotYLength;
    int shotTmp;
    private int shotXTemp;

    // Use this for initialization
    void Start()
    {
        shotX = GameObject.Find("RollsRoyce").transform.position.x;
        shotYLength = RoadController.roadY;
       // shotX = 0f;
        //fix it
        shotY = 3.2f;

        transform.position = new Vector2(shotX, shotY);

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, +shotSpeed + shotSpeed * Time.deltaTime);
      

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > shotYLength)
        {
            Destroy(this.gameObject);
        }
        else
        {

         }



    }

    void OnTriggerEnter2D(Collider2D other)
    {

        GameObject temp = other.gameObject;

        if (temp.tag == "Enemy Car")
        {
            temp.GetComponent<Renderer>().enabled = false;
            Destroy(temp);

            
        }
    }
    
}
