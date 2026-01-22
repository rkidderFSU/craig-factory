using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Craig"))
        {
            Destroy(collision.gameObject);
        }
    }
}
