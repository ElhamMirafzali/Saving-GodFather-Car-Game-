using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{

    private float healthX;
    private float healthY;
    private static float healthSpeed;
    private float healthYLength;
    public bool isHealthExisted;
    int healthTmp;
    private int healthXTemp;

    // Use this for initialization
    void Start()
    {
        healthSpeed = RoadController.speed;
        healthYLength = RoadController.roadY;
       // print(healthSpeed + "  " + healthYLength);
        isHealthExisted = false;
        Random.seed = 40;
        this.gameObject.GetComponent<Renderer>().enabled = false;

        InvokeRepeating("generateHealth", 0, 4);
        
    }

    private void generateHealth()
    {
        if (!isHealthExisted)
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;

            isHealthExisted = true;
            healthXTemp = Random.Range(-1, 2);
            healthX = healthXTemp * 1.1f;
            //fix it
            healthY = 8f;

            transform.position = new Vector2(healthX, healthY);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                this.gameObject.GetComponent<Rigidbody2D>().velocity.x, -healthSpeed - healthSpeed * Time.deltaTime);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isHealthExisted)
        //{
        //    this.gameObject.GetComponent<Renderer>().enabled = true;
            
        //    healthTmp = Random.Range(0, 20);

        //    if (healthTmp > 1)
        //    {
        //        isHealthExisted = true;
        //        healthXTemp = Random.Range(-1, 2);
        //        healthX = healthXTemp * 1.1f;
        //        //fix it
        //        healthY = 8f;

        //        transform.position = new Vector2(healthX, healthY);
        //        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
        //            this.gameObject.GetComponent<Rigidbody2D>().velocity.x, -healthSpeed - healthSpeed * Time.deltaTime);
        //    }
        //}
        //else if (transform.position.y < 0)
        //{
        //    this.gameObject.GetComponent<Renderer>().enabled = false;
        //    isHealthExisted = false;
        //}

        if (transform.position.y < 0)
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
            isHealthExisted = false;
        }

    }
}
