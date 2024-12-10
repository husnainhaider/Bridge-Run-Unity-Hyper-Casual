using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpObstacle : MonoBehaviour
{
    // sprites for obstacle status

    public Sprite obstacleBtnOn, obstacleBtnOff;

    public GameObject sharpObjectChild;
    // Start is called before the first frame update


    void Start()
    {
        sharpObjectChild.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }


    /*  private void OnTriggerEnter2D(Collider2D other)
      {
          if (other.gameObject.CompareTag("car"))
          {
              // active the sharp obstacle by changing the sprite first then start the animation 
              gameObject.GetComponent<SpriteRenderer>().sprite = obstacleBtnOn;

              //start sharp animation
              sharpObjectChild.SetActive(true);

              gameObject.GetComponent<BoxCollider2D>().enabled = false;
          }


      }*/

    private void OnCollisionEnter2D(Collision2D other) {
           
        if (other.gameObject.CompareTag("car"))
        {
            // active the sharp obstacle by changing the sprite first then start the animation 
            gameObject.GetComponent<SpriteRenderer>().sprite = obstacleBtnOn;

            //start sharp animation
            sharpObjectChild.SetActive(true);

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }


}
