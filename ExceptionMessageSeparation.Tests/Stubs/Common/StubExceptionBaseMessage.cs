using System;


namespace ExceptionMessageSeparation.Tests.Stubs.Common;

internal static class StubExceptionBaseMessage
{
    internal static string Get(int i, string s) =>
    $"{Environment.NewLine}" +
    $"{Environment.NewLine}Int Value::    {i}" +
    $"{Environment.NewLine}String Value:: {s}";
}