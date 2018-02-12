using System;
using Core.Commands;
using Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UtGetFundraiserCommand
    {
        [TestMethod]
        public void KoIfNull()
        {
            var cmd = new GetFundraiserCommand().GetFundraiser(null, null);

            Assert.IsTrue(cmd.Status == CommandStatus.BAD_PARAMETER);
        }

        [TestMethod]
        public void KoIfNotOrganismFound()
        {
            var cmd = new GetFundraiserCommand().GetFundraiser("unknow_ref", "1");

            Assert.IsTrue(cmd.Status == CommandStatus.NOT_FOUND);
        }

        [TestMethod]
        public void KoIfNotFound()
        {
            var cmd = new GetFundraiserCommand().GetFundraiser("1", "unknow_ref");

            Assert.IsTrue(cmd.Status == CommandStatus.NOT_FOUND);
        }

        [TestMethod]
        public void Ok()
        {
            var cmd = new GetFundraiserCommand().GetFundraiser("1", "1");

            Assert.IsTrue(cmd.Status == CommandStatus.DONE);
            Assert.IsTrue(cmd.Output != null);
        }
    }
}
