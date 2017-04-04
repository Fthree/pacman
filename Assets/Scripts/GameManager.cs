using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public StateHandler stateHandler;
    private StateHandler stateInstance;

    // Use this for initialization
    void Start () {
        stateInstance = Instantiate(stateHandler) as StateHandler;
        stateHandler.Initialize(Exit);
    }

    void Exit()
    {
        Destroy(stateInstance.gameObject);
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
        stateHandler.Update();
	}
}
