namespace RentalMVC.Application.ViewModels.ContactData;

public class ListContactDataVm
{
    public List<ContactDataForListVm> ContactDatas { get; set; } = new List<ContactDataForListVm>();
    public int Count { get; set; }
}