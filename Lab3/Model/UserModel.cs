using System.ComponentModel.DataAnnotations;

namespace Lab3.Model
{
    public class UserModel
    {
        [Key] public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }   
        public string password { get; set; }
    }
}
