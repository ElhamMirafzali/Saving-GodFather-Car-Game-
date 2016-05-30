using UnityEngine;
using System.Collections;

public class GodFatherHealthBarController : MonoBehaviour {


   
    //static
	public  float healthAmount;
	public  float maxHealth;

	public UnityEngine.UI.Image healthBar;

	// Use this for initialization
	void Start () {

     
	}
	
	// Update is called once per frame
	void Update () {
		updateGodFatherHealth ();
	}

	public  void makeDamageOnGodFather(int amount=1){
		healthAmount -= amount;
	}

    public void giveHealth(int amount = 1)
    {
        healthAmount += amount;
    }

	private void updateGodFatherHealth(){
		if (Mathf.Abs (healthBar.fillAmount * 100) != Mathf.Abs ((healthAmount / maxHealth) * 100)) {
			float diff = healthBar.fillAmount - (healthAmount / maxHealth);
			if (diff > 0) {
				healthBar.fillAmount -= 1 * Time.deltaTime;
			} else {
				healthBar.fillAmount += 1 * Time.deltaTime;
			}
		}
	}
}
