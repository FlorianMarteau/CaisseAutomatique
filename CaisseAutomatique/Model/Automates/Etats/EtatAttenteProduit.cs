using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatAttenteProduit : Etat
    {
        public EtatAttenteProduit(Caisse caisse, Automate auto) : base(caisse, auto)
        {
        }

        public override string Message => "Placez le produit";

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.POSER_BALANCE:
                    break;

            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etasuivant = this;
            switch (e)
            {
                case Evenement.POSER_BALANCE:
                    if (this.Caisse.PoidsBalance == this.Caisse.PoidsAttendu)
                    {
                        etasuivant = new EtatEnregistrement(this.Caisse, this.Automate);
                    }
                    else
                    {
                        etasuivant = new EtatProblemePoids(this.Caisse, this.Automate);
                    }
                    break;

            }
            return etasuivant;
        }
    }
}
