﻿using System.Reflection;

namespace EmployeeManager.Persistence;

public static class AssemblyReference
{
	public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
