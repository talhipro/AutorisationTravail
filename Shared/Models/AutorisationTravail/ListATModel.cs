using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shared.Models.AutorisationTravail
{
    public class ListATModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public long AutorisationID { get; set; }
        public string AutorisationNum { get; set; }
        public string AutorisationSite { get; set; }
        public string AutorisationEntite { get; set; }
        public string AutorisationService { get; set; }
        public string AutorisationDemandeur { get; set; }
        public DateTime AutorisationDate { get; set; }
        public DateTime AutorisationDateIntervention { get; set; }
        public string AutorisationHeureDebut { get; set; }
        public string AutorisationHeureFin { get; set; }
        public string AutorisationStatut { get; set; }
        public string AutorisationStatutTxtColor { get; set; }
        public string AutorisationStatutBgColor { get; set; }

        private bool _detailsColapse;
        public bool DetailsColapse
        {
            get => _detailsColapse;
            set
            {
                _detailsColapse = value;
                OnPropertyChanged("DetailsColapse");

            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
