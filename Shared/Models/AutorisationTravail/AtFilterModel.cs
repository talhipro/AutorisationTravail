using PropertyChanged;
using System.Collections.Generic;

namespace Shared.Models.AutorisationTravail
{
    [AddINotifyPropertyChangedInterface]
    public class AtFilterModel
    {
        public List<string> Statuts { get; set; } = new List<string>();
        public List<string> Entities { get; set; } = new List<string>();
        public List<string> Services { get; set; } = new List<string>();
        public List<string> Demandeurs { get; set; } = new List<string>();
        //public string Statuts { get; set; } = string.Empty;
        //public string Entities { get; set; } = string.Empty;
        //public string Services { get; set; } = string.Empty;
        //public string Demandeurs { get; set; } =  string.Empty;
    }
}
