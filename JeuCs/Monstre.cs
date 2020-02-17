using System;

namespace JeuCs
{
    public abstract class Monstre : ICombattant
    {
        private static Random random = new Random();
        private int DefMonstre = 0;
        public int Pv { get; set; }
        public int PvMax { get; set; }
        public int Atk { get; set; }
        public int Xp { get; set; }
        public int Lvl { get; set; }
        public string Nom { get; protected set; }

        public int Def
        {
            get { return DefMonstre; }
            set
            {
                DefMonstre = value;
                if (DefMonstre < 0)
                {
                    DefMonstre = 0;
                }
            }
        }

        public bool EstVivant
        {
            get
            {
                return Pv > 0;
            }
        }

        protected Monstre(int pv_, int atk_, string nom_/*, int pvJoueur_, int atkJoueur_*/)
        {
            Pv = pv_;
            PvMax = Pv;
            Atk = atk_;
            Nom = nom_;
            //Joueur.PvJoueur = pvJoueur_;
            //Joueur.AtkJoueur = atkJoueur_;
        }

        public static Monstre EnvoyerMonstre()
        {
            double hasard = random.Next(0, 100);
            Console.WriteLine(hasard);
            Monstre monstre = new Minotaure();
            if (Program.nbSalle < 10)
            {
                if (hasard >= 0 && hasard < 10)
                    monstre = new Minotaure();
                else if (hasard >= 10 && hasard < 20)
                    monstre = new Orc();
                else if (hasard >= 20 && hasard < 40)
                    monstre = new Squelette();
                else
                    monstre = new Gobelin();
            }
            else if (Program.nbSalle >= 10 && Program.nbSalle < 20)
            {
                if (hasard >= 0 && hasard < 14)
                    monstre = new Minotaure();
                else if (hasard >= 14 && hasard < 28)
                    monstre = new Orc();
                else if (hasard >= 28 && hasard < 48)
                    monstre = new Squelette();
                else
                    monstre = new Gobelin();
            }
            else if (Program.nbSalle >= 20 && Program.nbSalle < 30)
            {
                if (hasard >= 0 && hasard < 18)
                    monstre = new Minotaure();
                else if (hasard >= 18 && hasard < 35)
                    monstre = new Orc();
                else if (hasard >= 35 && hasard < 56)
                    monstre = new Squelette();
                else
                    monstre = new Gobelin();
            }
            else if (Program.nbSalle >= 30 && Program.nbSalle < 40)
            {
                if (hasard >= 0 && hasard < 21)
                    monstre = new Minotaure();
                else if (hasard >= 21 && hasard < 42)
                    monstre = new Orc();
                else if (hasard >= 42 && hasard < 63)
                    monstre = new Squelette();
                else
                    monstre = new Gobelin();
            }
            else  //(Program.nbSalle >= 40 && Program.nbSalle < 50)
            {
                if (hasard >= 0 && hasard < 30)
                    monstre = new Minotaure();
                else if (hasard >= 30 && hasard < 60)
                    monstre = new Orc();
                else if (hasard >= 60 && hasard < 80)
                    monstre = new Squelette();
                else
                    monstre = new Gobelin();
            }
            return monstre;
        }

        public override string ToString()
        {
            return $"Monstre : {Nom}";
        }
    }

    public class Gobelin : Monstre
    {
        public Gobelin()
            : base(15, 10, "Gobelin")
        {
        }
    }

    public class Squelette : Monstre
    {
        public Squelette()
            : base(20, 20, "Squelette")
        {
        }
    }

    public class Orc : Monstre
    {
        public Orc()
            : base(40, 20, "Orc")
        {
        }
    }

    public class Minotaure : Monstre
    {
        public Minotaure()
            : base(20, 35, "Minotaure")
        {
        }
    }
}