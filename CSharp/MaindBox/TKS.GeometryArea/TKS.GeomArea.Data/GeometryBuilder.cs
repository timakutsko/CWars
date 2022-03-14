using System;
using System.Collections.Generic;

namespace TKS.GeomArea.Data
{
    ///<summary>
    /// Создание грани фигуры. Фигура состоит из набора векторов, в количестве n-1, где n - количество граней фигуры. 
    /// Для создания окружности, вектору необходимо задать 'вращение', путем указания угла = 360 градусам
    ///</summary>
    public sealed class GeometryBuilder
    {
        private List<GeomVector> _geomEntity;
        private string _name;

        public GeometryBuilder(List<GeomVector> edges)
        {
            GeomEntity = edges;
        }

        public List<GeomVector> GeomEntity
        {
            get { return _geomEntity; }
            set 
            { 
                if (value.Count > 1)
                {
                    _geomEntity = value; 
                }
                else if (value.Count == 1 && value[0].Angle == 360)
                {
                    _geomEntity = value;
                }
                else
                {
                    throw new Exception("Неверный ввод! Число граней может быть 1 если угол составляет 360. В остальных случаях - должно быть больше 1-й грани");
                }
            }
        }

        public void GetArea()
        {
            double area = 0;
            int edgesCount = _geomEntity.Count;
            switch (edgesCount)
            {
                case 1:
                    // S = pi⋅r^2/4
                    area = Math.PI * _geomEntity[0].Lenght * _geomEntity[0].Lenght / 4;
                    _name = "Круг";
                    break;
                case 2:
                    // S =​ 1/2⋅a⋅b⋅sinα
                    area = 0.5 * _geomEntity[0].Lenght * _geomEntity[1].Lenght * Math.Sin(AngleToRad(_geomEntity[1].Angle));
                    _name = "Треугольник";
                    break;
                case 3:
                    if (_geomEntity[0].Lenght != _geomEntity[2].Lenght)
                    {
                        // S =​ (a+b)/2⋅c⋅sinα
                        area = (_geomEntity[0].Lenght + _geomEntity[2].Lenght) / 2 * _geomEntity[1].Lenght * Math.Sin(AngleToRad(_geomEntity[1].Angle));
                        _name = "Трапеция";
                    }
                    else
                    {
                        // S =​ a⋅b⋅sinα
                        area = _geomEntity[0].Lenght * _geomEntity[1].Lenght * Math.Sin(AngleToRad(_geomEntity[1].Angle));
                        if ((_geomEntity[0].Lenght == _geomEntity[1].Lenght) && (_geomEntity[1].Angle == 90))
                        {
                            _name = "Квадрат";
                        }
                        else if (_geomEntity[1].Angle == 90)
                        {
                            _name = "Прямоугольник";
                        }
                        else
                        {
                            _name = "Параллелепипед";
                        }
                    }
                    break;
            }
            Console.WriteLine($"Фигура '{_name}' с площадью: {area}"); ;
        }

        private double AngleToRad(double angle)
        {
            return angle * Math.PI / 180;
        }
    }
}
