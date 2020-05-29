using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Visual.VisualComponents
{
    public class CustomListView : ListView
    {
        public static readonly BindableProperty ItemClickCommandProperty = BindableProperty.Create(nameof(ItemClickCommand),
                                                                                             typeof(ICommand), typeof(CustomListView),
                                                                                             null);

        public CustomListView()
        {
            this.ItemTapped += OnItemTapped;
        }

        public ICommand ItemClickCommand
        {
            get 
            {
                return (ICommand)this.GetValue(ItemClickCommandProperty);
            }
            set
            {
                this.SetValue(ItemClickCommandProperty, value);
            }   
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item != null)
            {
                ItemClickCommand?.Execute(e.Item);
                SelectedItem = null;
            }
        }
    }
}
