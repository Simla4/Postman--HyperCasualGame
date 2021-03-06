using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Collision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            if(!CollectController.Instance.collectable.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Collected";
                other.gameObject.AddComponent<Collision>();

                CollectController.Instance.StackObject(other.gameObject, CollectController.Instance.collectable.Count - 1);
            }
        }

    }
}
