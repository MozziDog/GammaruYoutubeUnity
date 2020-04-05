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
        // 태그로 게임오브젝트 찾기
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        // GetComponent로 게임오브젝트에 부착된 컴포넌트 찾기 1
        gameManager = gameManagerObject.GetComponent<GameManager>();
        // GetComponent로 게임오브젝트에 부착된 컴포넌트 찾기 2
        audioSource = (AudioSource)(gameManagerObject.GetComponent(typeof (AudioSource)));
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
            GameObject effectObject = Instantiate(effect, gameObject.transform.localPosition, Quaternion.Euler(0,0,0));
            // 이펙트 오브젝트 2초 후 삭제
            Destroy(effectObject, 2f);
            // 현재 게임오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
