using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10f;

    [SerializeField] Transform GroundCheck;
    [SerializeField] float GroundDistance = 0.4f;
    [SerializeField] LayerMask GroundMask;

    Rigidbody2D _rigidbody2D;
    BoxCollider2D _playerCollider2D;
    bool _isGrounded = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundDistance,GroundMask);
        Debug.Log(_isGrounded);
        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            inputVector.x = 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Jump!");
            Jump();
        }

        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y,0f);
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
