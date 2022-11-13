using PizzaEShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Models
{
    public class IngredientCounter : INotifyPropertyChanged
    {
        private readonly IngredientType ingredient;
        private int count = 0;

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

        public IngredientCounter(IngredientType ingredient)
        {
            this.ingredient = ingredient;
        }

        public void Add() => Count++;
        public void Clear() => Count = 0;

        public void Remove()
        {
            if (Count != 0) { Count--; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
