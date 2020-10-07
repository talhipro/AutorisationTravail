using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.DemandeAutorisation
{
    public class DemandeDetailsModel
    {
        public string NumDemande { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
        public string CEEE { get; set; }
        public string Services { get; set; }
        public string DateIntervention { get; set; }
        public string HeureDebut { get; set; }
        public string HeureFin { get; set; }
        public string Site { get; set; }
        public string EntiteProp { get; set; }
        public string EntiteExec { get; set; }
        public string OTNum { get; set; }
        public string Lieu { get; set; }
        public string Entreprises { get; set; }
    }
}
