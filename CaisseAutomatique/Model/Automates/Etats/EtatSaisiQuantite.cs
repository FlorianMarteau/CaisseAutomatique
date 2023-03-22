using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatSaisiQuantite : Etat
    {
        public EtatSaisiQuantite(Caisse caisse, Automate auto) : base(caisse, auto)
        {
        }

        public override string Message => "Combien d'articles souhaitez vous ajouter ? ";

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.SAISIEQUANTITE:
                    this.Caisse.RegisterArticle(this.Caisse.QuantiteSaise);
                    break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etasuivant = this;
            switch (e)
            {
                case Evenement.SAISIEQUANTITE:
                    etasuivant = new EtatAttenteProduit(this.Caisse, Automate);
                    break;

            }
            return etasuivant;
        }
    }
}
