using System;

namespace DbAccessExample.Kern.Domain
{
    public class Dossier : EntityBase
    {
        // FK_CockpitSB_Dossier_AblageortId
        public DossierAblageort Ablageort { get; set; }
        // FK_CockpitSB_Dossier_Arzt
        public Benutzer Arzt { get; set; }
        public int DossierStatus { get; set; }
        public bool Dringend { get; set; }
        public DateTime ErstelltDatum { get; set; }
        public int ModifiziertBenutzerId { get; set; }
        public DateTime ModifiziertDatum { get; set; }
        // FK_CockpitSB_Dossier_Bearbeiter
        public Benutzer Sachbearbeiterin { get; set; }
        public int Typ { get; set; }
    }
}