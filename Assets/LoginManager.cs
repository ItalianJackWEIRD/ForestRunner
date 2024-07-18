using UnityEngine;
using TMPro; // Importa TextMeshPro
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public Button showPasswordButton; // Bottone per mostrare la password
    public Button hidePasswordButton; // Bottone per nascondere la password
    public Button loginButton;
    public Button goToRegisterButton;
    public TextMeshProUGUI errorMessage; // Campo per mostrare messaggi di errore

    private void Start()
    {
        // Imposta la password nascosta all'inizio
        passwordInput.contentType = TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();
        
        // Imposta i listener per i bottoni
        showPasswordButton.onClick.AddListener(ShowPassword);
        hidePasswordButton.onClick.AddListener(HidePassword);
        loginButton.onClick.AddListener(OnLogin);
        goToRegisterButton.onClick.AddListener(() => SceneManager.LoadScene("RegisterScene"));

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
        SceneManager.LoadScene("MainScene");
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
