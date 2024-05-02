using System;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

using System.Windows.Forms;

namespace noti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("fbpvs-a542d-firebase-adminsdk-5wljt-6f47e514db.json")
            });

    }

        private void btn_Click(object sender, EventArgs e)
        {

            {
                // Obtener el token de registro del dispositivo
                string registrationToken = "d0-Yh20FTyiEZ7nQF5i70U:APA91bE3c-6uKiXU8dcGhcwzb1Oxhw-fSS2ghvQ6BiRmdBnR09RB4nOd9JTEIIGUBrJx7SBwrytq0GxSXgkGSlZgGEThQj7pfIcUefNLSgNAuxIUu9RLkg7R73_v5RDenPNaRlWvgFT8";

                // Verificar si el token de registro está vacío
                if (string.IsNullOrWhiteSpace(registrationToken))
                {
                    MessageBox.Show("Por favor, ingresa un token de registro válido.", "Token de Registro Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Construir el mensaje de notificación
                var message = new FirebaseAdmin.Messaging.Message()
                {
                    Token = registrationToken,
                    Notification = new Notification()
                    {
                        Title = textBox1.Text,
                        Body = textBox2.Text
                    }
                };
                try
                {
                    // Enviar la notificación
                    string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
                    MessageBox.Show("Mensaje enviado exitosamente: " + response, "Mensaje Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar el mensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            }
    }

   
}

