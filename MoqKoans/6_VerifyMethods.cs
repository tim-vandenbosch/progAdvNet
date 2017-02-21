﻿using System;
using NUnit.Framework;
using Moq;
using MoqKoans.KoansHelpers;

namespace MoqKoans
{
	[TestFixture]
	public class Moq6_VerifyMethods : Koan
	{
		// This is an interface that we will be mocking.
		public interface IVolume
		{
			int Louder(int amount);
			int Quieter(int amount);
			string CurrentVolume();
		}

		[Test]
		public void MethodsSetUpWithVerifiableCanBeCheckedToSeeIfTheyWereCalled()
		{
			var mock = new Mock<IVolume>();
			mock.Setup(x => x.Louder(It.IsAny<int>()))
				.Returns(0)
				.Verifiable();

			var exceptionWasThrown = false;
			try
			{
				mock.Verify(); // the call to Verify tells Moq to ensure that all .Verifiable() setup methods have been called.
			}
			catch (Exception)
			{
				exceptionWasThrown = true;
			}
			Assert.AreEqual(___, exceptionWasThrown);
		}

		[Test]
		public void ACustomErrorMessageCanBeSpecifiedInVerifiable()
		{
			var mock = new Mock<IVolume>();
			mock.Setup(x => x.Louder(It.IsAny<int>()))
				.Returns(0)
				.Verifiable("This message will be in the Exception if the method is not called.");

			var exceptionWasThrown = false;
			try
			{
				mock.Verify();
			}
			catch (Exception ex)
			{
				exceptionWasThrown = true;
				Assert.IsTrue(ex.Message.Contains("___"));
			}
			Assert.AreEqual(___, exceptionWasThrown);
		}

		[Test]
		public void IfAMethodIsSetupVerifiableButVerifyIsNotCalledLaterThenNoExceptionIsThrown()
		{
			bool wasExceptionThrown = false;
			try
			{
				var mock = new Mock<IVolume>();
				mock.Setup(x => x.Louder(It.IsAny<int>()))
					.Returns(0)
					.Verifiable("Louder was not called.");

				//mock.Object.Louder(0);  <-- intentionally NOT calling .Louder(). Don't uncomment this.

				//mock.Verify(); <-- intentionally NOT calling .Verify(). Don't uncomment this.
			}
			catch (MockException)
			{
				wasExceptionThrown = true;
			}

			// Since the method is setup with .Verifiable(), and we did not call .Louder(), is an Exception thrown?
			// Why or Why Not?
			Assert.AreEqual(___, wasExceptionThrown);
		}

		[Test]
		public void VerifyChecksAllMethodsThatAreVerifiable_AllMustHaveBeenCalled()
		{
			var mock = new Mock<IVolume>();

			mock.Setup(x => x.Louder(It.IsAny<int>()))
				.Returns(0)
				.Verifiable("I can barely hear that thing. Crank it up!");

			mock.Setup(x => x.Quieter(It.IsAny<int>()))
				.Returns(0)
				.Verifiable("Its too loud in here. Turn it down!");

			var volume = mock.Object;
			volume.Quieter(100);
			volume.____();

			mock.Verify();
		}

		[Test]
		public void VerifiablePassesAsLongAsMethodIsCalledOneOrMoreTimes()
		{
			var mock = new Mock<IVolume>();
			mock.Setup(x => x.CurrentVolume()).Verifiable();

			var volume = mock.Object;
			volume.CurrentVolume();
			volume.CurrentVolume();
			volume.CurrentVolume();
			volume.CurrentVolume();

			var wasAnExceptionThrown = false;
			try
			{
				mock.Verify();
			}
			catch (Exception)
			{
				wasAnExceptionThrown = true;
			}

			Assert.AreEqual(___, wasAnExceptionThrown);
		}

		[Test]
		public void MethodCallsCanAlsoBeVerifiedWithTheVerifyMethodInsteadOfInSetup()
		{
			var mock = new Mock<IVolume>();
			var wasAnExceptionThrown = false;

			try
			{
				// the syntax for .Verify() is the same as .Setup() in that it is given a Lambda expression
				// that indicates what method and parameters to verify.
				mock.Verify(x => x.CurrentVolume());
			}
			catch (Exception)
			{
				wasAnExceptionThrown = true;
			}
			Assert.AreEqual(___, wasAnExceptionThrown);
		}

		[Test]
		public void VerifyCanFilterByInputParameters()
		{
			var mock = new Mock<IVolume>();

			mock.Object.Louder(20);

			var wasAnExceptionThrown = false;
			try
			{
				mock.Verify(x => x.Louder(10));
			}
			catch (Exception)
			{
				wasAnExceptionThrown = true;
			}

			Assert.AreEqual(___, wasAnExceptionThrown);	
		}

		[Test]
		public void VerifyCanBeUsedMoreThanOnceOnTheSameMethodWithDifferentConditions()
		{
			var mock = new Mock<IVolume>();
			var volume = mock.Object;

			volume.____();
			volume.____();

			mock.Verify(x => x.Quieter(10), "Quieter should have been called with the value 10.");
			mock.Verify(x => x.Quieter(It.Is<int>(p => p > 20 && p < 30)), "Quieter should have been called with a value between 20 and 30.");
		}

		[Test]
		public void VerifyTimesCanBeUsedToEnsureAMethodIsCalledAnExactNumberOfTimes()
		{
			var mock = new Mock<IVolume>();
			var volume = mock.Object;

			volume.CurrentVolume();
			volume.CurrentVolume();

			var wasAnExceptionThrown = false;
			try
			{
				mock.Verify(x => x.CurrentVolume(), Times.Once());
			}
			catch (Exception)
			{
				wasAnExceptionThrown = true;
			}

			Assert.AreEqual(___, wasAnExceptionThrown);
		}

		[Test]
		public void VerifyCurrentVolumeWasCalledExactlyThreeTimes()
		{
			var mock = new Mock<IVolume>();
			var volume = mock.Object;

			volume.____();

			mock.Verify(x => x.CurrentVolume(), Times.Exactly(3));
		}

		[Test]
		public void SetupAndVerifyCanBeUsedTogether()
		{
			var mock = new Mock<IVolume>();
			var volume = mock.Object;

			mock.Setup(x => x.Louder(It.IsAny<int>())).Returns<int>(p => p);

			Assert.AreEqual(___, volume.Louder(22));

			mock.Verify(x => x.Louder(____), Times.AtLeastOnce());
		}
	}
}
