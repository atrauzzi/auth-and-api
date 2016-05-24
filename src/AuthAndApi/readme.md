# Auth and API

This library encapsulates the idea of your project accessing other systems via 
the wide assorment of auth standards and APIs.

That means at least two things:

 - Abstract the stages of authentication to produce instances of `Authorization`
 - Generate correctly authenticated requests, ready to be sent

As a slightly higher level convenience, it also means:
 
 - Returning responses normalized to some kind of standard, opinionated structure