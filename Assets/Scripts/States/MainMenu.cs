using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;

public class MainMenu : MonoBehaviour {
    Action startGame;
    Action exit;

    public Button startGameButton;
    public Button exitButton;

    public void Initialize(Action startGame, Action exit)
    {
        this.startGame = startGame;
        this.exit = exit;
        startGameButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(EndGame);
    }

    public void StartGame()
    {
        startGame();
    }

    public void EndGame()
    {
        exit();
    }
}
