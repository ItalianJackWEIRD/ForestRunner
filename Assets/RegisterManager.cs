using UnityEngine;
using TMPro; // Importa TextMeshPro
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput; // Aggiungi questo campo
    public Button registerButton;
    public Button goToLoginButton;
    public TextMeshProUGUI errorMessage; // Campo per mostrare messaggi di errore

    private void Start()
    {
        registerButton.onClick.AddListener(OnRegister);
        goToLoginButton.onClick.AddListener(() => SceneManager.LoadScene("LoginScene"));
    }

    private void OnRegister()
    {
        // Controlla se le password corrispondono
        if (passwordInput.text != confirmPasswordInput.text)
        {
            DisplayError("Passwords do not match.");
            return;
        }

        // Controlla se la password è abbastanza lunga (opzionale)
        if (passwordInput.text.Length < 6)
        {
            DisplayError("Password must be at least 6 characters long.");
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registration successful!");
        SceneManager.LoadScene("LoginScene");
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        DisplayError("Registration failed: " + error.GenerateErrorReport());
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
