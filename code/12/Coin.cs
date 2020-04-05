using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;
    public GameManager gameManager;
    public GameObject effect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // 스코어 100 증가
            gameManager.score += 100;
            // 사운드 출력
            audioSource.PlayOneShot(sound);
            // 이펙트 오브젝트 생성
            Instantiate(effect, gameObject.transform.localPosition, Quaternion.Euler(0,0,0));
            // 현재 게임오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
