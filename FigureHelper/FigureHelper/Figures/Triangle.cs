using FigureAreaCalculator.Interfaces;

namespace FigureAreaCalculator.Figures;

public class Triangle : IFigure
{
    private readonly double _aSide;
    private readonly double _bSide;
    private readonly double _cSide;
    private readonly double[] _sortedSides;

    public Triangle(double aSide, double bSide, double cSide)
    {
        if (!IsTriangleExists(aSide, bSide, cSide))
            throw new ArgumentException("Triangle with these sides does not exists");
        _aSide = aSide;
        _bSide = bSide;
        _cSide = cSide;
        _sortedSides = new[] {aSide, bSide, cSide}.OrderBy(e => e).ToArray();
    }

    public double CalculateArea() => CalculateAreaUsingHeron(_aSide, _bSide, _cSide);

    private double CalculatePerimeter(double aSide, double bSide, double cSide) =>
        aSide + bSide + cSide;

    private double CalculateAreaUsingHeron(double aSide, double bSide, double cSide)
    {
        var halfPerimeter = CalculatePerimeter(aSide, bSide, cSide) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - aSide) * (halfPerimeter - bSide) * (halfPerimeter - cSide));
    }

    private bool IsTriangleExists(double aSide, double bSide, double cSide) =>
        aSide + bSide > cSide && aSide + cSide > bSide && bSide + cSide > aSide;

    public bool IsTriangleRight() =>
        Math.Abs(_sortedSides[0] * _sortedSides[0] +
                 _sortedSides[1] * _sortedSides[1] -
                 _sortedSides[2] * _sortedSides[2]) < double.Epsilon;
}