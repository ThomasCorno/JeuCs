using System;

namespace JeuCs
{
    public class Joueur : ICombattant
    {
        public static Random random = new Random();
        private int PvJoueur = 100;
        private int DefJoueur = 0;
        public int PvMax { get; set; } = 100;
        public int Atk { get; set; }

        public String Nom { get; set; }
        public int Lvl { get; set; }
        public int Xp { get; set; }

        public bool EstVivant
        {
            get
            {
                return Pv > 0;
            }
        }

        public int Def
        {
            get { return DefJoueur; }
            set
            {
                DefJoueur = value;
                if (DefJoueur < 0)
                {
                    DefJoueur = 0;
                }
            }
        }

        public int Pv
        {
            get { return PvJoueur; }
            set
            {
                PvJoueur = value;
                if (PvJoueur > PvMax)
                {
                    PvJoueur = PvMax;
                }
            }
        }

        public Joueur(String nom_)
        {
            Nom = nom_;
            Lvl = 1;
        }

        public void PrendreItem(Objet potion_)
        {
            //PvJoueur += contenance;
            //Console.WriteLine($"{Nom} a bu une potion de {contenance} PV !\nTotal de PV : {PvJoueur}");
            potion_.Utiliser(this);
        }

        public int AssignerAtk()
        {
            int chanceAtk = random.Next(1, 10);
            if (chanceAtk <= 2)
                Atk = random.Next(10, 15);
            else if (chanceAtk < 2 && chanceAtk <= 8)
                Atk = random.Next(15, 20);
            else
                Atk = random.Next(20, 25);
            return Atk;
        }

        public int AssignerGainAtk()
        {
            int chanceGainAtk = random.Next(1, 10);
            int GainAtk;
            if (chanceGainAtk <= 7)
                GainAtk = random.Next(2, 5);
            else
                GainAtk = random.Next(6, 8);
            Atk += GainAtk;
            return GainAtk;
        }

        //public void Combattre(Monstre monstre_)
        //{
        //    monstre_.Attaquer(this);
        //}

        public override string ToString()
        {
            return $"{this.Nom} {this.Pv}";
        }
    }
}