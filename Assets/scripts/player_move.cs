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
    Animator myAnim;
    SpriteRenderer myRend;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>(); 
        myAnim = GetComponent<Animator>();
        myRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        
        if(Input.GetButtonDown("Jump") && grounded )
        {
            myAnim.SetBool("jump", true); 
            jump = true;
        }

        if (Input.GetButton("Sprint")) 
        {
            myAnim.SetBool("run", true); 
            sprint = true;
        }
        if(horizontalMove == 0)
        {
            myAnim.SetBool("run", false); 
            sprint = false;
        }

        if (horizontalMove > 0.2f)
        {
            myAnim.SetBool("walk", true);
            myRend.flipX = true;
        }
        else if(horizontalMove < -0.2)
        {
            myAnim.SetBool("walk", true);
            myRend.flipX = false;
        }
        else
        {
            myAnim.SetBool("walk", false); 
        }
        
       


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
            myAnim.SetBool("jump", false); 
            grounded = true;
        }
        else
        {
            grounded = false; 
        }

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0f); 
    }

    
}
