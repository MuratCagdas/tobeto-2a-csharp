
using Core.Entities;

namespace Entities.Concrete;

public class Car :Entity<int>
{
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public bool CarState { get; set; }
    public decimal Kilometer { get; set; }
    public DateTime ModelYear { get; set; }
    public string Plate { get; set; }
}
