using Project.Core.Entity;

namespace CarStock.Entity
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string MotorNo { get; set; }
        public string Marka { get; set; }
        public int Model { get; set; }
        public string Renk { get; set; }
        public string Plaka { get; set; }
    }
}