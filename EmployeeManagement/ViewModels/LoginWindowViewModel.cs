using EmployeeManagement.Adapters;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagement.ViewModels
{
    public class LoginWindowViewModel : BindableBase
    {
        public DelegateCommand<Window> LoginCommand { get; set; }
        public DelegateCommand<Window> CancelCommand { get; set; }

        private string _userId = string.Empty;

        [StringLength(50, ErrorMessage = "ユーザーIDは {1} 文字以内で入力してください")]
        [RegularExpression("[0-9A-Z]+", ErrorMessage = "ユーザーIDは半角数字・英字大文字で入力してください")]
        public string UserId
        {
            get { return this._userId; }
            set
            {
                if (this._userId != value)
                    this.SetProperty(ref this._userId, value);
            }
        }

        private string _password = string.Empty;

        [StringLength(50, ErrorMessage = "パスワードは {1} 文字以内で入力してください")]
        [RegularExpression("[0-9A-Z]+", ErrorMessage = "パスワードIDは半角数字・英字大文字で入力してください")]
        public string Password
        {
            get { return this._password; }
            set
            {
                if (this._password != value)
                    this.SetProperty(ref this._password, value);
            }
        }

        public bool IsAuthenticated { get; private set; }

        public LoginWindowViewModel()
        {
            this.IsAuthenticated = false;

            // コマンド設定
            // ログイン時処理のコマンド
            this.LoginCommand = new DelegateCommand<Window>(
                x =>
                {
                    this.Login();
                    if (this.IsAuthenticated)
                        x.Close();
                },
                x =>
                {
                    return !string.IsNullOrWhiteSpace(this.UserId) && !string.IsNullOrWhiteSpace(this.Password);
                })
                .ObservesProperty(() => this.UserId)
                .ObservesProperty(() => this.Password);

            // キャンセル処理のコマンド
            this.CancelCommand = new DelegateCommand<Window>(
                x =>
                {
                    x.Close();
                });
        }

        private void Login()
        {
            using (var context = new EmployeeManagementDbContext())
            {
                foreach (var user in context.Users)
                {
                    this.IsAuthenticated = (user.UserId == this.UserId && user.Password == this.Password);
                    if (this.IsAuthenticated)
                        break;
                }
            }
        }
    }
}
