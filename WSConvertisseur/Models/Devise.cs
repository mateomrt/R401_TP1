namespace WSConvertisseur.Models
{
    public class Devise
    {
        private int id;
        private string? nomDevise;
        private double taux;

        public int Id
        {
            get { return Id; }
            set { Id = value; }
        }
        public string? NomDevise
        {
            get { return NomDevise; }
            set { NomDevise = value; }
        }
        public double Taux
        {
            get { return Taux; }
            set { Taux = value; }
        }
        public Devise(int id, string? nomDevise, double taux)
        {
            this.Id = id;
            this.NomDevise = nomDevise;
            this.Taux = taux;
        }
        public Devise()
        {




        }




    }
}
