using UnityEngine;
using System.Collections;

public class BrakeBarController : MonoBehaviour {


 
    //static
	public  float brakeAmount;
	public  float maxBrake;

	public UnityEngine.UI.Image brakeBar;

	// Use this for initialization
	void Start () {

     
	}
	
	// Update is called once per frame
	void Update () {
        updateCarBrake();
	}

	public  void reduceBrake(int amount= 2){
        brakeAmount -= amount;
	}

    public void increaseBrake(int amount = 2)
    {
        brakeAmount += amount;
    }

	private void updateCarBrake(){
        if (Mathf.Abs(brakeBar.fillAmount * 100) != Mathf.Abs((brakeAmount / maxBrake) * 100))
        {
            float diff = brakeBar.fillAmount - (brakeAmount / maxBrake);
			if (diff > 0) {
                brakeBar.fillAmount -= 2 * Time.deltaTime;
			} else {
                brakeBar.fillAmount += 2 * Time.deltaTime;
			}
		}
	}
}
