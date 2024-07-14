using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private Label coin;
    private Label hp;

    private Button PUCoin;
    private Button PUHp;
    private Button PUJump;

    private Button pauseButton;
    private Button resumeButton;
    private Button mainMenuButton;

    private VisualElement pauseMenu;

    public Score score;
    public PUManager manager;

    private bool isPaused = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement; 

        coin = root.Q<Label>("Coin");
        hp = root.Q<Label>("Hp");

        PUHp = root.Q<Button>("PotionHp");
        PUCoin = root.Q<Button>("PotionCoin");
        PUJump = root.Q<Button>("PotionJump");
        pauseButton = root.Q<Button>("PauseButton");
        pauseMenu = root.Q<VisualElement>("PauseMenu");
        resumeButton = root.Q<Button>("ResumeButton");
        mainMenuButton = root.Q<Button>("MainMenuButton");

        PUHp.style.display = DisplayStyle.None;
        PUJump.style.display = DisplayStyle.None;
        PUCoin.style.display = DisplayStyle.None;

        score = GetComponent<Score>();
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();

        pauseButton.clicked += TogglePause;
        resumeButton.clicked += TogglePause;
        mainMenuButton.clicked += GoToMainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = score.GetScore();
        hp.text = manager.GetLives().ToString();

        if (manager.Get2())
            PUHp.style.display = DisplayStyle.Flex;
        else
            PUHp.style.display = DisplayStyle.None;

        if (manager.Get1())
            PUCoin.style.display= DisplayStyle.Flex;
        else
            PUCoin.style.display = DisplayStyle.None;

        if (manager.Get3())
            PUJump.style.display = DisplayStyle.Flex;
        else
            PUJump.style.display = DisplayStyle.None;

    }

    void TogglePause(){
        isPaused = !isPaused;
        if(isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.style.display = DisplayStyle.Flex;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.style.display = DisplayStyle.None;
        }
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
