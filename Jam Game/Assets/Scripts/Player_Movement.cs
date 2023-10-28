using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10f;
    private void Update()
    {
        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            inputVector.x = 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump!");
        }

        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y,0f);
        transform.position += moveDir * MovementSpeed * Time.deltaTime;
        Debug.Log(inputVector);
    }
}
