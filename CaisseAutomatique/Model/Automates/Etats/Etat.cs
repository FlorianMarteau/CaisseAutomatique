using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CaisseAutomatique.Model.Automates.Etats
{
    public abstract class Etat : INotifyPropertyChanged
    {

        private Automate automate;

        private Caisse caisse;

        /// <summary>
        /// Evenement de l'observation
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Représente l'automate pour le manipuler
        /// </summary>
        protected Automate Automate { get => automate; }

        /// <summary>
        /// Représente la caisse de la couche métier
        /// </summary>
        protected Caisse Caisse { get => caisse; }

        /// <summary>
        /// Représente le message de l'état
        /// </summary>
        public abstract string Message { get; }

        /// <summary>
        /// Constructeur de la classe état
        /// </summary>
        /// <param name="caisse">caisse du métier</param>
        public Etat(Caisse caisse,Automate auto)
        {
            this.caisse = caisse;
            this.automate = auto;
        }

        /// <summary>
        /// Permet de passer d'un état à un autre à partir d'un évènement
        /// </summary>
        /// <param name="e">évènement de transition</param>
        /// <returns>le nouvel état</returns>
        public abstract Etat Transition(Evenement e);

        /// <summary>
        /// Permet d'effectuer l'action correspondant au nouvel évènement
        /// </summary>
        /// <param name="e">évènement à effectuer</param>
        public abstract void Action(Evenement e);

        /// <summary>
        /// Permet de notifier l'ihm que l'état a changé
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
