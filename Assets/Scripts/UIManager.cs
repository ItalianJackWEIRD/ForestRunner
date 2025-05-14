using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Associa questo campo con il TextMeshPro per il punteggio
    public TextMeshProUGUI lifeText; // Associa questo campo con il TextMeshPro per le vite
    public TextMeshProUGUI scoreText;
    public Image potionHpIcon; // Associa questo campo con l'immagine dell'icona della pozione di HP
    public Image potionCoinIcon; // Associa questo campo con l'immagine dell'icona della pozione di monete
    public Image potionJumpIcon; // Associa questo campo con l'immagine dell'icona della pozione di salto

    public Image scoreX2;
    public Image slowSpeed;

    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject HP4;
    public GameObject HP1_;
    public GameObject HP2_;
    public GameObject HP3_;
    public GameObject HP4_;

    public Score score; // Associa questo campo con il componente Score del Player
    public PUManager manager; // Associa questo campo con il componente PUManager del Player
    public LevelGenerator levelGenerator; // Associa questo campo con il componente LevelGenerator del Player

    void Start()
    {
        // Nascondi tutte le icone delle pozioni all'inizio
        potionHpIcon.gameObject.SetActive(false);
        potionCoinIcon.gameObject.SetActive(false);
        potionJumpIcon.gameObject.SetActive(false);
        scoreX2.gameObject.SetActive(false);
        slowSpeed.gameObject.SetActive(false);

        levelGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelGenerator>();
    }

    void Update()
    {
        // Aggiorna il testo del punteggio e delle vite
        if (score.GetScoreInt() < 10)
            coinText.text = string.Format("  {0}", score.GetScore());
        else if (score.GetScoreInt() < 100)
            coinText.text = string.Format(" {0}", score.GetScore());
        else
            coinText.text = score.GetScore();

        //lifeText.text = manager.GetLives().ToString();
        ManageLives(manager.GetLives());
        scoreText.text = string.Format("{0}", levelGenerator.GetScore());

        // Mostra o nascondi le icone delle pozioni in base allo stato dei power-up
        potionHpIcon.gameObject.SetActive(manager.Get2());
        potionCoinIcon.gameObject.SetActive(manager.Get1());
        potionJumpIcon.gameObject.SetActive(manager.Get3());

        scoreX2.gameObject.SetActive(levelGenerator.scoreX2);
        slowSpeed.gameObject.SetActive(levelGenerator.slowSpeed);
    }

    void ManageLives(int lives)
    {
        GameObject[] hp = { HP1, HP2, HP3, HP4 };
        GameObject[] hpAlt = { HP1_, HP2_, HP3_, HP4_ };

        for (int i = 0; i < 4; i++)
        {
            if (i < lives)
            {
                hp[i].SetActive(true);
                hpAlt[i].SetActive(false);
            }
            else
            {
                hp[i].SetActive(false);
                hpAlt[i].SetActive(true);
            }
        }
    }

}
