namespace Business.Responses.Car;

public class DeleteCarResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedAt { get; set; }
}