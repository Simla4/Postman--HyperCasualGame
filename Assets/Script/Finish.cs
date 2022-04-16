using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finish : MonoBehaviour
{
    public static Action OnFinish;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            OnFinish?.Invoke();
            Debug.Log("Finish");
        }
    }
}
