using UnityEngine;
using System.Collections;

public class RoadController : MonoBehaviour{

    public static float roadY;
	public static float speed = 6f;

    private Rigidbody2D _rigidBody;
    public int index;

	// Use this for initialization
	void Start () {
        roadY = this.gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
       // print(roadY);
        _rigidBody = GetComponent<Rigidbody2D>();
  	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -roadY / 2)
        {
            transform.position = new Vector2(transform.position.x,   Roadmanager.Insatnce.GetRoad((index+3)%4).transform.position.y+8);
        }
        
     //   _rigidBody.velocity = new Vector2(_rigidBody.velocity.x,  - speed * Time.deltaTime);

        //transform.position = new Vector2 (transform.position.x, transform.position.y - speed*Time.deltaTime);
         
       
	}
    void LateUpdate()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
      
        
    }
    //void OnBecameInvisible()
    //{
    //    transform.position = new Vector2(transform.position.x, 28);
    //}

}
