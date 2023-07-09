namespace Lab3.Model.InputModel
{
    public class UserInputModel
    {
       
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
   
        public UserInputModel(
            string name, string
             email, string password
            ) {
            this.name = name;
            this.email = email; 
            this.password = password;
        }

        

    }

   
}
