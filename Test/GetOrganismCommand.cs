using System;
using Core.Commands;
using Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UtGetOrganismCommand
    {
        [TestMethod]
        public void KoIfNull()
        {
            var cmd = new GetOrganismCommand().GetOrganism(null);

            Assert.IsTrue(cmd.Status == CommandStatus.BAD_PARAMETER);
        }

        [TestMethod]
        public void KoIfNotFound()
        {
            var cmd = new GetOrganismCommand().GetOrganism("unknow_ref");

            Assert.IsTrue(cmd.Status == CommandStatus.NOT_FOUND);
        }

        [TestMethod]
        public void Ok()
        {
            var cmd = new GetOrganismCommand().GetOrganism("1");

            Assert.IsTrue(cmd.Status == CommandStatus.DONE);
            Assert.IsTrue(cmd.Output != null);
        }
    }
}
