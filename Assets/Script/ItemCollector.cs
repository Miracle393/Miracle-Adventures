using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int strawberry = 0;


    [SerializeField] private TMP_Text strawberryCount;

    [SerializeField] private AudioSource collectSoundEffect;

    
   private void OnTriggerEnter2D(Collider2D collision)
   {
    if (collision.gameObject.CompareTag("Strawberry"))
    {
        Destroy(collision.gameObject);
        collectSoundEffect.Play();
        strawberry++;
        //Debug.Log("Strawberry Count: " + strawberry);
        strawberryCount.text = "Strawberry Count: " + strawberry;
    }
   }
}
