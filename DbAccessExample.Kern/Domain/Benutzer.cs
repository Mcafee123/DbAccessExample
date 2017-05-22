namespace DbAccessExample.Kern.Domain
{
    public class Benutzer : EntityBase
    {
        public string Adresse1 { get; set; }
        public int FMHId { get; set; }
        public bool FMHMember { get; set; }
        public byte Geschlecht { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
    }
}