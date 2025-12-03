using System;

namespace FigurasGeometricas
{
    public class Circulo
    {
        private double radio;
        public Circulo(double radio) { this.radio = radio; }
        public double Radio { get { return radio; } set { radio = value; } }
        public double CalcularArea() { return Math.PI * radio * radio; }
        public double CalcularPerimetro() { return 2 * Math.PI * radio; }
    }

    public class Cuadrado
    {
        private double lado;
        public Cuadrado(double lado) { this.lado = lado; }
        public double Lado { get { return lado; } set { lado = value; } }
        public double CalcularArea() { return lado * lado; }
        public double CalcularPerimetro() { return 4 * lado; }
    }
}
