namespace oop1projekt_sofia_magnus.Test;

using oop1projekt_sofia_magnus;

public class UnitBasket
{
    [Theory]
    [InlineData(10, true)]
    [InlineData(110, false)]
    [InlineData(0, true)]
    [InlineData(-1, false)]
    public void AddToBasket_AddProduct_ReturnsTrue(int value, bool expected)
    {
        // Arrange
        Basket basket = new();
        Product product = new Coffee("Ost", "made from milk", 1.99, Coffee.CoffeeRoasts.Light, 100);

        // Act
        bool actual = basket.AddToBasket(product, value);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(10, true)]
    [InlineData(95, false)]
    [InlineData(0, true)]
    public void AddToBasket_AddProductToExisting_ReturnsTrue(int value, bool expected)
    {
        // Arrange
        Basket basket = new();
        Product product = new Coffee("Ost", "made from milk", 1.99, Coffee.CoffeeRoasts.Light, 100);
        basket.AddToBasket(product, 10);
        // Act
        bool actual = basket.AddToBasket(product, value);

        // Assert
        Assert.Equal(expected, actual);
    }
}