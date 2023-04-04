namespace GhBrandingBackend.Models
{
    public class Registros
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime RegistroInicial { get; set; }
        public DateTime RegistroFinal { get; set; }
        public TimeSpan HorasDia { get; set; }

        public Registros() { }

        public Registros(
            int id, 
            string descricao, 
            DateTime registroInicial, 
            DateTime registroFinal, 
            TimeSpan horasDia)
        {
            Id = id;
            Descricao = descricao;
            RegistroInicial = registroInicial;
            RegistroFinal = registroFinal;
            HorasDia = horasDia;
        }

        public void CalularHorasDia() => HorasDia = RegistroFinal - RegistroInicial;

    }
}
