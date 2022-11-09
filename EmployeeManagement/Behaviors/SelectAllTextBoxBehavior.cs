using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EmployeeManagement.Behaviors
{
    public class SelectAllTextBoxBehavior : Behavior<TextBox>
    {
        /// <summary>
        /// フォーカス取得時の背景色
        /// </summary>
        public SolidColorBrush BackBrushOnGotFocus { get; set; }

        /// <summary>
        /// フォーカス喪失時の背景色
        /// </summary>

        public SolidColorBrush BackBrushOnLostFocus { get; set; }

        /// <summary>
        /// 規定の背景色
        /// </summary>
        private Brush _defaultBackBrush = null;

        /// <summary>
        /// フォーカス取得時の処理
        /// </summary>
        private void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            AssociatedObject.SelectAll();
        }

        /// <summary>
        /// ビヘイビアのアタッチ処理
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.GotFocus += AssociatedObject_GotFocus;
        }

        /// <summary>
        /// ビヘイビアのデタッチ処理
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
        }
    }
}
