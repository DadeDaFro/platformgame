using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterEnemy : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    Vector3 targetPos;
    [SerializeField]
    Transform playerPos; 
    [SerializeField]
    playerWaterCollision player;
    
    [SerializeField]
    float speed = 2f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.inWater == true)
        {
            Debug.Log("inwater"); 
            transform.position = Vector3.MoveTowards(this.transform.position, playerPos.transform.position, speed * Time.deltaTime); 
        }
        if(player.inWater == false)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, spawnPoint.transform.position, speed * Time.deltaTime);
        }
    }
}
