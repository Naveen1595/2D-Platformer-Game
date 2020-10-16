using UnityEngine;
public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() !=null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            SoundManager.Instance.Play(Sounds.ItemPickUp);
            playerController.pickUpKey();
            Destroy(gameObject);
        }
    }
}
