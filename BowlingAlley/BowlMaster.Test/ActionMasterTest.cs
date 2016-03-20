using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlMaster.Test
{
    [TestClass]
    public class ActionMasterTest
    {
        private ActionMaster actionMaster;
        [TestInitialize]
        public void TestInitialize()
        {
            actionMaster = new ActionMaster();
        }

        [TestMethod]
        public void TestBowlStrikeEndsTurn()
        {
            ActionMaster.BowlResult result = actionMaster.Bowl(10);
            Assert.AreEqual(ActionMaster.BowlResult.EndTurn, result);
        }

        [TestMethod]
        public void TestBowl9TidysLane()
        {
            var result = actionMaster.Bowl(9);
            Assert.AreEqual(ActionMaster.BowlResult.Tidy, result);
        }

        [TestMethod]
        public void TestBowl9And1EndsTurn()
        {
            actionMaster.Bowl(9);
            var result = actionMaster.Bowl(1);

            Assert.AreEqual(ActionMaster.BowlResult.EndTurn, result);
        }

        [TestMethod]
        public void TestBowl10InSecondBowlEndsTurn()
        {
            actionMaster.Bowl(0);
            var result = actionMaster.Bowl(10);

            Assert.AreEqual(ActionMaster.BowlResult.EndTurn, result);
            Assert.AreEqual(3, actionMaster.bowl);
        }
    }
}
