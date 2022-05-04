using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //gerir hljóð þegar maður tekur upp líf
    public AudioClip collectedClip;

    //lætur ruby fá líf ef hún snertir ávöxtinn nema ef hún er með 5 líf
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
               if(controller.currentHealth < controller.maxHealth)
               {
                    controller.ChangeHealth(1);
                    Destroy(gameObject);

                    controller.PlaySound(collectedClip);
               }
            
        }
    }
}
