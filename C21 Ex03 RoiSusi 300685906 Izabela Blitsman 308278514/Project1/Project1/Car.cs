using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{

    public abstract class Car : Vehicle
    {
        protected PaintColor m_PaintColor = 0;
        protected int m_NumberOfDoors = 0;
        protected readonly int r_MinDoorsNumber = 2;
        protected readonly int r_MaxDoorsNumber = 5;

        public Car()
        {
            //for Generics
        }
        public Car(string i_Model, string i_NumberLicense, float i_Fuel ,PaintColor i_PaintColor, int i_NumberOfDoors) : 
            base(i_Model, i_NumberLicense, i_Fuel)
        {
            this.m_PaintColor = i_PaintColor;

            if (i_NumberOfDoors <= r_MaxDoorsNumber && i_NumberOfDoors >= r_MinDoorsNumber)
            {
                this.m_NumberOfDoors = i_NumberOfDoors;
            }
            
            else 
            {
                throw new ArgumentException("Error occured - Invalid number of doors been entered");
            }   
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
            for (int i = r_MinDoorsNumber; i <= r_MaxDoorsNumber; i++)
            {
                colors += string.Format("{0} Doors\n", i);
                count++;
            }
            return colors;
        }

        public int NumberOfDoors
        {
            get { return this.m_NumberOfDoors; }
        }

        public PaintColor PaintColor
        {
            get { return this.m_PaintColor; }
            set { this.m_PaintColor = value; }
        }
    }
}
