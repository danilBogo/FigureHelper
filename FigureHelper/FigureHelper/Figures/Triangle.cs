using FigureAreaCalculator.Interfaces;

namespace FigureAreaCalculator.Figures;

public class Triangle : IFigure
{
    private readonly double _aSide;
    private readonly double _bSide;
    private readonly double _cSide;

    public Triangle(double aSide, double bSide, double cSide)
    {
        if (!IsTriangleExist(aSide, bSide, cSide))
            throw new ArgumentException("Triangle with these sides does not exists");
        _aSide = aSide;
        _bSide = bSide;
        _cSide = cSide;
    }

    public double CalculateArea()
    {
        return IsTriangleRight(_aSide, _bSide, _cSide)
            ? CalculateAreaTriangleRight(_aSide, _bSide, _cSide)
            : CalculateAreaUsingHeron(_aSide, _bSide, _cSide);
    }

    private double CalculatePerimeter(double aSide, double bSide, double cSide) =>
        aSide + bSide + cSide;

    private double CalculateAreaUsingHeron(double aSide, double bSide, double cSide)
    {
        var halfPerimeter = CalculatePerimeter(aSide, bSide, cSide) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - aSide) * (halfPerimeter - bSide) * (halfPerimeter - cSide));
    }

    private double CalculateAreaTriangleRight(double aSide, double bSide, double cSide)
    {
        double leg1;
        double leg2;
        if (aSide < bSide)
        {
            leg1 = aSide;
            leg2 = bSide < cSide ? bSide : cSide;
        }
        else
        {
            leg1 = bSide;
            leg2 = aSide < cSide ? aSide : cSide;
        }

        return 0.5 * leg1 * leg2;
    }

    private bool IsTriangleExist(double aSide, double bSide, double cSide) =>
        aSide + bSide > cSide && aSide + cSide > bSide && bSide + cSide > aSide;

    private bool IsTriangleRight(double aSide, double bSide, double cSide) =>
        IsTriangleRightUsingPythagoreanTheorem(aSide, bSide, cSide) ||
        IsTriangleRightUsingPythagoreanTheorem(aSide, cSide, bSide) ||
        IsTriangleRightUsingPythagoreanTheorem(bSide, cSide, aSide);

    private bool IsTriangleRightUsingPythagoreanTheorem(double aSide, double bSide, double cSide,
        double epsilon = double.Epsilon) =>
        Math.Abs(aSide * aSide + bSide * bSide - cSide * cSide) < epsilon;
}