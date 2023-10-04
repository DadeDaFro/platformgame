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
            if (Input.GetKeyDown(KeyCode.O))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
    
