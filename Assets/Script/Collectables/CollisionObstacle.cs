using UnityEngine;

public class CollisionObstacle : MonoBehaviour
{
    [SerializeField] private GameObject smokeVFX;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            var temporaryVFX = Instantiate(smokeVFX, transform.position, Quaternion.identity);
            temporaryVFX.transform.SetParent(null);
            temporaryVFX.transform.localScale *= 1.5f;
            var temporaryVFXPos=temporaryVFX.transform.position;
            temporaryVFXPos.y += 1f;
            temporaryVFXPos.z -= 0.5f;
            temporaryVFX.transform.position = temporaryVFXPos;
            Destroy(temporaryVFX,0.5f);
        }
    }
}
