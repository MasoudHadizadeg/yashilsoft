namespace Yashil.Common.Core.Dtos
{
    public class LoginResultModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public bool Succeeded { get; set; }
    }
}
