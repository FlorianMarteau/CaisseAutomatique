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
                    if (!this.Caisse.DernierArticleScanne.IsDenombrable)
                    {
                        this.Caisse.RegisterArticle();
                    }
                    else
                    {
                        NotifyPropertyChanged("ScanArticleDenombrable");
                    }
                    break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etasuivant = this;
            switch (e)
            {
                case Evenement.SCAN_ARTICLE:
                    if (!this.Caisse.DernierArticleScanne.IsDenombrable)
                    {
                        etasuivant = new EtatAttenteProduit(this.Caisse, Automate);
                    }
                    else
                    {
                        etasuivant = new EtatSaisiQuantite(this.Caisse, Automate);
                    }
                    break;

            }
            return etasuivant;
        }
    }
}
