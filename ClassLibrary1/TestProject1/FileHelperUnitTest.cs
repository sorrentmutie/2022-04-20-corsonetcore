using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1;


[TestClass]
public class FileHelperUnitTest
{
    [TestMethod]
    public void FileNameDoesExists()
    {
        IData data = new Data();
        var fileHelper = new FileHelper(data);
        var risultatoAtteso = true;

        var risultatoTrovato = fileHelper.FileEsiste(@"E:\\prova.txt");

        Assert.AreEqual(risultatoAtteso, risultatoTrovato);

    }

    [TestMethod]
    public void FileNameDoesNotExists()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    [ExpectedException(typeof(System.ArgumentNullException))]
    public void FileNameNullOrEmptyThrowsArgumentNullException()
    {
        IData data = new Data();
        var fileHelper = new FileHelper(data);

        
            var risultato = fileHelper.FileEsiste("");
        
        Assert.Fail("Non è stata restituita una argumentnullexceptio");
    }
}
