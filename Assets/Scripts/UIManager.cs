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
        coinText.text = score.GetScore();
        lifeText.text = manager.GetLives().ToString();
        scoreText.text = string.Format("Score: {0}", levelGenerator.GetScore());

        // Mostra o nascondi le icone delle pozioni in base allo stato dei power-up
        potionHpIcon.gameObject.SetActive(manager.Get2());
        potionCoinIcon.gameObject.SetActive(manager.Get1());
        potionJumpIcon.gameObject.SetActive(manager.Get3());

        scoreX2.gameObject.SetActive(levelGenerator.scoreX2);
        slowSpeed.gameObject.SetActive(levelGenerator.slowSpeed);
    }
}
