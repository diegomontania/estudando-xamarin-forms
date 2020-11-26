﻿using MeuPrimeiroAppXamarin.Classes;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class ListagemView : ContentPage
    {
        //cria propriedade que receberá a lista de veiculos
        public List<Veiculo> Veiculos { get; set; }

        public string TituloInicial { get; set; }

        public ListagemView()
        {
            InitializeComponent();

            this.TituloInicial = "Test Drive - Início";

            //popula lista com valores
            Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Ano = 1994, Preco = 60000},
                new Veiculo { Nome = "Azera V7", Ano = 1996, Preco = 70000},
                new Veiculo { Nome = "Azera V8", Ano = 1999, Preco = 80000},
                new Veiculo { Nome = "Azera V9", Ano = 2000, Preco = 90000}
            };

            //PS: Os valores definidos aqui, são associados aos componentes xaml
            //diretamente no xaml, pelo "Binding". Porém é necessário passar o contexto de binding.
            //No caso atual, esta mesma classe
            this.BindingContext = this;
        }

        private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item; /*convertendo um objeto genérico para um objeto veiculo*/

            //coloca uma nova página em cima da página atual fazendo uma 'pilha de navegação'
            Navigation.PushAsync(new DetalheView(veiculo)); //chama a próxima página
        }
    }
}
