using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public class EtatFin : Etat
    {
        /// <summary>
        /// Représente le timer pour manipuler l'automate
        /// </summary>
        private static Timer timer;

        public EtatFin(Caisse caisse, Automate auto) : base(caisse,auto)
        {
            if (timer == null)
            {
                timer = new Timer(2000);
                timer.Elapsed += Timer_Elasped;
                timer.AutoReset = false;
                timer.Start();
            }
        }

        public override string Message => "Au revoir";

        public override void Action(Evenement e)
        {
            switch (e)
            {
                case Evenement.RESET:
                    this.Caisse.Reset();
                    break;
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etasuivant = this;
            switch (e)
            {
                case Evenement.RESET:
                    etasuivant = new EtatAttenteClient(this.Caisse, this.Automate);
                    break;

            }
            return etasuivant;
        }

        /// <summary>
        /// Permet de faire un événement au bout d'un certain temps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elasped(object? sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                this.Automate.Activer(Evenement.RESET);
            });
            timer.Dispose();
            timer = null;
        }
    }
}
