using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public enum gameState { START,PLAYABLE,END,GAMEOVER }

public class GameManager : MonoBehaviour
{
    public gameState state;

    public static GameManager instance;

    public Animator player;

    [SerializeField] private GameObject gameOver;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(gameState.PLAYABLE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGameState(gameState newState)
    {
        state = newState;
        switch (state)
        {
            case gameState.START:
                break;
                
            case gameState.PLAYABLE:
                break;
    
            case gameState.END:
                Debug.Log("Dead");
                //player.Play("PlayerDead");
                player.SetTrigger("IsDeadTrigger");
                player.SetBool("IsDead",true);
                StartCoroutine(GameOverScene());
                break;
        }
    }

    private IEnumerator GameOverScene()
    {
        yield return new WaitForSeconds(1f);

        gameOver.SetActive(true);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
