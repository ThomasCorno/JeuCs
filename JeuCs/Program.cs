using System;

namespace JeuCs
{
    internal class Program
    {
        private static Random random = new Random();
        private static Joueur joueur = new Joueur("Arcan");
        public static int nbSalle;

        private static void Main(string[] args)
        {
            joueur.AssignerAtk();

            nbSalle = 1;
            while (joueur.EstVivant)
            {
                if (nbSalle == 1)
                    Console.WriteLine($"{joueur.Nom} entre dans le labyrynthe...\n Pv : {joueur.Pv} Atk : {joueur.Atk}");
                else
                    Console.WriteLine($"{joueur.Nom} avance dans la salle {nbSalle}");
                int labyrynthe = random.Next(1, 12);
                if (labyrynthe <= 7)
                {
                    Monstre monstreAleatoire = Monstre.EnvoyerMonstre();
                    ICombattant vainqueur = Attaquer(joueur, monstreAleatoire);
                    if (vainqueur == joueur)
                    {
                        joueur.Xp += monstreAleatoire.PvMax;
                        Console.WriteLine($"Victoire ! + {monstreAleatoire.PvMax} Xp !!\nPV : {joueur.Pv} | Def : {joueur.Def} | Atk : {joueur.Atk} | XP : {joueur.Xp}");
                        MonterDeNiveau(joueur);
                    }
                    else
                        Console.WriteLine($"{joueur.Nom} est mort | Lvl : {joueur.Lvl}  PvMax : {joueur.PvMax}  Atk : {joueur.Atk}  Def : {joueur.Def}");
                }
                else if (labyrynthe > 8)
                {
                    //joueur.PrendrePotion(Objet.TirerPotion());
                    //joueur.PrendreItem(Objet.TrouverPetitCoffre());
                    //MonterDeNiveau(joueur);
                    Console.WriteLine("Il y a un petit coffre au fond de la salle ! Vous vous empressez de l'ouvrir");
                    int item = random.Next(1, 10);
                    if (item <= 6)
                    {
                        joueur.PrendreItem(Objet.TirerPotion());
                    }
                    else
                    {
                        joueur.PrendreItem(Objet.TirerEquipement());
                    }
                    MonterDeNiveau(joueur);
                }
                else
                {
                    Console.WriteLine("la salle est vide");
                }
                nbSalle++;
                System.Threading.Thread.Sleep(1000);
            }
        }

        public static int MonterDeNiveau(ICombattant fighter)
        {
            if (fighter.Xp >= fighter.Lvl * 100 + (fighter.Lvl - 1) * 75)
            {
                fighter.Lvl++;
                fighter.PvMax += 15;
                fighter.Pv += 15;
                int gainAtk = joueur.AssignerGainAtk();

                if (fighter == joueur)
                {
                    Console.WriteLine($"Level up ! Vous êtes maintenant Niveau {fighter.Lvl} | PvMax + 15 Pv + 15 Atk + {gainAtk}\n" +
                        $"PvMax : {fighter.PvMax} | Pv : {fighter.Pv} | Atk {fighter.Atk}");
                }
            }
            return fighter.Lvl;
        }

        public static ICombattant Attaquer(ICombattant fighter1, ICombattant fighter2)
        {
            Console.WriteLine($"Un {fighter2.Nom} ({fighter2.Pv}PV {fighter2.Atk}Atk) attaque {fighter1.Nom}!");

            do
            {
                fighter1.Pv -= (fighter2.Atk - fighter1.Def);
                fighter2.Pv -= (fighter1.Atk - fighter2.Def);
                Console.WriteLine($"{fighter1.Nom} Perd {fighter2.Atk - fighter1.Def}Pv ! PV : {fighter1.Pv} | {fighter2.Nom} Perd {fighter1.Atk - fighter2.Def}Pv ! PV : {fighter2.Pv}");
            } while (fighter1.EstVivant && fighter2.EstVivant);

            if (fighter1.EstVivant)
                return fighter1;
            if (fighter2.EstVivant)
            {
                return fighter2;
            }
            return null;
        }
    }
}