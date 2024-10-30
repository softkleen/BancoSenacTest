using Banco;

namespace BancoTestes
{
    [TestClass]
    public class ContaBancariaTeste
    {
        [TestMethod] // atributo de teste
        public void Debito_ComMontanteValido_AtualizandoSaldo() // void = n�o retorna valor
        {
            double saldoInicial = 11.99;
            double montanteDebitado = 4.55;
            double esperado = 7.44;
            ContaBancaria conta = new("Mis Cristine",saldoInicial);

            // a��o
            conta.Debitar(montanteDebitado);

            double atual = conta.Saldo;
            Assert.AreEqual(esperado, atual, 0.001, "O debito n�o ocorreu corretamente");
        }
        [TestMethod]
        public void Debito_QuandoMontanteMenorQueZero_InterceptadoPorExcecao()
        {
            double saldoInicial = 11.99;
            double montanteDebitado = -100.00;
            ContaBancaria conta = new("Mis Cristine", saldoInicial);

            // a��o e Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>conta.Debitar(montanteDebitado));
        }
    }
}