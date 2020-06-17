using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shared.Models.Permis
{
    public class PermisListModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
		public string PermisNumAT { get; set; }
		public string PermisType { get; set; }
		public string PermisDemandeur { get; set; }
		public string PermisStatutValue { get; set; }
		public string PermisStatutBgColor { get; set; }
		public string PermisStatutTxtColor { get; set; }
		public string PermisDate { get; set; }
		public string PermisService { get; set; }
		public string PermisEntite { get; set; }

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
