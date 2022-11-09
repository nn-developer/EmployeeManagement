using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Constants;
using EmployeeManagement.Models;

namespace EmployeeManagement.Adapters
{
    public class EmployeeListAdapter
    {
        /// <summary>
        /// 従業員
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// 部門
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="employee">従業員</param>
        /// <param name="department">部門</param>
        public EmployeeListAdapter(
            Employee employee,
            Department department)
        {
            this.Employee = employee;
            this.Department = department;
        }

        /// <summary>
        /// 氏名
        /// </summary>
        public string EmployeeName
        {
            get { return $"{this.Employee.FamilyName} {this.Employee.FirstName}"; }
        }

        /// <summary>
        /// 年齢
        /// </summary>
        public int Age
        {
            get
            {
                return DateTime.Today.Year - this.Employee.Birthday.Year;
            }
        }

        /// <summary>
        /// 性別
        /// </summary>
        public Gender Gender
        {
            get
            {
                if (!Enum.IsDefined(typeof(Gender), this.Employee.Gender))
                    return Gender.Other;

                return (Gender)this.Employee.Gender;
            }

        }

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string MailAddress
        {
            get
            {
                return this.Employee.MailAddress;
            }
        }

        /// <summary>
        /// 部門名
        /// </summary>
        public string DepartmentName
        {
            get
            {
                return this.Department.Name;
            }
        }

        /// <summary>
        /// 備考
        /// </summary>
        public string Remark
        {
            get
            {
                return this.Employee.Remark;
            }
        }
    }
}
