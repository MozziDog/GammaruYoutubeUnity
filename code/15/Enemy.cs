using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb2d;
    GameObject player;
    enum state
    {
        patrol,
        chase
    }
    state currentState = state.patrol;
    public float patrolRange;
    public float moveSpeed;
    public float chaseRange;
    float moveValue;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moveValue = moveSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // 상태 전환해야하는지 체크
        float distance = Mathf.Abs(player.transform.localPosition.x - gameObject.transform.localPosition.x);
        if (distance < chaseRange)
        {
            currentState = state.chase;
        }
        else if (distance > chaseRange)
        {
            currentState = state.patrol;
        }
        // 현재 상태에 따라 정해진 동작 수행
        switch (currentState)
        {
            case state.patrol:
                if (gameObject.transform.localPosition.x < -patrolRange)
                {
                    moveValue = moveSpeed;
                }
                if (gameObject.transform.localPosition.x > patrolRange)
                {
                    moveValue = -moveSpeed;
                }
                rb2d.velocity = new Vector2(moveValue, rb2d.velocity.y);
                break;
            case state.chase:
                if((player.transform.localPosition.x - gameObject.transform.position.x)>0)
                {
                    moveValue = moveSpeed;
                }
                else
                {
                    moveValue = -moveSpeed;
                }
                rb2d.velocity = new Vector2(moveValue, rb2d.velocity.y);
                break;
        }
    }
}
