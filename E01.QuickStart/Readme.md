Keyboard Shortcuts
==================

	* Ctrl+R, W - Show Test Explorer - need to configure it
	* Ctrl+R, A - Run all tests
	* Ctrl+R, T - Run current test
	* Ctrl+R, L - Repeat last run
	* Ctrl+W, M - Show Package Manager Console
	* Ctrl+Alt+L - Show Solution Explorer


Setup
=====

Install NUnit via Package Manager Console

	PM> Install-Package NUnitTestAdapter.WithFramework -ProjectName E01.QuickStart

[optionally] Install Shouldly

	PM> Install-Package Shouldly -ProjectName E01.QuickStart


Task
====

Implement

	[Test]
    public void PickupOrder_ShouldIncludeBonusPack_WhenCustomerIsLoyal()
    {
	}

Extra
=====

dotnet Core supports Xunit out of the box; check it out:

	PM> Install-Package xunit -ProjectName E01.QuickStart.Tests
	PM> Install-Package xunit.runner.visualstudio -ProjectName E01.QuickStart.Tests



