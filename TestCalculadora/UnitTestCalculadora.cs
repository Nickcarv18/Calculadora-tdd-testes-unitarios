using Calculadora_tdd_testes_unitarios.Models;

namespace TestCalculadora;

public class UnitTestCalculadora
{
    public Calculadora ConstruirClasse()
    {
        string data = "08/10/2024";
        Calculadora calc = new Calculadora(data);
        return calc;
    }

    [Theory]
    [InlineData(1,2,3)]
    [InlineData(4, 5, 9)]
    public void TestSomar(int val1, int val2, int resultado)
    {
        Calculadora calc = ConstruirClasse();

        int resultadoCalculadora = calc.Somar(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(3, 2, 1)]
    [InlineData(8, 4, 4)]
    public void TestSubtrair(int val1, int val2, int resultado)
    {
        Calculadora calc = ConstruirClasse();

        int resultadoCalculadora = calc.Subtrair(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(10, 2, 20)]
    [InlineData(4, 5, 20)]
    public void TestMultiplicar(int val1, int val2, int resultado)
    {
        Calculadora calc = ConstruirClasse();

        int resultadoCalculadora = calc.Multiplicar(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(14, 7, 2)]
    [InlineData(10, 2, 5)]
    public void TestDividir(int val1, int val2, int resultado)
    {
        Calculadora calc = ConstruirClasse();

        int resultadoCalculadora = calc.Dividir(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        Calculadora calc = ConstruirClasse();

        Assert.Throws<DivideByZeroException>(
            () => calc.Dividir(3, 0)
        );
    }

    [Fact]
    public void TestarHistorico()
    {
        Calculadora calc = ConstruirClasse();

        calc.Somar(1,2);
        calc.Somar(2,3);
        calc.Somar(3,4);
        calc.Somar(4,5);

        var lista = calc.Historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }
}