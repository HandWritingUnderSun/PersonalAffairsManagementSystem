using System.ComponentModel.DataAnnotations;

namespace PersonalAffairsManagementSystem.Models
{
    public class UserLogon
    {
        private string _logonName;

        private string _logonPassword;

        [Required(ErrorMessage = "用户名不能为空!")]
        [Display(Name = "用户名")]
        public string LogonName { get => _logonName; set => _logonName = value; }

        [Required(ErrorMessage = "密码不能为空!")]
        [Display(Name = "密码")]
        public string LogonPassword { get => _logonPassword; set => _logonPassword = value; }
    }
}
