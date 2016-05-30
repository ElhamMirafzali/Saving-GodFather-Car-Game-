using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GodFatherCarController : MonoBehaviour {

    public GodFatherHealthBarController healthController;
    public BrakeBarController brakeController;
    public NitroBarController nitroController;

    public UIManager ui;
    public Text scoreText;
    private int score = 0;

    public int health = 10;
    public int maxHealth=10;

    public int brake = 10;
    public int maxBrake = 10;

    public int carNitro = 8;
    public int maxNitro = 15;

	private IEnumerator changeLaneCRV;
	private bool 		isGameStarted;
    private bool        isBrakeActive;
    private bool        isNitroActive;
	private Vector2		targetPos;
    private AudioSource brakeSound;
    public GameObject gunShotPrefab;
    public GameObject bombShotPrefab;
    private Animator animator;

    public enum Direction
    {
        Right,
        Left,
        Streight
    }

    List<GameObject> weapons = new List<GameObject>();
    private int waponsListIndex;
    private int scoreIncreaseNumber;



    // Use this for initialization
    void Start () {

        brakeSound = this.gameObject.GetComponent<AudioSource>();
	
		changeLaneCRV = carChangeLaneCR(transform.position ,new Vector2(0.0f, 1.2f), 1f);
        StartCoroutine (changeLaneCRV);
		isGameStarted = false;
        isBrakeActive = false;
        isNitroActive = false;
        weapons.Add(gunShotPrefab);
        weapons.Add(bombShotPrefab);
        waponsListIndex = 0;

        healthController = GameObject.Find("MainCanvas").GetComponent<GodFatherHealthBarController>();
        healthController.healthAmount = health;
        healthController.maxHealth = maxHealth;

        brakeController = GameObject.Find("MainCanvas").GetComponent<BrakeBarController>();
        brakeController.maxBrake = maxBrake;
        brakeController.brakeAmount = brake;

        nitroController = GameObject.Find("MainCanvas").GetComponent<NitroBarController>();
        nitroController.maxNitro = maxNitro;
        nitroController.NitroAmount = carNitro;

        InvokeRepeating("increseNitro", 0, 8);

        InvokeRepeating("increseBrake", 0, 15);

        InvokeRepeating("increseBrake", 0, 80);

        animator = this.gameObject.GetComponent<Animator>();

        scoreIncreaseNumber = 1;



    }

    // Update is called once per frame
    void Update () {
        if (isGameStarted)
        {
            score+= scoreIncreaseNumber;
            scoreText.text = "Score: " + score;

            if (Input.GetKeyDown(KeyCode.RightArrow) )
            {
                if (isBrakeActive || isNitroActive)
                {
                    
                    targetPos = new Vector2(targetPos.x + 1.1f, targetPos.y);
                    targetPos.x = Mathf.Clamp(targetPos.x, -1.1f, 1.1f);
                    changeLaneCRV = carChangeLaneCR(transform.position, targetPos, 0.2f,Direction.Right);
                    StartCoroutine(changeLaneCRV);
                    
                }
                else
                {
                    StopCoroutine(changeLaneCRV);

                    animator.SetBool("go_left", false);
                    animator.SetBool("go_right", false);
                    animator.SetBool("default_flag", true);

                    targetPos = new Vector2(targetPos.x + 1.1f, targetPos.y);
                    targetPos.x = Mathf.Clamp(targetPos.x, -1.1f, 1.1f);
                    changeLaneCRV = carChangeLaneCR(transform.position, targetPos, 0.2f, Direction.Right);
                    StartCoroutine(changeLaneCRV);
                }
                
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (isBrakeActive || isNitroActive)
                {
                    targetPos = new Vector2(targetPos.x - 1.1f, targetPos.y);
                    targetPos.x = Mathf.Clamp(targetPos.x, -1.1f, 1.1f);
                    changeLaneCRV = carChangeLaneCR(transform.position, targetPos, 0.2f, Direction.Left);
                    StartCoroutine(changeLaneCRV);
                }
                else
                {
                    StopCoroutine(changeLaneCRV);

                    animator.SetBool("go_left", false);
                    animator.SetBool("go_right", false);
                    animator.SetBool("default_flag", true);


                    targetPos = new Vector2(targetPos.x - 1.1f, targetPos.y);
                    targetPos.x = Mathf.Clamp(targetPos.x, -1.1f, 1.1f);
                    changeLaneCRV = carChangeLaneCR(transform.position, targetPos, 0.2f, Direction.Left);
                    StartCoroutine(changeLaneCRV);
                }
               
            }
            

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (brake > 1 && !isBrakeActive)
                {
                    StopCoroutine(changeLaneCRV);

                    animator.SetBool("go_left", false);
                    animator.SetBool("go_right", false);
                    animator.SetBool("default_flag", true);

                    brake -= 2;
                    brakeController.reduceBrake();
                    changeLaneCRV = tormoz();
                    StartCoroutine(changeLaneCRV);
                    
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                
                if (carNitro > 0 && !isNitroActive)
                {
                    carNitro--;
                    nitroController.reduceNitro();
                    changeLaneCRV = nitro();
                    StartCoroutine(changeLaneCRV);
            
                }
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject.Instantiate(weapons[waponsListIndex]);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                waponsListIndex = (waponsListIndex+1) % weapons.Count;
                print(waponsListIndex);
            }
        }
	}

    private void increseNitro()
    {
        if (carNitro < maxNitro)
        {
            carNitro++;
            nitroController.increaseNitro();
        }
    }

    private void increseBrake()
    {
        if (brake < maxBrake)
        {
            brake++;
            brakeController.increaseBrake();
        }
    }

    public void goToNextLEvel()
    {
        ui.goToNextLevel();
    }

	IEnumerator carChangeLaneCR(Vector2 source, Vector2 target, float overTime,Direction d = Direction.Streight)
	{
		float startTime = Time.time;
        if (d.Equals(Direction.Right))
        {
            animator.SetBool("default_flag", false);
            animator.SetBool("go_right", true);
        } else if (d.Equals(Direction.Left))
        {
            animator.SetBool("default_flag", false);
            animator.SetBool("go_left", true);
        }
		while (Time.time < startTime + overTime)
		{
			transform.position = Vector2.Lerp(source, target, (Time.time - startTime) / overTime);
			yield return null;
		}

        transform.position = target;

        if (d.Equals(Direction.Right))
        {
            animator.SetBool("go_right", false);
            animator.SetBool("default_flag", true);
        }
        else if (d.Equals(Direction.Left))
        {
            animator.SetBool("go_left", false);
            animator.SetBool("default_flag", true);
        }

        if (!isGameStarted)
        {
            isGameStarted = true;
            targetPos = transform.position;
        }
        
        

	}
    IEnumerator tormoz()
    {

        isBrakeActive = true;
        RoadController.speed -= 5;

        brakeSound.Play();
        yield return new WaitForSeconds(.9f);
       
        RoadController.speed += 5;
        brakeSound.Stop();

        isBrakeActive = false;

    }

    IEnumerator nitro()
    {

        isNitroActive = true;
        RoadController.speed += 10;
        scoreIncreaseNumber+=2;

        //handle the dound here
        yield return new WaitForSeconds(3.5f);

        RoadController.speed -= 10;
        //brakeSound.Stop();
        scoreIncreaseNumber-=2;

        isNitroActive = false;

    }


    IEnumerator gameOver()
    {
        this.gameObject.SetActive(false);
        //Destroy(gameObject);
        Time.timeScale = 0;
        ui.gameOverActivated();

        yield return null;

    }



    void OnCollisionEnter2D()
    {
       //

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        GameObject tmp = other.gameObject;
      //  GameObject current = this.gameObject;
        if ( tmp.tag == "Enemy Car")
        {
            tmp.GetComponent<Renderer>().enabled = false;

            health--;
            healthController.makeDamageOnGodFather();
            if (health == 0)
            {

                changeLaneCRV = gameOver();
                StartCoroutine(changeLaneCRV);
            }
        }

        switch (tmp.name)
        {
            case "fire":

                tmp.GetComponent<Renderer>().enabled = false;
                tmp.GetComponent<FireController>().isFireExisted = false;

                health--;
                healthController.makeDamageOnGodFather();
                if (health == 0)
                {

                    changeLaneCRV = gameOver();
                    StartCoroutine(changeLaneCRV);
                    //Application.LoadLevel(0);
                }
                
                break;

            case "carHealth_0":

                tmp.GetComponent<Renderer>().enabled = false;
                tmp.GetComponent<HealthController>().isHealthExisted = false;
                if (health < maxHealth)
                {
                    healthController.giveHealth(1);
                    health++;
                }
                break;

        }


    

    }
   
}
