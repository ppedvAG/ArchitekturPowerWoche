using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FluentAssertions;

namespace HalloEfCore.Tests.UI
{
    [TestClass]
    public class MainWindowTests
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var path = @"C:\Users\Fred\source\repos\ppedvAG\ArchitekturPowerWoche\HalloEfCore\HalloEfCore\bin\Debug\net6.0-windows\HalloEfCore.exe";
            using var app = FlaUI.Core.Application.Launch(path);
            using var automation = new UIA3Automation();
            automation.ConnectionTimeout = TimeSpan.FromSeconds(6);

            var window = app.GetMainWindow(automation);
            
            var button1 = window.FindFirstDescendant(cf => cf.ByText("Laden"))?.AsButton();
            button1?.Invoke();

            var dgv = window.FindFirstDescendant(x => x.ByAutomationId("myGrid")).AsGrid();
            //var dgv = window.FindFirstDescendant(x => x.ByName("myGrid")).AsGrid();

            dgv.Should().NotBeNull();
            dgv.Rows.Length.Should().BeGreaterThan(0);

            app.Close();
        }
    }
}
