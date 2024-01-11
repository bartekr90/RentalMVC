using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMVC.Application.ViewModels.User;

public class UserViewModel
{
    public required string RoleId { get; set; }
    public required string UserId { get; set; }
    public required string RoleName { get; set; }
    public bool IsSelected { get; set; }
}
