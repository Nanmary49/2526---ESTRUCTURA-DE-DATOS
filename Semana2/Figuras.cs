using System;

public class Circulo
{
    private double radio;

    public double Radio
    {
        get => radio;
        set
        {
            if (value <= 0)
                throw new ArgumentException("El radio debe ser mayor que cero.");
            radio = value;
        }
    }

    public Circulo(double radio)
    {
        Radio = radio;
    }

    public double CalcularArea()
    {
        return Math.PI * Radio * Radio;
    }

    public double CalcularPerimetro()
    {
        return 2 * Math.PI * Radio;
    }

    public override string ToString()
    {
        return $"Círculo - Radio: {Radio}, Área: {CalcularArea():F2}, Perímetro: {CalcularPerimetro():F2}";
    }
}

public class Cuadrado
{
    private double lado;

    public double Lado
    {
        get => lado;
        set
        {
            if (value <= 0)
                throw new ArgumentException("El lado debe ser mayor que cero.");
            lado = value;
        }
    }

    public Cuadrado(double lado)
    {
        Lado = lado;
    }

    public double CalcularArea()
    {
        return Lado * Lado;
    }

    public double CalcularPerimetro()
    {
        return 4 * Lado;
    }

    public override string ToString()
    {
        return $"Cuadrado - Lado: {Lado}, Área: {CalcularArea():F2}, Perímetro: {CalcularPerimetro():F2}";
    }
}

public class Rectangulo
{
    private double baseRect;
    private double altura;

    public double Base
    {
        get => baseRect;
        set
        {
            if (value <= 0)
                throw new ArgumentException("La base debe ser mayor que cero.");
            baseRect = value;
        }
    }

    public double Altura
    {
        get => altura;
        set
        {
            if (value <= 0)
                throw new ArgumentException("La altura debe ser mayor que cero.");
            altura = value;
        }
    }

    public Rectangulo(double baseRect, double altura)
    {
        Base = baseRect;
        Altura = altura;
    }

    public double CalcularArea()
    {
        return Base * Altura;
    }

    public double CalcularPerimetro()
    {
        return 2 * (Base + Altura);
    }

    public override string ToString()
    {
        return $"Rectángulo - Base: {Base}, Altura: {Altura}, Área: {CalcularArea():F2}, Perímetro: {CalcularPerimetro():F2}";
    }
}

