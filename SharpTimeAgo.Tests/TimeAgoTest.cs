using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SharpTimeAgo.Tests
{
    [TestFixture]
    public class TimeAgoTest
    {
        private string Run(TimeSpan timeSpan)
        {
            return timeSpan.GetTimeAgo();            
        }

        [TestCase]
        public void TestAll()
        {
            Assert.AreEqual("1 second ago", Run(new TimeSpan(0, 0, 0, 1)));
            Assert.AreEqual("3 seconds ago", Run(new TimeSpan(0, 0, 0, 3)));

            Assert.AreEqual("almost a minute ago", Run(new TimeSpan(0, 0, 0, 59)));
            Assert.AreEqual("1 minute ago", Run(new TimeSpan(0, 0, 1, 1)));
            Assert.AreEqual("3 minutes ago", Run(new TimeSpan(0, 0, 3, 1)));

            Assert.AreEqual("almost an hour ago", Run(new TimeSpan(0, 0, 59, 0)));
            Assert.AreEqual("1 hour ago", Run(new TimeSpan(0, 0, 61, 0)));
            Assert.AreEqual("3 hours ago", Run(new TimeSpan(0, 3, 3, 1)));

            Assert.AreEqual("almost a day ago", Run(new TimeSpan(0, 18, 0, 0)));
            Assert.AreEqual("1 day ago", Run(new TimeSpan(1, 0, 1, 1)));
            Assert.AreEqual("3 days ago", Run(new TimeSpan(3, 0, 1, 1)));

            Assert.AreEqual("almost a week ago", Run(new TimeSpan(6, 0, 0, 0)));
            Assert.AreEqual("1 week ago", Run(new TimeSpan(9, 0, 0, 0)));
            Assert.AreEqual("3 weeks ago", Run(new TimeSpan(22, 0, 0, 0)));

            Assert.AreEqual("almost a month ago", Run(new TimeSpan(30, 0, 0, 0)));
            Assert.AreEqual("1 month ago", Run(new TimeSpan(31, 0, 0, 0)));
            Assert.AreEqual("3 months ago", Run(new TimeSpan(96, 0, 0, 0)));

            Assert.AreEqual("almost 1 year ago", Run(new TimeSpan(320, 0, 0, 0)));
            Assert.AreEqual("1 year ago", Run(new TimeSpan(400, 0, 0, 0)));
            Assert.AreEqual("almost 2 years ago", Run(new TimeSpan(658, 0, 0, 0)));
            Assert.AreEqual("2 years ago", Run(new TimeSpan(800, 0, 0, 0)));       
            

        }

    }
}
