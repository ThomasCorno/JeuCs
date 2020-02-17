using System;
using System.Collections.Generic;
using System.Text;

namespace JeuCs
{
    public interface ICombattant
    {
        int Pv { get; set; }
        int PvMax { get; set; }
        int Atk { get; set; }
        int Def { get; set; }
        string Nom { get; }
        int Xp { get; set; }
        int Lvl { get; set; }
        bool EstVivant { get; }
    }
}