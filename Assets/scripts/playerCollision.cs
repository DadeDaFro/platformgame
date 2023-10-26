using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerCollision : MonoBehaviour
{
    public Animator myAnim; 

    public Transform restartTransform;
    public Transform restartTransform2;
    public Transform restartTransform3;
    public Transform restartTransform4;
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
        if (collision.gameObject.name == "bottomBounds")
        {
            transform.position = restartTransform.position;
        }
        if (collision.gameObject.name == "bottomBounds2")
        {
            transform.position = restartTransform2.position;
        }
        if (collision.gameObject.name == "bottomBounds3")
        {
            transform.position = restartTransform3.position;
        }
        if (collision.gameObject.name == "buzzsaw")
        {
            transform.position = restartTransform.position;
        }
        if (collision.gameObject.name == "axe")
        {
            transform.position = restartTransform.position;
        }
        if (collision.gameObject.name == "axe2")
        {
            transform.position = restartTransform3.position;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "waterEnemy")
        {
            Debug.Log("HIT");
            transform.position = restartTransform4.position;
        }
        if (myAnim.GetBool("push") == false)
        {
            if (collision.gameObject.name == "monolith" || collision.gameObject.name == "monolith2")
            {
                myAnim.SetBool("push", true);
            }
        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "monolith" || collision.gameObject.name == "monolith2")
        {
            myAnim.SetBool("push", false);
        }
    }



}
