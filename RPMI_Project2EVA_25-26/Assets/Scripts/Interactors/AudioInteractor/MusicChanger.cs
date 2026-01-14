using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField] int musicCliptoPlay;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayMusic(musicCliptoPlay);
        }
    }
}
