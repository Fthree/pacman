using UnityEngine;
using UnityEngine.UI;
using System;

public class Pause : MonoBehaviour {

    Action resumeGame;
    Action exitGame;

    public Button resumeButton;
    public Button exitButton;

    // Use this for initialization
    void Start () {
	
	}
	
	public void Initialize(Action resumeGame, Action exitGame)
    {
        this.resumeGame = resumeGame;
        this.exitGame = exitGame;

        resumeButton.onClick.AddListener(ResumeGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void ResumeGame()
    {
        resumeGame();
    }

    void ExitGame()
    {
        exitGame();
    }
}
