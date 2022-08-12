using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CaliburnPlayGround.CustomControls
{
    public class CustomListBox : ListBox
    {

        public string SelectedItemsStringFormat
        {
            get { return (string)GetValue(SelectedItemsStringFormatProperty); }
            set { SetValue(SelectedItemsStringFormatProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsStringFormatProperty =
            DependencyProperty.Register("SelectedItemsStringFormat", typeof(string), typeof(CustomListBox), new PropertyMetadata(""));


        public bool GenerateSelectedItemsStringFormat
        {
            get { return (bool)GetValue(GenerateSelectedItemsStringFormatProperty); }
            set { SetValue(GenerateSelectedItemsStringFormatProperty, value); }
        }

        public static readonly DependencyProperty GenerateSelectedItemsStringFormatProperty =
            DependencyProperty.Register("GenerateSelectedItemsStringFormat", typeof(bool), typeof(CustomListBox), new PropertyMetadata(false,OnGenerateSelectedItemsStringFormat));



        public string ItemSeperator
        {
            get { return (string)GetValue(ItemSeperatorProperty); }
            set { SetValue(ItemSeperatorProperty, value); }
        }

        public static readonly DependencyProperty ItemSeperatorProperty =
            DependencyProperty.Register("ItemSeperator", typeof(string), typeof(CustomListBox), new PropertyMetadata(";",OnItemSeparatorChanged));

        [Bindable(true,BindingDirection.OneWay)]
        public List<string> SelectedItems
        {
            get { return (List<string>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(List<string>), typeof(CustomListBox), new PropertyMetadata(null));






        private static void OnItemSeparatorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is ListBox lb)
            {
                lb.SetValue(ItemSeperatorProperty, e.NewValue.ToString());
            }
        }




        private static void OnGenerateSelectedItemsStringFormat(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is ListBox lb)
            {
                lb.SelectionChanged -= Lb_SelectionChanged;
                lb.SelectionChanged += Lb_SelectionChanged;
            }
        }

        private static void Lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(sender is ListBox lb)
            {
                string result = string.Empty;
                List<string> selectedItems = new();
                foreach (var item in lb.SelectedItems)
                {
                    string selectedItem = item.GetType().GetProperty(lb.DisplayMemberPath).GetValue(item, null).ToString();
                    result += $"{selectedItem} {lb.GetValue(ItemSeperatorProperty)} ";
                    selectedItems.Add(selectedItem);
                }
                lb.SetValue(SelectedItemsProperty, selectedItems);
                lb.SetValue(SelectedItemsStringFormatProperty, result);
            }
        }



       



    }
}
