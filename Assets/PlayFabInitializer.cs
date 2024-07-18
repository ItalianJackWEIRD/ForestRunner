using UnityEngine;
using PlayFab;

public class PlayFabInitializer : MonoBehaviour
{
    [SerializeField]
    private string playFabTitleId = "42697"; // Inserisci qui il tuo Title ID

    private void Awake()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = playFabTitleId;
        }
    }
}
