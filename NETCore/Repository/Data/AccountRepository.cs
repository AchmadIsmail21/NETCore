using Microsoft.EntityFrameworkCore;
using NETCore.Context;
using NETCore.Models;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NETCore.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        MyContext myContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        private static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
        }
        private static bool ValidatePassword(string password, string correct)
        {
            return BCrypt.Net.BCrypt.Verify(password, correct);
        }
        public int Login(LoginVM login)
        {
            //ForgotPasswordVM forgotPassword = new ForgotPasswordVM();

            var res = 0;
            var check = myContext.Persons.FirstOrDefault(p => p.Email == login.Email);
            //var checkPas = myContext.Accounts.FirstOrDefault(p => p.Password == login.Password); 
            if (check != null)
            {
                if (ValidatePassword(login.Password, check.Account.Password))
                {
                    res = 2;
                }
                else
                {
                    res = 1;
                }
            }
            return res;
        }

        public IEnumerable<LoginVM> GetLogin()
        {

            var all = (from p in myContext.Persons
                       join a in myContext.Accounts on p.NIK equals a.NIK
                       select new LoginVM
                       {
                          // NIK = p.NIK,
                           Email = p.Email,
                           Password = a.Password
                          
                       }).ToList();
            return all;

        }

        public int ForgotPassword(ForgotPasswordVM forgotPassword) {
            Account account = new Account();
            var checkEmail = myContext.Persons.Where(p => p.Email == forgotPassword.Email).FirstOrDefault();
            var result = 0;
            //generate guid
            string guid = Guid.NewGuid().ToString();
            if (checkEmail == null)
            {
                return 100;
            }
            var checkNikAccount = myContext.Accounts.Where(a => a.NIK == checkEmail.NIK).FirstOrDefault(); //linq //An exception was thrown while attempting to evaluate a LINQ query parameter expression //solve
            if (checkNikAccount == null) {
                return 100;
            }
               //account.Password = forgotPassword.NewPassword;
               string mail = $"Password Baru : {guid}";
               string hashPass = HashPassword(guid);
               Email(mail, checkEmail.Email);
               checkNikAccount.Password = hashPass;
               Update(checkNikAccount);
               result = myContext.SaveChanges();


               return result;
        }

        public static void Email(string htmlString, string toMailAddress)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("stevanloaned12@gmail.com");
                message.To.Add(new MailAddress(toMailAddress));
                message.Subject = "Reset";
                message.IsBodyHtml = true;
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("stevanloaned12@gmail.com", "makannasi12");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception e)
            {
            }

        }

        public int ChangePassword(ChangePassVM change) {
            var result = 0;
            var checkEmail = myContext.Persons.Where(p => p.Email == change.Email).FirstOrDefault();
            //var result = 0;
            if (checkEmail == null)
            {
                // untuk cek email
                return 100;
            }
            else {
                var checkNikAccount = myContext.Accounts.Where(a => a.NIK == checkEmail.NIK).FirstOrDefault(); //An exception was thrown while attempting to evaluate a LINQ query parameter expression //solve
                //var checkPass = myContext.Accounts.Where(cp => cp.NIK == checkEmail.NIK).FirstOrDefault();
                // untuk cek password lama
                var validatePassword = ValidatePassword(change.OldPassword, checkNikAccount.Password);
                if (validatePassword == false)
                {
                    return 200;
                }
                else {
                    if (change.NewPassword == change.ConfirmPassword)
                    {

                        checkNikAccount.Password = HashPassword(change.NewPassword);
                        myContext.Entry(checkNikAccount).State = EntityState.Modified;
                        Update(checkNikAccount);
                        result = myContext.SaveChanges();
                        return result;
                    }
                    else {
                        return 300;
                    }
                
                }
            }
        }

    }
}
