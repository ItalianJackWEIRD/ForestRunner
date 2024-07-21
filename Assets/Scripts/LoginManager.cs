using UnityEngine;
using TMPro; // Importa TextMeshPro
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public Button showPasswordButton; // Bottone per mostrare la password
    public Button hidePasswordButton; // Bottone per nascondere la password
    public Button loginButton;
    public Button goToRegisterButton;
    public TextMeshProUGUI errorMessage; // Campo per mostrare messaggi di errore

    private const string TutorialSeenKey = "TutorialSeen"; // Chiave per il salvataggio del tutorial

    private void Start()
    {
        // Imposta la password nascosta all'inizio
        passwordInput.contentType = TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();
        
        // Imposta i listener per i bottoni
        showPasswordButton.onClick.AddListener(ShowPassword);
        hidePasswordButton.onClick.AddListener(HidePassword);
        loginButton.onClick.AddListener(OnLogin);

        // Assicura che all'inizio il bottone per mostrare la password sia visibile e quello per nasconderla sia nascosto
        showPasswordButton.gameObject.SetActive(true);
        hidePasswordButton.gameObject.SetActive(false);
    }

    private void ShowPassword()
    {
        passwordInput.contentType = TMP_InputField.ContentType.Standard;
        passwordInput.ForceLabelUpdate();
        showPasswordButton.gameObject.SetActive(false);
        hidePasswordButton.gameObject.SetActive(true);
    }

    private void HidePassword()
    {
        passwordInput.contentType = TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();
        showPasswordButton.gameObject.SetActive(true);
        hidePasswordButton.gameObject.SetActive(false);
    }

    private void OnLogin()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login successful!");

        // Recupera i dati dell'utente per controllare lo stato del tutorial
        var getUserDataRequest = new GetUserDataRequest
        {
            PlayFabId = result.PlayFabId
        };
        PlayFabClientAPI.GetUserData(getUserDataRequest, OnGetUserDataSuccess, OnGetUserDataFailure);
    }

    private void OnGetUserDataSuccess(GetUserDataResult result)
    {
        bool tutorialSeen = false;

        if (result.Data != null && result.Data.ContainsKey(TutorialSeenKey))
        {
            bool.TryParse(result.Data[TutorialSeenKey].Value, out tutorialSeen);
        }

        if (tutorialSeen)
        {
            // Se il tutorial è già stato visto, carica la scena del menu
            SceneManager.LoadScene("Menu");
        }
        else
        {
            // Altrimenti, carica la scena del tutorial e aggiorna lo stato
            SceneManager.LoadScene("tutorialScene");

            var updateUserDataRequest = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string> { { TutorialSeenKey, "true" } }
            };
            PlayFabClientAPI.UpdateUserData(updateUserDataRequest, OnUpdateUserDataSuccess, OnUpdateUserDataFailure);
        }
    }

    private void OnGetUserDataFailure(PlayFabError error)
    {
        DisplayError("Failed to get user data: " + error.GenerateErrorReport());
        // In caso di errore nel recuperare i dati, puoi considerare che il tutorial non è stato visto
        SceneManager.LoadScene("tutorialScene");
    }

    private void OnUpdateUserDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log("User data updated successfully!");
    }

    private void OnUpdateUserDataFailure(PlayFabError error)
    {
        DisplayError("Failed to update user data: " + error.GenerateErrorReport());
    }

    private void OnLoginFailure(PlayFabError error)
    {
        DisplayError("Login failed: " + error.GenerateErrorReport());
    }

    private void DisplayError(string message)
    {
        if (errorMessage != null)
        {
            errorMessage.text = message;
        }
        Debug.LogError(message);
    }
}