using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolleverCheck : MonoBehaviour
{
    bool fTime = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("line"))
        {
            if (fTime == false)
            {
                fTime = true;
                StartCoroutine(CarControler.instance.Car_rellover());

                // gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

            }

        }

    }
}
