using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{

    public abstract class Car : Vehicle
    {
        protected PaintColor m_PaintColor = 0;
        protected int m_NumberOfDoors = 0;

        public Car()
        {
            //for Generics
        }
        public Car(PaintColor i_PaintColor, int i_NumberOfDoors)
        {
            this.m_PaintColor = i_PaintColor;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }
        public abstract override Dictionary<string, string> GetExpectation();

        public abstract override string ToString();

        protected string GetAllPaintColor()
        {
            int count = 1;
            string colors = string.Empty;
            foreach (PaintColor paintColor in Enum.GetValues(typeof(PaintColor)))
            {
                colors += string.Format("{0}. {1}\n", count, paintColor);
                count++;
            }
            return colors;
        }

        protected string GetAllDoors()
        {
            int count = 1;
            string colors = string.Empty;
            for (int i = 2; i < 6; i++)
            {
                colors += string.Format("{0}. {1} Doors\n", count, i);
                count++;
            }
            return colors;
        }

        public int NumberOfDoors
        {
            get { return this.m_NumberOfDoors; }
            set { this.m_NumberOfDoors = value; }
        }

        public PaintColor PaintColor
        {
            get { return this.m_PaintColor; }
            set { this.m_PaintColor = value; }
        }
    }
}
