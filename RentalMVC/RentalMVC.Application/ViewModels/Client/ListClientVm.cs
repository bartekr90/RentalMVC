namespace RentalMVC.Application.ViewModels.Client;

public class ListClientVm
{
    public List<ClientForListVm> Clients { get; set; } = new List<ClientForListVm>();
    public int Count { get; set; }
}
