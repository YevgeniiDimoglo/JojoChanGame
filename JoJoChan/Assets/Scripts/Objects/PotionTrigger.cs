using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTrigger : MonoBehaviour
{
    public GameObject player;
    private Player playerScript;
    public bool trigger;


    private void Update()
    {
        if (trigger)
        {
            UsePotion();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player") // Tag: Player
        {
            trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger = false;
        player = null;
    }

    void UsePotion()
    {

        playerScript = player.GetComponent<Player>();
        playerScript.PowerCapacity += 20;
        Destroy(gameObject);

    }
}
