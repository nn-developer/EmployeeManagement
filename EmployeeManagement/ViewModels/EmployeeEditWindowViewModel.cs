using EmployeeManagement.Constants;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeEditWindowViewModel : BindableBase
    {
        /// <summary>
        /// 読込処理コマンド
        /// </summary>
        public DelegateCommand LoadCommand { get; set; }

        /// <summary>
        /// 登録処理コマンド
        /// </summary>
        public DelegateCommand<Window> ResistCommand { get; set; }

        /// <summary>
        /// 編集処理コマンド
        /// </summary>
        public DelegateCommand<Window> CancelCommand { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        private string _FamilyName = string.Empty;

        /// <summary>
        /// 名字
        /// </summary>
        public string FamilyName
        {
            get { return this._FamilyName; }
            set
            {
                if (this._FamilyName != value)
                    SetProperty(ref this._FamilyName, value);
            }
        }

        /// <summary>
        /// 名前
        /// </summary>
        private string _FirstName = string.Empty;

        /// <summary>
        /// 名前
        /// </summary>
        public string FirstName
        {
            get { return this._FirstName; }
            set
            {
                if (this._FirstName != value)
                    SetProperty(ref this._FirstName, value);
            }
        }

        /// <summary>
        /// 生年月日
        /// </summary>
        private DateTime _Birthday = Employee.DEFAULT_BIRTHDAY;

        /// <summary>
        /// 生年月日
        /// </summary>
        public DateTime Birthday
        {
            get { return this._Birthday; }
            set
            {
                if (this._Birthday != value)
                    SetProperty(ref this._Birthday, value);
            }
        }

        /// <summary>
        /// 性別
        /// </summary>
        private Gender _Gender = Gender.Other;

        /// <summary>
        /// 性別
        /// </summary>
        public Gender Gender
        {
            get { return this._Gender; }
            set
            {
                if (this._Gender != value)
                    SetProperty(ref this._Gender, value);
            }
        }

        /// <summary>
        /// メールアドレス
        /// </summary>
        private string _MailAddress = string.Empty;

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string MailAddress
        {
            get { return this._MailAddress; }
            set
            {
                if (this._MailAddress != value)
                    SetProperty(ref this._MailAddress, value);
            }
        }

        /// <summary>
        /// 選択された部門Uid
        /// </summary>
        private Guid _SelectedDepartmentUid = Guid.Empty;

        /// <summary>
        /// 選択された部門Uid
        /// </summary>
        public Guid SelectedDepartmentUid
        {
            get { return this._SelectedDepartmentUid; }
            set
            {
                if (this._SelectedDepartmentUid != value)
                    SetProperty(ref this._SelectedDepartmentUid, value);
            }
        }

        /// <summary>
        /// 備考
        /// </summary>
        private string _Remark = string.Empty;

        /// <summary>
        /// 備考
        /// </summary>
        public string Remark
        {
            get { return this._Remark; }
            set
            {
                if (this._Remark != value)
                    SetProperty(ref this._Remark, value);
            }
        }

        /// <summary>
        /// 部門
        /// </summary>
        public ObservableCollection<Department> Departments { get; set; }

        /// <summary>
        /// 登録する従業員
        /// </summary>
        private Employee _employee = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="departments">部門</param>
        public EmployeeEditWindowViewModel(IEnumerable<Department> departments)
        {
            this.Departments = new ObservableCollection<Department>(departments);
            this.CreateCommand();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="employee">登録対象の従業員</param>
        /// <param name="departments">部門</param>
        public EmployeeEditWindowViewModel(
            Employee employee,
            IEnumerable<Department> departments)
        {
            this._employee = employee;
            this.Departments = new ObservableCollection<Department>(departments);
            this.CreateCommand();
        }

        /// <summary>
        /// 登録処理の可否
        /// </summary>
        public bool IsResisted { get; set; } = false;

        /// <summary>
        /// コマンド設定
        /// </summary>
        private void CreateCommand()
        {
            // ロード時処理のコマンド
            this.LoadCommand = new DelegateCommand(
                () =>
                {
                    if (this._employee == null)
                    {
                        this._employee = new Employee();
                    }
                    else
                    {
                        // 編集対象の値を設定
                        this.FamilyName = this._employee.FamilyName;
                        this.FirstName = this._employee.FirstName;
                        this.Birthday = this._employee.Birthday;
                        this.Gender = (Gender)this._employee.Gender;
                        this.MailAddress = this._employee.MailAddress;
                        this.SelectedDepartmentUid = this._employee.DepartmentUid;
                        this.Remark = this._employee.Remark;
                    }
                });

            // 登録処理のコマンド
            this.ResistCommand = new DelegateCommand<Window>(
                x =>
                {
                    this.ResistEmployee();
                    x.Close();
                },
                x =>
                {
                    // ボタンが押せるかどうかを決める処理(trueが「押せる」)
                    return true;
                }
                ).ObservesProperty(() => this.Remark);

            // キャンセル処理のコマンド
            this.CancelCommand = new DelegateCommand<Window>(
                x =>
                {
                    x.Close();
                });
        }

        /// <summary>
        /// 登録処理
        /// </summary>
        private void ResistEmployee()
        {
            this._employee.FamilyName = this.FamilyName;
            this._employee.FirstName = this.FirstName;
            this._employee.Birthday = this.Birthday;
            this._employee.Gender = (int)this.Gender;
            this._employee.MailAddress = this.MailAddress;
            this._employee.DepartmentUid = this.SelectedDepartmentUid;
            this._employee.Remark = this.Remark;
            this._employee.UpdateAt = DateTime.Now;

            using (var context = new EmployeeManagementDbContext())
            {
                context.Employees.AddOrUpdate(this._employee);
                context.SaveChanges();
            }

            this.IsResisted = true;
        }
    }
}
