namespace oop1projekt_sofia_magnus.Test;

using System.Collections.Generic;
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

    [Fact]
    public void DecreseStock_decresBy3_ChangeInventoryBy3()
    {
        // Arrange
        ProductService PS = new(new FakeDatabase());
        Product b1 = new Coffee("Ost", "made from milk", 1.99, Coffee.CoffeeRoasts.Light, 100);
        Product b2 = new Tea("AOst", "made from milk", 1.99, Tea.TeaTypes.GreenTea, 100);
        Product b3 = new Chocolate("BetaOst", "made from milk", 1.99, Chocolate.ChocolateTypes.DarkChocolate, 100);
        PS.AddProduct(b1);
        PS.AddProduct(b2);
        PS.AddProduct(b3);
        List<Product> expected = new()
        {
            new Coffee("Ost", "made from milk", 1.99, Coffee.CoffeeRoasts.Light, 98), b2, b3
        };
        // Act
        PS.DecreaseStock(b1, 3);

        // Assert
        Assert.Equal(expected, PS.GetAllProducts());
    }
}

internal class FakeDatabase : IProductRepository
{
    List<Product> pList = new();

    public FakeDatabase()
    {
        // pList.Add(new Coffee("Ost", "made from milk", 1.99, Coffee.CoffeeRoasts.Light, 100));
        // pList.Add(new Tea("AOst", "made from milk", 1.99, Tea.TeaTypes.GreenTea, 100));
        // pList.Add(new Chocolate("BetaOst", "made from milk", 1.99, Chocolate.ChocolateTypes.DarkChocolate, 100));
    }

    public int Add(Product p)
    {
        pList.Add(p);
        return 0;
    }

    public void DecreaseStock(Product product, int number)
    {
        pList.Find(t => t == product).InventoryBalance -= number;
    }

    public List<Product> GetAllProducts()
    {
        return pList;
    }

    public void IncreaseStock(Product product, int number)
    {
        throw new NotImplementedException();
    }

    public List<Product> SearchByName(string text)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> SearchByType(string type)
    {
        throw new NotImplementedException();
    }

    public void UpdateInfo(Product product, string value)
    {
        throw new NotImplementedException();
    }

    public void UpdateInventory(Product product, int value)
    {
        throw new NotImplementedException();
    }

    public void UpdatePrice(Product product, double value)
    {
        throw new NotImplementedException();
    }
}