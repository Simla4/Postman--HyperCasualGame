using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerRoot;

    [SerializeField] private float speed;
    [SerializeField] private float sidewaysMovementSensivity;

    private float currentMousePos;
    private float startMousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void MoveSideways()
    {
        var currentPlayerPos = playerRoot.position;
    }
}
