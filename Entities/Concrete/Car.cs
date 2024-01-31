
using Core.Entities;

namespace Entities.Concrete;

public class Car :Entity<int>
{
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public bool CarState { get; set; }
    public decimal Kilometer { get; set; }
    public string Plate { get; set; }
    public Car()
    {
        
    }
    public Car(bool carState, int colorId,int modelId,string plate,decimal kilometer)
    {
        CarState = carState;
        Kilometer = kilometer;
        CarState = carState;
        ColorId = colorId;
        ModelId = modelId;
        Plate = plate;
    }
}
