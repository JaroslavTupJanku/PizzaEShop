using PizzaEShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Models
{
    public class Ingredient : INotifyPropertyChanged
    {
        private readonly IngredientType ingredient;
        private readonly int prize;
        private int count = 0;

        public int Prize => prize;
        public IngredientType IngredientType => ingredient;
        public int Count 
        { 
            get => count; 
            private set
            {
                count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            } 
        }

        public Ingredient(IngredientType ingredient, int prize)
        {
            this.ingredient = ingredient;
            this.prize = prize;
        }

        public void Add() => Count++;
        public void Remove() => Count--;
        public void Clear() => Count = 0;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
