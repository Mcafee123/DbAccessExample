namespace DbAccessExample.Kern.Domain
{
    public class DossierAblageort: EntityBase
    {
        public int Typ { get; set; }
        public string TextDe { get; set; }
        public string TextFr { get; set; }
        public string TextIt { get; set; }
        public string TextEn { get; set; }
    }
}