using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10f;
    [SerializeField] float JumpHeight = 5f;
    [SerializeField] float GravityScale = 5;

    //parametrii legati de saritura
    [SerializeField] Transform GroundCheck;
    [SerializeField] ContactFilter2D Filter;
    bool _isGrounded;
    Collider2D[] results = new Collider2D[1];
   
    float velocityY;

    private void Update()
    {
        velocityY += Physics2D.gravity.y * GravityScale * Time.deltaTime;
        
        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            inputVector.x = 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector.x = -1;
        }
       
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            velocityY = Mathf.Sqrt(-2 * JumpHeight * (Physics2D.gravity.y * GravityScale));
        }

        //normalizez inputul just in case
        inputVector = inputVector.normalized;
        
        //translatez inputul pe transformul playerului
        Vector3 moveDir = new Vector3(inputVector.x, velocityY,0f);
        transform.position += moveDir * MovementSpeed * Time.deltaTime;



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
    }


    void Jump()
    {
        
    }
    
}
