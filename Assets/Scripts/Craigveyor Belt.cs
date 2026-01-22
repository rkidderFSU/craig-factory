using UnityEngine;

public class CraigveyorBelt : MonoBehaviour
{
    public float beltSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Craig"))
        {
            collision.transform.Translate(Vector3.forward * beltSpeed * Time.deltaTime, Space.Self);
        }
    }
}
