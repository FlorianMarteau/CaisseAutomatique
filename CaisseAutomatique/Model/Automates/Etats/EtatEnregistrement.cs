using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatEnregistrement : Etat
    {
        public EtatEnregistrement(Caisse caisse, Automate auto) : base(caisse,auto)
        {
        }

        public override string Message => "Scannez le produit suivant";

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.SCAN_ARTICLE:
                    this.Caisse.RegisterArticle();
                    break;
                case Evenement.PAYER:
                    this.Caisse.Payer();
                    break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etasuivant = this;
            switch (e)
            {
                case Evenement.PAYER:
                    etasuivant = new EtatFin(this.Caisse,Automate);
                    break;
                case Evenement.ENLEVER_BALANCE:
                    if (this.Caisse.PoidsBalance == this.Caisse.PoidsAttendu)
                    {
                        etasuivant = new EtatAttenteProduit(this.Caisse, this.Automate);
                    }
                    else
                    {
                        etasuivant = new EtatProblemePoids(this.Caisse, this.Automate);
                    }
                    break;
                case Evenement.SCAN_ARTICLE:
                    etasuivant = new EtatAttenteProduit(this.Caisse, this.Automate);
                    break;


            }
            return etasuivant;
        }
    }
}
