namespace RentalMVC.Application.ViewModels.UserDetail;

public class ListUserDetailVm 
{
    public List<UserDetailForListVm> UserDetails { get; set; } = new List<UserDetailForListVm>();
    public int Count { get; set; }
}