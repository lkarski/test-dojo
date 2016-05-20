Setup
=====

Install "nspec" and "Moq" via NuGet

	PM> Install-Package nspec -ProjectName E06.Spec
	PM> Install-Package Moq -ProjectName E06.Spec

Include 'NSpecShoppingCartSpecs.cs' in the project

Task
====

Run specs

	PM> .\packages\nspec.1.0.5\tools\NSpecRunner.exe .\E06.Spec.NJasmine\bin\Debug\E06.Spec.dll