using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    bool grounded = false;
    bool jump = false;
    bool sprint = false; 
    /*bool sprintTog = false; */

    public float castDist = 1.5f; 
    public float jumpPower = 20f;
    public float gravityScale = 5f;
    public float gravityFall = 20f;


    float horizontalMove;

    public float sprintSpeed = 10f; 
    public float speed = 5f; 

    Rigidbody2D myBody; 

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        
        if(Input.GetButtonDown("Jump") && grounded )
        {
            jump = true;
        }

        if (Input.GetButton("Sprint")) 
        {
            sprint = true;
        }
        if(horizontalMove == 0)
        {
            sprint = false;
        }
       /* else if( horizontalMove == 0 )
        {
            sprintTog = false;
        }

       /* if(sprintTog == false)
        {
            sprint = false; 
        }*/

        Debug.Log("sprint = " + sprint);
    }
    
    void FixedUpdate()
    {
        float moveSpeed = 0; 
        if(sprint)
        {
           moveSpeed = horizontalMove * sprintSpeed; 
        }
        else
        {
            moveSpeed = horizontalMove * speed; 
        }

        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); 
            jump = false;
        }
        Debug.Log("jump"); 
        if (myBody.velocity.y >= 0)
        {
            myBody.gravityScale = gravityScale;
        }else if (myBody.velocity.y < 0){
            myBody.gravityScale = gravityFall;
        }
            
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);

        Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);

        if (hit.collider != null && hit.transform.tag == "Ground")
        {
            grounded = true;
        }
        else
        {
            grounded = false; 
        }

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0f); 
    }

    
}
