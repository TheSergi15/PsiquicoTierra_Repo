using UnityEngine;

public class MusicStopper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.StopMusic();
        }
    }
}
