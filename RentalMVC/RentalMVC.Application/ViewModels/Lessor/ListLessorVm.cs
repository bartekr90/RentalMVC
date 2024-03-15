namespace RentalMVC.Application.ViewModels.Lessor;

public class ListLessorVm
{
    public List<LessorForListVm> Lessors { get; set; } = new List<LessorForListVm>();
    public int Count { get; set; }
}
