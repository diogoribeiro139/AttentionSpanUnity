using UnityEngine;

public class Bucket : MonoBehaviour
{
    private AudioSource audioSource;

void Awake() {
audioSource = GetComponent<AudioSource>();
}

 private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) 
        {
            audioSource.Play();
        }
    }
}
