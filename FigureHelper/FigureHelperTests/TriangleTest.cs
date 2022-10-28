using FigureAreaCalculator.Figures;

namespace FigureHelperTests;

public class TriangleTest
{
    [Theory]
    [MemberData(nameof(TriangleZeroSideData))]
    public void TriangleZeroSideTest(double aSide, double bSide, double cSide)
    {
        //arrange/act/assert
        Assert.Throws<ArgumentException>(() => new Triangle(aSide, bSide, cSide));
    }

    [Theory]
    [MemberData(nameof(NotExistingTriangleData))]
    public void NotExistingTriangleTest(double aSide, double bSide, double cSide)
    {
        //arrange/act/assert
        Assert.Throws<ArgumentException>(() => new Triangle(aSide, bSide, cSide));
    }

    [Theory]
    [MemberData(nameof(TriangleNegativeSideData))]
    public void TriangleNegativeSideTest(double aSide, double bSide, double cSide)
    {
        //arrange/act/assert
        Assert.Throws<ArgumentException>(() => new Triangle(aSide, bSide, cSide));
    }

    [Theory]
    [MemberData(nameof(CorrectTriangleData))]
    public void CorrectTriangleTest(double aSide, double bSide, double cSide, double epsilon, double expected)
    {
        //arrange
        var triangle = new Triangle(aSide, bSide, cSide);

        //act
        var area = triangle.CalculateArea();

        //assert
        Assert.True(Math.Abs(expected - area) <= epsilon);
    }
    
    [Theory]
    [MemberData(nameof(TriangularRightData))]
    public void TriangularRightTest(double aSide, double bSide, double cSide, bool expected)
    {
        //arrange
        var triangle = new Triangle(aSide, bSide, cSide);

        //act
        var result = triangle.IsTriangleRight();

        //assert
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> TriangleZeroSideData()
    {
        yield return new object[] {0, 0, 0};
        yield return new object[] {0, 1, 2};
        yield return new object[] {1, 0, 2};
        yield return new object[] {1, 2, 0};
    }

    private static IEnumerable<object[]> NotExistingTriangleData()
    {
        yield return new object[] {1, 2, 3};
        yield return new object[] {1, 1, 2};
    }

    private static IEnumerable<object[]> TriangleNegativeSideData()
    {
        yield return new object[] {-1, -2, -3};
        yield return new object[] {-1, 2, 10};
        yield return new object[] {1, -2, 10};
        yield return new object[] {1, 2, -10};
    }

    private static IEnumerable<object[]> CorrectTriangleData()
    {
        yield return new object[] {5, 5, 6, 0, 12};
        yield return new object[] {5, 5, 7, 1e-5, 12.4975};
        yield return new object[] {3, 4, 5, 0, 6};
    }
    
    private static IEnumerable<object[]> TriangularRightData()
    {
        yield return new object[] {3, 4, 5, true};
        yield return new object[] {3, 5, 4, true};
        yield return new object[] {4, 3, 5, true};
        yield return new object[] {4, 5, 3, true};
        yield return new object[] {5, 3, 4, true};
        yield return new object[] {5, 4, 3, true};
        yield return new object[] {5, 5, 6, false};
    }
}