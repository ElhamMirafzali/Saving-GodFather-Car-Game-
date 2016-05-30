using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{

    private float fireX;
    private float fireY;
    private static float fireSpeed;
    private float fireYLength;
    public bool isFireExisted;
    int fireTmp;
    private int fireXTemp;

    // Use this for initialization
    void Start()
    {
        //print(12345);
        fireSpeed = RoadController.speed;
        fireYLength = RoadController.roadY;
        print(fireSpeed + "  " + fireYLength);
        isFireExisted = false;
        Random.seed = 77;
        this.gameObject.GetComponent<Renderer>().enabled = false;

        InvokeRepeating("generateFire", 1, 2);

    }

    private void generateFire()
    {
        if (!isFireExisted)
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;
      
            isFireExisted = true;
            fireXTemp = Random.Range(-1, 2);
            fireX = fireXTemp * 1.1f;
            
            fireY = 8f;

            transform.position = new Vector2(fireX, fireY);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                this.gameObject.GetComponent<Rigidbody2D>().velocity.x, -fireSpeed - fireSpeed * Time.deltaTime);
            
        }
    }

    void Update()
    {

        //if (!isFireExisted)
        //{
        //    this.gameObject.GetComponent<Renderer>().enabled = true;
        //    fireTmp = Random.Range(0, 20);
        //    //print(fireTmp);
        //    if (fireTmp > 1)
        //    {
        //        isFireExisted = true;
        //        fireXTemp = Random.Range(-1, 2);
        //        fireX = fireXTemp * 1.1f;
        //        //fix it
        //        fireY = 8f;

        //        transform.position = new Vector2(fireX, fireY);
        //        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
        //            this.gameObject.GetComponent<Rigidbody2D>().velocity.x, -fireSpeed - fireSpeed * Time.deltaTime);
        //    }
        //}
        //else if (transform.position.y < 0)
        //{
        //    this.gameObject.GetComponent<Renderer>().enabled = false;
        //    isFireExisted = false;
        //}


        if (transform.position.y < 0)
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
            isFireExisted = false;
        }


    }
}
