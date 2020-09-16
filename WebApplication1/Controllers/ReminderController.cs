using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello World!";
        }
        static System.Net.Mail.SmtpClient client = null;
        public string Receiver = "603510162@qq.com";
        public string Subject = "love you";
        public string content = "hello world";
        public ActionResult<string> SendEmail()
        {
            if (string.IsNullOrEmpty(Receiver) || string.IsNullOrEmpty(Subject)
                 || string.IsNullOrEmpty(content))
            {
                return "SendEmail参数空异常！";
            }
            if (client == null)
            {
                try
                {
                    //163发送配置                    
                    client = new System.Net.Mail.SmtpClient();
                    client.Host = "smtp.163.com";
                    client.Port = 25;
                    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = true;               
                    client.Credentials = new System.Net.NetworkCredential("13289378670@163.com", "WSTVETKWHOHJHVZS");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            try
            {
                System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
                Message.SubjectEncoding = System.Text.Encoding.UTF8;
                Message.BodyEncoding = System.Text.Encoding.UTF8;
                Message.Priority = System.Net.Mail.MailPriority.High;

                Message.From = new System.Net.Mail.MailAddress("13289378670@163.com", "舟舟");
                //添加邮件接收人地址
                string[] receivers = Receiver.Split(new char[] { ',' });
                Array.ForEach(receivers.ToArray(), ToMail => { Message.To.Add(ToMail); });

                Message.Subject = Subject;
                Message.Body = content;
                Message.IsBodyHtml = true;
                client.Send(Message);
                return "OK";
            }
            catch (Exception ex)
            {
               return  ex.ToString();
            }
        }

        //WSTVETKWHOHJHVZS



    }

    }

