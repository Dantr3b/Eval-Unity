using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Joue le son via un GameManager ou AudioSource global
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Ajoute 1 point
            GameManager.Instance.AddPoint(1);

            // Détruit la pièce
            Destroy(gameObject);
        }
    }
}
