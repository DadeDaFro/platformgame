using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl2door : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {

            if(gameObject.name == "castle door")
            {
                SceneManager.LoadScene(1);
            }
            if(gameObject.name == "chest")
            {
                SceneManager.LoadScene(2);
            }
            /*if (Input.GetKeyDown(KeyCode.O))
            {*/
                
            //}
        }


    }
}
    
