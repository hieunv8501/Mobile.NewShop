using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuenMatKhau : ContentPage
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            lblEmail.Text = "Email";
            lblEmail.TextColor = Color.Blue;
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            lblEmail.Text = "";
        }

        private async void btnSend_Clicked(object sender, EventArgs e)
        {
            APIString APIString = new APIString();
            try
            {
                //Random pass
                var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[6];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);


                //Send mail
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("newshop070201@gmail.com");
                mail.To.Add(inputMail.Text);
                mail.Subject = "Your password";
                mail.Body = "Mật khẩu mới của bạn là: " + finalString;

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("newshop070201@gmail.com", "newshop123");

                SmtpServer.Send(mail);

                //update pass
                HttpClient httpClient = new HttpClient();
                var ConnectAPI = await httpClient.GetStringAsync(APIString.str + "UpdateMatKhauQuaEmail?Email=" + inputMail.Text + "&MatKhau=" + finalString);

                await DisplayAlert("Thông báo", "Mật khẩu mới đã gửi về Email của bạn", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Lỗi", ex.Message, "OK");
            }
        }
    }
}