using CaisseAutomatique.Model.Automates.Etats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates
{
    public class Automate : INotifyPropertyChanged
    {
        /// <summary>
        /// Représente la caisse de la couche métier
        /// </summary>
        private Caisse caisse;

        /// <summary>
        /// Représente l'état courant de l'automate
        /// </summary>
        private Etat etatCourant;

        /// <summary>
        /// Représente l'évènement à trigger quand l'automate est changé
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Représente le message relatif à l'état
        /// </summary>
        public string Message { get => etatCourant.Message; }

        /// <summary>
        /// Constructeur de la classe automate
        /// </summary>
        /// <param name="c">caisse de la couche métier</param>
        public Automate(Caisse c)
        {
            this.caisse = c;
            this.etatCourant = new EtatAttenteClient(caisse,this);
        }

        /// <summary>
        /// Permet d'activer l'automate sur un évènement voulu
        /// </summary>
        /// <param name="e">évènement choisi</param>
        public void Activer(Evenement e)
        {
            etatCourant.Action(e);
            this.etatCourant = etatCourant.Transition(e);
           NotifyPropertyChanged("Message");
        }

        /// <summary>
        /// Permet de notifier l'ihm que l'état a changé
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
