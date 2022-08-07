using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Shop.Manager
{
    public class MemberManager
    {
        ShopContext db = new ShopContext();
        public Member Add(Member mem)
        {
            db.Member.Add(mem);
            db.SaveChanges();
            return mem;
        }
        public Member Login(string Email, string Pwd)
        {
            Member mem = db.Member.Where(m => m.Email == Email && m.Password == Pwd).FirstOrDefault();
            return mem;
        }
        public string CheckEmail(string Email)
        {
            string email = db.Member.Where(m => m.Email == Email).Distinct().ToString();
            if(email!=null || email != "")
            {
                int min = 1000; int max = 9999;
                Random rdm = new Random();
                var confirmCode = rdm.Next(min, max);
                string cd = confirmCode.ToString();
                try{
                        
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("abcpteldt@gmail.com");
                        mail.To.Add(Email);
                        mail.Subject = "Confirm Your Email - Pele|ABC Pte.Ldt";
                        mail.Body = "Your Confirmation Code is '" + cd + "'. And this will expire between 2 minute.";
                        mail.IsBodyHtml = false;
                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("abcpteldt@gmail.com", "abcissafe");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                        #region Saving ConfirmCode
                        ShopContext db = new ShopContext();
                        AccRecover recover = new AccRecover();
                        recover.Email = Email;
                        recover.ConfirmCode = cd;
                        recover.Accesstime = DateTime.Now;
                        db.AccRecover.Add(recover);
                        db.SaveChanges();
                        #endregion
                        return "true";
                        #region Way 2
                        //var senderEmail = new MailAddress("abcpteldt@gmail.com", "ABC Pte Ldt");
                        //var receiverEmail = new MailAddress(Email, "Receiver");
                        //var password = "abcissafe";
                        //var subject = "Confirm Your Email - Pele|ABC Pte.Ldt";
                        //var body = "Your Confirmation Code is" + cd + "And this will expire between 2 minute.";
                        //var smtp = new SmtpClient
                        //{
                        //    Host = "smtp.gmail.com",
                        //    Port = 587,
                        //    EnableSsl = true,
                        //    DeliveryMethod = SmtpDeliveryMethod.Network,
                        //    UseDefaultCredentials = false,
                        //    Credentials = new NetworkCredential(senderEmail.Address, password)
                        //};
                        //using (var mess = new MailMessage(senderEmail, receiverEmail)
                        //{
                        //    Subject = subject,
                        //    Body = body
                        //})
                        //{
                        //    smtp.Send(mess);
                        //}
                        #endregion
                }
                catch (Exception e)
                    {
                        string a = e.Message;
                        return a;
                    }
            }
            else
            {
                return "false";
            }
        }
        
    }
}
