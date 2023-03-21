using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatAttenteClient : Etat
    {
        public EtatAttenteClient(Caisse caisse,Automate auto) : base(caisse,auto)
        {
        }

        public override string Message { get => "Bonjour, scannez votre premier article !"; }

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.SCAN_ARTICLE:
                    this.Caisse.RegisterArticle();
                    break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etasuivant = this;
            switch (e)
            {
                case Evenement.SCAN_ARTICLE:
                    etasuivant = new EtatAttenteProduit(this.Caisse,Automate);
                    break;

            }
            return etasuivant;
        }
    }
}
