﻿using MeuPrimeiroAppXamarin.Classes;
using MeuPrimeiroAppXamarin.Models;
using MeuPrimeiroAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MeuPrimeiroAppXamarin.Views
{
    public partial class ListagemView : ContentPage
    {
        public ListagemView()
        {
            InitializeComponent();

            //fazendo "Binding" das informações vindas do xaml, passando o contexto de binding para a classe.
            this.BindingContext = new ListagemViewModel();
        }

        //Ao abrir a view capture a mensagem
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Assinando a mensagem
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", 
                //funcao anonima que recebe e trata a mensagem e faz a execucao para a próxima pagina
                (msg) =>
                { 
                    Navigation.PushAsync(new DetalheView(msg)); //chama a próxima página
                });
        }

        //cancelando assinatura : evita criar multiplas mensagem do mesmo evento
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
