namespace RentalMVC.Application.ViewModels.Lessor;

public class NewLessorVm 
{
    public  string? UserId { get; set; }
    public  string? Name { get; set; }
    public int UserDetailId { get; set; }
    public bool CanLaunchRental { get; set; }
}
