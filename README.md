# ArgumentChecker.NET

A simple and succinct way to code defensively without clogging up your classes with dozens of lines of boring boilerplate.

```c#
using static Aspinall.ArgumentChecker.FluentChecker;

public class MyClass
{
	private string myString;

	public MyClass(string someString)
	{
		myString = CheckThat(someString, nameof(someString)).IsNotNullOrWhitespace().Value;
	}
	...
}
```

## Installing 

```shell
nuget install Aspinall.ArgumentChecker
```

## Getting started

The recommended way to use the library is through the fluent API demonstrated above. 

1. Add `using static Aspinall.ArgumentChecker.FluentChecker;` to your class.
2. For each argument you want to check:
   1. Create an `ArgumentChecker` instance using `CheckThat(value, nameof(value))`.
   2. Chain the checking method calls to it e.g. `CheckThat(value, nameof(value)).IsNotNull().IsNotEmpty()`. Each check method returns the `ArgumentChecker` again. If a check fails then an approriate exception will be thrown.
   3. If you want to assign the original value after it has been checked, it is available in the `Value` property of the `ArgumentChecker` e.g. `var local = CheckThat(argument, nameof(argument)).IsNotNull().Value;`

The following checks are currently available:

* `IsEqualTo(expectedValue)`
* `IsNotDefaultValue()`
* `IsNotEmpty()` _- assumes that the value implements `System.Collections.ICollection`_
* `IsNotNull()`
* `IsNotNullOrWhitespace()` _- assumes that the value is a `string`_

You can check the documentation comments and the unit tests for a detailed description of each check and example usage.


## Developing

This project targets .NET Standard 1.4 and was created using Visual Studio 2017. As such it uses the new `.csproj` file format and requires the VS2017 build tools. Other than that it is a very simple project.


## Contributing

If you'd like to contribute, please fork the repository and use a feature branch. Pull requests are warmly welcome.


## Licensing

The code in this project is licensed under MIT license.