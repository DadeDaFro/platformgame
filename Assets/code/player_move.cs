using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    bool grounded = false;
    bool jump = false;


    public float castDist = 1f; 
    public float jumpLimit = 20f;
    public float gravityScale = 5f;
    public float gravityFall = 20f;


    float horizontalMove;


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
    }
    
    void FixedUpdate()
    {
        float moveSpeed = horizontalMove * speed;

        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse); 
            jump = false;
        }
        Debug.Log("jump"); 
        if (myBody.velocity.y >= 0f)
        {
            myBody.gravityScale = gravityScale;
        }else if (myBody.velocity.y < 0f){
            myBody.gravityScale = gravityFall;
        }
            
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);

        Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);

        if (hit.collider != null && hit.transform.name == "Ground")
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
