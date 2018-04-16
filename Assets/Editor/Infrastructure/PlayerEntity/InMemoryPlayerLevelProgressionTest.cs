using GoCube.Infraestructure.PlayerEntity;
using NUnit.Framework;

namespace Infrastructure.PlayerEntity
{
    public class InMemoryPlayerLevelProgressionTest
    {

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(50)]
        [TestCase(99)]
        public void should_return_level_one(int exp)
        {
            var progression = new InMemoryPlayerLevelProgression();
            Assert.AreEqual(1, progression.GetLevelForExp(exp));
        }

        [TestCase(100)]
        [TestCase(200)]
        [TestCase(299)]
        public void should_return_level_two(int exp)
        {
            var progression = new InMemoryPlayerLevelProgression();
            Assert.AreEqual(2, progression.GetLevelForExp(exp));
        }

        [TestCase(300)]
        [TestCase(400)]
        [TestCase(799)]
        public void should_return_level_three(int exp)
        {
            var progression = new InMemoryPlayerLevelProgression();
            Assert.AreEqual(3, progression.GetLevelForExp(exp));
        }

        [TestCase(800)]
        [TestCase(1499)]
        public void should_return_level_four(int exp)
        {
            var progression = new InMemoryPlayerLevelProgression();
            Assert.AreEqual(4, progression.GetLevelForExp(exp));
        }

        [TestCase(1500)]
        [TestCase(5000)]
        public void should_return_level_five(int exp)
        {
            var progression = new InMemoryPlayerLevelProgression();
            Assert.AreEqual(5, progression.GetLevelForExp(exp));
        }
    }
}