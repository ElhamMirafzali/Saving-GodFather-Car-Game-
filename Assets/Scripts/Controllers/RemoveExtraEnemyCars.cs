using UnityEngine;
using System.Collections;

public class RemoveExtraEnemyCars : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject tmp = other.gameObject;

        if (tmp.tag == "Enemy Car")
        {
            Destroy(tmp);
        }
    }
}
