namespace Business.Responses.Transmission;

public class DeleteTransmissionResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedAt { get; set; }
}