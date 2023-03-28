using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatProblemePoids : Etat
    {
        public EtatProblemePoids(Caisse caisse, Automate auto) : base(caisse, auto)
        {
        }

        public override string Message => "Problème Poids !";

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.DEBUT_ADMIN:
                    NotifyPropertyChanged("OuvrirAdministration");
                    break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etaCourant = this;
            switch (e)
            {
                case Evenement.POSER_BALANCE:
                    if (this.Caisse.PoidsBalance == this.Caisse.PoidsAttendu)
                    {
                        etaCourant = new EtatEnregistrement(this.Caisse, this.Automate);
                    }
                    break;
                case Evenement.ENLEVER_BALANCE:
                    if (this.Caisse.PoidsBalance == this.Caisse.PoidsAttendu)
                    {
                        etaCourant = new EtatAttenteProduit(this.Caisse, this.Automate);
                    }
                    break;
                case Evenement.DEBUT_ADMIN:
                    etaCourant = new EtatAdministrateur(this.Caisse, this.Automate);
                    break;
            }
            return etaCourant;
        }
    }
}
