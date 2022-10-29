using FigureAreaCalculator.Interfaces;

namespace FigureAreaCalculator.Figures;

public class Circle : IFigure
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (!IsCircleExist(radius))
            throw new ArgumentException("Circle with this radius does not exists");
        _radius = radius;
    }

    public double CalculateArea() => Math.PI * _radius * _radius;

    private bool IsCircleExist(double radius) => radius >= 0;
}