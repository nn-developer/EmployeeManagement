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
    public class MoveFocusEnterKeyControlBehavior : Behavior<Control>
    {
        /// <summary>
        /// エンターキーによるフォーカス遷移の活性値
        /// </summary>
        public bool IsEnableEnterKeyMoveFocus { get; set; } = true;

        /// <summary>
        /// キーダウンイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
        {
            // エンターキー押下時にフォーカス遷移
            if ((Keyboard.Modifiers == ModifierKeys.None) && (e.Key == Key.Enter))
            {
                (AssociatedObject as UIElement)?.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

                e.Handled = true;
            }
            else if ((Keyboard.Modifiers == ModifierKeys.Shift) && (e.Key == Key.Enter))
            {
                (AssociatedObject as UIElement)?.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));

                e.Handled = true;
            }
        }

        /// <summary>
        /// ビヘイビアのアタッチ処理
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.KeyDown += AssociatedObject_KeyDown;
        }

        /// <summary>
        /// ビヘイビアのデタッチ処理
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
        }
    }
}
