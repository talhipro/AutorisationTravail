using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PropertyChanged;

namespace Shared.Models
{
    [AddINotifyPropertyChangedInterface]
    public class AtCheckedItem
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class SiteModel
    {
        public string Id { get; set; }
        public string SiteName { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class EntiteModel
    {
        public string Id { get; set; }
        public string EntiteName { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class ChefEntiteModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class DTModel
    {
        public string Id { get; set; }
        public string DTName { get; set; }
    }
}
