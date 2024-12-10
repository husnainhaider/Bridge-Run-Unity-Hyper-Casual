using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarsController : MonoBehaviour
{
    public static OtherCarsController instance;


    public WheelJoint2D car_wheelJoint2d_front;
    public WheelJoint2D car_wheelJoint2d_back;


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

    private void Start()
    {
        moveTheCar(false);
    }


    public void moveTheCar(bool status)
    {
        car_wheelJoint2d_front.useMotor = status;
        car_wheelJoint2d_back.useMotor = status;

    }

    public void destoryCar()
    {

        Destroy(gameObject);
    }
}
