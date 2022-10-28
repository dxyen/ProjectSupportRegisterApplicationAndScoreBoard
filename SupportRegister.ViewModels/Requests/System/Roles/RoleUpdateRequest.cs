using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.System.Roles
{
    public class RoleUpdateRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập vào tên quyền")]
        [DataType(DataType.Text)]
        [Display(Name = "Role name:", Prompt = "Tên quyền...")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Description of Role:", Prompt = "Mô tả...")]
        public string Description { get; set; }
    }
}
