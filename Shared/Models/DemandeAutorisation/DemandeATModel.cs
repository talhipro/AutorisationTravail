
using PropertyChanged;

namespace Shared.Models.DemandeAutorisation
{
    [AddINotifyPropertyChangedInterface]
    public class DemandeATModel
    {
        public SiteModel AtSite { get; set; } = new SiteModel();
        public EntiteModel AtEntite { get; set; } = new EntiteModel();
        public ChefEntiteModel ChefEntite { get; set; } = new ChefEntiteModel();

        public string DemandeAtNum { get; set; }
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

        public DemandeATModel() { }
    }

}


