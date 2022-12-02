using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //Increment score
            GameManager.instance.Increment();
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Boundary")
        {
            //Decrease Lives
            GameManager.instance.DecreaseLife();
            Destroy(gameObject);
        }
    }
}
