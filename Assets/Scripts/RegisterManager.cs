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
    public TMP_InputField confirmPasswordInput;
    public Button showPasswordButton;
    public Button hidePasswordButton;
    public Button showConfirmPasswordButton;
    public Button hideConfirmPasswordButton;
    public Button registerButton;
    public Button goToLoginButton;
    public TextMeshProUGUI errorMessage; // Campo per mostrare messaggi di errore

    private void Start()
    {
        // Imposta le password nascoste all'inizio
        passwordInput.contentType = TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();
        confirmPasswordInput.contentType = TMP_InputField.ContentType.Password;
        confirmPasswordInput.ForceLabelUpdate();
        
        // Imposta i listener per i bottoni
        showPasswordButton.onClick.AddListener(() => ShowPassword(passwordInput, showPasswordButton, hidePasswordButton));
        hidePasswordButton.onClick.AddListener(() => HidePassword(passwordInput, showPasswordButton, hidePasswordButton));
        showConfirmPasswordButton.onClick.AddListener(() => ShowPassword(confirmPasswordInput, showConfirmPasswordButton, hideConfirmPasswordButton));
        hideConfirmPasswordButton.onClick.AddListener(() => HidePassword(confirmPasswordInput, showConfirmPasswordButton, hideConfirmPasswordButton));
        registerButton.onClick.AddListener(OnRegister);
        goToLoginButton.onClick.AddListener(() => SceneManager.LoadScene("LoginScene"));

        // Assicura che all'inizio i bottoni per mostrare la password siano visibili e quelli per nasconderla siano nascosti
        showPasswordButton.gameObject.SetActive(true);
        hidePasswordButton.gameObject.SetActive(false);
        showConfirmPasswordButton.gameObject.SetActive(true);
        hideConfirmPasswordButton.gameObject.SetActive(false);
    }

    private void ShowPassword(TMP_InputField inputField, Button showButton, Button hideButton)
    {
        inputField.contentType = TMP_InputField.ContentType.Standard;
        inputField.ForceLabelUpdate();
        showButton.gameObject.SetActive(false);
        hideButton.gameObject.SetActive(true);
    }

    private void HidePassword(TMP_InputField inputField, Button showButton, Button hideButton)
    {
        inputField.contentType = TMP_InputField.ContentType.Password;
        inputField.ForceLabelUpdate();
        showButton.gameObject.SetActive(true);
        hideButton.gameObject.SetActive(false);
    }

    private void OnRegister()
    {
        // Controlla se le password corrispondono
        if (passwordInput.text != confirmPasswordInput.text)
        {
            DisplayError("Le due password non coincidono!");
            return;
        }

        // Controlla se la password è abbastanza lunga (opzionale)
        if (passwordInput.text.Length < 6) //|| (passwordInput.text)
        {
            DisplayError("La password deve essere lunga almeno 6 caratteri e contenere almeno un carattere numerico!");
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