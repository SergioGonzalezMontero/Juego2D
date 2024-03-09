using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal;

    public bool isCollectec;

    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollectec)
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;

                UIController.instance.UpdateGemCount();
                Instantiate(pickupEffect, transform.position, transform.rotation);
                isCollectec = true;
                Destroy(gameObject);
            }

            if (isHeal)
            {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();

                    isCollectec = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
