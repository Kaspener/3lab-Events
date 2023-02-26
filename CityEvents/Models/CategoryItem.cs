using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvents.Models
{
    public class CategoryItem
    {
        public bool[] categories = new bool[9];

        public CategoryItem() 
        {
            for (int i = 0; i < 9; i++)
            {
                categories[i] = false;
            }
        }

        public bool ForChildren
        {
            get => categories[0];
            set => categories[0] = value;
        }

        public bool Sport
        {
            get => categories[1];
            set => categories[1] = value;
        }

        public bool Culture
        {
            get => categories[2];
            set => categories[2] = value;
        }

        public bool Excursions
        {
            get => categories[3];
            set => categories[3] = value;
        }

        public bool Lifestyle
        {
            get => categories[4];
            set => categories[4] = value;
        }

        public bool Party
        {
            get => categories[5];
            set => categories[5] = value;
        }

        public bool Education
        {
            get => categories[6];
            set => categories[6] = value;
        }

        public bool Online
        {
            get => categories[7];
            set => categories[7] = value;
        }

        public bool Show
        {
            get => categories[8];
            set => categories[8] = value;
        }
    }
}
