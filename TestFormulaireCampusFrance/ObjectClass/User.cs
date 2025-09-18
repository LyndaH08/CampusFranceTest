


namespace CampusFrance.test.ObjectClass
{
    public class User
    {
        public string AdresseMail { get; set; }
        public string MotDePasse { get; set; }
        public string Civilité { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string PaysResidence { get; set; }
        public string PaysNationalite { get; set; }
        public Adresse Adresse { get; set; }
        public string Telephone { get; set; }
        public string Statut { get; set; }
        public string Domaine { get; set; }
        public string Niveau { get; set; }
        public string Fonction { get; set; }
        public string TypeOrganisme { get; set; }
        public string NomOrganisme { get; set; }

    }


    public class Adresse
    {
        public string CodePostale { get; set; }
        public string Ville { get; set; }

        public string getAdresse()
        {
            return this.CodePostale + " " + this.Ville;
        }
    }
}
