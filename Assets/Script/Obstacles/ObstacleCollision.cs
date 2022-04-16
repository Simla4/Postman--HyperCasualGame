using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] private GameObject collectable;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Collected"))
        {
            ChangePosition(other.gameObject);
        }
    }
    private void ChangePosition(GameObject other)
    {
        //Debug.Log(other.transform.localPosition);
        List<GameObject> newList = new List<GameObject>();
        var index = CollectController.Instance.collectable.IndexOf(other.gameObject);
        var soldierCount = CollectController.Instance.collectable.Count;
        if (index > 0)
        {
            for (int i = index; i < soldierCount; i++)
            {
                var soldier = CollectController.Instance.collectable[i];
                newList.Add(soldier);

            }
            for (int i = 0; i < newList.Count; i++)
            {
                var soldier = newList[i];
                CollectController.Instance.collectable.Remove(soldier);
                soldier.tag = "Collectable";
                var currentpos = soldier.transform.position;
                var newpos = new Vector3(Random.Range(-3.2f, 3.3f), 0,
                                         Random.Range(currentpos.z + 8, currentpos.z + 12f));
                currentpos = newpos;
                soldier.transform.DOKill();
                soldier.transform.parent = collectable.transform;
                soldier.transform.DOJump(currentpos, 5, 1, 0.5f);
                soldier.transform.position = currentpos;
                Destroy(soldier.GetComponent<Collision>());

            }
        }
    }
}
