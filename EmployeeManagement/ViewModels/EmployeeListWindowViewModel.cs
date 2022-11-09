﻿using EmployeeManagement.Adapters;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
using EmployeeManagement.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeListWindowViewModel : BindableBase
    {
        /// <summary>
        /// 読込処理コマンド
        /// </summary>
        public DelegateCommand LoadCommand { get; set; }

        /// <summary>
        /// 追加処理コマンド
        /// </summary>
        public DelegateCommand AddCommand { get; set; }

        /// <summary>
        /// 編集処理コマンド
        /// </summary>
        public DelegateCommand EditCommand { get; set; }

        /// <summary>
        /// 削除処理コマンド
        /// </summary>
        public DelegateCommand RemoveCommand { get; set; }

        /// <summary>
        /// リスト出力処理コマンド
        /// </summary>
        public DelegateCommand ExportListCommand { get; set; }

        /// <summary>
        /// 従業員リスト
        /// </summary>
        public ObservableCollection<EmployeeListAdapter> EmployeeListAdapters { get; set; } = new ObservableCollection<EmployeeListAdapter>();

        /// <summary>
        /// 選択済の従業員リスト
        /// </summary>
        private EmployeeListAdapter _selectedEmployeeListAdapter = null;

        /// <summary>
        /// 部門モデル
        /// </summary>
        private IEnumerable<Department> _departments { get; set; }

        /// <summary>
        /// 選択された従業員リスト
        /// </summary>
        public EmployeeListAdapter SelectedEmployeeListAdapter
        {
            get { return this._selectedEmployeeListAdapter; }
            set
            {
                if (this._selectedEmployeeListAdapter != value)
                    SetProperty(ref this._selectedEmployeeListAdapter, value);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmployeeListWindowViewModel()
        {
            // コマンド生成
            this.CreateCommand();
        }

        /// <summary>
        /// コマンド生成
        /// </summary>
        private　void CreateCommand()
        {
            // コマンド設定
            // ロード時処理のコマンド
            this.LoadCommand = new DelegateCommand(
                () =>
                {
            this.Initialize();
        });

            // 追加処理のコマンド
            this.AddCommand = new DelegateCommand(
                () =>
                {
            this.AddEmployee();
        });

            // 編集処理のコマンド
            this.EditCommand = new DelegateCommand(
                () =>
                {
            this.EditEmployee();
        },
                () =>
                {
                    // ボタンが押せるかどうかを決める処理(trueが「押せる」)
                    return this.SelectedEmployeeListAdapter != null;
                }
                ).ObservesProperty(() => this.SelectedEmployeeListAdapter);

            // 削除処理のコマンド
            this.RemoveCommand = new DelegateCommand(
                () =>
                {
                    this.RemoveEmployee();
                }
                ,
                () =>
                {
                    // ボタンが押せるかどうかを決める処理(trueが「押せる」)
                    return this.SelectedEmployeeListAdapter != null;
                }).ObservesProperty(() => this.SelectedEmployeeListAdapter);

            // 名簿出力処理のコマンド
            this.ExportListCommand = new DelegateCommand(
                () =>
                {
                    this.ExportEmployeeList();
                });
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        private void Initialize()
        {
            this.EmployeeListAdapters.Clear();
            using (var context = new EmployeeManagementDbContext())
            {
                foreach (var employee in context.Employees)
                {
                    var department = context.Departments.Where(x => x.Uid == employee.DepartmentUid).FirstOrDefault();
                    var adapter = new EmployeeListAdapter(
                        employee,
                        department);
                    this.EmployeeListAdapters.Add(adapter);
                }

                this._departments = context.Departments.ToList();
            }
        }

        /// <summary>
        /// 追加処理
        /// </summary>
        private void AddEmployee()
        {
            var editVm = new EmployeeEditWindowViewModel(this._departments);
            var editVw = new EmployeeEditWindowView();
            editVw.Owner = Application.Current.MainWindow;
            editVw.DataContext = editVm;
            editVw.ShowDialog();

            if (editVm.IsResisted)
                this.Initialize();
        }

        /// <summary>
        /// 編集処理
        /// </summary>
        private void EditEmployee()
        {
            var editVm = new EmployeeEditWindowViewModel(
                this.SelectedEmployeeListAdapter.Employee,
                this._departments);
            var editVw = new EmployeeEditWindowView();
            editVw.Owner = Application.Current.MainWindow;
            editVw.DataContext = editVm;
            editVw.ShowDialog();

            if (editVm.IsResisted)
                this.Initialize();
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        private void RemoveEmployee()
        {
            using (var context = new EmployeeManagementDbContext())
            {
                var removeEmployee = context.Employees.Where(x => x.Uid == this.SelectedEmployeeListAdapter.Employee.Uid).FirstOrDefault();
                context.Employees.Remove(removeEmployee);
                context.SaveChanges();
            }

            this.Initialize();
        }

        /// <summary>
        /// 出力処理
        /// </summary>
        private void ExportEmployeeList()
        { }
    }
}
