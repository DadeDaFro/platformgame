using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class platformController : MonoBehaviour
{

    public Transform posA, posB;
    public int Speed;
    Vector2 targetPos; 

    // Start is called before the first frame update
    void Start()
    {
        targetPos = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log(transform.position);


        if (Vector2.Distance(transform.position, posA.position) < .1f)
        {
          //UnityEngine.Debug.Log("hitL");
            targetPos = posB.position;
        }


        if (Vector2.Distance(transform.position, posB.position) < .1f)
        {
           //UnityEngine.Debug.Log("hitR");
            targetPos = posA.position;
        }
        

        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
