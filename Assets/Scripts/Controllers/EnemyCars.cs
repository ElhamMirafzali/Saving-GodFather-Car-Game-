using UnityEngine;
using System.Collections;

public class EnemyCars : MonoBehaviour {
   // public GameObject car;
    public GameObject[] cars;
    int carNo;
    public float maxPos = 1.1f;
    public float delayTimer = 12f;
    float timer;

    private float enemyCarX;
    private float enemyCarY;
    private int enemyCarXTemp;



    
            

	// Use this for initialization
	void Start () {
        timer = delayTimer;
	}

    
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            enemyCarXTemp = Random.Range(-1, 2);
            enemyCarX = enemyCarXTemp * 1.1f;
            enemyCarY = 12f;

            Vector2 carPos = new Vector2(enemyCarX, enemyCarY);
            //Vector3 carPos = new Vector3(Random.Range(-1.1f, 1.1f), transform.position.y, transform.position.z);
            carNo = Random.Range(0, 6);
            Instantiate(cars[carNo], carPos, transform.rotation);
            timer = delayTimer;
        }
	}
}
