using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;

public class FileUpload : MonoBehaviour
{

    public void UploadFile ()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("_GMAILNAMEYOUWILLSENDFROM_@gmail.com");
        mail.To.Add("_GMAILNAMEYOUWILLBESENDINGTO_@gmail.com");
        mail.Subject = "Bitirme Loglari";
        mail.Body = "Here are the logs and frames";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("_GMAILNAMEYOUWILLSENDFROM_@gmail.com", "_GMAILPASSWORDYOULLSENDFROM_") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

        string desktop_dir = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Desktop) + "/GAME_FOLDER";
        mail.Attachments.Add(new Attachment(desktop_dir + "/LOGS/logs.txt"));
        int counter = 0;
        while (File.Exists(desktop_dir + "/FRAMES/" + counter + ".png"))
        {
            mail.Attachments.Add(new Attachment(desktop_dir + "/FRAMES/" + counter + ".png"));
            counter++;
        }
        smtpServer.Send(mail);
    }
}