using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PropertyChanged;

namespace Shared.Models.Permis
{
	[AddINotifyPropertyChangedInterface]
    public class PermisListModel
    {
		public string PermisNumAT { get; set; }
		public string PermisDemandeur { get; set; }
		public string PermisStatutValue { get; set; }
		public string PermisStatutBgColor { get; set; }
		public string PermisStatutTxtColor { get; set; }
		public string PermisDate { get; set; }
		public string PermisService { get; set; }
		public string PermisEntite { get; set; }
		public string PermisSite { get; set; }
		public string PermisType { get; set; }
        public bool DetailsColapse { get; set; }
    }
}
