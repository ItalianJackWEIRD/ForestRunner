using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class UI : MonoBehaviour
{
    private Label coin;
    private Label hp;

    private Button PUCoin;
    private Button PUHp;
    private Button PUJump;

    public Score score;
    public PUManager manager;

    // Start is called before the first frame update
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement; 

        coin = root.Q<Label>("Coin");
        hp = root.Q<Label>("Hp");

        PUHp = root.Q<Button>("PotionHp");
        PUCoin = root.Q<Button>("PotionCoin");
        PUJump = root.Q<Button>("PotionJump");

        PUHp.style.display = DisplayStyle.None;
        PUJump.style.display = DisplayStyle.None;
        PUCoin.style.display = DisplayStyle.None;

        score = GetComponent<Score>();
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
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
}
