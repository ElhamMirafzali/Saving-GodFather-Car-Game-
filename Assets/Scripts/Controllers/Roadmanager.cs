using UnityEngine;
using System.Collections;

public class Roadmanager : MonoBehaviour {

	// Use this for initialization
    public RoadController[] Roads;
    public static Roadmanager Insatnce;
    void Awake()
    {
        Insatnce = this;
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public RoadController GetRoad(int index)
    {
        return Roads[index];
    }
}
