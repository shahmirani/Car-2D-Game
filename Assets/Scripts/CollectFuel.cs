using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    [SerializeField] private AudioSource scoreSound;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            if (scoreSound != null)
            {
                AudioSource.PlayClipAtPoint(scoreSound.clip, transform.position);
            }
            FuelController.instance.FillFuel(gameObject.tag);
            Destroy(gameObject);
            
        }
    }
   
    
}
