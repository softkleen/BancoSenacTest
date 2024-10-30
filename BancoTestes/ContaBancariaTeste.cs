using Banco;

namespace BancoTestes
{
    [TestClass]
    public class ContaBancariaTeste
    {
        [TestMethod] // atributo de teste
        public void Debito_ComMontanteValido_AtualizandoSaldo() // void = não retorna valor
        {
            double saldoInicial = 11.99;
            double montanteDebitado = 4.55;
            double esperado = 7.44;
            ContaBancaria conta = new("Mis Cristine",saldoInicial);

            // ação
            conta.Debitar(montanteDebitado);

            double atual = conta.Saldo;
            Assert.AreEqual(esperado, atual, 0.001, "O debito não ocorreu corretamente");
        }
        [TestMethod]
        public void Debito_QuandoMontanteMenorQueZero_InterceptadoPorExcecao()
        {
            double saldoInicial = 11.99;
            double montanteDebitado = -100.00;
            ContaBancaria conta = new("Mis Cristine", saldoInicial);

            // ação e Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>conta.Debitar(montanteDebitado));
        }
    }
}