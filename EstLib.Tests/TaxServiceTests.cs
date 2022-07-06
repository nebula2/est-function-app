namespace EstLib.Tests;

public class TaxServiceTests
{
    [Theory]
    [InlineData(2022, true, 45000, 9945)]
    [InlineData(2022, false, 45000, 5606)]
    public void Test1(int year, bool isSingle, decimal taxableIncome, decimal expectedResult)
    {
        // arrange
        var taxService = new TaxService();

        // act
        var result = taxService.GetTax(year, isSingle, taxableIncome);

        // assert
        Assert.Equal(expectedResult, result);
    }
}