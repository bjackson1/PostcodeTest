using NUnit.Framework;
using System;
using PostcodeValidator;

namespace PostcodeUnitTests
{
	[TestFixture ()]
	public class PostcodeTests
	{
		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithInvalidCharacters_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("$%± ()()").Validate (), "Junk");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithInvalid_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("XX XXX").Validate (), "Invalid");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithIncorrectInwardCodeLength_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("A1 9A").Validate (), "Incorrect inward code length");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithNoSpace_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("LS44PL").Validate (), "No space");		
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithQInFirstPosition_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("Q1A 9AA").Validate (), "'Q' in first position");		
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithVInFirstPosition_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("V1A 9AA").Validate (), "'V' in first position");		
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithXInFirstPosition_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("X1A 9BB").Validate (), "'X' in first position");		
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithIInSecondPosition_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("LI10 3QP").Validate (), "'I' in second position");		
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithJInSecondPosition_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("LJ10 3QP").Validate (), "'J' in second position");		
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithZInSecondPosition_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("LZ10 3QP").Validate (), "'Z' in second position");		
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithQInThirdPositionAndA9AStructure_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("A9Q 9AA").Validate (), "'Q' in third position with 'A9A' structure");		
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithCInFourthPositionAndAA9AStructure_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("AA9C 9AA").Validate (), "'C' in fourth position with 'AA9A' structure");		
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithOnlySingleDigitCharacters_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("FY10 4PL").Validate (), "Area with only single digit districts");		
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithOnlyDoubleDigitCharacters_ReturnsFalse ()
		{
			Assert.IsFalse (new Postcode ("SO1 4QQ").Validate (), "Area with only double digit districts");
		}


		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithAA9A9AAFormat_ReturnsTrue ()
		{
			Assert.IsTrue (new Postcode ("EC1A 1BB").Validate (), "Area code is valid but failed validation");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithA9A9AAFormat_ReturnsTrue ()
		{
			Assert.IsTrue (new Postcode ("W1A 0AX").Validate (), "Area code is valid but failed validation");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithA99AAFormat_ReturnsTrue ()
		{
			Assert.IsTrue (new Postcode ("M1 1AE").Validate (), "Area code is valid but failed validation");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithA999AAFormat_ReturnsTrue ()
		{
			Assert.IsTrue (new Postcode ("B33 8TH").Validate (), "Area code is valid but failed validation");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithAA99AAFormat_ReturnsTrue ()
		{
			Assert.IsTrue (new Postcode ("CR2 6XH").Validate (), "Area with only double digit districts");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithAA999AAFormat_ReturnsTrue ()
		{
			Assert.IsTrue (new Postcode ("DN55 1PT").Validate (), "Area code is valid but failed validation");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithGirobankCode_ReturnsTrue ()
		{
			Assert.IsTrue (new Postcode ("GIR 0AA").Validate (), "Area code is valid but failed validation");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithSOAndDoubleDigitsCode_ReturnsTrue ()
		{
			Assert.IsTrue (new Postcode ("SO10 9AA").Validate (), "Area code is valid but failed validation");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithFYAndSingleDigitCode_ReturnsTrue ()
		{
			Assert.IsTrue (new Postcode ("FY9 9AA").Validate (), "Area code is valid but failed validation");
		}

		[Test ()]
		public void test_Postcode_Validate_WhenCalledWithAreaWithWC9A9AAFormat_ReturnsTrue ()
		{
			Assert.IsTrue (new Postcode ("WC1A 9AA").Validate (), "Area code is valid but failed validation");
		}
	}
}

