using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverDeathFromHead : MonoBehaviour
{
    [SerializeField] private AudioSource gameoverSound;
   private void OnCollisionEnter2D(Collision2D collision){
    if (collision.gameObject.CompareTag("Ground")){
        if (gameoverSound != null)
            {
                AudioSource.PlayClipAtPoint(gameoverSound.clip, transform.position);
            }
        GameManager.instance.GameOver();
    }
   }
}
