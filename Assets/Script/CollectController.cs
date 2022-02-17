using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectController : MonoSingleton<CollectController>
{

    public List<GameObject> collectable = new List<GameObject>();
    public float movementDelay;

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            MoveListElements();
        }
        if(Input.GetButtonDown("Fire1"))
        {
            MoveOrigin();
        }
    }

    public void StackObject(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = collectable[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;

        collectable.Add(other);

        StartCoroutine(MakeObjectBigger());
    }

    private IEnumerator MakeObjectBigger()
    {

        for(int i = collectable.Count - 1; i > 1; i-- )
        {
            var index = i;

            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;

            collectable[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
            collectable[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f ));

            yield return new WaitForSeconds(0.05f);
        }
    }

    private void MoveListElements()
    {
        for(int i = 1; i < collectable.Count; i++)
        {
            var pos = collectable[i].transform.localPosition;
            pos.x = collectable[i - 1].transform.localPosition.x;
            collectable[i].transform.DOLocalMove(pos, movementDelay);
        }
    }

    private void MoveOrigin()
    {

        for (int i = 1; i < collectable.Count; i++)
        {
            var pos = collectable[i].transform.localPosition;
            pos.x = collectable[0].transform.localPosition.x;
            collectable[i].transform.DOLocalMove(pos, 0.7f);
        }
    }
    
}
