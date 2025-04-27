using UnityEngine;

public class Pickup : MonoBehaviour
{
    const string PlayerString = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == PlayerString)
        {
            Destroy(this.gameObject);
        }
    }
}
