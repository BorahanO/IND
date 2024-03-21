using UnityEngine;

public class NPCcars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Endpoint")
        {
            Destroy(gameObject);
        }
    }
}
