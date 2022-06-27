namespace TDDBank.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void New_account_should_have_zero_as_balance()
        {
            var acc = new BankAccount();

            Assert.Equal(0m, acc.Balance);
        }

        [Fact]
        public void Can_deposit()
        {
            var account = new BankAccount();

            account.Deposit(5m);

            Assert.Equal(5m, account.Balance);
        }

        [Fact]
        public void Can_deposit_add_balance()
        {
            var account = new BankAccount();

            account.Deposit(5m);
            account.Deposit(5m);

            Assert.Equal(10m, account.Balance);
        }

        [Fact]
        public void Can_withdraw()
        {
            var account = new BankAccount();

            account.Deposit(20m);
            account.Withdraw(8m);
            account.Withdraw(5m);

            Assert.Equal(7m, account.Balance);
        }

        [Fact]
        public void Withdraw_more_than_balance_throw_InvalidOpEx()
        {
            var account = new BankAccount();

            account.Deposit(20m);
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(21m));

        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        public void Deposit_a_negative_value_or_zero_throws_ArgumentEx(decimal value)
        {
            var account = new BankAccount();

            Assert.Throws<ArgumentException>(() => account.Deposit(value));
        }


        [Theory]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        public void Withdraw_a_negative_value_or_zero_throws_ArgumentEx(decimal value)
        {
            var account = new BankAccount();

            Assert.Throws<ArgumentException>(() => account.Withdraw(value));
        }
    }
}