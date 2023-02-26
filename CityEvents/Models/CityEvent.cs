using Avalonia.Controls.Primitives;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Models
{
    public class CityEvent : AbstractNotifyPropertyChanged
    {
        private string header = "";
        private string description = "Описание отсутствует";
        private string image = "";
        private string date = "";
        private CategoryItem category;
        private decimal price = 0;

        private string checkStringLenght(string? str)
        {
            if (str != "")
            {
                if (str.Length > 135)
                {
                    int len = str.Length - 133;
                    str = str[..^len];
                    str += "...";
                }
            }
            return str;
        }
        public string Header
        {
            get => header;
            set => SetAndRaise(ref header, value);
        }

        public string Description
        {
            get => description;
            set {
                SetAndRaise(ref description, checkStringLenght(value));
            }
        }

        public string Image
        {
            get => image;
            set => SetAndRaise(ref image, value);
        }

        public string Date
        {
            get => date;
            set => SetAndRaise(ref date, value);
        }

        public CategoryItem Category
        {
            get => category;
            set => SetAndRaise(ref category, value);
        }

        public decimal Price
        {
            get => price;
            set => SetAndRaise(ref price, value);
        }
    }
}
