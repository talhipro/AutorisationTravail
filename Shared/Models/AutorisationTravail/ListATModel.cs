using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.AutorisationTravail
{
    public class ListATModel
    {
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
        public string AutorisationStatutColor { get; set; }
    }
}
