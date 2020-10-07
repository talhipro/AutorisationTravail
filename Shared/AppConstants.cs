using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class AppConstants
    {
        /* STATUS */
        public const string AppName = "Autorisation de travail";

        public const string StatutValidé = "Validé";
        public const string StatutEnCours = "En Cours";
        public const string StatutRefusé = "Refusé";
        public const string StatutEnRetard = "En Retard";

        public const string StatutValidéColor = "#e67e22";
        public const string StatutEnCoursColor = "#3498db";
        public const string StatutRefuséColor = "#71BA51";
        public const string StatutEnRetardColor = "#E81123";

        //ROLES
        public const string ROLE_CEEE = "ROLE_CEEE";
        public const string ROLE_CEEP = "ROLE_CEEP";
        public const string ROLE_HSEENTITE = "ROLE_HSESITE";
        public const string ROLE_HSESITE = "ROLE_HSESITE";

        //MESSAGING CENTER
        public const string FILTER_AT = "FILTER_AT";
        public const string FILTER_PERMIS = "FILTER_PERMIS";
    }
}
