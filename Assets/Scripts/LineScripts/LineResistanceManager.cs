using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineResistanceManager : MonoBehaviour
{


   [HideInInspector] public float allLinesLineResistance;   // the sum of lines force
   [HideInInspector] public float currentLineResistance;   // current force(resistance)all lines force curen

    public static LineResistanceManager instance;


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



    public void setupdAlllienResistance(float force)
    {
        allLinesLineResistance += force;
        currentLineResistance = allLinesLineResistance;

    }

    public void updateAllLineResistance()
    {

        currentLineResistance--;


    //**********    HealthBarImage.instance.setHealthValue(currentLineResistance / allLinesLineResistance); //to change the line force
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
