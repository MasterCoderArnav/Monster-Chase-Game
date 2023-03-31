using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] players;
    public static GameManager instance;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        //Singleton Pattern as scene objects destroyed when scene changed one instance
        if(instance== null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Called every time player is enabled
    private void OnEnable()
    {
        SceneManager.sceneLoaded += onLevelFinishedLoading;
    }
    //Called every time player is disabled
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= onLevelFinishedLoading;
    }
    void onLevelFinishedLoading(Scene sc, LoadSceneMode mode)
    {
        if (sc.name == "GamePlay")
        {
            Instantiate(players[CharIndex]);
        }
    }
}
