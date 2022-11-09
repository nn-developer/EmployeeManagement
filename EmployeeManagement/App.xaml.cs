using EmployeeManagement.ViewModels;
using EmployeeManagement.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagement
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// アプリケーションのスタートポイント
        /// </summary>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // ログイン画面が閉じられた時にアプリケーションが終了しないよう、OnExplicitShutdownを設定
            var tmp = Application.Current.ShutdownMode;
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            // ログイン画面を表示し、ユーザ認証を行う
            var loginVw = new LoginWindowView();
            loginVw.ShowDialog();

            // ユーザが認証された場合のみ従業員リスト画面をメイン画面に設定して表示
            Application.Current.ShutdownMode = tmp;
            var loginVm = loginVw.DataContext as LoginWindowViewModel;
            if (loginVm?.IsAuthenticated ?? false)
            {
                // 従業
                this.MainWindow = new EmployeeListWindowView();
                this.MainWindow.ShowDialog();
            }
            else
            {
                // ログインがキャンセルされた場合は明示的にアプリケーションを終了
                this.Shutdown();
            }
        }
    }
}
