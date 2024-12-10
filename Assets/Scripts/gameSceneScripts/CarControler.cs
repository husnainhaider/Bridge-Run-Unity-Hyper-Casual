using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControler : MonoBehaviour
{

    public static CarControler instance;


    public WheelJoint2D car_wheelJoint2d_front;
    public WheelJoint2D car_wheelJoint2d_back;

    public GameObject explosionEffects;
    public float car_speed;

    private bool isCarLose = false;

    Vector3 priorFrameTransform;

    bool IsBeingMoved = false;

    bool carStartMoving;
    bool firstTimeCalled = true;




    public float speed;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        moveTheCar(false);
        playIdleSound();

        GetComponent<Rigidbody2D>().centerOfMass = new Vector3(2, -3.5f, 0);
        IsBeingMoved = false;
        priorFrameTransform = transform.position;



        //  moveTheCar();
        //   car_wheelJoint2d_front.motor.motorSpeed=100f;
    }


    public void moveTheCar(bool b)
    {
        if (b == true)
        {
            GameSoundManager.instance.PlayaudioCLip(GameSoundManager.GamesAudioClipsList.car_acceleration);
        }
        carStartMoving = b;
        car_wheelJoint2d_front.useMotor = b;
        car_wheelJoint2d_back.useMotor = b;
    }


    private void Update()
    {

        if (transform.position.y < -25)
        {
            StartCoroutine(Car_rellover());
        }


    }



    void playIdleSound()
    {
        GameSoundManager.instance.PlayaudioCLip(GameSoundManager.GamesAudioClipsList.Car_idle);
    }
    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("colider with" + other.gameObject.name);
        if (other.gameObject.CompareTag("Win_Flag") && isCarLose == false)
        {
            GameSoundManager.instance.PlayaudioCLip(GameSoundManager.GamesAudioClipsList.car_horn);

            // call wining methode
            Game_scneManager.instance.playerWinLevel();
            Invoke("destroy_cars", 1.2f);
        }
    }



    private void destroy_cars()
    {
        Destroy(gameObject);
        if (OtherCarsController.instance != null)
        {
            OtherCarsController.instance.destoryCar();
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {

        //Debug.Log("colider with" + other.gameObject.name);
        if (other.gameObject.CompareTag("sharpObject") || other.gameObject.CompareTag("enemy_cars") && isCarLose == false)
        {
            StartCoroutine(Car_rellover());

            Destroy(other.gameObject);

        }

    }

    /* public IEnumerator carBeignnotMoved()
     {
         while (IsBeingMoved == false)
         {
             yield return new WaitForSeconds(2.0f);
         }
         // the car dosnt work as wel it should so destroy it
         StartCoroutine(Car_rellover());

     }*/


    public IEnumerator Car_rellover()
    {
        if (isCarLose == false)
        {
            isCarLose = true;
            moveTheCar(false);

            car_wheelJoint2d_front.enabled = car_wheelJoint2d_back.enabled = false;
            GameSoundManager.instance.PlayaudioCLip(GameSoundManager.GamesAudioClipsList.car_horn);
            GameObject fx = Instantiate(explosionEffects, transform.position, Quaternion.identity);
            fx.transform.SetParent(transform);

            yield return new WaitForSeconds(2.5f);

            //desable car colider to get bets performance for the next animation step to brigns up the u panels
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;

            // play losing  animation to bring lose ui element to the screen
            Game_scneManager.instance.playerLoseLevel();
            yield return new WaitForSeconds(2.0f);
            Destroy(gameObject);
            Game_scneManager.instance.restartLevel();
        }
    }

}

