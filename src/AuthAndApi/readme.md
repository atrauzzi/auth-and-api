# Auth and API

This library encapsulates the idea of your project accessing other systems via 
the wide assorment of auth standards and APIs.

That means at least two things:

 - Abstract the stages of authentication to produce instances of `Authorization`
 - Generate correctly authenticated requests, ready to be sent
 - Be easier to use than ASP.net Identity
 - Support multiple authorizations per Owner
 - Store better data in the database
