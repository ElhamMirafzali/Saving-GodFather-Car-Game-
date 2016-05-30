using UnityEngine;
using System.Collections;

public class NitroBarController : MonoBehaviour {


    //static
    public float NitroAmount;
    public float maxNitro;

    public UnityEngine.UI.Image nitroBar;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        updateCarNitro();
    }

    public void reduceNitro(int amount = 1)
    {
        NitroAmount -= amount;
    }

    public void increaseNitro(int amount = 1)
    {
        NitroAmount += amount;
    }

    private void updateCarNitro()
    {
        if (Mathf.Abs(nitroBar.fillAmount * 100) != Mathf.Abs((NitroAmount / maxNitro) * 100))
        {
            float diff = nitroBar.fillAmount - (NitroAmount / maxNitro);
            if (diff > 0)
            {
                nitroBar.fillAmount -= 1 * Time.deltaTime;
            }
            else
            {
                nitroBar.fillAmount += 1 * Time.deltaTime;
            }
        }
    }
}
