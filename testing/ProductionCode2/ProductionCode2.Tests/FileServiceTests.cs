using Moq;
using Moq.Protected;
using NUnit.Framework;
using ProductionCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCode2.Tests
{
    [TestFixture]
    public class FileServiceTests
    {
        //
        //MTF
        //
        [Test]
        public void TestPrivateGetFiterExtensionFilesReturnOnlyTmpFiles()
        {
            FileService fileService = new FileService();

            string[] files = new[] { "asd.tmp", "xzc.ditr", "ph.tmp", };
            string[] validFiles = new[] { "asd.tmp", "ph.tmp" };
            var method = this.GetMethod("GetFiterExtensionFiles", fileService);
             
            var retCollection = method.Invoke(fileService, new[] { files }) as IEnumerable<string>;

            CollectionAssert.AreEqual(retCollection, validFiles);
        }

        [Test]
        public void TestPrivateGetOutputFileTextReturnConcatTextInString()
        {
            FileService fileService = new FileService();

            string[] fileTexts = new[] { "gay", "woman", "man" };
            string validOutputText = "gaywomanman";
            var method = this.GetMethod("GenerateOutputFileText", fileService);

            var ret = method.Invoke(fileService, new[] { fileTexts }) as string;

            Assert.That(ret, Is.EqualTo(validOutputText));
        }

        [Test]
        public void TestPrivateGetCountValidFilesReturn3()
        {
            FileService fileService = new FileService();

            string[] files = new[] { "bbb.tmp", "gay.tmp", "ko0la.tmp", };
            int validOutputText = 3;
            var method = this.GetMethod("GetCountValidFiles", fileService);

            var ret = (int)method.Invoke(fileService, new[] { files });

            Assert.That(ret, Is.EqualTo(validOutputText));
        }

        [Test]
        public void TestPrivateDirectoryExistsReturnFalseThenThrowsExceptionCallMTF()
        {
            var fileService = new Mock<FileService>();

            fileService.Protected().Setup<bool>("ValidationDirectory", ItExpr.IsAny<string>()).Returns(false);

            Assert.That(() => fileService.Object.MergeTemporaryFiles(string.Empty), Throws.Exception.TypeOf<DirectoryNotFoundException>());
        }

        //

        //
        //MTF
        //

        [Test]
        public void TestPrivateDirectoryExistsReturnFalseThenThrowsExceptionCallRTF()
        {
            Mock<FileService> fileService = new Mock<FileService>();

            fileService.Protected().Setup<bool>("ValidationDirectory", ItExpr.IsAny<string>()).Returns(false);

            Assert.That(() => fileService.Object.RemoveTemporaryFiles(string.Empty), Throws.Exception.TypeOf<DirectoryNotFoundException>());
        }

        [Test]
        public void TestPrivateRemoveTemporaryFilesWhenTwoValidFilesReturn8bytes()
        {
            var fileService = new Mock<FileService>();

            fileService.Protected().Setup<bool>("ValidationDirectory", ItExpr.IsAny<string>()).Returns(true);
            fileService.Protected().Setup<bool>("ValidationFile", ItExpr.IsAny<string>()).Returns(true);
            fileService.Protected().Setup<IEnumerable<string>>("GetFiles", ItExpr.IsAny<string>()).Returns(new[] { "first", "second" });
            fileService.Protected().Setup<long>("GetSizeInBytes", ItExpr.IsAny<string>()).Returns(4);

            int retValue = fileService.Object.RemoveTemporaryFiles(string.Empty);

            Assert.That(retValue, Is.EqualTo(retValue));
        }

        [Test]
        public void TestPrivateRemoveTemporaryFilesWhenOneNotValidFileWriteLogMessage()
        {
            var fileService = new Mock<FileService>();

            fileService.Protected().Setup<bool>("ValidationDirectory", ItExpr.IsAny<string>()).Returns(true);
            fileService.Protected().Setup<bool>("ValidationFile", ItExpr.IsAny<string>()).Returns(false);
            fileService.Protected().Setup<IEnumerable<string>>("GetFiles", ItExpr.IsAny<string>()).Returns(new[] { "first" });

            int retValue = fileService.Object.RemoveTemporaryFiles(string.Empty);

            fileService.Protected().Verify("WriteErrorMessageToLog", Times.Once(), new[] { string.Empty, "first" });
        }

        //
        private MethodInfo GetMethod(string methodName, object objectUnderTest)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                Assert.Fail("methodName cannot be null or whitespace");

            var method = objectUnderTest.GetType()
                .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (method == null)
                Assert.Fail(string.Format("{0} method not found", methodName));

            return method;
        }
    }
}
