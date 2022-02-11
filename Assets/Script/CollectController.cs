using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Collect"))
        {
            collision.gameObject.transform.position = transform.position + Vector3.forward;

            Destroy(gameObject.GetComponent<CollectController>());
            collision.gameObject.AddComponent<CollectController>();
        }
    }
}
