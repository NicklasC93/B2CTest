using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.Identity.Client;
using Xamarin.Forms;

namespace B2CTest
{
    public partial class LoginResultPage : ContentPage
    {
        private AuthenticationResult authenticationResult;

        public LoginResultPage(AuthenticationResult authResult)
        {
            authenticationResult = authResult;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            GetClaims();
            base.OnAppearing();
        }
        private void GetClaims()
        {
            var token = authenticationResult.IdToken;
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var data = handler.ReadJwtToken(authenticationResult.IdToken);
                var claims = data.Claims.ToList();
                if (data != null)
                {
                    this.welcome.Text = $"Welcome {data.Claims.FirstOrDefault(x => x.Type.Equals("name")).Value}";
                    this.issuer.Text = $"Issuer: {data.Claims.FirstOrDefault(x => x.Type.Equals("iss")).Value}";
                    this.subject.Text = $"Subject: {data.Claims.FirstOrDefault(x => x.Type.Equals("sub")).Value}";
                    this.audience.Text = $"Audience: {data.Claims.FirstOrDefault(x => x.Type.Equals("aud")).Value}";
                }
            }
        }

        async void SignOutBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            await App.AuthenticationClient.RemoveAsync(authenticationResult.Account);
            await Navigation.PushAsync(new LoginPage());
        }
    }
}