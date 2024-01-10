namespace oop1projekt_sofia_magnus.Test;
using oop1projekt_sofia_magnus;

public class UnitTest1
{
    [Fact]
    public void SortProductList_SortOneProduct_Return1Product()
    {
        // Arrange
        List<Product> expected = new()
        {
            new Product("Ost", "made from milk", 1.99, 100)
        };
        List<Product> pList = new()
        {
            new Product("Ost", "made from milk", 1.99, 100)
        };
        int sortBy = 0;

        // Act
        List<Product> actual = Skrep.SortProductList(pList, sortBy);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SortProductList_Sort2Product_Return2ProductInSortedOrder()
    {
        // Arrange
        Product b1 = new Product("Ost", "made from milk", 1.99, 100);
        Product b2 = new Product("AOst", "made from milk", 1.99, 100);
        List<Product> expected = new()
        {
            b2, b1
        };
        List<Product> pList = new()
        {
            b1, b2
        };
        int sortBy = 0; // name

        // Act
        List<Product> actual = Skrep.SortProductList(pList, sortBy);

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void SortProductList_Sort3Product_Return3ProductInSortedOrder()
    {
        // Arrange
        Product b1 = new Coffee("Ost", "made from milk", 1.99, Coffee.CoffeeRoasts.Light, 100);
        Product b2 = new Tea("AOst", "made from milk", 1.99, Tea.TeaTypes.GreenTea, 100);
        Product b3 = new Chocolate("BetaOst", "made from milk", 1.99, Chocolate.ChocolateTypes.DarkChocolate, 100);
        List<Product> expected = new()
        {
            b1, b2, b3
        };
        List<Product> pList = new()
        {
            b2, b3, b1
        };
        int sortBy = 1; // drinkType

        // Act
        List<Product> actual = Skrep.SortProductList(pList, sortBy);

        // Assert
        Assert.Equal(expected, actual);
    }
}