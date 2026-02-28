using System;
using System.Net;
using System.Net.Mail;
using UnityEngine;
using TMPro;

public class SimpleEmailSender : MonoBehaviour
{
    string fromEmail = "ingmultimediausbbog@gmail.com";
    string password = "fsjq ioqf zsxs jrzf";
    public string toEmail;
    public void SetReceiver(string email)
    {
        toEmail = email;
    }

    void Awake()
    {
        if (FindObjectsByType<SimpleEmailSender>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SendEmail(string subject, string body, TextMeshProUGUI statusText)
    {
        if (string.IsNullOrWhiteSpace(toEmail))
        {
            if (statusText != null)
                statusText.text = "No proporcionaste correo.";

            return;
        }

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromEmail);
        mail.To.Add(toEmail);
        mail.Subject = subject;
        mail.Body = body;

        SmtpClient smtp = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromEmail, password),
            EnableSsl = true
        };

        try
        {
            smtp.Send(mail);

            if (statusText != null)
                statusText.text = "Correo enviado correctamente.";
        }
        catch (Exception ex)
        {
            if (statusText != null)
                statusText.text = "El correo no existe o no se pudo enviar." + ex.Message;
        }
    }
}