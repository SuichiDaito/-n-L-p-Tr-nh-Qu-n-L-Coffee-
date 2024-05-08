using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BLL
{
    public class KiemTraEmail
    {
        public bool IsValidEmail(string email)
        {
            // Biểu thức chính quy để kiểm tra định dạng email
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            // Kiểm tra so khớp với biểu thức chính quy
            Match match = Regex.Match(email, pattern);

            // Trả về true nếu có khớp hoàn toàn
            return match.Success;
        }
    }
}
