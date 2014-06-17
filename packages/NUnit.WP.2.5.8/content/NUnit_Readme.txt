Delete UnitTest.cs and Test_Readme.txt since they use MsTest and not NUnit
An example test has been included in NUnitTest.cs

Handle the Loaded event in MainPage and add the following line:

this.StartTestRunner(new Microsoft.Silverlight.Testing.UnitTesting.Metadata.NUnit.NUnitProvider());