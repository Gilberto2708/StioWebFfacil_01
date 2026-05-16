using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;
using WebFFACIL.Models;

namespace WebFFACIL.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ContactoController> _logger;

        public ContactoController(IConfiguration config, ILogger<ContactoController> logger)
        {
            _config = config;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST: Contacto/Enviar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Enviar(ContactoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var smtpHost    = _config["Smtp:Host"]!;
                    var smtpPort    = int.Parse(_config["Smtp:Port"] ?? "587");
                    var enableSsl   = bool.Parse(_config["Smtp:EnableSsl"] ?? "true");
                    var smtpUsuario = _config["Smtp:Usuario"]!;
                    var smtpPass    = _config["Smtp:Password"]!;
                    var de          = _config["Smtp:De"]!;
                    var para        = _config["Smtp:Para"]!;

                    var cuerpo = new StringBuilder();
                    cuerpo.AppendLine("<html><body style='font-family:Arial,sans-serif;color:#212121;'>");
                    cuerpo.AppendLine("<h2 style='color:#0D47A1;'>Nuevo mensaje desde FacturaFácil.net</h2>");
                    cuerpo.AppendLine("<table cellpadding='8' style='border-collapse:collapse;width:100%;max-width:600px;'>");
                    cuerpo.AppendLine($"<tr><td style='background:#F5F5F5;font-weight:bold;width:160px;'>Nombre</td><td>{model.Nombre}</td></tr>");
                    if (!string.IsNullOrWhiteSpace(model.Empresa))
                        cuerpo.AppendLine($"<tr><td style='background:#F5F5F5;font-weight:bold;'>Empresa</td><td>{model.Empresa}</td></tr>");
                    cuerpo.AppendLine($"<tr><td style='background:#F5F5F5;font-weight:bold;'>Correo</td><td>{model.Email}</td></tr>");
                    cuerpo.AppendLine($"<tr><td style='background:#F5F5F5;font-weight:bold;'>Teléfono</td><td>{model.Telefono}</td></tr>");
                    cuerpo.AppendLine($"<tr><td style='background:#F5F5F5;font-weight:bold;'>Tipo de consulta</td><td>{model.TipoConsulta}</td></tr>");
                    if (!string.IsNullOrWhiteSpace(model.ProductoInteres))
                        cuerpo.AppendLine($"<tr><td style='background:#F5F5F5;font-weight:bold;'>Producto de interés</td><td>{model.ProductoInteres}</td></tr>");
                    cuerpo.AppendLine($"<tr><td style='background:#F5F5F5;font-weight:bold;'>Mensaje</td><td>{model.Mensaje}</td></tr>");
                    cuerpo.AppendLine("</table></body></html>");

                    var correo = new MailMessage
                    {
                        From       = new MailAddress(de, "FacturaFácil.net"),
                        Subject    = $"Contacto web: {model.TipoConsulta} — {model.Nombre}",
                        Body       = cuerpo.ToString(),
                        IsBodyHtml = true,
                        Priority   = MailPriority.Normal
                    };
                    correo.To.Add(para);
                    correo.ReplyToList.Add(new MailAddress(model.Email, model.Nombre));

                    var smtp = new SmtpClient(smtpHost, smtpPort)
                    {
                        Credentials = new NetworkCredential(smtpUsuario, smtpPass),
                        EnableSsl   = enableSsl
                    };

                    smtp.Send(correo);

                    ViewBag.Success = true;
                    ModelState.Clear();
                    return View("Index", new ContactoViewModel());
                }
                catch (Exception ex)
                {
                    var detalle = ex.InnerException?.Message ?? ex.Message;
                    _logger.LogError(ex, "Error SMTP al enviar contacto de {Email}: {Detalle}", model.Email, detalle);
                    ViewBag.ErrorSmtp = $"Error al enviar: {detalle}";
                    ModelState.AddModelError(string.Empty, $"No se pudo enviar el mensaje: {detalle}");
                }
            }

            return View("Index", model);
        }
    }
}
