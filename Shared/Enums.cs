using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shared
{
    public enum AtStatut
    {
        [Description("Draft")]
        Draft = 1,
        [Description("Attente permis")]
        AttentePermis,
        [Description("En exécution")]
        EnExecution,
        [Description("Attente validation")]
        AttenteValidation,
        [Description("Attente réception")]
        AttenteReception,
        [Description("Réceptionné")]
        Receptionne,
    }

    public enum PermisStatut
    {
        [Description("Draft")]
        Draft = 1,
        [Description("En cours de préparation")]
        EnCoursDePreparation,
        [Description("Attente validation")]
        AttenteValidation,
        [Description("Validé")]
        Valide,
        [Description("Refusé")]
        Refuse,
    }

}
