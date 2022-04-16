using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerRoot;

    [SerializeField] private float speed;
    [SerializeField] private float sidewaysMovementSensivity;
    [SerializeField] private float sidewaysMovementLerpSensivity;
    [SerializeField] private float sidewaysLimitPos;
 
    private Vector3 inputDrag;
    private Vector2 prevMousePos;
    private float sideMovementTarget;

    private bool isGameStart;
    private bool isMiniGameStart;
    
    // Update is called once per frame
    void Update()
    {
        /*PlayerMovement();
        GetInput();
        MoveSideways();*/
        
        GetInput();
        MoveSideways();
        if (isMiniGameStart || !isGameStart) return;
        PlayerMovement();
    }
    private Vector2 mousePositionCM
    {
        get
        {
            Vector2 pixels = Input.mousePosition;
            var inches = pixels / Screen.dpi;
            var centimeters = inches * 2.54f;

            return centimeters;
        }
    }
    private void PlayerMovement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void MoveSideways()
    {
        //var currentPlayerPos = playerRoot.localPosition;
       
        /*var dragPos = Vector3.right * inputDrag.x * sidewaysMovementSensivity ;
        playerRoot.localPosition += dragPos;
        var sideMovementLimits = Mathf.Clamp( playerRoot.localPosition.x, -sidewaysLimitPos, sidewaysLimitPos);
        playerRoot.localPosition = new Vector3(sideMovementLimits,playerRoot.localPosition.y,playerRoot.localPosition.z);*/
        
        sideMovementTarget += inputDrag.x * sidewaysMovementSensivity;
        sideMovementTarget = Mathf.Clamp(sideMovementTarget, -sidewaysLimitPos, sidewaysLimitPos);
        var localPos = playerRoot.localPosition;
        localPos.x = Mathf.Lerp(localPos.x, sideMovementTarget, Time.deltaTime * sidewaysMovementLerpSensivity);
        playerRoot.localPosition = localPos;
        
        
        /*var dragPos = Vector3.right * inputDrag.x * sidewaysMovementSensivity ;
        playerRoot.localPosition += dragPos;
        var sideMovementLimits = Mathf.Clamp( playerRoot.localPosition.x, -sidewaysLimitPos, sidewaysLimitPos);
        playerRoot.localPosition = new Vector3(sideMovementLimits,playerRoot.localPosition.y,playerRoot.localPosition.z);*/
        
        
    }

    private void GetInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            prevMousePos = mousePositionCM;
        }
        else if(Input.GetMouseButton(0))
        {
            var distance = mousePositionCM - prevMousePos;
            inputDrag = distance;
            prevMousePos = mousePositionCM;
        }
        else
        {
            inputDrag = Vector2.zero;
        }
        
        
        if (Input.GetMouseButtonUp(0) && !isGameStart) //for tap to start
        {
            isGameStart = true;
        }
    }
}
