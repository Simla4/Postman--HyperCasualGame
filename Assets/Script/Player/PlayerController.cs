using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerRoot;

    [SerializeField] private float speed;
    [SerializeField] private float sidewaysMovementSensivity;
    [SerializeField] private float sidewaysLimitPos;
 
    private Vector3 inputDrag;
    private Vector3 prevMousePos;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        GetInput();
        MoveSideways();
    }

    private void PlayerMovement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void MoveSideways()
    {
        var currentPlayerPos = playerRoot.localPosition;
       
        var dragPos = Vector3.right * inputDrag.x * sidewaysMovementSensivity ;
        if (currentPlayerPos.x + dragPos.x < sidewaysLimitPos && currentPlayerPos.x + dragPos.x > -sidewaysLimitPos)
        {
            playerRoot.localPosition += dragPos;
        }
    }

    private void GetInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            prevMousePos = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            var distance = Input.mousePosition - prevMousePos;
            inputDrag = distance;
            prevMousePos = Input.mousePosition;
        }
        else
        {
            inputDrag = Vector2.zero;
        }
    }
}
