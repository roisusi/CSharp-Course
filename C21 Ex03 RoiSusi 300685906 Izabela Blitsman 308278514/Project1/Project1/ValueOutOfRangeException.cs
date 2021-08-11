using System;

namespace Project1
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;

        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        private float m_MinValue;

        public float MinValue
        {
            get { return m_MinValue; }
        }

        public ValueOutOfRangeException(
            Exception i_InnerException,
            float i_MaxValue,
            float i_MinValue)
            : base(string.Format("An value out of range error occured - the range should be bettween {0} and {1}", i_MinValue, i_MaxValue),
                  i_InnerException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;

        }
    }
}
