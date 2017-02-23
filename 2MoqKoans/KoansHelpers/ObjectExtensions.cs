﻿using NUnit.Framework;
using Moq;

namespace MoqKoans.KoansHelpers
{
	public static class ObjectExtensions
	{
		private const string REPLACE_METHOD_MSG = "Replace the method call \".___()\" with the appropriate method to make the test pass.";

		public static object ___(this object obj, params object[] inputs)
		{
			throw new AssertionException(REPLACE_METHOD_MSG);
		}

		public static object ____(this object obj, params object[] inputs)
		{
			return null;
		}
	}
}
