using FigureAreaCalculator.Interfaces;

namespace FigureAreaCalculator.Figures;

public class Circle : IFigure
{
    private readonly double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }
    
    public double CalculateArea()
    {
        if (!IsCircleExist(_radius))
            throw new ArgumentException("Circle with this radius does not exists");
        return Math.PI * _radius * _radius;
    }

    private bool IsCircleExist(double radius) => radius >= 0;
}