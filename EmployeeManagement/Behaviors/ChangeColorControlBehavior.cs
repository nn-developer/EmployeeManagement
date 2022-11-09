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
    public class ChangeColorControlBehavior : Behavior<Control>
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
            if (this.BackBrushOnLostFocus == null)
                this._defaultBackBrush = AssociatedObject.Background;

            AssociatedObject.Background = BackBrushOnGotFocus;
        }

        /// <summary>
        /// フォーカス喪失時の処理
        /// </summary>
        private void AssociatedObject_LostFocus(object sender, RoutedEventArgs e)
        {
            // 喪失時の背景色が設定されているかを判定
            if (this.BackBrushOnLostFocus == null)
            {
                // 設定されている背景色を設定
                AssociatedObject.Background = this._defaultBackBrush;
            }
            else
            {
                // 既定の背景色を設定
                AssociatedObject.Background = BackBrushOnLostFocus;
            }
        }

        /// <summary>
        /// ビヘイビアのアタッチ処理
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.GotFocus += AssociatedObject_GotFocus;

            AssociatedObject.LostFocus += AssociatedObject_LostFocus;
        }

        /// <summary>
        /// ビヘイビアのデタッチ処理
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.GotFocus -= AssociatedObject_GotFocus;

            AssociatedObject.LostFocus -= AssociatedObject_LostFocus;
        }
    }
}
