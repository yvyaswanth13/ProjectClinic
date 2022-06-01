using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicMgmtSys;
using BeanLib;
namespace ClinicTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program p = new Program();
         Assert.IsFalse( p.frontEndValidation(new Users("", "")));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Program p = new Program();
            Assert.IsFalse(p.frontEndValidation(new Users("Yanama", "ok@fine123")));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Program p = new Program();
            Assert.IsFalse(p.frontEndValidation(new Users("Yanama123", "ok@fine123")));
        }
        [TestMethod]
        public void TestMethod4()
        {
            Program p = new Program();
            Assert.IsTrue(p.frontEndValidation(new Users("YanamalaYaswanth", "ok@fine12312")));
        }
    }
}
