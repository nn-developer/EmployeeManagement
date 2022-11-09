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
        public static readonly DependencyProperty FocusedBackgroundProperty = 
            DependencyProperty.Register(
                "FocusedBackground",
                typeof(Brush),
                typeof(ChangeColorControlBehavior));

        /// <summary>
        /// フォーカス取得時の背景色
        /// </summary>
        public Brush FocusedBackground
        {
            get { return (Brush)GetValue(FocusedBackgroundProperty); }
            set { SetValue(FocusedBackgroundProperty, value); }
        }

        public static readonly DependencyProperty UnfocusedBackgroundProperty =
            DependencyProperty.Register(
                "UnfocusedBackground",
                typeof(Brush),
                typeof(ChangeColorControlBehavior));

        /// <summary>
        /// フォーカス喪失時の背景色
        /// </summary>
        public Brush UnfocusedBackground
        {
            get { return (Brush)GetValue(UnfocusedBackgroundProperty); }
            set { SetValue(UnfocusedBackgroundProperty, value); }
        }

        /// <summary>
        /// 規定の背景色
        /// </summary>
        private Brush _defaultBackBrush = null;

        /// <summary>
        /// フォーカス取得時の処理
        /// </summary>
        private void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.UnfocusedBackground == null)
                this._defaultBackBrush = AssociatedObject.Background;

            AssociatedObject.Background = FocusedBackground;
        }

        /// <summary>
        /// フォーカス喪失時の処理
        /// </summary>
        private void AssociatedObject_LostFocus(object sender, RoutedEventArgs e)
        {
            // 喪失時の背景色が設定されているかを判定
            if (this.UnfocusedBackground == null)
            {
                // 設定されている背景色を設定
                AssociatedObject.Background = this._defaultBackBrush;
            }
            else
            {
                // 既定の背景色を設定
                AssociatedObject.Background = UnfocusedBackground;
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
