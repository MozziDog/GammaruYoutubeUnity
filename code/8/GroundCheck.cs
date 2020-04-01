using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;

    void OnTriggerEnter2D(Collider2D other)
    {
        player.leftJump = 2;
        player.isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        player.isGrounded = false;
    }

}
