using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public SimpleEmailSender emailSender;

    public void StartGame()
    {
        emailSender.SetReceiver(emailInput.text);
        SceneManager.LoadScene("GameScene");
    }
}