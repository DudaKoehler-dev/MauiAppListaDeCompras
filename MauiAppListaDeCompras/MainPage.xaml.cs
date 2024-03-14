using System.Collections.ObjectModel;
using MauiAppListaDeCompras.Models;

namespace MauiAppListaDeCompras
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Produto> Lista_produtos = new ObservableCollection<Produto>();
        public MainPage()
        {
            InitializeComponent();
            lst_produtos.ItemsSource = Lista_produtos;
        }


        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {
            double soma = Lista_produtos.Sum(i => (i.Preco * i.Quantidade));
            string msg = $"O total é{soma:C}";
            DisplayAlert("Somatória", msg, "Fechar");
        }
        protected override void OnAppearing()
        {
            if (Lista_produtos.Count == 0)
            {
                Task.Run(async () =>
                {
                    List<Produto> tmp = await App.Db.GetAll();
                    foreach (Produto p in tmp)
                    {
                        Lista_produtos.Add(p);
                    }
                });
            }
        }

        private void ToolbarItem_Clicked_Add(object sender, EventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue;
            Lista_produtos.Clear();
            Task.Run(async () =>
            {
                List<Produto> tmp = await App.Db.Search(q);
                foreach (Produto p in tmp)
                {
                    Lista_produtos.Add(p);
                }
            });
        }

        private void ref_carregando_Refreshing(object sender, EventArgs e)
        {
            Lista_produtos.Clear();
            Task.Run(async () =>
            {
                List<Produto> tmp = await App.Db.GetAll();
                foreach (Produto p in tmp)
                {
                    Lista_produtos.Add(p);
                }
            });
            ref_carregando.IsRefreshing = false;

        }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void MenuItem_Clicked_Remover(object sender, EventArgs e)
    {

    }
}

}
