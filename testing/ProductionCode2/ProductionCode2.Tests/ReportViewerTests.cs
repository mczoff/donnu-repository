using Moq;
using NUnit.Framework;
using ProductionCode;
using ProductionCode2.Tests.Fakes;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionCode2.Tests
{
    [TestFixture]
    public class ReportViewerTests
    {
        //1-1

        [Test]
        public void MTFWithZeroMyStub()
        {
            FakeStubFileService stubFileService = new FakeStubFileService();
            ReportViewer reportViewer = new ReportViewer(stubFileService);

            stubFileService.ReturnValueMergeTemporaryFiles = 0;
            reportViewer.PrepareData(string.Empty);

            Assert.That(stubFileService.MergeTemporaryFiles(string.Empty), Is.EqualTo(reportViewer.BlockCount));
        }

        [Test]
        public void MTFWithZeroMoqStub()
        {
            var stubFileService = new Mock<IFileService>();
            ReportViewer reportViewer = new ReportViewer(stubFileService.Object);

            stubFileService.Setup(t => t.MergeTemporaryFiles(string.Empty)).Returns(0);

            reportViewer.PrepareData(string.Empty);

            Assert.That(stubFileService.Object.MergeTemporaryFiles(string.Empty), Is.EqualTo(reportViewer.BlockCount));
        }

        [Test]
        public void MTFWithValueMyStub()
        {
            FakeStubFileService stubFileService = new FakeStubFileService();
            ReportViewer reportViewer = new ReportViewer(stubFileService);

            stubFileService.ReturnValueMergeTemporaryFiles = 5;
            reportViewer.PrepareData(string.Empty);

            Assert.That(stubFileService.MergeTemporaryFiles(string.Empty), Is.EqualTo(reportViewer.BlockCount));
        }

        [Test]
        public void MTFWithValueMoqStub()
        {
            var stubFileService = new Mock<IFileService>();
            ReportViewer reportViewer = new ReportViewer(stubFileService.Object);

            stubFileService.Setup(t => t.MergeTemporaryFiles(string.Empty)).Returns(5);

            reportViewer.PrepareData(string.Empty);

            Assert.That(stubFileService.Object.MergeTemporaryFiles(string.Empty), Is.EqualTo(reportViewer.BlockCount));
        }

        [Test]
        public void MTFWithNotFoundDirectoryMyStub()
        {
            FakeStubExceptionFileService stubFileService = new FakeStubExceptionFileService();
            ReportViewer reportViewer = new ReportViewer(stubFileService);

            stubFileService.ExceptionMergeTemporaryFiles = new FileNotFoundException();

            Assert.That(() => { reportViewer.PrepareData(string.Empty); } , Throws.TypeOf<FileNotFoundException>());
        }

        [Test]
        public void MTFWithNotFoundDirectoryMoqStub()
        {
            var stubFileService = new Mock<IFileService>();
            ReportViewer reportViewer = new ReportViewer(stubFileService.Object);

            stubFileService.Setup(t => t.MergeTemporaryFiles(string.Empty))
                .Throws<FileNotFoundException>();

            Assert.That(() => { reportViewer.PrepareData(string.Empty); }, Throws.InstanceOf<FileNotFoundException>());
        }

        [Test]
        public void MTFWithInvokeMergeTemporaryFilesMyMock()
        {
            var mockFileService = new FakeMockFileService();
            ReportViewer reportViewer = new ReportViewer(mockFileService);

            string directory = string.Empty;
            double countFiles = reportViewer.BlockCount;

            reportViewer.PrepareData(string.Empty);

            Assert.That(mockFileService.MergeTemporaryFilesIsCalledCount, Is.GreaterThan(0));
        }

        [Test]
        public void MTFWithInvokeMergeTemporaryFilesMoqMock()
        {
            var mockFileService = new Mock<IFileService>();
            ReportViewer reportViewer = new ReportViewer(mockFileService.Object);

            string directory = string.Empty;
            reportViewer.PrepareData(directory);
            double countFiles = reportViewer.BlockCount;

            mockFileService.Verify(t => t.MergeTemporaryFiles(directory));
        }

        //2-1

        [Test]
        public void RTFWithZeroMyStub()
        {
            FakeStubFileService stubFileService = new FakeStubFileService();
            ReportViewer reportViewer = new ReportViewer();

            reportViewer.FileService = stubFileService;

            stubFileService.ReturnValueRemoveTemporaryFiles = 0;
            reportViewer.Clean(string.Empty);

            Assert.That(reportViewer.UsedSize, Is.EqualTo(stubFileService.ReturnValueRemoveTemporaryFiles));
        }

        [Test]
        public void RTFWithZeroMoqStub()
        {
            var stubFileService = new Mock<IFileService>();
            ReportViewer reportViewer = new ReportViewer();

            reportViewer.FileService = stubFileService.Object;

            stubFileService.Setup(t => t.RemoveTemporaryFiles(string.Empty)).Returns(5);
            reportViewer.Clean(string.Empty);

            Assert.That(stubFileService.Object.RemoveTemporaryFiles(string.Empty), Is.EqualTo(reportViewer.UsedSize));
        }

        [Test]
        public void RTFWithValueMyStub()
        {
            FakeStubFileService stubFileService = new FakeStubFileService();
            ReportViewer reportViewer = new ReportViewer();

            reportViewer.FileService = stubFileService;

            stubFileService.ReturnValueRemoveTemporaryFiles = 5;
            reportViewer.Clean(string.Empty);

            Assert.That(reportViewer.UsedSize, Is.EqualTo(stubFileService.ReturnValueRemoveTemporaryFiles));
        }

        [Test]
        public void RTFWithValueMoqStub()
        {
            var stubFileService = new Mock<IFileService>();
            ReportViewer reportViewer = new ReportViewer();

            reportViewer.FileService = stubFileService.Object;

            stubFileService.Setup(t => t.RemoveTemporaryFiles(string.Empty)).Returns(5);
            reportViewer.Clean(string.Empty);

            Assert.That(stubFileService.Object.RemoveTemporaryFiles(string.Empty), Is.EqualTo(reportViewer.UsedSize));
        }

        [Test]
        public void RTFWithNotFoundDirectoryMyStub()
        {
            FakeStubExceptionFileService stubFileService = new FakeStubExceptionFileService();
            ReportViewer reportViewer = new ReportViewer();

            reportViewer.FileService = stubFileService;
            stubFileService.ExceptionRemoveTemporaryFiles = new FileNotFoundException();

            Assert.That(() => { reportViewer.Clean(string.Empty); }, Throws.Nothing);
        }

        [Test]
        public void RTFWithNotFoundDirectoryMoqStub()
        {
            var stubFileService = new Mock<IFileService>();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.FileService = stubFileService.Object;

            stubFileService.Setup(t => t.RemoveTemporaryFiles(string.Empty))
                .Throws<FileNotFoundException>();

            Assert.That(() => { reportViewer.Clean(string.Empty); }, Throws.Nothing);
        }

        [Test]
        public void RTFWithInvokeRemoveTemporaryFilesMyMock()
        {
            var mockFileService = new FakeMockFileService();
            ReportViewer reportViewer = new ReportViewer();
            string directory = string.Empty;

            reportViewer.FileService = mockFileService;
            reportViewer.Clean(directory);

            Assert.That(() => mockFileService.RemoveTemporaryFilesIsCalledCount, Is.GreaterThan(0));
        }

        [Test]
        public void RTFWithInvokeRemoveTemporaryFilesMoqMock()
        {
            var mockFileService = new Mock<IFileService>();
            ReportViewer reportViewer = new ReportViewer();

            reportViewer.FileService = mockFileService.Object;

            string directory = string.Empty;
            reportViewer.Clean(directory);

            mockFileService.Verify(t => t.RemoveTemporaryFiles(directory));
        }
    }
}
