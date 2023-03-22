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

        public override string Message => throw new NotImplementedException();

        public override void Action(Evenement e)
        {
        }

        public override Etat Transition(Evenement e)
        {
            throw new NotImplementedException();
        }
    }
}
