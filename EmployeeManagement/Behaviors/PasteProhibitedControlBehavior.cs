using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmployeeManagement.Behaviors
{
    public class PasteProhibitedControlBehavior : Behavior<Control>
    {
        /// <summary>
        /// 貼り付けイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            // 貼り付け禁止のメッセージを表示
            Dispatcher.BeginInvoke(new Action(() => MessageBox.Show("貼り付けは使用しないで下さい")));
            e.CancelCommand();
        }

        /// <summary>
        /// ビヘイビアのアタッチ処理
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            DataObject.AddPastingHandler(AssociatedObject, AssociatedObject_PastingHandler);
        }

        /// <summary>
        /// ビヘイビアのデタッチ処理
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            DataObject.RemovePastingHandler(AssociatedObject, AssociatedObject_PastingHandler);
        }
    }
}
