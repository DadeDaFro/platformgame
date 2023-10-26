using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWaterCollision : MonoBehaviour
{
    public bool inWater = false;
    public Animator myAnim; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inWater = true;
            myAnim.SetBool("swim", true); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inWater = false; 
            myAnim.SetBool("swim", false);
        }
    }

    /*private void OnCollisionEnter(Collision2D collision)
    {
        if
    }*/
}

