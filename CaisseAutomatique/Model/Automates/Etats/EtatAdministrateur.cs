using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatAdministrateur : Etat
    {
        public EtatAdministrateur(Caisse caisse, Automate auto) : base(caisse, auto)
        {
        }

        public override string Message => "Session administrateur";

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.ANNULER_ARTICLE:
                    this.Caisse.CancelLastArticle();
                    break;
                case Evenement.ANNULER_COMMANDE:
                    this.Caisse.Reset();

                    break;
 
                
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etat = this;
            switch (e)
            {
                case Evenement.FIN_ADMIN:
                    if (this.Caisse.PoidsBalance == this.Caisse.PoidsAttendu)
                    {
                        etat = new EtatEnregistrement(this.Caisse, this.Automate);
                    }
                    else
                    {
                        etat = new EtatProblemePoids(this.Caisse, this.Automate);
                    }
                break;
            }
            return etat;
        }
    }
}
