## LHS Bracket Parser in C#

This is a simple parser for LHS Bracket syntax.

[![Build status](https://ci.appveyor.com/api/projects/status/ep3y2xobn3wcmoc9/branch/master?svg=true)](https://ci.appveyor.com/project/Jalalx/LhsBracketParser/branch/master)

### Install from Nuget:

Install [LhsParser Package](https://www.nuget.org/packages/LhsParser/) by running this command in Package Manager Console:

    Install-Package LhsParser -Version 1.0.1

#### Why is this created at first place?

We needed some advanced filtering in our ASP.NET WebApi based project. I couldn't find any good library to 
turn predicates like `(CreateDate[lt]2018-12-20 or Creator[eq]"Jalal") and IsNew[eq]true` to an ORM based
predicate.

I have already [implemented an Evaluator](https://github.com/Jalalx/LhsBracketParser/blob/master/LhsBracketParser.LLBLGenAdapter/PredicateExpressionEvaluator.cs) for LLBLGen `PredicateExpression` type.
You can implement your own by inheriting from `EvaluatorBase` class.

#### How it works?

In your application, get filter from query string and apply it to your repository like sample below. I am using LLBLGen as ORM so I instantiate `PredicateExpressionEvaluator` but you can implement your own by extending `EvaluatorBase` for EntityFramework or NHibernate.

    // https://mysite.com/products?filter=(CreateDate[lt]2018-12-20 or Creator[eq]"Jalal") and IsNew[eq]true
    
    [HttpGet]
    public IActionResult Get(string filter)
    {
        var evaluator = new PredicateExpressionEvaluator();
        var predicate = (PredicateExpression)evaluator.Evaluate(filter);
        
        var entities = repository.GetCollectionBy(predicate);
        
        /// ...
    }

## Comparing Notation

| Operator 	| Bracket Notation 	|
|:--------:	|:----------------:	|
|     =    	|       [eq]       	|
|    !=    	|       [ne]       	|
|     >    	|       [gt]       	|
|    >=    	|       [gte]       |
|     <    	|       [lt]       	|
|    <=    	|       [lte]       |
