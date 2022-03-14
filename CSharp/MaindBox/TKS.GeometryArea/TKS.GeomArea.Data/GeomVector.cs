using System;

namespace TKS.GeomArea.Data
{
    ///<summary>
    /// Базовый класс, для создания направленных векторов (длина и угол отклонения от начально точки)
    ///</summary>
    public sealed class GeomVector
    {
        private double _lenght;
        private double _angle;

        public GeomVector(double lenght, int angle)
        {
            Lenght = lenght;
            Angle = angle;
        }

        public double Lenght
        {
            get { return _lenght; }
            set
            {
                if (value > 0)
                {
                    _lenght = value;
                }
                else
                {
                    throw new Exception("Неверный ввод! Длина должна быть больше 0");
                }
            }
        }
        public double Angle
        {
            get { return _angle; }
            set
            {
                if (value >= 0 && value <= 360)
                {
                    _angle = value;
                }
                else
                {
                    throw new Exception("Неверный ввод! Угол должен быть > или = 0, и < или = 360");
                }
            }
        }
    }
}
