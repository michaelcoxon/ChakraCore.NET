using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ChakraCore.NET.UnitTest
{
    [TestClass]
    public class ES6ModuleTest : UnitTestBase
    {
        protected override void SetupContext()
        {
        }


        [TestMethod]
        public void BasicClassProject()
        {
            var value = this.projectModuleClass("BasicExport", "TestClass");
            var result = value.CallFunction<int, int>("Test1", 1);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MultipleClassProject()
        {
            for (var i = 0; i < 10; i++)
            {
                var value = this.projectModuleClass("BasicExport", "TestClass");
                var result = value.CallFunction<int, int>("Test1", 1);
                Assert.AreEqual(2, result);
            }
        }

        [TestMethod]
        public void ImportExport()
        {
            var value = this.projectModuleClass("BasicImport", "TestClass2");
            var result = value.CallFunction<int, int>("Test2", 1);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NestedImport()
        {
            var value = this.projectModuleClass("NestedImport0", "Test");
            var result = value.CallFunction<int, int>("Test1", 1);
            Assert.AreEqual(2, result);
        }


        [TestMethod]
        public async Task ModulePromiseAsync()
        {
            this.context.ServiceNode.GetService<IJSValueConverterService>().RegisterTask<int>();
            var c = this.projectModuleClass("ModulePromise", "test");
            var tt = await c.CallFunction<int, Task<int>>("test1", 1);
            Assert.AreEqual(2, tt);
        }

    }
}
