using UnityEngine;

public class CollectibleMorb : MonoBehaviour
{
    public delegate void  SphereCollectedDelegate();
    public static event  SphereCollectedDelegate OnSphereCollected;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            OnSphereCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
