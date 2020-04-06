using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void OnDamage()
    {
        life --;
        if(life<=0)
        {
            // TODO: 게임오버 화면
            Debug.Log("게임 오버!");
        }
    }

    public void GameClear()
    {
        // TODO: 게임 클리어 화면 띄우기
        clearUI.SetActive(true);
        Debug.Log("게임 클리어!");
    }
}
