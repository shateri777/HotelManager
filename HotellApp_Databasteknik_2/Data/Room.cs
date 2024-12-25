using System.ComponentModel.DataAnnotations.Schema;

namespace HotellApp_Databasteknik_2.Data
{
    public class Room
    {
        public int RoomId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public RoomType RoomType { get; set; }
        public int PricePerNight { get; set; }
        public int Bed { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public enum RoomType
    {
        Single = 1,
        Double = 2
    }
}
