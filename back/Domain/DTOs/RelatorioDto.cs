namespace Domain.DTOs
{
    public class RelatorioDto
    {
        public string Nome { get; set; }
        public decimal Matematica { get; set; }
        public decimal Portugues { get; set; }
        public decimal Historia { get; set; }
        public decimal Geografica { get; set; }
        public decimal Ingles { get; set; }
        public decimal Biologia { get; set; }
        public decimal Filosofia { get; set; }
        public decimal Fisica { get; set; }
        public decimal Quimica { get; set; }
        public decimal Media
        {
            get
            {
                var media = (Matematica + Portugues + Historia + Geografica + Ingles + Biologia + Filosofia + Fisica + Quimica) / 9;
                return decimal.Round(media, 2);
            }
        }
    }
}


