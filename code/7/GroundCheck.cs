using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;

    // 트리거에 다른 콜라이더가 접촉했을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        player.leftJump = 2;
    }

}
