using UnityEngine;
using System.Collections;
using System;

public class StateHandler : MonoBehaviour {

    private Action exit;

    public Game gameState;
    private Game game;
    public MainMenu mainMenuState;
    private MainMenu mainMenu;
    public Pause pauseState;
    private Pause pause;

    State currentState;

	// Use this for initialization
	public void Initialize(Action exit) {
        this.exit = exit;
        StartMenu();
    }

    public void OnStartGame()
    {
        EndMenu();
        StartGame();
    }

    public void OnExit()
    {
        EndMenu();
        ExitGame();
    }

    public void OnExitPause()
    {
        EndGame();
        EndPause();
        ExitGame();
    }


    public void StartGame()
    {
        game = Instantiate(gameState) as Game;
        game.Initialize();
        currentState = State.Game;
    }

    public void StartPause()
    {
        pause = Instantiate(pauseState) as Pause;
        pause.Initialize(ResumeGame, OnExitPause);
        currentState = State.Pause;
    }

    public void StartMenu()
    {
        mainMenu = Instantiate(mainMenuState) as MainMenu;
        mainMenu.Initialize(OnStartGame, OnExit);
        currentState = State.MainMenu;
    }

    public void EndGame()
    {
        game.DestroyGame();
        Destroy(game.gameObject);
    }

    public void EndMenu()
    {
        Destroy(mainMenu.gameObject);
    }

    public void EndPause()
    {
        Destroy(pause.gameObject);
    }

    public void PauseGame()
    {
        game.Pause();
        StartPause();
    }

    public void ResumeGame()
    {
        EndPause();
        game.Resume();
        currentState = State.Game;
    }

    public void ExitGame()
    {
        exit();
    }

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(currentState == State.Game)
            {
                PauseGame();
            }
            else if (currentState == State.Pause)
            {
                ResumeGame();
            }
        }
    }
}
