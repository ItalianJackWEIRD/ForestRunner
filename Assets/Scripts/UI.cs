using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class UI : MonoBehaviour
{
    private Label coin;
    private Label hp;

    public Score score;
    public PUManager manager;

    // Start is called before the first frame update
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement; 

        coin = root.Q<Label>("Coin");
        hp = root.Q<Label>("Hp");

        score = GetComponent<Score>();
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = score.GetScore();
        hp.text = manager.GetLives().ToString();
    }
}
