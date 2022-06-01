using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClinicServ;
using BeanLib;
namespace ClinicTest
{
    [TestClass]
    public class UnitTest1
    {

        public ClinicServiceImpl cl;
        [TestMethod]
         public void TestMethod1()
        {
            cl = new ClinicServiceImpl();
            Users u = new Users("Ya1nam", "ok@fine123");
            Assert.IsTrue(cl.UserCheck(u));
        }
    }
}
