using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectController : MonoSingleton<CollectController>
{

    public List<GameObject> collectable = new List<GameObject>();

    public void StackObject(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = collectable[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        StartCoroutine(MakeObjectBigger());
    }

    private IEnumerator MakeObjectBigger()
    {

        for(int i = collectable.Count; i > 0; i++ )
        {
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;

            collectable[i].transform.DOScale(scale, 0.1f).OnComplete(() =>
            collectable[i].transform.DOScale(new Vector3(1, 1, 1), 0.1f ));

            yield return new WaitForSeconds(0.05f);
        }

        
    }
    
}
