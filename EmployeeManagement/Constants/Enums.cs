using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Constants
{
    public enum Gender
    {
        Male = 0,
        Female,
        Other,
    }

    public enum EditMode
    {
        Add,
        Edit,
    }

    public static class GenderExtensions
    {
        public static string GetName(this Gender value)
        {
            switch (value)
            {
                case Gender.Male:
                    {
                        return "男性";
                    }
                default:
                    {
                        return "女性";
                    }
            }
        }
    }
}
