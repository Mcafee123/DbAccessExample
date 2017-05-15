using System;
using System.Collections.Generic;

namespace DbAccessExample.Kern.Domain
{
    public class Dossier : EntityBase
    {
        public DateTime? AnTitelkommissionDatum { get; set; }
        public int ArztBenutzerId { get; set; }
        public int? BearbeiterBenutzerId { get; set; }
        public string Bemerkungen { get; set; }
        // FK_CockpitSB_Dossier_Bearbeiter
        public Benutzer Sachbearbeiterin { get; set; }
        // FK_CockpitSB_Dossier_AblageortId
        public DossierAblageort Ablageort { get; set; }
        public int DossierStatus { get; set; }
        // FK_CockpitSB_DossierVerlauf_CockpitSB_Dossier
        public IEnumerable<DossierVerlauf> DossierVerlauf { get; set; }
        public bool Dringend { get; set; }
        public DateTime ErstelltDatum { get; set; }
        // FK_CockpitSB_Dossier_Arzt
        public Benutzer Arzt { get; set; }
        public DateTime? GesuchEingangDatum { get; set; }
        public string KandidatText { get; set; }
        public int ModifiziertBenutzerId { get; set; }
        public DateTime ModifiziertDatum { get; set; }
        public DateTime? PosteingangDatum { get; set; }
        // FK_CockpitSB_Dossier_RevisionId
        public Revision Revision { get; set; }
        public int? RevisionId { get; set; }
        public int Typ { get; set; }
        public DateTime? UlaAngefordertDatum { get; set; }
        public DateTime? UlaEingegangenDatum { get; set; }
    }
}