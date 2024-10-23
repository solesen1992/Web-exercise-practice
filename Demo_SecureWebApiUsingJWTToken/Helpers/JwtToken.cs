/*
* Trying to generate a token that can access the resource 
* (WeatherForecastController - the method with [Authorize] which is a secure resource)
* 
* Secret key should be the same in the token and jwtAuthenticationExtentions.
*/

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

/*
 * CODE ALONG SESSION
 * Credit: https://www.youtube.com/watch?v=h2hGGPHLqqc
 */

namespace Demo_SecureWebApiUsingJWTToken.Helpers
{
    public static class JwtToken
    {
        private const string SECRET_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJwtToken() { 
            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            // Finally create a Token
            var header = new JwtHeader(credentials); // used in the header section

            // Token will be good for 1 minutes
            DateTime Expiry = DateTime.UtcNow.AddMinutes(1); // The token is valid for 1 minute
            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            // Some PayLoad that contain information about the customer
            var payload = new JwtPayload
            {
                {  "sub", "testSubject"},
                {  "Name", "Scott"},
                {  "email", "smithest@test.com"},
                //, {  "nbf", new DateTimeOffset(DateTime.Now).DateTime},
                {  "exp", ts}, // how long the token is valid. How long it takes to expire.
                {  "iss", "https://localhost:7022"}, // Issuer - the party generating the JWT
                {  "aud", "https://localhost:7022"}, // Audience - the address of the resource
            };

            var secToken = new JwtSecurityToken(header, payload); // creates security token object and pass in header and payload information

            var handler = new JwtSecurityTokenHandler(); // writes / generates the token

            var tokenString = handler.WriteToken(secToken); // SecurityToken

            Console.WriteLine(tokenString);
            Console.WriteLine("Consume Token");

            return tokenString;
        }
    }
}
