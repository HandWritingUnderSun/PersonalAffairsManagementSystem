using System.ComponentModel.DataAnnotations;

namespace PersonalAffairsManagementSystem.Models
{
    public class S_Constant
    {
        [Key]
        public string CName { get; set; }

        public string CValue { get; set; }

        public string CDscp { get; set; }
    }
}
