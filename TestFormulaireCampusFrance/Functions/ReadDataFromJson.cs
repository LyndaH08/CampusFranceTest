using CampusFrance.test.ObjectClass;
using System.Text.Json;

namespace CampusFrance.test.Functions
{
    internal class ReadDataFromJson
    {

        public static List<User> FromJsonFileToObject()
        {
            // ReadAllText lit tout le contenu du fichier et retourne ce contenu sous forme d'une chaine de caractére
            string jsonString = File.ReadAllText(@"Data\UserCampusFrance.json");

            //prendre la chaine jsonString et la convertit en objet Utilisateirs
            List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);

            return users;
        }


    }
}
