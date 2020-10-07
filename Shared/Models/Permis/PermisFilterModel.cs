using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.Permis
{
    [AddINotifyPropertyChangedInterface]
    public class PermisFilterModel
    {
        public List<string> Statuts { get; set; } = new List<string>();
        public List<string> Entities { get; set; } = new List<string>();
        public List<string> Services { get; set; } = new List<string>();
        public List<string> Demandeurs { get; set; } = new List<string>();
        public List<string> Sites { get; set; } = new List<string>();
        public List<string> Types { get; set; } = new List<string>();
    }
}
