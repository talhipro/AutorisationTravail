using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Shared.Models.AutorisationTravail
{
    [AddINotifyPropertyChangedInterface]
    public class ATModel
    {
        public SiteModel AtSite { get; set; } = new SiteModel();
        public EntiteModel AtEntite { get; set; } = new EntiteModel();
        public string AtNum { get; set; }
        public string DiNum { get; set; }
        public string OtNum { get; set; }
        public string BtNum { get; set; }
        public string AtLieu { get; set; }
        public string AtServices { get; set; }
        public string AtEntreprises { get; set; }
        public string AtDescription { get; set; }
        public string AtDate { get; set; }
        public string AtHeurDebut { get; set; }
        public string AtHeurFin { get; set; }

        public List<AtCheckedItem> AtRisques { get; set; } = new List<AtCheckedItem>();
        public List<AtCheckedItem> AtMesures { get; set; } = new List<AtCheckedItem>();
        public List<AtCheckedItem> AtMoyensAcces { get; set; } = new List<AtCheckedItem>();
        public List<AtCheckedItem> AtEpiSpecifiques { get; set; } = new List<AtCheckedItem>();
        public List<AtCheckedItem> AtPermis { get; set; } = new List<AtCheckedItem>();

        public string AtRisquesCount
        {
            get
            {
                return $"({AtRisques?.Count})";
            }
        }
        public bool AtRisquesShowAddEditBtn
        {
            get
            {
                return AtRisques?.Count == 0;
            }
        }

        public string AtMesuresCount
        {
            get
            {
                return $"({AtMesures.Count})";
            }
        }
        public bool AtMesuresShowAddEditBtn
        {
            get
            {
                return AtMesures.Count == 0;
            }
        }

        public string AtMoyensAccesCount
        {
            get
            {
                return $"({AtMoyensAcces.Count})";
            }
        }
        public bool AtMoyensAccesShowAddEditBtn
        {
            get
            {
                return AtMoyensAcces.Count == 0;
            }
        }

        public string AtEpiSpecifiquesCount
        {
            get
            {
                return $"({AtEpiSpecifiques.Count})";
            }
        }
        public bool AtEpiSpecifiquesShowAddEditBtn
        {
            get
            {
                return AtEpiSpecifiques.Count == 0;
            }
        }

        public string AtPermisCount
        {
            get
            {
                return $"({AtPermis.Count})";
            }
        }
        public bool AtPermisShowAddEditBtn
        {
            get
            {
                return AtPermis.Count == 0;
            }
        }
    }
}
