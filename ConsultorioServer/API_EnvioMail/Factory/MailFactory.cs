using API_ObrasSociales.Models.DTO;
using MailKit.Net.Smtp;
using MimeKit;
using System.Text;

namespace API_EnvioMail.Factory
{
    public interface IMailFactory
    {
        bool EnvioMail(DTOTurno turno);
    }
    public class MailFactory : IMailFactory
    {
        public MailFactory() { }

        public bool EnvioMail(DTOTurno turno)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Agus un capo", "blandinoagustin@gmail.com"));
                message.To.Add(new MailboxAddress("Destinatario", turno.email));
                message.Subject = "PRUEBA (DE ESPERMA)";

                var emailBody = new StringBuilder();
                emailBody = ArmarCuerpoMail(turno);

                // Construir el cuerpo del mensaje manualmente
                var body = new TextPart("html")
                {
                    Text = emailBody.ToString()
                };

                message.Body = body;

                ConfigurarSMTPEnviarMail(message);
                return true;
    
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool ConfigurarSMTPEnviarMail(MimeMessage message)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    string smtpServer = "smtp.gmail.com";
                    int smtpPort = 587;
                    string smtpUsername = "blandinoagustin@gmail.com";
                    string smtpPassword = "xmyb weqq zkai smar\r\n";

                    client.Connect(smtpServer, smtpPort, false);
                    client.Authenticate(smtpUsername, smtpPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }
            catch(Exception ex) {
                return false;
            }
        }
        public StringBuilder ArmarCuerpoMail(DTOTurno turnoNuevo)
        {
            StringBuilder emailBody = new StringBuilder();
            emailBody.Append("<!DOCTYPE html>");
            emailBody.Append("<html lang=\"en\">");
            emailBody.Append("<head>");
            emailBody.Append("    <meta charset=\"UTF-8\">");
            emailBody.Append("    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            emailBody.Append("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            emailBody.Append("    <link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css\">");
            emailBody.Append("    <script src=\"https://unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>");
            emailBody.Append("    <title>Document</title>");
            emailBody.Append("</head>");
            emailBody.Append("<body>");
            emailBody.Append("    <div class=\"container card border border-success mt-5\">");
            emailBody.Append("        <div class=\"d-flex row justify-content-center\">");
            emailBody.Append("            <div class=\"col-12 mt-3\">");
            emailBody.Append("                <h2 class=\"text-center\">");
            emailBody.Append("                    NUEVO TURNO CREADO");
            emailBody.Append("                </h2>");
            emailBody.Append("                <hr>");
            emailBody.Append("            </div>");
            emailBody.Append("            <div class=\"col-12\">");
            emailBody.Append("                <h4><strong>Datos:<strong></h4>");
            emailBody.Append("                    <ul class=\"my-4\">");

            emailBody = DatosTurno(emailBody, turnoNuevo);

            emailBody.Append("                    </ul>");
            emailBody.Append("                    <hr>");
            emailBody.Append("            </div>");
            emailBody.Append("            <div class=\" col-12 mb-3 \">");
            emailBody.Append("                <button type=\"button\" onclick=\"AprobarTurno()\" class=\"btn btn-outline-success\">Confirmar Turno</button>");
            emailBody.Append("                <button type=\"button\" onclick=\"RechazarTurno()\" class=\"btn btn-outline-danger\">Rechazar Turno</button>");
            emailBody.Append("            </div>");
            emailBody.Append("        </div>");
            emailBody.Append("    </div>");
            emailBody = ScriptSweetAlert(emailBody);
            emailBody.Append("</body>");
            emailBody.Append("</html>");


            return emailBody;
        }
        public StringBuilder ScriptSweetAlert(StringBuilder emailBody)
        {

            emailBody.Append("    <script>");
            emailBody.Append("        function AprobarTurno(){");
            emailBody.Append("            swal(\"Turno Aprobado!\", \"\", \"success\");");
            emailBody.Append("        }");
            emailBody.Append("         ");
            emailBody.Append("        function RechazarTurno(){");
            emailBody.Append("            swal({");
            emailBody.Append("            title: \"Desea rechazar el turno?\",");
            emailBody.Append("            text: \"\",");
            emailBody.Append("            icon: \"warning\",");
            emailBody.Append("            buttons: true,");
            emailBody.Append("            dangerMode: true,");
            emailBody.Append("            })");
            emailBody.Append("            .then((willDelete) => {");
            emailBody.Append("            if (willDelete) {");
            emailBody.Append("                swal(\"Turno eliminado correctamente\", {");
            emailBody.Append("                icon: \"success\",");
            emailBody.Append("                });");
            emailBody.Append("            } else {");
            emailBody.Append("                ");
            emailBody.Append("            }");
            emailBody.Append("            });");
            emailBody.Append("        }");
            emailBody.Append("    </script>");



            return emailBody;
        }
        public StringBuilder DatosTurno(StringBuilder emailBody, DTOTurno turno)
        {

            emailBody.Append($"                        <li><h5>Nombre:{turno.nombreApellido} </h5> </li>");
            emailBody.Append($"                        <li><h5>Obra Social: {turno.obraSocial}</h5> </li>");
            emailBody.Append($"                        <li><h5>Dia: {turno.fecha}</h5> </li>");
            emailBody.Append($"                        <li><h5>Horario: {turno.horario}</h5> </li>");
            emailBody.Append($"                        <li><h5>Comentarios: te kiero comel la tetonga kakak </h5> </li>");



            return emailBody;
        }
    }
}
