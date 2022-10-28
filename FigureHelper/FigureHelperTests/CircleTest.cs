using FigureAreaCalculator.Figures;

namespace FigureHelperTests;

public class CircleTest
{
    [Fact]
    public void CircleNegativeRadiusTest()
    {
        //arrange
        var radius = -1;
        
        //act/assert
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }
    
    [Fact]
    public void CircleZeroRadiusTest()
    {
        //arrange
        var radius = 0;
        var expected = 0;
        var circle = new Circle(radius);
        
        //act
        var area = circle.CalculateArea();

        //assert
        Assert.Equal(expected, area);
    }
    
    [Fact]
    public void CorrectCircleTest()
    {
        //arrange
        var radius = 10;
        var expected = Math.PI * radius * radius;
        var epsilon = double.Epsilon;
        var circle = new Circle(radius);
        
        //act
        var area = circle.CalculateArea();

        //assert
        Assert.True(Math.Abs(expected - area) < epsilon);
    }
}