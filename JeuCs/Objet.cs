using System;

namespace JeuCs
{
    public abstract class Objet
    {
        private static Random random = new Random();
        public int Amplitude { get; protected set; }
        public static int Arme { get; protected set; } = 0;
        public int AncienneArme { get; protected set; } = 0;
        public static int Protection { get; protected set; } = 0;

        //Constructeur
        protected Objet(int amplitude_)
        {
            Amplitude = amplitude_;
        }

        //fonction de choix de potion
        public static Objet TirerPotion()
        {
            Objet potion = null;
            int ChancePotion = random.Next(0, 100);
            if (ChancePotion < 10)
                potion = new PotionXP();
            else if (ChancePotion >= 10 && ChancePotion < 75)
                potion = new PotionDeVie();
            else
                potion = new PotionNulle();
            return potion;
        }

        //fonction de choix d'équipement
        public static Objet TirerEquipement()
        {
            Objet equipement = null;
            int ChanceEquipement = random.Next(1, 3);
            if (ChanceEquipement == 1)
            {
                equipement = new Epee();
            }
            else if (ChanceEquipement == 2)
            {
                equipement = new Armure();
            }
            return equipement;
        }

        public static Objet TrouverPetitCoffre()
        {
            Objet item = null;
            int hasard = random.Next(1, 10);
            Console.WriteLine("Il y a un petit coffre au fond de la salle ! Vous vous empressez de l'ouvrir");
            if (hasard < 10)
            {
                item = TirerPotion();
            }
            else
            {
                item = TirerEquipement();
            }
            return item;
        }

        //fonction d'utilisation d'objet à usage unique
        public virtual void Utiliser(Joueur joueur_)
        {
        }
    }

    public class PotionDeVie : Objet
    {
        public PotionDeVie()
            : base(40)
        { }

        public override void Utiliser(Joueur joueur_)
        {
            Console.WriteLine($"Vous trouvez une potion de soin.");
            if (joueur_.Pv == joueur_.PvMax)
            {
                joueur_.Pv += Amplitude;
                Console.WriteLine($"Vos Pv sont déja au max mais vous la buvez au cas où...");
            }
            else if (joueur_.Pv > joueur_.PvMax - Amplitude)
            {
                joueur_.Pv += Amplitude;
                Console.WriteLine($"Vous êtes comme neuf! Pv : {joueur_.Pv}");
            }
            else
            {
                joueur_.Pv += Amplitude;
                Console.WriteLine($"Vous regagnez {Amplitude} Pv! Pv : {joueur_.Pv}");
            }
        }
    }

    public class PotionXP : Objet
    {
        public PotionXP()
            : base(100)
        { }

        public override void Utiliser(Joueur joueur_)
        {
            Console.WriteLine($"Vous trouvez une potion d'XP. Elle vous rapporte {Amplitude} XP");
            joueur_.Xp += Amplitude;
            Console.WriteLine($"Xp : {joueur_.Xp}");
        }
    }

    public class PotionNulle : Objet
    {
        public PotionNulle()
            : base(0)
        { }

        public override void Utiliser(Joueur joueur_)
        {
            Console.WriteLine("Vous trouvez une potion étrange... ca tombe bien vous aviez soif!");
        }
    }

    public class Epee : Objet
    {
        private Random random = new Random();
        //int test = (new Random()).Next(0, 3);

        public Epee()
            : base(0)
        {
            int c = random.Next(1, 10);

            if (c <= 8)
                Amplitude = random.Next(5, 10);
            else
                Amplitude = random.Next(10, 15);
        }

        public override void Utiliser(Joueur joueur_)
        {
            if (Amplitude > Arme)
            {
                AncienneArme = Arme;
                Arme = Amplitude;
                joueur_.Atk += Arme - AncienneArme;
                Console.WriteLine($"Vous trouvez une épée (Atk : {Amplitude}) ! Atk : {joueur_.Atk} ");
            }
            else if (Arme == Amplitude)
            {
                Console.WriteLine("Vous trouvez une épée mais la votre est plus jolie");
            }
            else
            {
                Console.WriteLine("L'épée que vous trouvez vous rend fier de la qualité de la votre");
            }
        }
    }

    public class Armure : Objet
    {
        public Armure()
            : base(5)
        { }

        public override void Utiliser(Joueur joueur_)
        {
            if (Amplitude > Protection)
            {
                Protection = Amplitude;
                joueur_.Def += Protection;
                Console.WriteLine($"Vous trouvez une armure (Def + {Amplitude}) ! Def : {joueur_.Def} ");
            }
            else if (Arme == Amplitude)
            {
                Console.WriteLine("Vous trouvez une armure mais votre flemme est plus forte que votre envie d'essayer de nouvelles choses");
            }
            else
            {
                Console.WriteLine("En voyant l'armure que vous trouvez vous préferez garder la votre");
            }
        }
    }
}