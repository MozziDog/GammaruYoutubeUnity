using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public Animator animator;

    // 좌우 이동 속도
    public float speed;

    // 점프력
    public float jumpPower;

    // 남은 점프 횟수
    public int leftJump = 2;

    // 현재 땅에 닿아있는가
    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input 시스템에서 Horizontal 축의 값을 받아옴 (범위 -1 ~ +1)
        float velocity_x = Input.GetAxis("Horizontal");

        // velocity_x에 speed 값을 곱해서 원하는 속도로 만들어줌
        velocity_x = velocity_x * speed;

        // 새 벡터를 생성하고 현재 속도 값을 새 벡터로 치환함.
        rb2d.velocity = new Vector2(velocity_x, rb2d.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
        animator.SetBool("isGrounded", isGrounded);

        // 만약 이번 프레임에서 점프 키가 눌렸다면...
        if(Input.GetButtonDown("Jump") && leftJump > 0)
        {
            // y축 방향의 속도를 jumpPower만큼 증가시킴
            rb2d.velocity = rb2d.velocity + new Vector2(0, jumpPower);

            // 남은 점프 횟수 1회 차감
            leftJump --;
        }

        if(rb2d.velocity.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if(rb2d.velocity.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
